using BLL.Services.IServices;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.Services
{
    public class IndividualService : IIndividualService
    {
        private readonly IIndividualRepository _IndividualRepository;

        public IndividualService(IIndividualRepository IndividualRepository)
        {
            _IndividualRepository = IndividualRepository;
        }

        public Individual Add(Individual individual)
        {
            Individual indi=_IndividualRepository.Add(individual);
            return indi;
        }

        public Individual Delete(int id)
        {
            Individual individual =  _IndividualRepository.Remove(GetById(id));
            return individual;
        }

        public IEnumerable<Individual> GetAll()
        {
            return _IndividualRepository.GetAll();
        }

        public Individual GetById(int id)
        {
            return _IndividualRepository.GetById(id); ;
        }

        public Individual Update(Individual individual)
        {
            var errors = new List<string>();
            var existingIndividual = _IndividualRepository.GetById(individual.Cust_Id);
            if (existingIndividual == null)
            {
                errors.Add("Individual is not exist");
            }
   
            if (errors.Any())
            {
                throw new AggregateException(errors.Select(e => new Exception(e)));
            }

            
            existingIndividual.BirthDay = individual.BirthDay;
            existingIndividual.FirstName = individual.FirstName;
            existingIndividual.LastName = individual.LastName;
            Individual indivi=_IndividualRepository.Update(existingIndividual);
            return indivi;
        }
    }
}
