using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dependencies
{
    public class Singleton
    {
        private IServiceProvider _serviceProvider;
        private Scoped _scoped;

        public Singleton(
            IServiceProvider serviceProvider,
            Scoped scoped)
        {
            _serviceProvider = serviceProvider;
            _scoped = scoped;
        }

        public Guid ScopedID { get { return _scoped.ID; } }

        public IServiceProvider ServiceProvider { get { return _serviceProvider; } }

        public Scoped ResolveScoped()
        {
            return _serviceProvider.GetService<Scoped>();
        }

        public TransientDisposable ResolveTransient()
        {
            return _serviceProvider.GetService<TransientDisposable>();
        }
    }
}
