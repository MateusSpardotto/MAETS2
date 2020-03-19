﻿using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IJogoRepository
    {
        Task Create(JogoDTO jogo);
        Task Update(JogoDTO jogo);
        Task Delete(JogoDTO jogo);
        Task<List<JogoDTO>> GetJogos();
        Task<List<JogoDTO>> GetJogosByGenero(GeneroDTO genero);
    }
}
