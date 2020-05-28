namespace Win32Console.Command
{
    /// <summary>
    /// Win32命令接口
    /// </summary>
    interface IWin32Command
    {
        string CommandId { get; }
        string Description { get; }
        void Execute(string paras);
    }
}
