using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Evergreen.Infrastructure.Configuration.GlobalStateObject;
using Photosphere.DependencyInjection;
using Photosphere.DependencyInjection.Attributes;

[assembly: RegisterDependencies(typeof(IConfigSection), Lifetime.PerContainer)]
[assembly: RegisterDependencies(typeof(IInfrastructureService), Lifetime.PerContainer)]