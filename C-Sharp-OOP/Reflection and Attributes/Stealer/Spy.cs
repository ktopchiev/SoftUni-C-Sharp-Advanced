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
            Type searchedClass = Type.GetType(investigatedClass);
            FieldInfo[] fields = new FieldInfo[investigatedFields.Length];

            Hacker hacker = new Hacker();

            StringBuilder sb = new StringBuilder($"Class under investigation: {searchedClass.FullName}{Environment.NewLine}");

            for (int i = 0; i < investigatedFields.Length; i++)
            {
                fields[i] = searchedClass.GetField(investigatedFields[i],
                    BindingFlags.NonPublic | 
                    BindingFlags.Public | 
                    BindingFlags.Static | 
                    BindingFlags.Instance);
            }

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name}: {field.GetValue(hacker)}");
            }

            return sb.ToString();
        }
    }
}
