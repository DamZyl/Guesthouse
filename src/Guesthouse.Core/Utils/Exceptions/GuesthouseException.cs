using System;
using System.Collections.Generic;
using System.Text;

namespace Guesthouse.Core.Utils.Exceptions
{
    public abstract class GuesthouseException : Exception
    {
        public string Code { get; }

        protected GuesthouseException()
        {
        }

        protected GuesthouseException(string code)
        {
            Code = code;
        }

        protected GuesthouseException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        protected GuesthouseException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        protected GuesthouseException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        protected GuesthouseException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
