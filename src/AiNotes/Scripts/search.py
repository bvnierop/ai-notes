#!/usr/bin/env python3

# semantic_search_app.py

from sentence_transformers import SentenceTransformer
import numpy as np
import faiss
import sys
import json

all = json.loads(''.join(sys.stdin.readlines()))
documents = all['notes']
search_term = all['term']

# Load the pre-trained model
model = SentenceTransformer('all-MiniLM-L6-v2')

# Generate embeddings for documents
corpus = [doc['title'] + ". " + doc['content'] for doc in documents]
document_embeddings = model.encode(corpus, convert_to_numpy=True)
faiss.normalize_L2(document_embeddings)

# Build the FAISS index
dimension = document_embeddings.shape[1]
index = faiss.IndexFlatIP(dimension)
index.add(document_embeddings)

# Function to perform semantic search
def semantic_search(query, top_k=3):
    # Generate embedding for the query
    query_embedding = model.encode([query], convert_to_numpy=True)
    faiss.normalize_L2(query_embedding)

    # Search the index
    distances, indices = index.search(query_embedding, top_k)

    # Retrieve and display results
    results = []
    for idx in indices[0]:
        result = {
            "id": documents[idx]['id'],
            "title": documents[idx]['title'],
            "content": documents[idx]['content']
        }
        results.append(result)
    return results

# Example usage
if __name__ == "__main__":
    query = search_term
    results = semantic_search(query, top_k=3)

    print(f"Query: {query}\n")
    print("Top results:")
    for i, res in enumerate(results):
        print(f"Rank {i+1}:")
#         print(f"ID: {res['id']}")
        print(f"Title: {res['title']}")
#         print(f"Content: {res['content']}\n")
