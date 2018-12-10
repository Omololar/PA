using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAInfrastructure
{
    public class ConfigService : IConfigService
    {
        public string MyConnection
        {
            get
            {
                string cnString = null;
                var cnSettings = ConfigurationManager.ConnectionStrings["PraiseDbContext"];
                if (cnSettings != null)
                {
                    cnString = cnSettings.ConnectionString;
                }
                return cnString;
            }
        }
    }
}
