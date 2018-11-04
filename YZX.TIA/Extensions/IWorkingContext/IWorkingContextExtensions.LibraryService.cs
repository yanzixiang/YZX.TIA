using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;

using Siemens.Simatic.PlcLanguages.LibraryService;
using Siemens.Simatic.PlcLanguages.LibraryService.Meta;
using Siemens.Simatic.PlcLanguages.LibraryService.Tree;
using Siemens.Simatic.Lang.PLInternal.BlockInterface;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static ILibBaseService GetBaseService(this IWorkingContext workingContext)
    {
      return LibraryServices.GetBaseService(workingContext);
    }

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
