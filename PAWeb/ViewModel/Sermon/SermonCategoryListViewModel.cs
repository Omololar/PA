using PADomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAWeb
{
    public class SermonCategoryListViewModel
    {
        public IEnumerable<ISermonCategory> SermonCategories { get; set; } = Enumerable.Empty<ISermonCategory>();

    }
}