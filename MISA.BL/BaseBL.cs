using MISA.BL.Exceptions;
using MISA.BL.Interfaces;
using MISA.Common.Attributes;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL
{
    public class BaseBL<MISAEntity> : IBaseBL<MISAEntity>
    {
        IBaseDL<MISAEntity> _baseDL;

        public BaseBL(IBaseDL<MISAEntity> baseDL)
        {
            _baseDL = baseDL;
        }
        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseDL.GetAll();
        }

        public MISAEntity GetById(Guid entityId)
        {
            return _baseDL.GetById(entityId);
        }

        public int Insert(MISAEntity entity)
        {
            Validate(entity);
            ValidateCustom(entity);
            return _baseDL.Insert(entity);
        }

        public int Update(MISAEntity entity, Guid id)
        {
            return _baseDL.Update(entity, id);
        }

        public int Delete(Guid id)
        {
            return _baseDL.Delete(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <param name="entity"></param>
        void Validate(MISAEntity entity)
        {
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var property in properties)
            {
                var attributeRequireds = property.GetCustomAttributes(typeof(MISARequired), true);
                var attributeMaxLength = property.GetCustomAttributes(typeof(MISAMaxLength), true);

                if (attributeRequireds.Length > 0)
                {
                    // Lấy ra giá trị của Property
                    var propertyValue = property.GetValue(entity);
                    var propertyType = property.GetType();

                    if (property.PropertyType == typeof(string) && string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        // Lấy ra câu cảnh báo lỗi:
                        var msgError = (attributeRequireds[0] as MISARequired).MsgError;
                        throw new GuardException<MISAEntity>(msgError, entity);
                    }
                }

                if (attributeMaxLength.Length > 0)
                {
                    // Lấy ra giá trị của Property
                    var propertyValue = property.GetValue(entity);

                    // Lấy ra độ dài cho phép
                    var maxLength = (attributeMaxLength[0] as MISAMaxLength).MaxLength;

                    if (propertyValue.ToString().Length > maxLength)
                    {
                        throw new GuardException<MISAEntity>($"Thông tin {property.Name} không được dài quá {maxLength} ký tự", entity);
                    }
                }
            }
        }

        protected virtual void ValidateCustom(MISAEntity entity)
        {

        }
    }
}
