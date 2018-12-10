﻿using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAInfrastructure
{
    public class ConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigService>().To<ConfigService>();
        }
    }
}
