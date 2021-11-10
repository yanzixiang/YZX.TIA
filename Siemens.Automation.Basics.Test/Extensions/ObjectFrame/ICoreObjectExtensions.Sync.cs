using System.ComponentModel;

using Siemens.Automation.ObjectFrame;
using Siemens.Automation.Basics;
using Siemens.Simatic.PlcLanguages.Utilities;

namespace YZX.Tia.Extensions.ObjectFrame
{
  public static partial class ICoreObjectExtensions
  {
    public static string GetObjectName(this ICoreObject element)
    {
      ICoreAttributes coreAttributes = element.GetAttributeSet(typeof(ICoreAttributes)) as ICoreAttributes;
      if (coreAttributes == null)
        return "";
      return coreAttributes.Name;
    }
    public static ISynchronizeInvoke GetSynchronizer(this ICoreObject coreObject)
    {
      return ((IDlc)coreObject.Context).WorkingContext.DlcManager.LoadByDlcId(DlcIds.Platform.Basics.SynchronizerService);
    }
  }
}
