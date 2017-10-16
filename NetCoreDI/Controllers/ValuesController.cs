using Dependencies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

namespace NetCoreDI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private TransientDisposable _transientDisposable;
        private DependantOnTransient _dependantOnTransient;
        private Scoped _scoped;
        private DependantOnScoped _dependantOnScoped;
        private IServiceProvider _serviceProvider;
        private Singleton _singleton;

        public ValuesController(
            TransientDisposable transientDisposable,
            DependantOnTransient dependantOnTransient,
            Scoped scoped,
            DependantOnScoped dependantOnScoped,
            IServiceProvider serviceProvider,
            Singleton singleton)
        {
            _transientDisposable = transientDisposable;
            _dependantOnTransient = dependantOnTransient;

            _scoped = scoped;
            _dependantOnScoped = dependantOnScoped;
            _serviceProvider = serviceProvider;
            _singleton = singleton;
        }

        // GET api/values
        [HttpGet]
        public string GetValues()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"First instance of Transient:  {_transientDisposable.ID}");
            result.AppendLine($"Second instance of Transient: {_dependantOnTransient.ID}");

            result.AppendLine($"First instance of Scoped:  {_scoped.ID}");
            result.AppendLine($"Second instance of Scoped: {_dependantOnScoped.ID}");
            result.AppendLine(Environment.NewLine);

            result.AppendLine("Explicit resolutions:");

            var explicitlyResolved = _serviceProvider.GetService<Scoped>();
            result.AppendLine($"Scoped explicitly resoleved at Controller level: {explicitlyResolved.ID}");

            var scopedFromSingleton = _singleton.ResolveScoped();
            result.AppendLine($"Scoped explicitly resoleved at Singleton level. call 1: {scopedFromSingleton.ID}");

            scopedFromSingleton = _singleton.ResolveScoped();
            result.AppendLine($"Scoped explicitly resoleved at Singleton level. call 2: {scopedFromSingleton.ID}");

            var transientFromSingleton = _singleton.ResolveTransient();
            result.AppendLine($"Transient explicitly resoleved at Singleton level. call 1: {transientFromSingleton.ID}");

            transientFromSingleton = _singleton.ResolveTransient();
            result.AppendLine($"Transient explicitly resoleved at Singleton level. call 2: {transientFromSingleton.ID}");

            return result.ToString();
        }
    }
}
