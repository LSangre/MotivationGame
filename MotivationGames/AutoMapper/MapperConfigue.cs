using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MotivationGame.DataLayer.Data;
using MotivationGame.Models;

namespace MotivationGames.AutoMapper
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<CreateGameModel, Game>();
        }
    }
}
