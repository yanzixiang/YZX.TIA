

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.ProjectHandling.PrimaryProject;
using Siemens.Automation.UserProjectManagement.BL.PrimaryProject;

using Reflection;

namespace YZX.Tia.Proxies
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

    internal PrimaryProjectUiWorkingContextManagerProxy(PrimaryProjectUiWorkingContextManager manager)
    {
      this.manager = manager;
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
