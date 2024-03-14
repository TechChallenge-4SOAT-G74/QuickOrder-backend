using Amazon;
using Amazon.Runtime;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System.Text;

namespace QuickOrder.Core.IoC
{
    public class AwsSecretGetter
    {
        public static string GetSecret(string secretName, string region, string credentialProfile)
        {
            AWSConfigs.AWSRegion = region;
            string text = "";
            IAmazonSecretsManager amazonSecretsManager = (string.IsNullOrEmpty(credentialProfile) ? new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region)) : new AmazonSecretsManagerClient(new StoredProfileAWSCredentials(credentialProfile), RegionEndpoint.GetBySystemName(region)));
            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT"
            };
            GetSecretValueResponse result = amazonSecretsManager.GetSecretValueAsync(request).Result;
            if (result.SecretString != null)
            {
                return result.SecretString;
            }

            StreamReader streamReader = new StreamReader(result.SecretBinary);
            return Encoding.UTF8.GetString(Convert.FromBase64String(streamReader.ReadToEnd()));
        }
    }
}