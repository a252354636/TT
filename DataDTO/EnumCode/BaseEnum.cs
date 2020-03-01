using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataDTO.EnumCode
{
    public class BaseEnum
    {
        public static string GetEnumDescription(Enum enumValue)
        {
            string value = enumValue.ToString();
            FieldInfo field = enumValue.GetType().GetField(value);
            //获取描述属性
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            //当描述属性没有时，直接返回名称
            if (objs.Length == 0)
            {
                return value;
            }
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
            return descriptionAttribute.Description;
        }
        public static string GetEnumDescription(Type type, int key)
        {
           var e = Enum.Parse(type, key.ToString());
          return  GetEnumDescription((Enum)e);
        }
    }
}
