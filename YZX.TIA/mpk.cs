using System.Collections.Generic;

using Siemens.Automation.Utilities.PackagingService;
using Siemens.Automation.Archiving.Private;
using Siemens.Automation.FrameApplication.Releasemanagement;
using Siemens.Automation.FrameApplication.ContextNavigator;

namespace YZX.Tia
{
  public class mpk
  {
    public static IList<string> GetNames(string path)
    {
      PackagingImplementationBase pib = new PackagingImplementationBase(path, null, null);
      return pib.GetFiles();
    }

    public static void unpack(string path)
    {
      PackagingImplementationBase pib = new PackagingImplementationBase(path, null, null);
      IList<string> files = pib.GetFiles();
    }
  }
}
