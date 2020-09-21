using Autofac;
using Autofac.Core;
using Autofac.Core.Lifetime;
using Autofac.Core.Resolving;
using System;
using System.Threading.Tasks;

namespace Gaming.API.Utils
{
    public abstract class AutofacSelfContainer<T> : IContainer
        where T : AutofacSelfContainer<T>
    {
        private IContainer Container { get; }
        public AutofacSelfContainer(ContainerBuilder builder)
        {
            builder.RegisterInstance(this).AsSelf().SingleInstance();
            Container = builder.Build();
        }
        public IDisposer Disposer => Container.Disposer;

        public object Tag => Container.Tag;

        public IComponentRegistry ComponentRegistry => Container.ComponentRegistry;

        public event EventHandler<LifetimeScopeBeginningEventArgs> ChildLifetimeScopeBeginning;
        public event EventHandler<LifetimeScopeEndingEventArgs> CurrentScopeEnding;
        public event EventHandler<ResolveOperationBeginningEventArgs> ResolveOperationBeginning;

        public ILifetimeScope BeginLifetimeScope()
        {
            return Container.BeginLifetimeScope();
        }

        public ILifetimeScope BeginLifetimeScope(object tag)
        {
            return Container.BeginLifetimeScope(tag);
        }

        public ILifetimeScope BeginLifetimeScope(Action<ContainerBuilder> configurationAction)
        {
            return Container.BeginLifetimeScope(configurationAction);
        }

        public ILifetimeScope BeginLifetimeScope(object tag, Action<ContainerBuilder> configurationAction)
        {
            return Container.BeginLifetimeScope(tag, configurationAction);
        }

        public void Dispose()
        {
            Container.Dispose();
        }

        public ValueTask DisposeAsync()
        {
            return Container.DisposeAsync();
        }

        public object ResolveComponent(ResolveRequest request)
        {
            return Container.ResolveComponent(request);
        }
    }
}
