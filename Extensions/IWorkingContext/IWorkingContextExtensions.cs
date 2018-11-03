using System;
using System.ComponentModel;
using System.Threading;
using System.Collections.Generic;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.CommonServices;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.Basics.Synchronizer;
using Siemens.Automation.FrameApplication.MetaData;
using Siemens.Automation.DomainServices.ConnectionService;
using Siemens.Automation.DomainServices.OnlineService;
using Siemens.Automation.DomainServices;


using Siemens.Simatic.PLCMessaging;


using Reflection;

using YZX.Tia.Proxies;

namespace YZX.Tia.Extensions
{
  public  static partial class IWorkingContextExtensions
  {
    public static ISynchronizeInvoke GetSynchronizeInvoke([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<ISynchronizer>("Siemens.Automation.Basics.Synchronizer.ThreadSynchronizer")
        as ISynchronizeInvoke;
    }

    public static ISynchronizer GetSynchronizer([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<ISynchronizer>("Siemens.Automation.Basics.Synchronizer.ThreadSynchronizer");
    }

    public static Thread GetMainThread([NotNull] this IWorkingContext workingContext)
    {
      ISynchronizer syn = workingContext.GetSynchronizer();
      return syn.MainThread;
    }



    internal static IMetaDataManager GetMetaDataManager([NotNull] this IWorkingContext workingContext)
    {
      return GetRequiredDlc<IMetaDataManager>(workingContext, "Siemens.Automation.FrameApplication.MetaData.MetaDataManager");
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
    
    public static ConnectionServiceProvider GetConnectionService([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.DomainServices.ConnectionService") as ConnectionServiceProvider;
    }

    public static OnlineServiceProvider GetOnlineService([NotNull] this IWorkingContext workingContext)
    {
      IOnlineService ios = workingContext.DlcManager.Load("Siemens.Automation.DomainServices.OnlineService") as IOnlineService;

      return ios.ToOnlineServiceProvider();
    }



    public static IOnlineCommandInvoke GetOnlineCommandInvoke([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Automation.DomainServices.OnlineService.OnlineCommandInvoke") as IOnlineCommandInvoke;
    }




    
    public static IIconService GetIconService([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetService("Siemens.Automation.CommonServices.IconService") as IIconService;
    }







  }
}