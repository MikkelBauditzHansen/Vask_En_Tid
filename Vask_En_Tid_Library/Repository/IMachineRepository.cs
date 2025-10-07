using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repository
{
    public interface IMachineRepository
    {
        public void Add(Machine machine);
        public void Delete(int id);
        public List<Machine> GetAll();
        public void Update(Machine machine);
    }
}
