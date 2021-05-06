using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired : Attribute
    {
        public string MsgError = string.Empty;
        public MISARequired(string msgError)
        {
            MsgError = msgError;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISAMaxLength : Attribute
    {
        public string MsgError = string.Empty;
        public int MaxLength = 0;
        public MISAMaxLength(int maxlength = 0, string msgError = "")
        {
            MaxLength = maxlength;
            MsgError = msgError;
        }
    }
}
