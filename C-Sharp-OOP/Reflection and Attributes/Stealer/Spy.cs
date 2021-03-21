using System;
using System.Collections.Generic;
using System.Linq;
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

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);

            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type investigatedClass = Type.GetType(className);
            Type baseClass = Type.GetType(className).BaseType;
            MethodInfo[] classPrivateMethods = investigatedClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            
            StringBuilder sb = new StringBuilder($"All Private Methods of Class: {investigatedClass.FullName}{Environment.NewLine}" +
                $"Base Class: {baseClass.Name}{Environment.NewLine}");

            foreach (MethodInfo method in classPrivateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type investigatedClass = Type.GetType(className);

            MethodInfo[] classMethods = investigatedClass.GetMethods(BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.Static);

            StringBuilder sb = new StringBuilder();


            foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }
    }
}
