using System;

using Siemens.Automation.Basics;

using Siemens.Simatic.PlcLanguages.LibraryService;
using Siemens.Simatic.PlcLanguages.LibraryService.Meta;
using Siemens.Simatic.PlcLanguages.LibraryService.Tree;
#if TIAV13
#else
using Siemens.Simatic.Lang.PLInternal.BlockInterface;
#endif

namespace YZX.Tia.Dlc
{
  partial class IWorkingContextExtensions
  {
    #if TIAV13
    #else
    public static ILibBaseService GetBaseService(this IWorkingContext workingContext)
    {
      return LibraryServices.GetBaseService(workingContext);
    }
    #endif 

    public static ILibMetaService GetMetaService(this IWorkingContext workingContext)
    {
      return LibraryServices.GetMetaService(workingContext);
    }

    public static ILibTreeService GetTreeService(this IWorkingContext workingContext)
    {
      return LibraryServices.GetTreeService(workingContext);
    }
  }
}
