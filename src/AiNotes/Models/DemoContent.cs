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
        new("Popcorn explained", """
                                 Popcorn is a fascinating example of how simple physics and biology combine to create a popular snack. At the heart of every popcorn kernel is a small amount of water stored within the starchy endosperm, surrounded by a hard outer shell called the pericarp. When the kernel is heated, typically to around 356°F (180°C), the water inside turns into steam, and the pressure builds. This pressure continues to rise until the kernel explodes, flipping inside out and puffing the starchy insides into the familiar fluffy, edible form.
                                 
                                 The popping process relies heavily on the unique properties of the popcorn kernel’s pericarp. Not all corn can pop; the popcorn variety has a shell that is both strong enough to contain the steam pressure and capable of holding in moisture during storage. Without this durable outer shell, the kernel would crack or leak steam prematurely, preventing the starch from expanding into the desired popped state. This makes popcorn unique among corn types and highlights the role of genetics in food science.
                                 
                                 Popcorn also has a distinctive texture and taste, largely determined by its structure after popping. The rapid expansion of steam gelatinizes the starch inside the kernel, which then cools and sets into a foam-like structure, giving popcorn its light, airy quality. This transformation is a direct result of the specific moisture content and the starch’s ability to stretch during the sudden release of pressure. Scientists have found that the ideal moisture content for popping is about 13-14%, providing the right amount of steam for maximum puffing without burning the kernel.
                                 
                                 In addition to its physical properties, the science of popcorn has been refined for both commercial and home consumption. Different varieties of popcorn kernels, such as mushroom-shaped and butterfly-shaped, pop into different structures and are used for specific purposes. Mushroom popcorn is denser and rounder, making it ideal for caramel or chocolate coatings, while butterfly popcorn is lighter and has irregular shapes, perfect for buttery, movie-style popcorn.
                                 
                                 To prepare popcorn, several key steps need to be followed to achieve the perfect pop. First, it’s important to select quality popcorn kernels with the right moisture content, ideally around 13-14%, for optimal popping. Heat a pan or popcorn maker with a small amount of oil, around a tablespoon for every half cup of kernels, to distribute heat evenly and prevent sticking. Once the oil is hot, usually around medium-high heat, add the kernels and cover the pan to trap the steam inside. Shake the pan gently as the kernels heat up to ensure even popping and prevent burning. Once the popping slows to a few seconds between pops, remove the pan from the heat, carefully uncover it to release steam, and season the popcorn to taste—whether with butter, salt, or other flavorings like cheese or caramel. It’s also important to store any unused kernels in an airtight container to preserve their moisture content for future use.
                                 """),

        new("OCR", "", [ new ImageAttachment("Files/marketing.jpeg") ]),
        new("OCR-2", ""),
        new("Transcribe demo", ""),
        new("Search Results", ""),
        new("Search Results 2", ""),
    ];
}
