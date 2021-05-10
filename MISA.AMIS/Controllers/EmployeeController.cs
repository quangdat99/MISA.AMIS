
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL.Interfaces;
using MISA.Common.Entitis;
using MISA.CukCuk.Api.Controllers;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class EmployeeController : MISAEntityController<Employee>
    {
        public EmployeeController(IBaseBL<Employee> baseBL):base(baseBL)
        {

        }
        [HttpGet("EmployeeCodeMax")]
        public IActionResult GetEmployeeCodeMax()
        {
            // 1. Khai báo thông tin kết nối đến Database :
            string connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "Database = 15B_MS145_AMIS_DQDAT;";

            // 2. Khởi tạo kết nối :
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // 3. Tương tác với Database ( lấy, sửa, xóa )
            var sqlCommand = $"Proc_GetEmployeeCodeMax";
            var employeeCodeMax = dbConnection.QueryFirstOrDefault<string>(sqlCommand, commandType: CommandType.StoredProcedure);

            // 4. Kiểm tra dữ liệu và trả về cho client
            // - Nếu có dữ liệu trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (employeeCodeMax != null)
            {
                return Ok(employeeCodeMax);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("CountEmployees")]
        public int GetCountEmployees(string employeeFilter)
        {
            // 1. Khai báo thông tin kết nối đến Database :
            string connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "Database = 15B_MS145_AMIS_DQDAT;";

            // 2. Khởi tạo kết nối :
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // 3. Tương tác với Database ( lấy, sửa, xóa )

            var sqlCommand = $"Proc_GetCountEmployees";
            if (employeeFilter == null)
            {
                employeeFilter = "";
            }
            var param = new
            {
                m_Filter = employeeFilter
            };
            var countEmployees = dbConnection.Query<int>(sqlCommand, param: param, commandType: CommandType.StoredProcedure).First();
            return countEmployees;
        }

        [HttpGet("EmployeeCodeExist/{EmployeeCode}")]

        public IActionResult CheckEmployeeCodeExist(string EmployeeCode)
        {
            // 1. Khai báo thông tin kết nối đến Database :
            string connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "Database = 15B_MS145_AMIS_DQDAT;";

            // 2. Khởi tạo kết nối :
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            var param = new
            {
                m_EmployeeCode = EmployeeCode
            };

            // 3. Tương tác với Database ( lấy, sửa, xóa )
            var sqlCommand = $"Proc_CheckEmployeeCodeExist";
            var employeeCodeExist = dbConnection.QueryFirstOrDefault<int>(sqlCommand,param: param, commandType: CommandType.StoredProcedure);

            // 4. Kiểm tra dữ liệu và trả về cho client
            // - Nếu có dữ liệu trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (employeeCodeExist != null)
            {
                return Ok(employeeCodeExist);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("EmployeeFilter")]
        public IEnumerable<Employee> GetEmployeeFilter (string employeeFilter, string pageSize, string pageNumber)
        {
            // 1. Khai báo thông tin kết nối đến Database :
            string connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "Database = 15B_MS145_AMIS_DQDAT;";

            // 2. Khởi tạo kết nối :
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // 3. Tương tác với Database ( lấy, sửa, xóa )
            var sqlCommand = $"Proc_EmployeeFilter";
            if (employeeFilter == null)
            {
                employeeFilter = "";
            }
            var param = new
            {
                m_PageIndex = pageNumber,
                m_PageSize = pageSize,
                m_Filter = employeeFilter
            };
            var employeeFilters = dbConnection.Query<Employee>(sqlCommand, param: param, commandType: CommandType.StoredProcedure);
            return employeeFilters;
        }

    }
}
