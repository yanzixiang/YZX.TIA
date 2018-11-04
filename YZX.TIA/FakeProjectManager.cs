using System;
using System.ComponentModel;
using Siemens.Automation.CommonServices;
using Siemens.Automation.ObjectFrame;

namespace YZX.Tia
{
  public class FakeProjectManager : IProjectManager
  {
    private IProjectManager projectManager;

    public FakeProjectManager(IProjectManager projectManager)
    {
      this.projectManager = projectManager;
    }

    public ICoreContextHandler CurrentCoreContextHandler
    {
      get
      {
        return projectManager.CurrentCoreContextHandler;
      }
    }

    public ICorePersistence CurrentProject
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public string CurrentProjectPath
    {
      get
      {
        return projectManager.CurrentProjectPath;
      }
    }

    public string ProjectExtension
    {
      get
      {
        return projectManager.ProjectExtension;
      }
    }

    public event EventHandler Closed;
    public event EventHandler Closing;
    public event EventHandler Opened;
    public event CancelEventHandler PreOpening;
    public event EventHandler Saved;
    public event CancelEventHandler Saving;

    public bool AreProjectVersionsCompatible(Version version1, Version version2)
    {
      throw new NotImplementedException();
    }

    public void DeleteProject(string path)
    {
      throw new NotImplementedException();
    }

    public string GetArchiveDirectory()
    {
      throw new NotImplementedException();
    }

    public Version GetStarterFileVersion(string directoryOrStarterFilePath)
    {
      throw new NotImplementedException();
    }

    public string[] GetSupportedGlobalLibraryExtensions()
    {
      throw new NotImplementedException();
    }

    public string[] GetSupportedLibraryZipExtensions()
    {
      throw new NotImplementedException();
    }

    public string[] GetSupportedLocalSessionExtensions()
    {
      throw new NotImplementedException();
    }

    public string[] GetSupportedProjectExtensions()
    {
      throw new NotImplementedException();
    }

    public string[] GetSupportedSystemLibraryExtensions()
    {
      throw new NotImplementedException();
    }

    public string[] GetSupportedZipExtensions()
    {
      throw new NotImplementedException();
    }

    public void RenameProject(string oldDirectory, string newDirectory)
    {
      throw new NotImplementedException();
    }

    public void SaveProject(ICorePersistence persistence)
    {
      throw new NotImplementedException();
    }

    public void SaveProjectAs(ICorePersistence project, string path)
    {
      throw new NotImplementedException();
    }
  }
}
