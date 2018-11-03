using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Siemens.Automation.Basics;
using Siemens.Simatic.PlcLanguages.BlockLogic;
using Siemens.Simatic.PlcLanguages.Utilities;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static class DlcManagerExtensions
  {
    //internal static void AddLoadedDlcsToList(
    //  IEnumerable<IWorkingContext> workingContexts, 
    //  IList<DlcMetaInfo> dlcMetaInfoList, 
    //  List<IDlc> loadedDlcs)
    //{
    //  Reflector.RunStaticMethodByName(typeof(DlcManager),
    //    "",
    //    ReflectionWays.SystemReflection,
    //    workingContexts, dlcMetaInfoList, loadedDlcs);
    //}

    public static ILibraryVersionService GetLibraryVersionService(this IDlcManager dlcManager)
    {
      return DlcIdExtensions.LoadByDlcId(dlcManager, DlcIds.Iecpl.BlockLogic.LibraryVersionService);
    }
  }
}
