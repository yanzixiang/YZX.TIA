using System;
using System.ComponentModel;

using Siemens.Automation.CommonServices;
using Siemens.Automation.ObjectFrame;
#if Tia
using Siemens.Simatic.PlcLanguages.BlockLogic.OpenBlockHandling;
#endif
using Siemens.Automation.ProjectManager;
using Siemens.Automation.ProjectManager.Legacy;
using Siemens.Automation.ProjectManager.Impl.UI;
using Siemens.Automation.ProjectManager.Impl.Tia;

using Reflection;

namespace YZX.Tia.Proxies
{
  public class TiaProjectManagerLegacyHandlerProxy:IProjectManager
  {
    internal TiaProjectManagerLegacyHandler TPMLH;
    public IProjectManager ProjectManager
    {
      get
      {
        return TPMLH as IProjectManager;
      }
    }

    internal TiaProjectManager TiaProjectManager
    {
      get
      {
        return Reflector.GetInstancePropertyByName(TPMLH,
          "ProjectManager",
          ReflectionWays.SystemReflection)
          as TiaProjectManager;
      }
    }

    TiaProjectManagerProxy m_TiaProjectManagerProxy;

    public event CancelEventHandler PreOpening;
    public event EventHandler Opened;
    public event CancelEventHandler Saving;
    public event EventHandler Saved;
    public event EventHandler Closing;
    public event EventHandler Closed;

    public TiaProjectManagerProxy TiaProjectManagerProxy
    {
      get
      {
        if(m_TiaProjectManagerProxy == null)
        {
          m_TiaProjectManagerProxy = new TiaProjectManagerProxy(TiaProjectManager);
        }
        return m_TiaProjectManagerProxy;
      }
    }
    public TiaProjectManagerLegacyHandlerProxy(IProjectManager tpmlh)
    {
      TPMLH = tpmlh as TiaProjectManagerLegacyHandler;
      CurrentProject = ProjectManager.CurrentProject;
    }

    public void SetCurrentProject(ICorePersistence persistence)
    {
      CurrentProject = persistence;
    }
    public void ResetCurrentProject()
    {
      CurrentProject = ProjectManager.CurrentProject;
    }

    public ICorePersistence CurrentProject { get; private set; }

    public string CurrentProjectPath
    {
      get
      {
        return ProjectManager.CurrentProjectPath;
      }
    }

    public ICoreContextHandler CurrentCoreContextHandler
    {
      get
      {
        return ProjectManager.CurrentCoreContextHandler;
      }
    }

    public string ProjectExtension
    {
      get
      {
        return ProjectManager.ProjectExtension;
      }
    }

    public string[] GetSupportedProjectExtensions()
    {
      return ProjectManager.GetSupportedProjectExtensions();
    }

    public string[] GetSupportedLocalSessionExtensions()
    {
      return ProjectManager.GetSupportedLocalSessionExtensions();
    }

    public string[] GetSupportedGlobalLibraryExtensions()
    {
      return ProjectManager.GetSupportedGlobalLibraryExtensions();
    }

    public string[] GetSupportedSystemLibraryExtensions()
    {
      return ProjectManager.GetSupportedSystemLibraryExtensions();
    }

    public string[] GetSupportedZipExtensions()
    {
      return ProjectManager.GetSupportedZipExtensions();
    }

    public string[] GetSupportedLibraryZipExtensions()
    {
      return ProjectManager.GetSupportedLibraryZipExtensions();
    }

    public void RenameProject(string oldDirectory, string newDirectory)
    {
      ProjectManager.RenameProject(oldDirectory, newDirectory);
    }

    public void SaveProject(ICorePersistence persistence)
    {
      ProjectManager.SaveProject(persistence);
    }

    public void SaveProjectAs(ICorePersistence project, string path)
    {
      ProjectManager.SaveProjectAs(project, path);
    }

    public void DeleteProject(string path)
    {
      ProjectManager.DeleteProject(path);
    }

    public Version GetStarterFileVersion(string directoryOrStarterFilePath)
    {
      return ProjectManager.GetStarterFileVersion(directoryOrStarterFilePath);
    }

    public bool AreProjectVersionsCompatible(Version version1, Version version2)
    {
      return ProjectManager.AreProjectVersionsCompatible(version1, version2);
    }

    public string GetArchiveDirectory()
    {
      return ProjectManager.GetArchiveDirectory();
    }

#if Tia
    public ICoreObject FindCPU(string name)
    {
      IControllerTargetLookup QBCTL = new QueryBasedControllerTargetLookup(CurrentCoreContextHandler.CoreContext);
      ICoreObject cpu = QBCTL.FindControllerTargetByName(name);
      return cpu;
    }
#endif
  }
}
