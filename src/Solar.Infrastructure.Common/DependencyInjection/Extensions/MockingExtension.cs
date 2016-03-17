using System;
using System.Linq;
using LightInject;

namespace Solar.Infrastructure.Common.DependencyInjection.Extensions
{
    public static class MockingExtension
    {
        private static readonly ThreadSafeDictionary<Tuple<IServiceRegistry, Type, string>, ServiceRegistration> MockedServices
            = new ThreadSafeDictionary<Tuple<IServiceRegistry, Type, string>, ServiceRegistration>();

        private static readonly ThreadSafeDictionary<Tuple<IServiceRegistry, Type, string>, ServiceRegistration> ServicesMocks
            = new ThreadSafeDictionary<Tuple<IServiceRegistry, Type, string>, ServiceRegistration>();

        public static void StartMocking(this IServiceRegistry serviceRegistry, Type serviceType, Type implementingType)
        {
            StartMocking(serviceRegistry, serviceType, string.Empty, implementingType);
        }

        public static void StartMocking(this IServiceRegistry serviceRegistry, Type serviceType, string serviceName, Type implementingType)
        {
            var key = CreateServiceKey(serviceRegistry, serviceType, serviceName);
            ILifetime lifeTime = null;
            var serviceRegistration = GetExistingServiceRegistration(serviceRegistry, serviceType, serviceName);

            if (serviceRegistration != null)
            {
                MockedServices.TryAdd(key, serviceRegistration);
                lifeTime = CreateLifeTimeBasedOnExistingServiceRegistration(serviceRegistration);
            }

            var mockServiceRegistration = CreateTypeBasedMockServiceRegistration(serviceType, serviceName, implementingType, lifeTime);
            ((ServiceContainer)serviceRegistry).Invalidate();
            serviceRegistry.Register(mockServiceRegistration);
            ServicesMocks.TryAdd(key, mockServiceRegistration);
        }

        public static void StartMocking<TService>(this IServiceRegistry serviceRegistry, Func<TService> mockFactory, string serviceName) where TService : class
        {
            var key = CreateServiceKey(serviceRegistry, typeof(TService), serviceName);
            ILifetime lifeTime = null;
            var serviceRegistration = GetExistingServiceRegistration(serviceRegistry, typeof(TService), serviceName);

            if (serviceRegistration != null)
            {
                MockedServices.TryAdd(key, serviceRegistration);
                lifeTime = CreateLifeTimeBasedOnExistingServiceRegistration(serviceRegistration);
            }

            var mockServiceRegistration = CreateFactoryBasedMockServiceRegistration(mockFactory, serviceName, lifeTime);
            ((ServiceContainer)serviceRegistry).Invalidate();
            serviceRegistry.Register(mockServiceRegistration);
            ServicesMocks.TryAdd(key, mockServiceRegistration);
        }
     
        public static void StartMocking<TService>(this IServiceRegistry serviceRegistry, Func<TService> mockFactory) where TService : class
        {
            StartMocking(serviceRegistry, mockFactory, string.Empty);
        }

        public static void EndMocking<TService>(this IServiceRegistry serviceRegistry, string serviceName)
        {
            EndMocking(serviceRegistry, typeof(TService), serviceName);
        }

        public static void EndMocking(this IServiceRegistry serviceRegistry, Type serviceType)
        {
            EndMocking(serviceRegistry, serviceType, string.Empty);
        }

        public static void EndMocking(this IServiceRegistry serviceRegistry, Type serviceType, string serviceName)
        {
            var key = Tuple.Create(serviceRegistry, serviceType, serviceName);
            ServiceRegistration serviceRegistration;

            ServicesMocks.TryRemove(key, out serviceRegistration);

            if (serviceRegistration == null)
            {
                throw new InvalidOperationException($"No mocked service found. ServiceType: {serviceType}, ServiceName: {serviceName}");
            }

            serviceRegistration.IsReadOnly = false;

            if (MockedServices.TryRemove(key, out serviceRegistration))
            {
                ((ServiceContainer)serviceRegistry).Invalidate();
                serviceRegistry.Register(serviceRegistration);
            }
        }
    
        public static void EndMocking<TService>(this IServiceRegistry serviceRegistry)
        {
            EndMocking<TService>(serviceRegistry, string.Empty);
        }

        private static ServiceRegistration CreateFactoryBasedMockServiceRegistration<TService>(Func<TService> mockFactory, string serviceName, ILifetime lifeTime)
           where TService : class
        {
            var mockServiceRegistration = new ServiceRegistration { ServiceType = typeof(TService), ServiceName = serviceName, Lifetime = lifeTime, IsReadOnly = true };
            Func<IServiceFactory, TService> factoryExpression = factory => mockFactory();
            mockServiceRegistration.FactoryExpression = factoryExpression;
            return mockServiceRegistration;
        }

        private static ServiceRegistration CreateTypeBasedMockServiceRegistration(Type serviceType, string serviceName, Type implementingType, ILifetime lifeTime)
        {
            var mockServiceRegistration = new ServiceRegistration { ServiceType = serviceType, ImplementingType = implementingType, ServiceName = serviceName, Lifetime = lifeTime, IsReadOnly = true };
            return mockServiceRegistration;
        }

        private static Tuple<IServiceRegistry, Type, string> CreateServiceKey(IServiceRegistry serviceRegistry, Type serviceType, string serviceName)
        {
            return Tuple.Create(serviceRegistry, serviceType, serviceName);
        }

        private static ILifetime CreateLifeTimeBasedOnExistingServiceRegistration(ServiceRegistration serviceRegistration)
        {
            ILifetime lifeTime = null;
            if (serviceRegistration.Lifetime != null)
            {
                lifeTime = (ILifetime)Activator.CreateInstance(serviceRegistration.Lifetime.GetType());
            }

            return lifeTime;
        }

        private static ServiceRegistration GetExistingServiceRegistration(IServiceRegistry serviceRegistry, Type serviceType, string serviceName)
        {
            return serviceRegistry.AvailableServices.FirstOrDefault(sr => sr.ServiceType == serviceType && sr.ServiceName == serviceName);
        }
    }
}