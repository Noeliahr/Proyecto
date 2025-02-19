using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WSControldePacientesApi.Configuration;
using WSControldePacientesApi.EntityFrameworkCore;
using WSControldePacientesApi.Migrator.DependencyInjection;

namespace WSControldePacientesApi.Migrator
{
    [DependsOn(typeof(WSControldePacientesApiEntityFrameworkModule))]
    public class WSControldePacientesApiMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public WSControldePacientesApiMigratorModule(WSControldePacientesApiEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(WSControldePacientesApiMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                WSControldePacientesApiConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WSControldePacientesApiMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
