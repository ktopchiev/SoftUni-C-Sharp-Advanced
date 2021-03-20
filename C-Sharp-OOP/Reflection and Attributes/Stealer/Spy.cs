using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] investigatedFields)
        {
            //Get type of a class from passed string variable
            Type searchedClass = Type.GetType(investigatedClass);

            //Create new FieldInfo array to hold the fields
            FieldInfo[] fields = new FieldInfo[investigatedFields.Length];

            //Create new instance of the investigated class
            Hacker hacker = new Hacker();

            //Create stringbuilder
            StringBuilder sb = new StringBuilder($"Class under investigation: {searchedClass.FullName}{Environment.NewLine}");

            //Get the fields from the investigated class
            for (int i = 0; i < investigatedFields.Length; i++)
            {
                fields[i] = searchedClass.GetField(investigatedFields[i],
                    BindingFlags.NonPublic | 
                    BindingFlags.Public | 
                    BindingFlags.Static | 
                    BindingFlags.Instance);
            }

            //Get the values of fields of the investigated class from his instance
            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name}: {field.GetValue(hacker)}");
            }

            return sb.ToString();
        }
    }
}
