namespace P02_BlackBoxInteger
{
    using System.Reflection;
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);
            var instance = (BlackBoxInteger)Activator.CreateInstance(type, true);


            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split('_', StringSplitOptions.RemoveEmptyEntries);

                string methodName = args[0];
                int numberParameter = int.Parse(args[1]);
                var methodInfo = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

                methodInfo.Invoke(instance, new object[] { numberParameter });

                var innerField = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

                Console.WriteLine(innerField.GetValue(instance));
            }
        }
    }
}
