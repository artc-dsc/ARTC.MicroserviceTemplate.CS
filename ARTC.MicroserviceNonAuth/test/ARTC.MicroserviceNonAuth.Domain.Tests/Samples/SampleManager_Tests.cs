﻿using System.Threading.Tasks;
using Xunit;

namespace ARTC.MicroserviceNonAuth.Samples;

public class SampleManager_Tests : MicroserviceNonAuthDomainTestBase
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
