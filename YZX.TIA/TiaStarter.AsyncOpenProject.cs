using Microsoft.Practices.Unity;

using System;

using Siemens.Automation.Basics;
using Siemens.Automation.CommonServices;

using YZX.Tia.Extensions;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    public void AsyncOpenProject(string path)
    {
      SynchronizeInvoke.Invoke((Action)(() => this.OpenProjectSynchronized(path)), null);
    }

    private void OpenProjectSynchronized(string projectLocation)
    {
      try
      {
        ICommandProcessor commandProcessor = IDlcManagerExtension.Get<ICommandProcessor>(UnityContainerExtensions.Resolve<IDlcManager>(Ioc.Container, Array.Empty<ResolverOverride>()), null);
        string id = "ProjectHandler.OpenProject";
        ICommand command = commandProcessor.CreateCommand(id);
        command.Arguments["ProjectPath"] = projectLocation;
        ICommand cmd = command;
        commandProcessor.Execute(cmd);
      }
      catch (Exception ex)
      {
        //this.Log.Exception(ex, "OpenProjectSynchronized");
        throw;
      }
    }
  }
}
