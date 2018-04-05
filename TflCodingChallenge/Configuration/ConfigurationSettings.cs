using System;
using System.Configuration;

namespace TflCodingChallenge.Configuration
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        private readonly Uri baseUri;
        private readonly string appKey;
        private readonly string appId;

        public ConfigurationSettings()
        {
            // Configure the HttpClient
            var baseUriSetting = ConfigurationManager.AppSettings["baseUri"];
            if (baseUriSetting == null)
            {
                throw new ConfigurationErrorsException($"AppSetting 'baseUri' is missing from the configuration file");
            }

            if (!Uri.TryCreate(baseUriSetting, UriKind.Absolute, out baseUri))
            {
                throw new ConfigurationErrorsException($"Unable to convert '{baseUriSetting}' to a valid Uri.");
            }

            appId = ConfigurationManager.AppSettings["appKey"];
            if (appId == null)
            {
                throw new ConfigurationErrorsException($"AppSetting 'appId' is missing from the configuration file");
            }


            appKey = ConfigurationManager.AppSettings["appId"];
            if (appKey == null)
            {
                throw new ConfigurationErrorsException($"AppSetting 'appKey' is missing from the configuration file");
            }

        }

        public Uri BaseUri { get { return baseUri; } }

        public string AppId { get { return appId; } }

        public string AppKey { get { return appKey; } }
    }
}
