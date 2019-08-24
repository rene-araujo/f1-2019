using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class FileResult
    {
        public bool Success { get; }

        public IEnumerable<LapEntry> Lines { get; }
        
        public FileResult(bool success, IEnumerable<LapEntry> lines)
        {
            Success = success;
            Lines = lines;
        }
    }
}
