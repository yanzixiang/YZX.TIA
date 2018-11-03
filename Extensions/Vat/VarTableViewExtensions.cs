using JetBrains.Annotations;

using Siemens.Automation.Basics;
using Siemens.Simatic.PlcLanguages.VatService.Exceptions;
using Siemens.Simatic.PlcLanguages.VatService.Views;

namespace YZX.Tia.Extensions
{
  public static class VarTableViewExtensions
  {
    internal static IWorkingContext GetViewContextTest([NotNull] this VarTableView IvarTableView)
    {
      VarTableView varTableView = IvarTableView as VarTableView;
      if (varTableView.DomainGrid == null)
        throw new VatServiceInvalidOperationException("The project view context is not available for the given view instance.");
      IWorkingContext workingContext = varTableView.DomainGrid.ViewFrame.WorkingContext;
      if (workingContext.WorkingContextEnvironment != WorkingContextEnvironment.Project || !workingContext.IsViewContext || !(workingContext.Scope == "Project"))
        workingContext = varTableView.DomainGrid.GetService(typeof(IWorkingContext)) as IWorkingContext;
      if (workingContext.WorkingContextEnvironment != WorkingContextEnvironment.Project || !workingContext.IsViewContext || !(workingContext.Scope == "Project"))
        throw new VatServiceInvalidOperationException("The project view context is not available for the given view instance.");
      return workingContext;
    }
  }
}
