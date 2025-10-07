using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vask_En_Tid_Library.Models
{
    public interface IMachineActions
    {
        void Book();
        void CancelBooking();
    }
}
