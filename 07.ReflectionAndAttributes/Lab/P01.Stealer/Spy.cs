using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

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
    }
}
