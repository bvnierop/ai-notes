using System.Collections.Generic;

namespace AiNotes.Models;

public class DemoContent
{
    public static Note[] DemoNotes = [
        new("Introduction to ONNX", """
                                    What is ONNX?
                                    
                                        Open Neural Network Exchange (ONNX) is an open-source format for representing machine learning models.
                                    
                                    Purpose of ONNX
                                    
                                        Enables interoperability between different deep learning frameworks like PyTorch, TensorFlow, and Caffe2.
                                    
                                    Benefits
                                    
                                        Allows developers to switch between tools without recreating models.
                                    """),
        new("ONNX Runtime", """
                            What is ONNX Runtime?
                            
                                A high-performance inference engine for running ONNX models.
                            
                            Key Features
                            
                                Cross-platform support and optimized performance on various hardware.
                            
                            Usage
                            
                                Ideal for deploying models in production environments.
                            """),
        new("Converting Models to ONNX", """
                                         Exporting from PyTorch
                                         
                                             Use torch.onnx.export() function.
                                         
                                         Exporting from TensorFlow
                                         
                                             Convert using the tf2onnx converter.
                                         
                                         Common Challenges
                                         
                                             Compatibility issues and how to troubleshoot them.
                                         """),

        new("Understanding Artificial Intelligence", """
                                                     Definition
                                                     
                                                         AI is the simulation of human intelligence processes by machines, especially computer systems.
                                                     
                                                     Core Components
                                                     
                                                         Learning, reasoning, problem-solving, perception, and language understanding.
                                                     
                                                     Types of AI
                                                     
                                                         Narrow AI: Designed for specific tasks.
                                                         General AI: Hypothetical AI that can perform any intellectual task.
                                                     """),

        new("Types of Machine Learning Models", """ 
            Supervised Learning
                Models trained on labeled data (e.g., regression, classification).
            Unsupervised Learning
                Models find patterns in unlabeled data (e.g., clustering, association).
            Reinforcement Learning
                Models learn by interacting with an environment to achieve a goal.
"""),


        new("Model Evaluation Metrics", """
            Classification Metrics
                Accuracy, precision, recall, F1-score.
            Regression Metrics
                Mean Squared Error (MSE), Root Mean Squared Error (RMSE), R-squared.
            Cross-Validation
                Techniques like k-fold to assess model performance.
"""),

        new("Model Deployment", """
                                Methods
                                    Batch processing, real-time inference, edge deployment.
                                Tools
                                    Docker, Kubernetes, cloud services like AWS SageMaker.
                                Best Practices
                                    Monitor performance, handle scalability, ensure security.
                                """),

        new("Introduction to Whisper","""
            What is Whisper?
                An automatic speech recognition (ASR) system developed by OpenAI.
            Capabilities
                Transcribes audio to text, supports multiple languages and accents.
            Use Cases
                Transcription services, voice-controlled applications.
"""),

        new("Technical Overview", """
            Architecture
                Based on the Transformer model.
            Training Data
                Trained on diverse audio datasets for robustness.
            Performance
                High accuracy even in noisy environments.
"""),
        new("Implementing Whisper", """
            Access
                Available via OpenAI's API.
            Integration
                Can be integrated into applications using RESTful API calls.
            Limitations
                Be aware of potential latency and cost for large-scale use.
"""),

        new("Understanding GPT Models", """
            What is GPT?
                Generative Pre-trained Transformer models for natural language processing tasks.
            Evolution
                GPT-1, GPT-2, GPT-3, and the latest GPT-4 with increasing capabilities.
            Core Functionality
                Text generation, completion, translation, and summarization.
"""),

        new("Applications of GPT", """
            Content Creation
                Blog posts, articles, and marketing copy.
            Conversational AI
                Chatbots and virtual assistants.
            Coding Assistance
                Generating code snippets and debugging help.
"""),

        new("Ethical Considerations", """
            Bias and Fairness
                Models may reflect biases present in training data.
            Responsible Use
                Guidelines to prevent misuse like generating misleading information.
            Regulatory Compliance
                Adhering to data protection laws and ethical standards.
"""),

        new("The Science of Popcorn", """
        
            What Makes Popcorn Pop?
                Each kernel has moisture that turns to steam when heated, causing it to explode.
            Types of Popcorn Kernels
                Butterfly (light and airy) vs. Mushroom (denser, good for coatings).
            History
                Originated in the Americas; enjoyed for thousands of years.
"""),

        new("OCR", "", [ new ImageAttachment("Files/marketing.jpeg") ]),
        new("OCR-2", ""),
        new("Transcribe demo", ""),
        new("Search Results", ""),
        new("Search Results 2", ""),
    ];
}
