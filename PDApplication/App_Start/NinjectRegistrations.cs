using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PD.DataCore.Interfaces;
using PD.DataJson.Repository;
using PD.DataEF.Repository;

namespace PDApplication.App_Start
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IPhoneDictionary>().To<JsonPhoneRepository>();
            //Bind<IPhoneDictionary>()
            //    .To<EFPhoneDictionaryRepository>()
            //    .WithConstructorArgument("nameOrConnectionString", "de");

        }
    }
}