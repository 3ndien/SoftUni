 namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            FieldInfo[] myFieldInfo;
            Type myType = typeof(HarvestingFields);
            myFieldInfo = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance
                | BindingFlags.Public);
            string command;

            

            while ((command = Console.ReadLine()) != "HARVEST")
            {
                var filteredFields = new List<FieldInfo>();

                switch (command)
                {
                    case "protected":
                        filteredFields = myFieldInfo.Where(f => f.IsFamily).ToList();
                        PrintFilteredFields(filteredFields);
                        break;
                    case "private":
                        filteredFields = myFieldInfo.Where(f => f.IsPrivate).ToList();
                        PrintFilteredFields(filteredFields);
                        break;
                    case "public":
                        filteredFields = myFieldInfo.Where(f => f.IsPublic).ToList();
                        PrintFilteredFields(filteredFields);
                        break;
                    case "all":
                        filteredFields = myFieldInfo.ToList();
                        PrintFilteredFields(filteredFields);
                        break;
                    default:
                        Console.WriteLine("invalid command");
                        break;
                }
            }

            
        }

        private static void PrintFilteredFields(List<FieldInfo> filteredFields)
        {
            for (int f = 0; f < filteredFields.Count; f++)
            {
                var accessModifier = filteredFields[f].Attributes.ToString();
                accessModifier = accessModifier == "Family" ? "protected" : accessModifier.ToLower();
                Console.WriteLine($"{accessModifier} {filteredFields[f].FieldType.Name} {filteredFields[f].Name}");
            }
        }
    }
}
