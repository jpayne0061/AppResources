using AppResourcesWatcher.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AppResourcesWatcher.Services
{
    public class ParsingService
    {
        public MemorySnapshot ParseMemorySnapshot(string unparsedMemorySnapshot)
        {
            try
            {
                int[] stats = unparsedMemorySnapshot.Split('\n')[1].Split(null).Where(x => x.All(Char.IsDigit) && !string.IsNullOrEmpty(x)).Select(x => int.Parse(x)).ToArray();

                return new MemorySnapshot {
                    Total = stats[0],
                    Used = stats[1],
                    Free = stats[2],
                    Shared = stats[3],
                    BuffCache = stats[4],
                    Available = stats[5],
                    DateTimeUTC = DateTime.UtcNow
                };
            }
            catch(Exception ex)
            {
                File.WriteAllText("error-message.txt", ex.Message + "/r/n" + unparsedMemorySnapshot);
                return null;
            }

        }

    }
}
