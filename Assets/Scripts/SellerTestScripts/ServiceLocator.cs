using System;
using System.Collections.Generic;
using SellerTestScripts.Services.Interfaces;

namespace SellerTestScripts
{
    public class ServiceLocator : IDisposable
    {
        public static ServiceLocator Instance => _instance ??= new ServiceLocator();

        private static ServiceLocator _instance;
    
        private readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();
    
        private ServiceLocator(){}

        public void Register<TService>(TService service) where TService : IService
        {
            _services[typeof(TService)] = service;
        }

        public TService Get<TService>() where TService : class, IService
        {
            return _services[typeof(TService)] as TService;
        }
    
        public void Dispose()
        {
            foreach (var service in _services.Values)
            {
                if (service is IDisposable disposableService)
                {
                    disposableService.Dispose();
                }
            }
        }
    }
}