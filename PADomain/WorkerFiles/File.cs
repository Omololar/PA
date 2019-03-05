using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain.WorkerFiles
{
    public class Filess:IFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] Bytes { get; set; }
       
    }
}
