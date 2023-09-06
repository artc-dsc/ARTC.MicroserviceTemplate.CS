﻿using ARTC.Microservice.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ARTC.Microservice;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(MicroserviceEntityFrameworkCoreTestModule)
    )]
public class MicroserviceDomainTestModule : AbpModule
{

}
