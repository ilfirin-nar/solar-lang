using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Evergreen.Infrastructure.Common.Interfaces.DomainLayer;
using Photosphere.DependencyInjection;
using Photosphere.DependencyInjection.Attributes;

[assembly: AssemblyTitle("Evergreen.Domain.Analysis.Lexical")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Evergreen.Domain.Analysis.Lexical")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("da10b67c-de09-4d20-82df-392554464541")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: InternalsVisibleTo("Evergreen.Domain.Analysis.Lexical.Tests")]

[assembly: RegisterDependencies(typeof(IEntityBehaviorService), Lifetime.PerContainer)]
[assembly: RegisterDependencies(typeof(IDomainService), Lifetime.PerContainer)]