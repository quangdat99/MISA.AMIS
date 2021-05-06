using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL;
using MISA.BL.Exceptions;
using MISA.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    public class MISAEntityController<MISAEntity> : ControllerBase
    {
        IBaseBL<MISAEntity> _baseBL;
        public MISAEntityController(IBaseBL<MISAEntity> baseBL)
        {
            _baseBL = baseBL;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseBL.GetAll();
            // 4. Kiểm tra dữ liệu và trả về cho client
            // - Nếu có dữ liệu trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (entities.Count() > 0)
            {
                return Ok(entities);

            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {

            var entity = _baseBL.GetById(id);

            // 4. Kiểm tra dữ liệu và trả về cho client
            // - Nếu có dữ liệu trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (entity != null)
            {
                return Ok(entity);

            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] MISAEntity entity)
        {
            try
            {

                var rowAffects = _baseBL.Insert(entity);
                // 4. Kiểm tra dữ liệu và trả về cho client
                // - Nếu có dữ liệu trả về 200 kèm theo dữ liệu
                // - Không có dữ liệu thì trả về 204:
                if (rowAffects > 0)
                {
                    return Ok(rowAffects);

                }
                else
                {
                    return NoContent();
                }
            }
            catch (GuardException<MISAEntity> ex)
            {
                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Dữ liệu không hợp lệ, vui lòng kiểm tra lại!",
                    field = "EmployeeCode",
                    data = ex.Data
                };
                return StatusCode(400, mes);
            }
            catch (Exception ex)
            {
                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp",
                    field = "EmployeeCode"
                };
                return StatusCode(500, mes);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] MISAEntity entity)
        {

            var res = _baseBL.Update(entity, id);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            var res = _baseBL.Delete(id);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }
        }

    }
}
