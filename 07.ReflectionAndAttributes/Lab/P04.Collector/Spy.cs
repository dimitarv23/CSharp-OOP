using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            Type type = Type.GetType(classToInvestigate);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic
                | BindingFlags.Public | BindingFlags.Static);
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Class under investigation: {classToInvestigate}");

            object hacker = Activator.CreateInstance(type);

            foreach (var field in fields)
            {
                if (fieldsToInvestigate.Contains(field.Name))
                {
                    result.AppendLine($"{field.Name} = {field.GetValue(hacker)}");
                }
            }

            return result.ToString();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            var classToInvestigate = "Stealer." + className;
            Type typeOfClass = Type.GetType(classToInvestigate);
            FieldInfo[] nonPrivateFields = typeOfClass.GetFields(BindingFlags.Public |
                BindingFlags.Instance | BindingFlags.Static);
            StringBuilder result = new StringBuilder();

            foreach (var field in nonPrivateFields)
            {
                result.AppendLine($"{field.Name} must be private!");
            }

            PropertyInfo[] properties = typeOfClass.GetProperties(BindingFlags.Instance | BindingFlags.Public
                | BindingFlags.NonPublic | BindingFlags.Static);

            foreach (var property in properties)
            {
                MethodInfo[] accessors = property.GetAccessors(true);

                foreach (var accessor in accessors)
                {
                    if (accessor.ReturnType == typeof(void) && accessor.IsPublic)
                    {
                        //this is a setter
                        result.AppendLine($"{accessor.Name} have to be private!");
                    }
                    else if (accessor.ReturnType != typeof(void) && accessor.IsPrivate)
                    {
                        //this is a getter
                        result.AppendLine($"{accessor.Name} have to be public");
                    }
                }
            }

            return result.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type typeOfClass = Type.GetType(className);
            MethodInfo[] privateMethods = typeOfClass.GetMethods(BindingFlags.NonPublic
                | BindingFlags.Instance | BindingFlags.Static);

            StringBuilder result = new StringBuilder();
            result.AppendLine($"All Private Methods of Class: {className}");
            result.AppendLine($"Base Class: {typeOfClass.BaseType}");

            foreach (var method in privateMethods)
            {
                result.AppendLine($"{method.Name}");
            }

            return result.ToString();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder result = new StringBuilder();

            Type typeOfClass = Type.GetType(className);
            MethodInfo[] methods = typeOfClass.GetMethods(BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Static | BindingFlags.Instance);

            foreach (var method in methods)
            {
                if (method.Name.StartsWith("get"))
                {
                    result.AppendLine($"{method.Name} will return {method.ReturnType}");
                }
                else if (method.Name.StartsWith("set"))
                {
                    var parameter = method.GetParameters()[0];
                    result.AppendLine($"{method.Name} will set field of {parameter.ParameterType}");
                }
            }

            return result.ToString();
        }
    }
}
