#!/usr/bin/env python3

from transformers import AutoTokenizer, AutoModelForSeq2SeqLM
import sys

documents = sys.stdin.readlines()

# Load the tokenizer and model
model_name = 'facebook/bart-large-cnn'
tokenizer = AutoTokenizer.from_pretrained(model_name)
model = AutoModelForSeq2SeqLM.from_pretrained(model_name)

# List of documents to summarize
# documents = [
#     "Open Neural Network Exchange (ONNX) is an open-source format designed to facilitate interoperability between different machine learning frameworks. Introduced in 2017 by Facebook and Microsoft, ONNX provides a standardized representation for deep learning models, allowing developers to switch between frameworks like PyTorch, TensorFlow, and others without the need to recreate or convert models manually. This interoperability accelerates the development and deployment process, making it easier to integrate machine learning models into diverse environments and platforms.",
#     "ONNX supports a wide array of operators and data types, covering various neural network architectures used in computer vision, natural language processing, and other domains. The format is extensible, enabling the community to contribute and update the specification to accommodate new advancements in machine learning research. By standardizing model representation, ONNX reduces the friction associated with deploying models across different hardware and software configurations, promoting a more collaborative and efficient AI ecosystem.",
#     "A key component of the ONNX ecosystem is the ONNX Runtime, a high-performance inference engine that executes ONNX models with optimized efficiency. Developed by Microsoft, ONNX Runtime is designed to deliver fast and flexible deployments on a range of hardware platforms, including CPUs, GPUs, and specialized accelerators. It supports hardware-specific optimizations and integrates with various execution providers like NVIDIA TensorRT, Intel OpenVINO, and others. This allows developers to leverage the best available hardware acceleration without changing their codebase.",
#     "The adoption of ONNX has been widespread, with major tech companies and open-source projects embracing the format for its flexibility and efficiency. Platforms like Windows ML, Azure Machine Learning, and AWS Elastic Inference support ONNX models, underscoring its industry acceptance. By enabling seamless transitions between development and production environments, ONNX plays a crucial role in simplifying machine learning workflows, reducing costs, and fostering innovation within the AI community.",
# ]

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
