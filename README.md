# CICD-API-Encryption/Decryption Project
## Introduction
This project aims to create and implement a complete CI/CD pipeline for an API project in C# which is develped in ASP.NET CORE , focusing on encryption and decryption.
GitHub Actions will be utilized for version control and automated deployment. 
The final step involves deploying the API to AWS Elastic Beanstalk as part of a continuous integration and continuous delivery (CI/CD) process.
## Frontend
Using index.html for basic frontend
## API
The API should consist of at least two endpoints: one for encryption and one for decryption.
The encryption method is open to choice and does not need to be secure (e.g., Caesar cipher).

## GitHub
Git and GitHub will be used throughout the project. All code will be written in master branches and merged using pull requests .
## Deployment
The API will be published on AWS Elastic Beanstalk using GitHub Actions for automated deployment.
## Test Url:
##### Encrypt
(http://encryptionapi-env.eba-tyihg6pz.eu-north-1.elasticbeanstalk.com/Crypto/encrypt?text=iloveyou)



<img width="729" alt="Screenshot 2024-02-10 230644" src="https://github.com/IvyAnalisa/CICD-API-Encryption/assets/37039741/466fbc0b-cefd-460e-9e05-30da1aee0c8b">

##### Decrypt
(http://encryptionapi-env.eba-tyihg6pz.eu-north-1.elasticbeanstalk.com/Crypto/decrypt?encryptedText=add)

<img width="684" alt="Screenshot 2024-02-10 232252" src="https://github.com/IvyAnalisa/CICD-API-Encryption/assets/37039741/b49882b9-c024-4607-af54-31ce511102c4">

##### Frontend:
(http://encryptionapi-env.eba-tyihg6pz.eu-north-1.elasticbeanstalk.com/crypto)

<img width="523" alt="Screenshot 2024-02-10 230555" src="https://github.com/IvyAnalisa/CICD-API-Encryption/assets/37039741/87564350-390c-49f1-9230-d044a66e0feb">

## Figma chart to  decribe CI/CD process for both frontend and backend
![CICDFigma](https://github.com/IvyAnalisa/CICD-API-Encryption/assets/37039741/6f740452-ef8a-4a9c-941a-9450b5c062c1)

