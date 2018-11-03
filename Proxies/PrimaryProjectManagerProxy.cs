using System;

using Siemens.Automation.ProjectManager;
using Siemens.Automation.UserProjectManagement.BL.PrimaryProject;

namespace YZX.Tia.Proxies
{
  public class PrimaryProjectManagerProxy
  {
    internal IPrimaryProjectManager m_PrimaryProjectManager;

    internal PrimaryProjectManagerProxy(IPrimaryProjectManager m_PrimaryProjectManager)
    {
      this.m_PrimaryProjectManager = m_PrimaryProjectManager;

      m_PrimaryProjectManager.ProjectOpened += M_PrimaryProjectManager_ProjectOpened;
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

  }
}
