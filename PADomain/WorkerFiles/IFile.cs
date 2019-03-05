using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain.WorkerFiles
{
    public interface IFile
    {
        int Id { get; set; }
       string FileName { get; set; }
       byte[] Bytes { get; set; }
    }
}
