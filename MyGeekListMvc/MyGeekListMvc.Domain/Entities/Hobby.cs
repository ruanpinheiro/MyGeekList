using MyGeekListMvc.Domain.Validation;
using MyHobbyListMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeekListMvc.Domain.Entities
{
    public abstract class Hobby<T>
    {

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string[] Status { get; private set; }
        public string[] Score { get; private set; }
        public string[] ClassificationGenre { get; private set; }
        public string? Description { get; private set; }

        public Hobby(string name, string[] status, string[] score, string[] classificationGenre, string description)
        {
            ValidateDomain(name, status, score, classificationGenre, description);
        }
        
        public Hobby(int id, string name, string[] status, string[] score, string[] classificationGenre, string description)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, status, score, classificationGenre, description);         
        }    

        private void ValidateDomain(string name, string[] status, string[] score, string[] classificationGenre, string description)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 1, "Invalid name, too short, minimum 1 characters.");
            for (int i = 0; i <= status.Length; i++)
            {
                if (string.IsNullOrEmpty(status[i]))
                    DomainExceptionValidation.When(string.IsNullOrEmpty(status[i]), "Status invalid. Status is required.");

                if (status[i].Length < 7 || status[i].Length > 20)
                    DomainExceptionValidation.When(status[i].Length < 7 || status[i].Length > 20,
                                                               "Invalid status. Minimun 7 and Maximum 20 characteres.");
            }

            for (int i = 0; i <= score.Length; i++)
            {
                if (string.IsNullOrEmpty(score[i]))
                    DomainExceptionValidation.When(string.IsNullOrEmpty(score[i]), "Score invalid. Score is required.");
            }

            for (int i = 0; i <= classificationGenre.Length; i++)
            {
                if (string.IsNullOrEmpty(classificationGenre[i]))
                    DomainExceptionValidation.When(string.IsNullOrEmpty(classificationGenre[i]), "Classification/Genre invalid. " +
                                                                                                "Classification/Genre is required.");
            }

            DomainExceptionValidation.When(description?.Length > 300, "Invalid Description. Maximum 300 characteres.");

            Name = name;
            Status = status;
            Score = score;
            ClassificationGenre = classificationGenre;
            Description = description;
        }
    }
}