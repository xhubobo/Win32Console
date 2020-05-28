using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Win32Console.Command
{
    internal sealed class HelpCommand : Win32Command
    {
        public override string CommandId => "help";
        public override string Description => "";

        public override void Execute(string paras)
        {
            Console.WriteLine();
            Console.WriteLine("{0, -30} {1}", "Command", "Description");

            var cmdList = Win32CommandManager.Instance.GetCommandList();
            foreach (var cmd in cmdList)
            {
                if (!CommandId.Equals(cmd.CommandId))
                {
                    Console.WriteLine($"-{cmd.CommandId, -30}{cmd.Description}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}