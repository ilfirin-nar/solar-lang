using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Evergreen.Infrastructure.Common.Interfaces.FrontendLayer;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Photosphere.DependencyInjection;
using Photosphere.DependencyInjection.Attributes;

[assembly: AssemblyTitle("Evergreen.Frontend.Compiler")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Evergreen.Frontend.Compiler")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("53c0c8e9-79fe-46ab-87ef-ed7fadd30f34")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: InternalsVisibleTo("Evergreen.Frontend.Compiler.Tests")]

[assembly: RegisterDependencies(typeof(IInfrastructureService), Lifetime.PerContainer)]
[assembly: RegisterDependencies(typeof(IFrontendService), Lifetime.PerContainer)]