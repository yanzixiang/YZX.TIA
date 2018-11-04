using System.Collections.Generic;

using Siemens.Automation.Basics;

using Reflection;

namespace YZX.Tia.Proxies
{
  public class WorkingContextProxy
  {
    WorkingContext WC;

    public WorkingContextProxy(IWorkingContext wc)
    {
      WC = wc as WorkingContext;
    }

    public List<WorkingContext> ChildWorkingContexts
    {
      get
      {
        return Reflector.GetInstanceFieldByName(WC,
          "m_ChildWorkingContexts",
          ReflectionWays.SystemReflection) as List<WorkingContext>;
      }
    }

    public IWorkingContext SiblingInBusinessLogicForUnload
    {
      get
      {
        return Reflector.GetInstanceFieldByName(WC,
          "m_SiblingInBusinessLogicForUnload",
          ReflectionWays.SystemReflection) as IWorkingContext;
      }
    }

    public IWorkingContext SiblingInViewContext
    {
      get
      {
        return Reflector.GetInstanceFieldByName(WC,
          "m_SiblingInViewContext",
          ReflectionWays.SystemReflection) as IWorkingContext;
      }
    }

    public PlatformServiceContainer PlatformServiceContainer
    {
      get
      {
        return Reflector.GetInstanceFieldByName(WC,
          "m_PlatformServiceContainer",
          ReflectionWays.SystemReflection) as PlatformServiceContainer;
      }
    }
  }
}
