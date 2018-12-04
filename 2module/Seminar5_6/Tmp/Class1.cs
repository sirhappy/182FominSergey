using System;

namespace Common
{
    public class Parser
    {
        /// <summary>
        /// Universal input method
        /// Copyright (c) AndBondStyle 2018
        /// </summary>
        /// <param name="prompt">Input prompt</param>
        /// <param name="check">Check function (defaults to x => true)</param>
        /// <param name="parse">Parse function (defaults to T.Parse)</param>
        /// <typeparam name="T">Value type</typeparam>
        /// <returns>Value of requested type</returns>
        /// <exception cref="ApplicationException">
        /// Throws if parse argument is null and T.Parse method not found
        /// </exception>
        public static T Input<T>(string prompt, Func<T, bool> check = null, Func<string, T> parse = null)
        {
            if (check == null) check = x => true;
            if (parse == null)
            {
                var method = typeof(T).GetMethod("Parse", new[] { typeof(string) });
                if (method == null) throw new ApplicationException("Could not find \"Parse\" method of type T");
                parse = x => (T)method.Invoke(null, new object[] { x });
            }

            while (true)
            {
                Console.Write(prompt);
                var line = Console.ReadLine();
                try
                {
                    var value = parse(line);
                    if (check(value)) return value;
                }
                catch (Exception)
                {
                    // The "parse" function is expected to be very short and simple lambda. Therefore,
                    // in sake of simplicity, *all* errors are treated as the result of bad input.
                }
                Console.WriteLine("Incorrect input");
            }
        }
    }
}