using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL.Interfaces
{
    public interface IBaseBL<MISAEntity>
    {
        IEnumerable<MISAEntity> GetAll();
        MISAEntity GetById(Guid id);

        int Insert(MISAEntity entity);

        int Update(MISAEntity entity, Guid id);
        int Delete(Guid id);

    }
}
