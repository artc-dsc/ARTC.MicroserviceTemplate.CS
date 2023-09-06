using ARTC.MicroserviceNonAuth.Books.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ARTC.MicroserviceNonAuth.Books
{
    public class BookAppService : MicroserviceNonAuthAppService, IBookAppService
    {
        private readonly IRepository<Book, Guid> _bookRepository;

        public BookAppService(IRepository<Book, Guid> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> CreateAsync(string text)
        {
            var projectItem = await _bookRepository.InsertAsync(
                                new Book { Name = text }
                                );

            return new BookDto
            {
                Id = projectItem.Id,
                Name = projectItem.Name
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<List<BookDto>> GetListAsync()
        {
            var items = await _bookRepository.GetListAsync();
            return items
                .Select(item => new BookDto
                {
                    Id = item.Id,
                    Name = item.Name
                }).ToList();
        }
    }
}
