using Microsoft.Extensions.DependencyInjection;
using System;

namespace Dependencies
{
    public class Singleton
    {
        private IServiceProvider _serviceProvider;

        public Singleton(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

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
