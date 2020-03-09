using DAO.Interfaces;
using DTO;
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

        public Task Create(JogoDTO jogo)
        {
            throw new NotImplementedException();
        }

        public Task Delete(JogoDTO jogo)
        {
            throw new NotImplementedException();
        }

        public Task<List<JogoDTO>> GetJogos()
        {
            throw new NotImplementedException();
        }

        public Task Update(JogoDTO jogo)
        {
            throw new NotImplementedException();
        }
    }
}
