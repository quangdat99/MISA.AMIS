using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Common.Entitis
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public Guid? EmployeeDepartmentId { get; set; }

        public string EmployeeDepartmentName { get; set; }
        public string IdentityNumber { get; set; }
        public string IdentityPlace { get; set; }
        public DateTime? IdentityDate { get; set; }
        public string EmployeePosition { get; set; }
        public string EmployeeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string TeleNumber { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }

        public string BankBranchName { get; set; }

    }
}
