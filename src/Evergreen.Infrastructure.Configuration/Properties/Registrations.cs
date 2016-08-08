using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Photosphere.DependencyInjection;
using Photosphere.DependencyInjection.Attributes;

[assembly: RegisterDependencies(typeof(IGlobalStateObject), Lifetime.PerContainer)]
[assembly: RegisterDependencies(typeof(IInfrastructureService), Lifetime.PerContainer)]