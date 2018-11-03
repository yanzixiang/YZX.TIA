using Siemens.Automation.Basics;
using Siemens.Simatic.FPlus.FEngine.Interface.Utilities;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static IWorkingContext GetProjectWorkingContext(this IWorkingContext inputWorkingContext)
    {
      return WorkingContextFinder.GetProjectWorkingContext(inputWorkingContext);
    }
  }
}
