using System;

namespace Win32Console.Command
{
    /// <summary>
    /// Win32命令抽象类
    /// </summary>
    internal abstract class Win32Command : IWin32Command
    {
        public event Action<string> OnResult = (result) => { };

        public abstract string CommandId { get; }
        public abstract string Description { get; }
        public abstract void Execute(string paras);

        protected void AddResult(string result)
        {
            OnResult?.Invoke(result);
        }
    }
}
