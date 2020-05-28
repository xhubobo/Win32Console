using System;
using System.Collections.Generic;
using System.Linq;
using Win32Console.Command;

namespace Win32Console
{
    /// <summary>
    /// Win32命令管理单例类
    /// </summary>
    internal sealed class Win32CommandManager
    {
        public readonly Dictionary<string, Win32Command> _commandDic;

        //注册命令
        public void RegisterCommand(Win32Command command)
        {
            if (string.IsNullOrEmpty(command?.CommandId))
            {
                return;
            }

            if (!_commandDic.ContainsKey(command.CommandId))
            {
                command.OnResult += OnResult;
                _commandDic.Add(command.CommandId, command);
            }
        }

        //获取命令
        public IWin32Command GetCommand(string commandId)
        {
            if (string.IsNullOrEmpty(commandId) || !_commandDic.ContainsKey(commandId))
            {
                return null;
            }

            return _commandDic[commandId];
        }

        //获取命令列表
        public List<IWin32Command> GetCommandList()
        {
            return _commandDic.Values.ToList<IWin32Command>();
        }

        public void Show()
        {
            foreach (var item in _commandDic)
            {
                Console.WriteLine($"{item.Key}");
            }
        }

        //输出结果
        private void OnResult(string result)
        {
            Console.WriteLine(result);
        }

        #region 单例模式

        private static Win32CommandManager _instance;
        private static readonly object InstanceLockHelper = new object();

        private Win32CommandManager()
        {
            _commandDic = new Dictionary<string, Win32Command>();
        }

        public static Win32CommandManager Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                lock (InstanceLockHelper)
                {
                    _instance = _instance ?? new Win32CommandManager();
                }

                return _instance;
            }
        }

        #endregion
    }
}