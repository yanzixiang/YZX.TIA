using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;

using Siemens.Automation.DomainServices;
using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.PlcLanguages.Utilities;
using Siemens.Automation.Basics;
using System.ComponentModel;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    public ITagService TagService
    {
      get
      {
        return projectWorkingContext.DlcManager.Load("Siemens.Automation.DomainServices.TagService") as ITagService;
      }
    }

    internal static bool RunInSynchronizer(ISynchronizeInvoke usingSynchronizer, Func<bool> p)
    {
      return true;
    }

    internal static void RunActionInSynchronizer(ISynchronizeInvoke usingSynchronizer, Action action)
    {
    }

    internal static IBLTag RunFuncInSynchronizer(ISynchronizeInvoke usingSynchronizer, Func<ICoreObject, IBLTag> func, ICoreObject tagRef)
    {
      throw new NotImplementedException();
    }
  }
}
