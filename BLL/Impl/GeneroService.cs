using BLL.Validators;
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
            if (!result.IsValid)
            {
                List<string> Erros = new List<string>();
                foreach(var erro in result.Errors)
                {
                    Erros.Add("Campo: " + erro.PropertyName + " Erro: " + erro.ErrorMessage);
                }
            }

            await _generorepository.Create(genero);
        }

        public Task Delete(GeneroDTO genero)
        {
            throw new NotImplementedException();
        }

        public Task<List<GeneroDTO>> GetGeneros()
        {
            throw new NotImplementedException();
        }

        public Task Update(GeneroDTO genero)
        {
            throw new NotImplementedException();
        }
    }
}
