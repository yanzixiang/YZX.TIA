using System;
using System.ComponentModel;

using Siemens.Automation.Basics.Synchronizer;
using Siemens.Automation.DomainServices;

using YZX.Tia.Extensions;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    public ISynchronizer Synchronizer
    {
      get
      {
        return m_ViewApplicationContext.GetRequiredDlc<ISynchronizer>("Siemens.Automation.Basics.Synchronizer.ThreadSynchronizer");
      }
    }

    public ISynchronizeInvoke SynchronizeInvoke
    {
      get
      {
        return Synchronizer as ISynchronizeInvoke;
      }
    }

    public static object RunInSynchronizer(ISynchronizeInvoke Synchronizer, Delegate method, params object[] args)
    {
      return UnifiedSynchronizerAccess.Invoke(Synchronizer, method, args).InvokeResult;
    }
  }
}
