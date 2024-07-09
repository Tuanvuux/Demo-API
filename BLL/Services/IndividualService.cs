using BLL.Services.IServices;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BranchService : IIndividualService
    {
        private readonly IIndividualRepository _IndividualRepository;

        public BranchService(IIndividualRepository IndividualRepository)
        {
            _IndividualRepository = IndividualRepository;
        }

        public void Add(Individual individual)
        {
            _IndividualRepository.Add(individual);
        }

        public void Delete(int id)
        {
            _IndividualRepository.Remove(GetById(id));
        }

        public IEnumerable<Individual> GetAll()
        {
            return _IndividualRepository.GetAll();
        }

        public Individual GetById(int id)
        {
            return _IndividualRepository.GetById(id); ;
        }

        public void Update(Individual individual)
        {

            var existingIndividual = _IndividualRepository.GetById(individual.Cust_Id);
            if (existingIndividual != null)
            {
                existingIndividual.BirthDay = individual.BirthDay;
                existingIndividual.FirstName = individual.FirstName;
                existingIndividual.LastName = individual.LastName;
            }
        }
    }
}
