using System.Reflection;
using System.Runtime.InteropServices;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Photosphere.DependencyInjection;
using Photosphere.DependencyInjection.Attributes;

[assembly: AssemblyTitle("Evergreen.Infrastructure.Configuration.Tests")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Evergreen.Infrastructure.Configuration.Tests")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("170827ab-0b88-4144-9ad1-365552a4fd14")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: RegisterDependencies(typeof(IInfrastructureService), Lifetime.PerContainer)]
[assembly: RegisterDependencies(typeof(IGlobalStateObject), Lifetime.PerContainer)]