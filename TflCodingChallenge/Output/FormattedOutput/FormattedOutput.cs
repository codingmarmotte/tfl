using System;
using System.IO;

namespace TflCodingChallenge.Output.FormattedOutput
{
    public class FormattedOutput
    {
        protected readonly TextWriter textWriter;
        public FormattedOutput(TextWriter textWriter)
        {
            this.textWriter = textWriter ?? throw new ArgumentNullException(nameof(textWriter));
        }
    }
}
