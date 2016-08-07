using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Evergreen.Infrastructure.Configuration.GlobalStateObject;
using Photosphere.DependencyInjection;
using Photosphere.DependencyInjection.Attributes;

[assembly: AssemblyTitle("Evergreen.Infrastructure.Logging")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Evergreen.Infrastructure.Logging")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("5bedec95-9655-44b9-b5b6-4327c226de0d")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: InternalsVisibleTo("Evergreen.Infrastructure.Logging.Tests")]

[assembly: RegisterDependencies(typeof(IConfigSection), Lifetime.PerContainer)]
[assembly: RegisterDependencies(typeof(IInfrastructureService), Lifetime.PerContainer)]