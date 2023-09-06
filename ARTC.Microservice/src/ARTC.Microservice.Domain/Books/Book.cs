using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace ARTC.Microservice.Books
{
    public class Book : Entity<Guid>
    {
        public string Name { get; set; }
    }
}
