#!/usr/bin/env python3

from transformers import AutoTokenizer, AutoModelForSeq2SeqLM
import sys

documents = sys.stdin.readlines()

# Load the tokenizer and model
model_name = 'facebook/bart-large-cnn'
tokenizer = AutoTokenizer.from_pretrained(model_name)
model = AutoModelForSeq2SeqLM.from_pretrained(model_name)

# Combine the documents
combined_text = ' '.join(documents)

# Prepare the input
inputs = tokenizer(
    combined_text,
    max_length=1024,
    truncation=True,
    return_tensors='pt'
)

# Generate the summary
summary_ids = model.generate(
    inputs['input_ids'],
    num_beams=4,
    length_penalty=2.0,
    max_length=150,
    min_length=40,
    no_repeat_ngram_size=3,
    early_stopping=True
)

# Decode and print the summary
summary = tokenizer.decode(summary_ids[0], skip_special_tokens=True)
print(summary)
