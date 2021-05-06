using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Common.Entitis
{
    public class EmployeeDepartment
    {
        public Guid EmployeeDepartmentId { get; set; }
        public string EmployeeDepartmentName { get; set; }
        public string Description { get; set; }
        public string Response { get; set; }
        public string Profit { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
