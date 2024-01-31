using Autofac;
using DeviantPasswordManager.Core.Interfaces;
using DeviantPasswordManager.Core.Services;

namespace DeviantPasswordManager.Core;

/// <summary>
/// An Autofac module that is responsible for wiring up services defined in the Core project.
/// </summary>
public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<DeleteProjectService>()
      .As<IDeleteProjectService>().InstancePerLifetimeScope();
    
    builder.RegisterType<PasswordService>()
      .As<IPasswordService>().InstancePerLifetimeScope();

  }
}
