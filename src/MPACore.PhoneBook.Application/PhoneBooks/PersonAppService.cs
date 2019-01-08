using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MPACore.PhoneBook.PhoneBooks.Dtos;
using MPACore.PhoneBook.PhoneBooks.Persons;

namespace MPACore.PhoneBook.PhoneBooks
{
    public class PersonAppService : PhoneBookAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public Task CreateOrUpdatePersonAsync()
        {
            throw new NotImplementedException();
        }

        public async Task CreateOrUpdatePersonAsync(CreateOrUpdatePersonDto input)
        {
            if (input.PersonEditDto.Id.HasValue)
            {
                await UpdatePersonAsync(input.PersonEditDto);
            }
            else
            {
                await CreatePersonAsync(input.PersonEditDto);
            }

            throw new NotImplementedException();
        }

        public Task DeletePersonAsync(EntityDto input)
        {
            throw new NotImplementedException();
        }
        
        public async Task<PagedResultDto<PersonListDto>> GetPagedPersonAsync(GetPersonInput input)
        {
            var query = _personRepository.GetAll();

            var personCount = await query.CountAsync();

            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            var dtos = persons.MapTo<List<PersonListDto>>();

            return new PagedResultDto<PersonListDto>(personCount, dtos);
        }

        public Task<PersonListDto> GetPersonByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PersonListDto> GetPersonByIdAsync(NullableIdDto input)
        {
            throw new NotImplementedException();
        }

        protected async Task UpdatePersonAsync(PersonEditDto input)
        {
            var entity = await _personRepository.GetAsync(input.Id.Value);

            await _personRepository.UpdateAsync(input.MapTo(entity));
        }

        protected async Task CreatePersonAsync(PersonEditDto input)
        {
            _personRepository.InsertAsync(input.MapTo<Person>());
        }
    }
}
