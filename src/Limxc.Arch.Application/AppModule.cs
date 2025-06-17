using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;
using Limxc.Arch.Core.Shared.Interfaces;

namespace Limxc.Arch.Core
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<IAppService>()
                .AsImplementedInterfaces();
        }
    }
}
