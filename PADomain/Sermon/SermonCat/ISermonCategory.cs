using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PADomain
{
    public interface ISermonCategory
    {
        int Id { get; set; }
        string SermonName { get; set; }
        string SermonDescription { get; set; }
    }
}
