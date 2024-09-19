#!/usr/bin/env python3

from transformers import pipeline
import sys

documents = sys.stdin.readlines()

# Initialize the zero-shot classification pipeline
classifier = pipeline('zero-shot-classification', model='facebook/bart-large-mnli')

# Candidate labels
labels = ['action item', 'statement']

# Function to extract actionables
def extract_actionables(docs):
    actionables = []
    for doc in docs:
        result = classifier(doc, labels)
        if result['labels'][0] == 'action item':
            actionables.append(doc)
    return actionables

def is_empty_or_whitespace(s):
    return not s.strip()

# Extract and print actionables
action_items = extract_actionables(documents)
print("Actionable items:")
num = 1
for idx, item in enumerate(action_items, 1):
    if not is_empty_or_whitespace(item):
        print(f"{num}. {item}")
        num += 1
