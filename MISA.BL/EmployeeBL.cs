using MISA.Common.Entitis;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL
{
    public class EmployeeBL:BaseBL<Employee>
    {
        public EmployeeBL(IBaseDL<Employee> baseDL):base(baseDL)
        {

        }
    }
}
