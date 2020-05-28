using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Win32Console.Command
{
    internal sealed class StringArraySortCommand : Win32Command
    {
        public override string CommandId => "string-array-sort";
        public override string Description => "String array sort method.";

        public override void Execute(string paras)
        {
            if (string.IsNullOrEmpty(paras))
            {
                return;
            }

            JArray jArray;
            var array = new List<string>();

            try
            {
                jArray = JArray.Parse(paras);
                if (jArray == null)
                {
                    return;
                }

                foreach (var item in jArray)
                {
                    array.Add(item["String"].ToString());
                }
            }
            catch (Exception)
            {
                return;
            }

            //排序
            array.Sort();

            jArray = new JArray();
            foreach (var item in array)
            {
                jArray.Add(new JObject {["String"] = item});
            }

            AddResult(jArray.ToString());
        }
    }
}