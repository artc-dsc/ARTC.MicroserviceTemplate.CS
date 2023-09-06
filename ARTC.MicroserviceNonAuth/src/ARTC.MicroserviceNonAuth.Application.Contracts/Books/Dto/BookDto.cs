using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ARTC.MicroserviceNonAuth.Books.Dto
{
    public class BookDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
