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
        Individual Add(Individual individual);
        Individual Update(Individual individual);
        Individual Delete(int id);

    }
}
