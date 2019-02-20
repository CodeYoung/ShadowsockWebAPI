using Abp.Dependency;
using Castle.Windsor;
using System;
using System.Reflection;

namespace ShadowsocksWebAPI.Controllers
{
    public class IocManager : IIocManager, IIocRegistrar,
    IIocResolver, IDisposable
    {
        //public static object Intance { get; internal set; }
        public static IocManager Instance { get; }
        public IWindsorContainer IocContainer => throw new NotImplementedException();

        public void AddConventionalRegistrar(IConventionalDependencyRegistrar registrar)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool IsRegistered(Type type)
        {
            throw new NotImplementedException();
        }

        public bool IsRegistered<T>()
        {
            throw new NotImplementedException();
        }

        public void Register<T>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where T : class
        {
            throw new NotImplementedException();
        }

        public void Register(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            throw new NotImplementedException();
        }

        public void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            throw new NotImplementedException();
        }

        public void RegisterAssemblyByConvention(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public void RegisterAssemblyByConvention(Assembly assembly, ConventionalRegistrationConfig config)
        {
            throw new NotImplementedException();
        }

        public void Release(object obj)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(Type type)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(object argumentsAsAnonymousType)
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type, object argumentsAsAnonymousType)
        {
            throw new NotImplementedException();
        }

        public T[] ResolveAll<T>()
        {
            throw new NotImplementedException();
        }

        public T[] ResolveAll<T>(object argumentsAsAnonymousType)
        {
            throw new NotImplementedException();
        }

        public object[] ResolveAll(Type type)
        {
            throw new NotImplementedException();
        }

        public object[] ResolveAll(Type type, object argumentsAsAnonymousType)
        {
            throw new NotImplementedException();
        }

        void IIocRegistrar.Register<TType, TImpl>(DependencyLifeStyle lifeStyle)
        {
            throw new NotImplementedException();
        }
    }
}