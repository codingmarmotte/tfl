using System;

namespace TflCodingChallenge.Configuration
{
    public interface IConfigurationSettings
    {
        Uri BaseUri { get; }
        String AppId { get; }
        String AppKey { get; }
    }
}
