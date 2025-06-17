using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;
using HDP.Infra.Services;
using Limxc.Arch.Core.Shared.Interfaces;
using Limxc.Arch.Infra.Services;
using Limxc.Tools.Contract.Interfaces;
using Limxc.Tools.Core.Common;
using Limxc.Tools.Core.Services;

namespace Limxc.Arch.Core
{
    public class InfraModule : Module
    {
        /// <summary>
        ///     EnvPath.SetBaseDir(() => "xxx");
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(LiteDB5Repo<,>))
                .As(typeof(IRepo<,>))
                .InstancePerLifetimeScope();

            builder
                .RegisterGeneric(typeof(LiteDB5Repo<>))
                .As(typeof(IRepo<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<FileConfigService>()
                .As<IConfigService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterGeneric(typeof(JsonFileSettingService<>))
                .As(typeof(ISettingService<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<IInfraService>()
                .AsImplementedInterfaces();
        }
    }
}
