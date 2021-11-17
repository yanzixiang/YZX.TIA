using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Basics;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.OnlineService;
using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Extensions.Lifelist
{
  public static class LifelistActivatorExtensions
  {
    public static LifeListRootObjectWrapper GetLifeListRootObjectWrapper(this LifelistActivator activator)
    {
      return Reflector.GetInstanceFieldByName(activator, "m_RootObjectWrapper",
        ReflectionWays.SystemReflection) as LifeListRootObjectWrapper;
    }

    public static IWorkingContext GetPersistanceViewContext(this LifelistActivator activator)
    {
      return Reflector.GetInstanceFieldByName(activator, "m_PersistanceViewContext", 
        ReflectionWays.SystemReflection) as IWorkingContext;
    }

    public static IWorkingContext GetProjectViewContext(this LifelistActivator activator)
    {
      return Reflector.GetInstanceFieldByName(activator, "m_ProjectViewContext",
        ReflectionWays.SystemReflection) as IWorkingContext;
    }
  }
}
