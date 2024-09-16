#!/usr/bin/env python3

# Install dependencies
# pip install transformers datasets
#
# Dependencies:
# pytorch, easyocr

import easyocr
import sys
import json

if len(sys.argv) != 2:
    print("Usage: ocr <filename>")
    exit(1)

image_name = sys.argv[1]

reader = easyocr.Reader(['en'], gpu=True)
ocr_result = reader.readtext(image_name)

res=[]
for result in ocr_result:
    box, text, confidence = result
    # print(f"Text: {text}, Bounding Box: {box}, Confidence: {confidence}")
    intbox = [[int(x) for x in pt] for pt in box]
    obj = dict(text=text, box=intbox, confidence=confidence)
    res.append(obj)

print(json.dumps(res))
