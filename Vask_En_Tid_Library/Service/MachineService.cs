using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.Models;
using Vask_En_Tid_Library.Repository;

namespace Vask_En_Tid_Library.Service
{
    internal class MachineService
    {
        private readonly IMachineRepository _machineRepo;

        public MachineService(IMachineRepository machineRepo)
        {
            _machineRepo = machineRepo;
        }

        public void Add(Models.Machine machine)
        {
            _machineRepo.Add(machine);
        }

        public void Delete(int id)
        {
            _machineRepo.Delete(id);
        }

        public List<Models.Machine> GetAll()
        {
            return _machineRepo.GetAll();
        }
        public void Update(Models.Machine machine) 
        {
            _machineRepo.Update(machine);
        }
    }
}
