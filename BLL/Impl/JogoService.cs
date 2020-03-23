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
    public class JogoService : IJogoService
    {
        private IJogoRepository _jogorepository;

        public JogoService(IJogoRepository jogorepository)
        {
            this._jogorepository = jogorepository;
        }

        public async Task Create(JogoDTO jogo)
        {
            ValidationResult result = new JogoValidator().Validate(jogo);
            result.ThrowExceptionIfFail();

            await _jogorepository.Create(jogo);
        }

        public async Task Delete(JogoDTO jogo)
        {
            await _jogorepository.Delete(jogo);
        }

        public async Task<List<JogoDTO>> GetJogos()
        {
            return await _jogorepository.GetJogos();
        }

        public async Task<List<JogoDTO>> GetJogosByGenero(int generoID)
        {
            return await _jogorepository.GetJogosByGenero(generoID);
        }

        public async Task<List<JogoDTO>> GetJogosByDesenvolvedor(int desenvolvedorID)
        {
            return await _jogorepository.GetJogosByDesenvolvedor(desenvolvedorID);
        }

        public Task Update(JogoDTO jogo)
        {
            throw new NotImplementedException();
        }
    }
}
