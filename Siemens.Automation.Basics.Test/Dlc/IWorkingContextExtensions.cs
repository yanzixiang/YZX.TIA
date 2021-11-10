using System;
using System.ComponentModel;
using System.Threading;
using System.Collections.Generic;

using Siemens.Automation.Basics;
using Siemens.Automation.CommonServices;
using Siemens.Automation.Basics.Synchronizer;
using Siemens.Automation.DomainServices.ConnectionService;
using Siemens.Automation.DomainServices;


using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Dlc
{
  public  static partial class IWorkingContextExtensions
  {
    public static ISynchronizeInvoke GetSynchronizeInvoke(this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<ISynchronizer>("Siemens.Automation.Basics.Synchronizer.ThreadSynchronizer")
        as ISynchronizeInvoke;
    }

    public static ISynchronizer GetSynchronizer(this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<ISynchronizer>("Siemens.Automation.Basics.Synchronizer.ThreadSynchronizer");
    }

    public static Thread GetMainThread(this IWorkingContext workingContext)
    {
      ISynchronizer syn = workingContext.GetSynchronizer();
      return syn.MainThread;
    }

    public static IEnumerable<WorkingContext> GetTopWorkingContexts()
    {
      return Reflector.RunStaticMethodByName(typeof(WorkingContext),
        "GetTopWorkingContexts",
        ReflectionWays.SystemReflection) as IEnumerable<WorkingContext>;
    }

    public static IWorkingContext GetRootWorkingContext(this IWorkingContext currentContext)
    {
      for (IWorkingContext parentWorkingContext = currentContext.ParentWorkingContext; parentWorkingContext != null; parentWorkingContext = currentContext.ParentWorkingContext)
        currentContext = parentWorkingContext;
      return currentContext;
    }

    public static IWorkingContext GetCommonWorkingContext(
      this IWorkingContext workingContext1,
      IWorkingContext workingContext2)
    {
      return Reflector.RunStaticMethodByName(typeof(WorkingContext),
        "GetCommonWorkingContext",
        ReflectionWays.SystemReflection,
        workingContext1,
        workingContext2) as IWorkingContext;
    }
    
    public static ConnectionServiceProvider GetConnectionService(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.DomainServices.ConnectionService") as ConnectionServiceProvider;
    }

    public static IOnlineCommandInvoke GetOnlineCommandInvoke(this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.DomainServices.OnlineService.OnlineCommandInvoke") as IOnlineCommandInvoke;
    }
    
    public static IIconService GetIconService(this IWorkingContext workingContext)
    {
      return workingContext.GetService("Siemens.Automation.CommonServices.IconService") as IIconService;
    }
  }
}