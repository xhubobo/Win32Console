using System;
using System.Text;
using Win32Console.Command;

namespace Win32Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input command(For help input -help):");

            //获取输入
            var content = Console.ReadLine();
            if (string.IsNullOrEmpty(content))
            {
                return;
            }

            //获取命令和参数
            var lines = content.Split(' ');
            var cmd = GetCmd(lines);
            var paras = GetParas(lines);
            if (string.IsNullOrEmpty(cmd))
            {
                return;
            }

            //注册命令实体
            RegisterCommand();

            //执行命令
            var win32Command = Win32CommandManager.Instance.GetCommand(cmd);
            win32Command?.Execute(paras);
        }

        private static string GetCmd(string[] lines)
        {
            var paras = string.Empty;
            if (lines == null || lines.Length < 1)
            {
                return paras;
            }

            var cmd = lines[0];
            cmd = cmd.TrimStart('-');
            return cmd;
        }

        private static string GetParas(string[] lines)
        {
            var paras = string.Empty;
            if (lines == null || lines.Length < 2)
            {
                return paras;
            }

            var parasStr = new StringBuilder();
            for (var i = 1; i < lines.Length; i++)
            {
                parasStr.Append($"{lines[i]} ");
            }

            paras = parasStr.ToString().TrimEnd(' ');
            return paras;
        }

        private static void RegisterCommand()
        {
            //注册命令
            Win32CommandManager.Instance.RegisterCommand(new HelpCommand());
            Win32CommandManager.Instance.RegisterCommand(new StringArraySortCommand());
        }
    }
}
