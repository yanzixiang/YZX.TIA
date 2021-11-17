using System;

using Siemens.Automation.Basics;
using Siemens.Automation.ProjectManager;
using Siemens.Automation.UserProjectManagement.BL.PrimaryProject;
using Siemens.Automation.FrameApplication.ProjectHandling.PrimaryProject;

using YZX.Tia.Proxies.ProjectManager;

namespace YZX.Tia.Proxies
{
  public class PrimaryProjectManagerProxy
  {
    internal IPrimaryProjectManager m_PrimaryProjectManager;

    internal IPrimaryProjectUiWorkingContextManager IPrimaryProjectUiWorkingContextManager
    {
      get
      {
        return m_PrimaryProjectManager as IPrimaryProjectUiWorkingContextManager;
      }
    }

    public PrimaryProjectManagerProxy Instance { get; private set; }

    internal PrimaryProjectManagerProxy(IPrimaryProjectManager m_PrimaryProjectManager)
    {
      this.m_PrimaryProjectManager = m_PrimaryProjectManager;

      m_PrimaryProjectManager.ProjectOpened += M_PrimaryProjectManager_ProjectOpened;
      Instance = this;
    }

    private void M_PrimaryProjectManager_ProjectOpened(object sender, TiaPrimaryProjectOpenedEventArgs e)
    {
      this.ProjectOpened?.Invoke(sender,e);
    }

    public TiaProjectProxy PrimaryProject
    {
      get
      {
        return new TiaProjectProxy(m_PrimaryProjectManager.PrimaryProject);
      }
    }

    public IWorkingContext UiPersistenceWorkingContext
    {
      get
      {
        return IPrimaryProjectUiWorkingContextManager.UiPersistenceWorkingContext;
      }
    }

    public event EventHandler<EventArgs> ProjectOpened;

    public bool OpenProjectReadOnly(string path, out object projectO, bool silent = false)
    {
      OpenProjectParams parameters = new OpenProjectParams(path);
      parameters.Access = TiaProjectAccess.ReadOnly;
      parameters.Silent = silent;
      ITiaProject project;
      bool returnB = m_PrimaryProjectManager.OpenProject(parameters, out project);
      if (project != null)
      {
        projectO = new TiaProjectProxy(project);
      }
      else
      {
        projectO = null;
      }
      return returnB;
    }

    public bool OpenProjectReadWrite(string path, out object projectO,bool silent = false)
    {
      OpenProjectParams parameters = new OpenProjectParams(path);
      parameters.Access = TiaProjectAccess.ReadWrite;
      parameters.Silent = silent;
      ITiaProject project;
      bool returnB;
      try
      {
        returnB = m_PrimaryProjectManager.OpenProject(parameters, out project);

        if (project != null)
        {
          projectO = new TiaProjectProxy(project);
        }
        else
        {
          projectO = null;
        }
        return returnB;
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex);
        projectO = null;
        return false;
      }
      
    }

  }
}
