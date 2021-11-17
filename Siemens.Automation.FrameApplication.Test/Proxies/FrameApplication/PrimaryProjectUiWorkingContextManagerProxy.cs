using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.ProjectHandling.PrimaryProject;
using Siemens.Automation.UserProjectManagement.BL.PrimaryProject;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class PrimaryProjectUiWorkingContextManagerProxy
  {
    internal PrimaryProjectUiWorkingContextManager manager;
    internal IPrimaryProjectUiWorkingContextManager IManager
    {
      get
      {
        return manager as IPrimaryProjectUiWorkingContextManager;
      }
    }

    public PrimaryProjectManagerProxy PrimaryProjectManager
    {
      get
      {
        IPrimaryProjectManager m_PrimaryProjectManager =
         Reflector.GetInstanceFieldByName(manager, "m_PrimaryProjectManager",
         ReflectionWays.SystemReflection)
         as IPrimaryProjectManager;
        return new PrimaryProjectManagerProxy(m_PrimaryProjectManager);
      }
    }

    public IUIContextHolder IUIContextHolder
    {
      get
      {
        return Reflector.GetInstanceFieldByName(manager, 
          "m_PrimaryProjectUiContextHolder", 
          ReflectionWays.SystemReflection) 
          as IUIContextHolder;
      }
    }

    public static PrimaryProjectUiWorkingContextManagerProxy Instance { get; private set; }

    internal PrimaryProjectUiWorkingContextManagerProxy(
      PrimaryProjectUiWorkingContextManager manager)
    {
      this.manager = manager;
      Instance = this;
    }

    public IWorkingContext UiPersistenceWorkingContext
    {
      get
      {
        return IManager.UiPersistenceWorkingContext;
      }
    }
  }
}
