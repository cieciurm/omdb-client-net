using System;

namespace OmdbClientNet.Base
{
    public abstract class StronglyTypedId
    {
        public string Value { get; }

        protected StronglyTypedId(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value;
        }
    }
}
