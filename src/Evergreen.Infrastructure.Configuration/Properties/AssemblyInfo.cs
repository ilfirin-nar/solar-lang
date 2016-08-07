using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Photosphere.DependencyInjection;
using Photosphere.DependencyInjection.Attributes;

[assembly: AssemblyTitle("Evergreen.Infrastructure.Configuration")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Evergreen.Infrastructure.Configuration")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("9a8ee86f-09e0-4ee5-984f-8db794ae5e93")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: InternalsVisibleTo("Evergreen.Infrastructure.Configuration.Tests")]

[assembly: RegisterDependencies(typeof(IInfrastructureService), Lifetime.PerContainer)]
[assembly: RegisterDependencies(typeof(IGlobalStateObject), Lifetime.PerContainer)]