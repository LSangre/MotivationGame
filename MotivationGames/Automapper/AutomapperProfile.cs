using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MotivationGame.DataLayer.Data;
using MotivationGame.Pages.Game;

namespace MotivationGames.Automapper
{
    public class AutomapperProfile: Profile
    {
        public void Configure()
        {
            CreateMap<Game, EditModel.InputModel>();
            CreateMap<Game, CreateModel.InputModel>();
            CreateMap<CreateModel.InputModel, Game>();
        }
    }
}
