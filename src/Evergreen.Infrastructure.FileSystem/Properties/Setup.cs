using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Photosphere.DependencyInjection;
using Photosphere.DependencyInjection.Attributes;

[assembly: RegisterDependencies(typeof(IInfrastructureService), Lifetime.PerContainer)]