using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Samples
{
    internal static class Win32CommandHelper
    {
        public static List<string> ExecuteCommand(string exeFileName, string command, string paras)
        {
            var lines = new List<string>();
            var processEncoding = Encoding.Default;
            var process = new Process
            {
                StartInfo =
                {
                    FileName = exeFileName,
                    StandardOutputEncoding = processEncoding,
                    UseShellExecute = false, //不使用系统Shell启动
                    RedirectStandardInput = true, //接收来自调用程序的输入信息
                    RedirectStandardOutput = true, //输出信息
                    RedirectStandardError = true, //错误信息
                    CreateNoWindow = true //不显示窗口
                }
            };
            if (!process.Start())
            {
                return lines;
            }

            //向cmd发送输入信息
            command = command.TrimStart('-');
            paras = paras.Replace(Environment.NewLine, "");
            var input = $"-{command} {paras}";

            //使用流写入类关联输入编码
            var stream = new StreamWriter(process.StandardInput.BaseStream, processEncoding);
            stream.WriteLine(input);
            stream.Close();

            //process.StandardInput.WriteLine(input);
            //process.StandardInput.AutoFlush = true;

            //获取cmd输出信息
            while (!process.StandardOutput.EndOfStream)
            {
                lines.Add(process.StandardOutput.ReadLine());
            }

            //等待程序执行完毕退出
            process.WaitForExit();
            process.Close();

            if (lines.Count > 0)
            {
                lines.RemoveAt(0);
            }

            return lines;
        }
    }
}