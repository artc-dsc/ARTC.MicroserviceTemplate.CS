using ARTC.Microservice.Book.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ARTC.Microservice.Books
{
    public interface IBookAppService : IApplicationService
    {
        Task<List<BookDto>> GetListAsync();
        Task<BookDto> CreateAsync(string text);
        Task DeleteAsync(Guid id);
    }
}
