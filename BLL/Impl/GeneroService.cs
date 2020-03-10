using BLL.Validators;
using Common;
using Common.Extensions;
using DAO.Interfaces;
using DTO;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class GeneroService : IGeneroService
    {
        private IGeneroRepository _generorepository;

        public GeneroService(IGeneroRepository generorepository)
        {
            this._generorepository = generorepository;
        }

        public async Task Create(GeneroDTO genero)
        {
            ValidationResult result = new GeneroValidator().Validate(genero);
            result.ThrowExceptionIfFail();

            await _generorepository.Create(genero);
        }

        public async Task Delete(GeneroDTO genero)
        {
            await _generorepository.Delete(genero);
        }

        public async Task<List<GeneroDTO>> GetGeneros()
        {
            return await _generorepository.GetGeneros();
        }

        public Task Update(GeneroDTO genero)
        {
            throw new NotImplementedException();
        }
    }
}
