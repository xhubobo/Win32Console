using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Samples.Test
{
    internal static class StringArraySort
    {
        public static void Test(string exeFileName)
        {
            Console.WriteLine("TestStringArraySort==========");

            var array = new[]
            {
                "方案", "顺序", "郑州",
                "123", "一体机", "222",
                "456", "1", "第一"
            };
            Console.WriteLine("String array before sort:");
            Console.WriteLine(string.Join(";", array));

            var jArray = new JArray();
            foreach (var item in array)
            {
                jArray.Add(new JObject {["String"] = item});
            }

            var resultList = Win32CommandHelper.ExecuteCommand(exeFileName,
                "string-array-sort", jArray.ToString());
            resultList.RemoveAt(0);
            var result = string.Join(Environment.NewLine, resultList);
            var list = new List<string>();

            try
            {
                jArray = JArray.Parse(result);
                if (jArray != null)
                {
                    foreach (var item in jArray)
                    {
                        list.Add(item["String"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}.");
            }

            Console.WriteLine();
            Console.WriteLine("String array after sort:");
            Console.WriteLine(string.Join(";", list));
        }
    }
}