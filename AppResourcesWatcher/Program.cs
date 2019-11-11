using AppResourcesWatcher.Models;
using AppResourcesWatcher.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace AppResourcesWatcher
{
    class Program
    {

        static void Main(string[] args)
        {
            long currentInterval = 0;

            string connectionString = GetConnectionString();

            MemorySnapShotContext memorySnapShotContext = new MemorySnapShotContext(connectionString);

            Data data = new Data(memorySnapShotContext);

            List<MemorySnapshot> memorySnapshots = new List<MemorySnapshot>();

            ShellCommands shellCommandsService = new ShellCommands();

            ParsingService parsingService = new ParsingService();

            while (true)
            {
                string unparsedMemory = shellCommandsService.ExecuteLinuxCommand("free", "-m");

                MemorySnapshot ms = parsingService.ParseMemorySnapshot(unparsedMemory);

                if (ms != null)
                    memorySnapshots.Add(ms);
                else
                    memorySnapshots.Add(new MemorySnapshot());

                if (currentInterval > 300000)
                {
                    data.SaveMemorySnapshots(memorySnapshots);
                    memorySnapshots = new List<MemorySnapshot>();
                    currentInterval = 0;
                }

                currentInterval += 10000;

                Thread.Sleep(10000);
            }

        }

        static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            return configuration.GetConnectionString("AppDb");
        }

    }
}
