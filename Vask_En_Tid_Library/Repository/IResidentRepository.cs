using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repository
{
    internal interface IResidentRepository
    {
        public void Add(Resident resident);
        public void Delete(int id);
        public List<Resident> GetAll();
        public void Update(Resident resident);
    }
}
