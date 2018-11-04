using System.ComponentModel;

using Siemens.Automation.ObjectFrame;
using Siemens.Automation.Basics;
using Siemens.Simatic.PlcLanguages.Utilities;

namespace YZX.Tia.Extensions
{
  partial class ICoreObjectExtensions
  {
    public static ISynchronizeInvoke GetSynchronizer(this ICoreObject coreObject)
    {
      return ((IDlc)coreObject.Context).WorkingContext.DlcManager.LoadByDlcId(DlcIds.Platform.Basics.SynchronizerService);
    }
  }
}
