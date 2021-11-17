using System;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;

using YZX.Tia.Proxies;
using YZX.Tia.Extensions;
using YZX.Tia.Proxies.FrameApplication;
using YZX.Tia.Extensions.FrameApplication;
using YZX.Tia.Proxies.Dlc;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    public static WorkingContext m_BusinessLogicApplicationContext;
    public static WorkingContext m_ViewApplicationContext;
    public static WorkingContext PersistenceWorkingContext;

    public IWorkingContext projectWorkingContext;
    public IWorkingContext projectViewWorkingContext;
    public IWorkingContext projectPersistenceWorkingContext;

    public PrimaryProjectUiWorkingContextManagerProxy PrimaryProjectUiWorkingContextManagerProxy;
    public PrimaryProjectManagerProxy PrimaryProjectManagerProxy;
    public IUIContextHolder UIContextHolder;
    public IWorkingContext ProjectUIContext;

    private void CreateWorkingContextHierarchy()
    {
      m_BusinessLogicApplicationContext = new WorkingContext(false,
        WorkingContextEnvironment.Application,
        AppId,
        "Project"
      );

      m_BusinessLogicApplicationContext.ConstructServiceEvent += m_BusinessLogicApplicationContext_ConstructServiceEvent;
      m_BusinessLogicApplicationContext.ServiceLoadedEvent += m_BusinessLogicApplicationContext_ServiceLoadedEvent;
      m_BusinessLogicApplicationContext.ServiceAddedEvent += m_BusinessLogicApplicationContext_ServiceAddedEvent;
      m_BusinessLogicApplicationContext.WorkingContextChildCreatedEvent += M_BusinessLogicApplicationContext_WorkingContextChildCreatedEvent;

      m_BusinessLogicApplicationContext.AutoLoadDlcs();

      WorkingContextProxy wcp = new WorkingContextProxy(m_BusinessLogicApplicationContext);
      PlatformServiceContainer psc = wcp.PlatformServiceContainer;

      m_ViewApplicationContext = new WorkingContext(true,
        WorkingContextEnvironment.Application,
        AppId,
        "Project"
      );
      m_ViewApplicationContext.SiblingInBusinessLogicContext = m_BusinessLogicApplicationContext;

      m_ViewApplicationContext.ConstructServiceEvent += M_ViewApplicationContext_ConstructServiceEvent;
      m_ViewApplicationContext.ServiceLoadedEvent += M_ViewApplicationContext_ServiceLoadedEvent;
      m_ViewApplicationContext.ServiceAddedEvent += M_ViewApplicationContext_ServiceAddedEvent;
      m_ViewApplicationContext.AutoLoadDlcs();



      PersistenceWorkingContext = new WorkingContext(m_ViewApplicationContext,
        WorkingContextEnvironment.Persistence);

      PrimaryProjectUiWorkingContextManagerProxy = m_ViewApplicationContext.GetPrimaryProjectUiWorkingContextManagerProxy();
      PrimaryProjectManagerProxy =
        PrimaryProjectUiWorkingContextManagerProxy.PrimaryProjectManager;

      
    }

    #region m_ViewApplicationContext Event

    private void M_ViewApplicationContext_ServiceAddedEvent(object sender, ServiceChangedEventArgs e)
    {
      Console.WriteLine("M_ViewApplicationContext_ServiceAddedEvent {0} -> {1}", e.ServiceCreatorType, e.ServiceType);
    }
    private void M_ViewApplicationContext_ConstructServiceEvent(object sender, ConstructServiceEventArgs e)
    {
      Console.WriteLine("M_ViewApplicationContext_ConstructServiceEvent {0} -> {1}", e.ServiceCreatorType, e.ServiceInstance);
    }

    private void M_ViewApplicationContext_ServiceLoadedEvent(object sender,
      ServiceChangedEventArgs e)
    {
      Console.WriteLine("M_ViewApplicationContext_ServiceLoadedEvent {0} -> {1}", e.ServiceCreatorType, e.ServiceType);
    }
    #endregion

    #region m_BusinessLogicApplicationContext Event

    private void m_BusinessLogicApplicationContext_ServiceAddedEvent(object sender, ServiceChangedEventArgs e)
    {
      Console.WriteLine("m_BusinessLogicApplicationContext_ServiceAddedEvent {0} -> {1}", e.ServiceCreatorType, e.ServiceType);
    }
    private void m_BusinessLogicApplicationContext_ConstructServiceEvent(object sender, ConstructServiceEventArgs e)
    {
      Console.WriteLine("m_BusinessLogicApplicationContext_ConstructServiceEvent {0} -> {1}", e.ServiceCreatorType, e.ServiceInstance);
    }

    private void m_BusinessLogicApplicationContext_ServiceLoadedEvent(object sender,
      ServiceChangedEventArgs e)
    {
      Console.WriteLine("m_BusinessLogicApplicationContext_ServiceLoadedEvent {0} -> {1}", e.ServiceCreatorType, e.ServiceType);
    }

    private void M_BusinessLogicApplicationContext_WorkingContextChildCreatedEvent(object sender, ChildCreatedEventArgs e)
    {
      Console.WriteLine("M_BusinessLogicApplicationContext_WorkingContextChildCreatedEvent {0}", e.ChildContext);
    }
    #endregion
  }
}
