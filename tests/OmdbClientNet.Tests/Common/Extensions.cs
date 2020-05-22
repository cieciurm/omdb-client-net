using FluentAssertions;
using OmdbClientNet.Base;

namespace OmdbClientNet.Tests.Common
{
    public static class Extensions
    {
        public static void ShouldBeSuccessful(this BaseResponse response)
        {
            response.Should().NotBeNull();
            response.Response.Should().BeTrue();
        }
    }
}
