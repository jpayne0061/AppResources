using AppResourcesWatcher.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppResourcesWatcher
{
    public class Data
    {
        private MemorySnapShotContext _context;

        public Data(MemorySnapShotContext context)
        {
            _context = context;
        }

        public void SaveMemorySnapshots(List<MemorySnapshot> memorySnapshots)
        {
            _context.MemorySnapshots.AddRange(memorySnapshots);
            _context.SaveChanges();
        }

    }
}
