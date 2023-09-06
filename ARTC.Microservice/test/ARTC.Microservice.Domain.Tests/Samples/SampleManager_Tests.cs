using System.Threading.Tasks;
using Xunit;

namespace ARTC.Microservice.Samples;

public class SampleManager_Tests : MicroserviceDomainTestBase
{
    //private readonly SampleManager _sampleManager;

    public SampleManager_Tests()
    {
        //_sampleManager = GetRequiredService<SampleManager>();
    }

    [Fact]
    public Task Method1Async()
    {
        return Task.CompletedTask;
    }
}
