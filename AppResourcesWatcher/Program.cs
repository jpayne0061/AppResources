using AppResourcesWatcher.Enums;
using AppResourcesWatcher.Models;
using AppResourcesWatcher.Services;
using System.Collections.Generic;
using System.Threading;

namespace AppResourcesWatcher
{
    class Program
    {

        static void Main(string[] args)
        {
            #region dependencies
            Data data = new Data(new MemorySnapShotContext());

            List<MemorySnapshot> memorySnapshots = new List<MemorySnapshot>();

            ShellCommands shellCommandsService = new ShellCommands();

            ParsingService parsingService = new ParsingService();

            long currentInterval = 0;

            int tenSeconds = (int)TimeFromMsEnums.TenSeconds;
            #endregion dependencies

            while (true)
            {
                string unparsedMemory = shellCommandsService.ExecuteLinuxCommand("free", "-m");

                MemorySnapshot ms = parsingService.ParseMemorySnapshot(unparsedMemory);

                if (ms != null)
                    memorySnapshots.Add(ms);
                else
                    memorySnapshots.Add(new MemorySnapshot());

                if (currentInterval > (int)TimeFromMsEnums.FiveMinutes)
                {
                    data.SaveMemorySnapshots(memorySnapshots);
                    memorySnapshots = new List<MemorySnapshot>();
                    currentInterval = 0;
                }

                currentInterval += tenSeconds;

                Thread.Sleep(tenSeconds);
            }

        }

    }
}
