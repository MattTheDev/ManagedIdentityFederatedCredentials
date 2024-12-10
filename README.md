# ManagedIdentityFederatedCredentials

## Option #1

1. Ensure your app service in Azure has a System Assigned Identity.
2. Go to your Entra App
3. Go to Certificates & secrets
4. Go to Federated Credentials
5. Click Add Credential
6. Choose Customer Managed Keys
7. Click Select a managed identity
8. Choose your managed identity
9. Give it a name
10. Click Add
11. Use code in Option1.cs

## Option #2

1. If you have a pre-existing User Assigned Identity, assign it to your app service.
2. Go to your Entra App
3. Go to Certificates & secrets
4. Go to Federated Credentials
5. Click Add Credential
6. Choose Customer Managed Keys
7. Click Select a managed identity
8. Choose your managed identity
9. Give it a name
10. Click Add
11. Use code in Option2.cs
