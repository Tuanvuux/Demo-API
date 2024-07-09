using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IServices
{
    public interface IIndividualService
    {
        IEnumerable<Individual> GetAll();
        Individual GetById(int id);
        void Add(Individual individual);
        void Update(Individual individual);
        void Delete(int id);

    }
}
