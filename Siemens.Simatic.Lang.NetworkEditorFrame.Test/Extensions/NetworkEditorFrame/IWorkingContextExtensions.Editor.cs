using System;

using Siemens.Automation.Basics;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Starter;

using YZX.Tia.Dlc;

namespace YZX.Tia.Extensions.NetworkEditorFrame
{
  public static class IWorkingContextExtensions
  {
    public static IEditorStarter GetEditorStarterFacadeDlc(this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<EditorStarterFacadeDlc>("Siemens.Simatic.PlcLanguages.BlockEditorFrame.EditorStarterFacade");
    }
  }
}
