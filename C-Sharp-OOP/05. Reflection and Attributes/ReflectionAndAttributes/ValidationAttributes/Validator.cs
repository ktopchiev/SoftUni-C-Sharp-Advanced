using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            //Get the object's properties
            PropertyInfo[] properties = obj.GetType().GetProperties();


            //Get through each property and get his attributes
            foreach (var property in properties)
            {
                MyValidationAttribute[] attributes = property.GetCustomAttributes()
                    .Where(a => a is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                //Get object's current property value
                object value = property.GetValue(obj);

                foreach (var attribute in attributes)
                {
                    //Check if object's value is valid with his attributes
                    bool isValid = attribute.IsValid(value);

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
