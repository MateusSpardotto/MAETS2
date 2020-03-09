using DAO.Interfaces;
using DTO;
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

        public Task Create(DesenvolvedorDTO desenvolvedor)
        {
            throw new NotImplementedException();
        }

        public Task Delete(DesenvolvedorDTO desenvolvedor)
        {
            throw new NotImplementedException();
        }

        public Task<List<DesenvolvedorDTO>> GetDesenvolvedores()
        {
            throw new NotImplementedException();
        }

        public Task Update(DesenvolvedorDTO desenvolvedor)
        {
            throw new NotImplementedException();
        }
    }
}
