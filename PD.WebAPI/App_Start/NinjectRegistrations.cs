using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PD.DataCore.Interfaces;
using PD.DataJson.Repository;
using PD.DataEF.Repository;
using PD.WebAPI.Utils;

namespace PD.WebAPI.App_Start
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            if (!AppSettings.UseDB)
            {
                Bind<IPhoneDictionary>().To<JsonPhoneRepository>();
            }
            else
            {
                Bind<IPhoneDictionary>()
                    .To<EFPhoneDictionaryRepository>()
                    .WithConstructorArgument("nameOrConnectionString", "defaultLocal");
            }
        }
    }
}