using System;
using System.Collections.Generic;
using System.Globalization;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.ObjectFrame.Private;

using Reflection;

namespace YZX.Tia.Proxies
{
  public class CoreContextProxy
  {
    CoreContext CoreContext;
    ICoreContext ICoreContext
    {
      get
      {
        return CoreContext;
      }
    }

    IDlc IDlc
    {
      get
      {
        return CoreContext;
      }
    }
    public CoreContextProxy(ICoreContext coreContext)
    {
      CoreContext = coreContext as CoreContext;
    }

    public CultureInfo DefaultLanguage
    {
      get
      {
        return ICoreContext.DefaultLanguage;
      }
    }

    public ICorePersistence Persistence
    {
      get
      {
        return ICoreContext.Persistence;
      }
    }

    public IWorkingContext WorkingContext
    {
      get
      {
        return IDlc.WorkingContext;
      }
    }

    internal IList<ICoreObjectInternal> AllEnvironmentRootObjects
    {
      get
      {
        return Reflector.GetInstancePropertyByName(CoreContext,
          "AllEnvironmentRootObjects",
          ReflectionWays.SystemReflection)
          as IList<ICoreObjectInternal>;
      }
    }

    public DateTime GetTimestamp()
    {
      return ICoreContext.GetTimestamp();
    }
  }
}
