﻿using System.Reflection;
using System.Runtime.InteropServices;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Photosphere.DependencyInjection;
using Photosphere.DependencyInjection.Attributes;

[assembly: AssemblyTitle("Evergreen.Infrastructure.Logging.Tests")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Evergreen.Infrastructure.Logging.Tests")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("838daae7-094e-44a9-b851-0beb69bcc9b0")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: RegisterDependencies(typeof(IGlobalStateObject), Lifetime.PerContainer)]
[assembly: RegisterDependencies(typeof(IInfrastructureService), Lifetime.PerContainer)]