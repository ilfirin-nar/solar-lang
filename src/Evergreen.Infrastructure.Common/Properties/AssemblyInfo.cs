using System.Reflection;
using System.Runtime.InteropServices;
using Evergreen.Infrastructure.Common;
using Evergreen.Infrastructure.Common.Interfaces;
using LightInject;
using Photosphere.DependencyInjection;
using Photosphere.DependencyInjection.Attributes;

[assembly: AssemblyTitle("Evergreen.Infrastructure.Common")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Evergreen.Infrastructure.Common")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("cc47ee27-0f13-4cfb-87dd-ac7163bc5375")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: CompositionRootType(typeof(CompositionRoot))]
[assembly: RegisterDependencies(typeof(IService), Lifetime.PerContainer)]