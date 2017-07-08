using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Evergreen.Infrastructure.Common.Interfaces;
using Evergreen.Infrastructure.Common.Interfaces.DomainLayer;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Photosphere.DependencyInjection;
using Photosphere.DependencyInjection.Attributes;

[assembly: AssemblyTitle("Evergreen.Domain.Grammar")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Evergreen.Domain.Grammar")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("1df046e6-3083-4ba2-b38a-138fba765ae2")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: InternalsVisibleTo("Evergreen.Domain.Grammar.Tests")]

[assembly: RegisterDependencies(typeof(IEntityBehaviorService), Lifetime.PerContainer)]
[assembly: RegisterDependencies(typeof(IDomainService), Lifetime.PerContainer)]
[assembly: RegisterDependencies(typeof(IDirectory), Lifetime.PerContainer)]
[assembly: RegisterDependencies(typeof(IGlobalStateObject), Lifetime.PerContainer)]
