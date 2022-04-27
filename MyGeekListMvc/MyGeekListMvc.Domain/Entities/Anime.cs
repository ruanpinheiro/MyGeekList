using MyGeekListMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHobbyListMvc.Domain.Entities
{
    public class Anime : Hobby<Anime>
    {
        public int QtdEpisodes { get; private set; }

        public Anime(int id, string name, string[] status, string[] score, string[] classificationGenre, string description,int qtdEpisodes) : base(id, name, status, score, classificationGenre, description)
        {
            QtdEpisodes = qtdEpisodes;
            
        }
    }
}
