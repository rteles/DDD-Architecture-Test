using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Linq;

namespace Arch.Infra.Common.IoC
{
    public class AppContext
    {
        private static IUnityContainer ContainerInstance { get; set; }

        static AppContext()
        {
            if (ContainerInstance == null)
            {
                ContainerInstance = new UnityContainer();
                ContainerInstance.AddNewExtension<Interception>();
            }
        }
        
        public static void InitializeContainer(System.Reflection.Assembly coreAssembly)
        {
            ContainerInstance = new UnityContainer();
            ContainerInstance.AddNewExtension<Interception>();

            var components = coreAssembly.GetTypes().Where(t => t.IsClass /*&&
            (
                  typeof(Arch.Core.Interfaces.Service.IServiceBase).IsAssignableFrom(t) ||
                  typeof(Arch.Core.Interfaces.Repository.IRepositoryBase<>).IsAssignableFrom(t)
            )*/);

            foreach (var component in components)
            {
                var cpType = component.UnderlyingSystemType;
                if (cpType.GetInterfaces().Any(i => i.Name == string.Concat("I", cpType.Name)))
                {
                    ContainerInstance.RegisterType(cpType.GetInterfaces().First(), cpType, new ContainerControlledLifetimeManager());
                }
            }
        }

        public static void RegisterType<TFrom, TTo>()
        {
            if (ContainerInstance == null)
                throw new Exception("Container instance has not been set to an IoC Container.");

            if (!ContainerInstance.IsRegistered<TTo>())
                ContainerInstance.RegisterType(typeof(TFrom), typeof(TTo), new ContainerControlledLifetimeManager());
        }
        
        public static void RegisterType(Type from, Type to)
        {
            if (ContainerInstance == null)
                throw new Exception("Container instance has not been set to an IoC Container.");

            if (!ContainerInstance.IsRegistered(to))
                ContainerInstance.RegisterType(from, to, new ContainerControlledLifetimeManager());
        }

        public static T Get<T>()
        {
            if (ContainerInstance == null)
                throw new Exception("Container instance has not been set to an IoC Container.");

            return ContainerInstance.Resolve<T>(new ResolverOverride[] { });
        }

        public static T Get<T>(string name)
        {
            if (ContainerInstance == null)
                throw new Exception("Container instance has not been set to an IoC Container.");

            return ContainerInstance.Resolve<T>(name, new ResolverOverride[] { });
        }

        public static T GetOrRegister<T>()
        {
            if (!ContainerInstance.IsRegistered<T>())
                ContainerInstance.RegisterType<T, T>(new ContainerControlledLifetimeManager());

            return Get<T>();
        }

        public static T GetOrRegister<T>(string name)
        {
            if (!ContainerInstance.IsRegistered<T>(name))
                ContainerInstance.RegisterType<T, T>(name, new ContainerControlledLifetimeManager());

            return Get<T>(name);
        }
    }
}