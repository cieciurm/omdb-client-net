using System;

namespace OmdbClientNet.Exceptions
{
    public abstract class BaseOmdbClientException : Exception
    {
        protected BaseOmdbClientException()
        {
        }

        protected BaseOmdbClientException(string message) : base(message)
        {
        }
    }
}
