using System.ComponentModel;
using System.Collections.Generic;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static partial class ICoreObjectExtensions
  {
    public static WorkingContext FindWorkingContext(this ICoreObject ico)
    {
      List<ICoreObject> icoL = new List<ICoreObject>() { ico };
      return WorkingContext.FindWorkingContextForGivenObjects(icoL) as WorkingContext;
    }
  }
}
