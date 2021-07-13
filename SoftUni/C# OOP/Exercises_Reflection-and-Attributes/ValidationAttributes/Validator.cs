using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] objProprerties = obj.GetType().GetProperties();

            foreach (var propertyInfo in objProprerties)
            {
                IEnumerable<MyValidationAttribute> attributes = propertyInfo
                    .GetCustomAttributes()
                    .Where(a => a is MyValidationAttribute)
                    .Cast<MyValidationAttribute>();

                foreach (var attribute in attributes)
                {
                    bool result = attribute.IsValid(propertyInfo.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
