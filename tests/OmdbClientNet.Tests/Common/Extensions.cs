using OmdbClientNet.Base;
using Shouldly;

namespace OmdbClientNet.Tests.Common
{
    public static class Extensions
    {
        public static void ShouldBeSuccessful(this BaseResponse response)
        {
            response.ShouldNotBeNull();
            response.ResponseBool.ShouldBeTrue();
        }
    }
}
