using BLL.Validators;
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
     public class DesenvolvedorService : IDesenvolvedorService
     {
        private IDesenvolvedorRepository _desenvolvedorrepository;
        public DesenvolvedorService(IDesenvolvedorRepository desenvolvedorrepository)
        {
            this._desenvolvedorrepository = desenvolvedorrepository;
        }

        public async Task Create(DesenvolvedorDTO desenvolvedor)
        {
            ValidationResult result = new DesenvolvedorValidator().Validate(desenvolvedor);
            result.ThrowExceptionIfFail();

            await _desenvolvedorrepository.Create(desenvolvedor);
        }

        public async Task Delete(DesenvolvedorDTO desenvolvedor)
        {
            await _desenvolvedorrepository.Delete(desenvolvedor);
        }

        public async Task<List<DesenvolvedorDTO>> GetDesenvolvedores()
        {
            return await _desenvolvedorrepository.GetDesenvolvedores();
        }

        public Task Update(DesenvolvedorDTO desenvolvedor)
        {
            throw new NotImplementedException();
        }
    }
}
