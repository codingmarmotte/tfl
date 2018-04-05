using System;
using System.IO;
using TflCodingChallenge.Api;
using TflCodingChallenge.Output.FormattedOutput;

namespace TflCodingChallenge.Output
{
    public class FormattedOutputFactory : IFormattedOutputFactory
    {
        private readonly TextWriter textWriter;
        public FormattedOutputFactory(TextWriter textWriter)
        {
            this.textWriter = textWriter ?? throw new ArgumentNullException(nameof(textWriter));
        }

        public IFormattedOutput GenerateFormattedOutput(ResponseEnum result)
        {
            switch (result)
            {
                case ResponseEnum.Success: return new SuccessFormattedOutput(textWriter);
                case ResponseEnum.NotFound: return new NotFoundFormattedOutput(textWriter);
                case ResponseEnum.Failed: return new FailedFormattedOutput(textWriter);
                default: throw new ArgumentException("Unknown ResultEnum value.", nameof(result));
            }
        }
    }
}
