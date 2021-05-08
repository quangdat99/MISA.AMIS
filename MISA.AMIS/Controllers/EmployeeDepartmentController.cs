using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interfaces;
using MISA.Common.Entitis;
using MISA.CukCuk.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class EmployeeDepartmentController : MISAEntityController<EmployeeDepartment>
    {
        public EmployeeDepartmentController(IBaseBL<EmployeeDepartment> baseBL):base(baseBL)
        {

        }
    }
}
