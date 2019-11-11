using System;
using System.Collections.Generic;
using System.Text;

namespace AppResourcesWatcher.Models
{
    public class MemorySnapshot
    {
        public int MemorySnapshotId { get; set; }
        public int Total { get; set; }
        public int Used { get; set; }
        public int Free { get; set; }
        public int Shared { get; set; }
        public int BuffCache { get; set; }
        public int Available { get; set; }

    }
}
