using System;

using Siemens.Automation.Basics;
using Siemens.Automation.CommonServices;
using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.PlcLanguages.BlockLogic.OpenBlockHandling;
using Siemens.Automation.ProjectManager.Impl.UI;

using YZX.Tia.Extensions;
using YZX.Tia.Proxies;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    //static CmdHandlerHelper CHH;
    public static ICoreContextHandler cch;

    IProjectManager m_ProjectManager;
    public IProjectManager ProjectManager
    {
      get
      {
        if (m_ProjectManager == null)
        {
          m_ProjectManager = m_ViewApplicationContext.GetProjectManager();
        }
        return m_ProjectManager;
      }
      set
      {
        m_ProjectManager = value;
      }
    }

    private TiaProjectManagerLegacyHandlerProxy m_ProjectManagerProxy;

    public TiaProjectManagerLegacyHandlerProxy ProjectManagerProxy
    {
      get
      {
        if(m_ProjectManagerProxy == null)
        {
          m_ProjectManagerProxy = new TiaProjectManagerLegacyHandlerProxy(ProjectManager);
        }
        return m_ProjectManagerProxy;
      }
    }

    #region projectWorkingContext Event

    private void ProjectWorkingContext_ServiceLoadedEvent(object sender, ServiceChangedEventArgs e)
    {
      Console.WriteLine("ProjectWorkingContext_ServiceLoadedEvent {0}", e.ServiceCreatorType, e.ServiceType);
    }

    private void ProjectWorkingContext_ServiceAddedEvent(object sender, ServiceChangedEventArgs e)
    {
      Console.WriteLine("ProjectWorkingContext_ServiceAddedEvent {0}", e.ServiceCreatorType, e.ServiceType);
    }

    private void ProjectWorkingContext_WorkingContextChildCreatedEvent(object sender, ChildCreatedEventArgs e)
    {
      Console.WriteLine("ProjectWorkingContext_WorkingContextChildCreatedEvent {0}", e.ChildContext);
    }
    #endregion


    #region projectWorkingContext Event
    private void ProjectViewWorkingContext_WorkingContextChildCreatedEvent(object sender, ChildCreatedEventArgs e)
    {
      Console.WriteLine("ProjectViewWorkingContext_WorkingContextChildCreatedEvent {0}", e.ChildContext);
    }

    private void ProjectViewWorkingContext_ServiceLoadedEvent(object sender, ServiceChangedEventArgs e)
    {
      Console.WriteLine("ProjectViewWorkingContext_ServiceLoadedEvent {0}", e.ServiceCreatorType, e.ServiceType);
    }

    private void ProjectViewWorkingContext_ServiceAddedEvent(object sender, ServiceChangedEventArgs e)
    {
      Console.WriteLine("ProjectViewWorkingContext_ServiceAddedEvent {0}", e.ServiceCreatorType, e.ServiceType);
    }

    #endregion

  }
}
