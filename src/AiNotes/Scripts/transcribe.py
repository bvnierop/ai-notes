#!/usr/bin/env python3

# transcribe.py
# A script that takes an audio file (wav, mp3, mp4) and outputs a timestamped transcription using Silero VAD and Whisper

# Ensure the required packages are installed:
# pip install torch numpy openai-whisper

import torch
import numpy as np
import whisper
import sys

def main(audio_path):
    # Load audio using Whisper's load_audio function
    # This function uses FFmpeg to load the audio file and resamples it to 16kHz
    # Supports various audio formats, including WAV, MP3, and MP4
    audio = whisper.load_audio(audio_path)
    sr = 16000  # Whisper's load_audio function resamples audio to 16kHz

    # Load Silero VAD model and utilities
    vad_model, utils = torch.hub.load(
        repo_or_dir='snakers4/silero-vad',
        model='silero_vad',
        force_reload=False
    )

    (get_speech_timestamps,
     save_audio,
     read_audio,
     VADIterator,
     collect_chunks) = utils

    # Get speech timestamps from the audio using Silero VAD
    speech_timestamps = get_speech_timestamps(audio, vad_model, sampling_rate=sr)

    # Load Whisper model
    # You can choose different models: tiny, base, small, medium, large
    device = "cuda" if torch.cuda.is_available() else "cpu"
    model = whisper.load_model("base", device=device)

    # Prepare results list
    results = []

    # Loop over each detected speech segment
    for idx, segment in enumerate(speech_timestamps):
        # Extract the audio segment
        start = segment['start']
        end = segment['end']
        segment_audio = audio[start:end]

        # Transcribe the audio segment with Whisper
        options = {
            'language': 'en',  # Assuming English language
            'verbose': False
        }
        if device == 'cpu':
            options['fp16'] = False  # Disable FP16 if using CPU

        # Transcribe the segment
        transcription = model.transcribe(segment_audio, **options)

        # Store the transcription and timestamps
        results.append({
            'start': start / sr,  # Convert from samples to seconds
            'end': end / sr,
            'text': transcription['text'].strip()
        })

    # Output the results
    for res in results:
        start_time = res['start']
        end_time = res['end']
        text = res['text']
        print(f"[{start_time:.2f} - {end_time:.2f}] {text}")

if __name__ == '__main__':
    import sys
    if len(sys.argv) < 2:
        print("Usage: python transcribe.py audio_file")
        sys.exit(1)
    audio_path = sys.argv[1]
    main(audio_path)
