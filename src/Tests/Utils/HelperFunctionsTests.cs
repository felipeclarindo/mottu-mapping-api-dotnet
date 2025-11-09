using FluentAssertions;
using MotoMappingApiDotnet.Src.Utils.Functions;
using Xunit;


namespace MotoMappingApiDotnet.Src.Tests.Utils
{
    public class HelperFunctionsTests
    {
        [Fact]
        public void LoadEnvFromRoot_DeveNaoGerarErro()
        {
            var helper = new HelperFunctions();

            var act = () => helper.LoadEnvFromRoot();

            act.Should().NotThrow();
        }
    }
}