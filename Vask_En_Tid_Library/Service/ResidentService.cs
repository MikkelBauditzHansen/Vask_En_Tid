using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.Models;
using Vask_En_Tid_Library.Repository;

namespace Vask_En_Tid_Library.Service
{
    internal class ResidentService
    {
        private readonly IResidentRepository _residentRepo;

        public ResidentService(IResidentRepository residentRepo)
        {
            _residentRepo = residentRepo;
        }

        public void Add(Resident resident)
        {
            _residentRepo.Add(resident);
        }

        public void Delete(int id)
        {
            _residentRepo.Delete(id);
        }

        public List<Resident> GetAll()
        {
            return _residentRepo.GetAll();
        }
        public void Update(Resident resident)
        {
            _residentRepo.Update(resident);
        }
    }
}
