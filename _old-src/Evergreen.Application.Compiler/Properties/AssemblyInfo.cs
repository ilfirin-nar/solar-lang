using System.Reflection;
using System.Runtime.InteropServices;
using Evergreen.Infrastructure.Common.Interfaces.ApplicationLayer;
using Photosphere.DependencyInjection;
using Photosphere.DependencyInjection.Attributes;

[assembly: AssemblyTitle("Evergreen.Application.Compiler")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Evergreen.Application.Compiler")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("d0f8b16d-4d00-49e0-af26-d826c5b702a3")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: RegisterDependencies(typeof(IApplicationService), Lifetime.PerContainer)]