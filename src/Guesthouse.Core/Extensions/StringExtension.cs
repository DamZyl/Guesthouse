using System;

namespace Guesthouse.Core.Extensions
{
    public static class StringExtension
    {
        public static string ToUppercaseFirstInvariant(this string convertString)
            => (char.ToUpperInvariant(convertString[0]) + convertString.Substring(1).ToLowerInvariant());
    }
}