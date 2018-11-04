using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Starter;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static IEditorStarter GetEditorStarterFacadeDlc([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<EditorStarterFacadeDlc>("Siemens.Simatic.PlcLanguages.BlockEditorFrame.EditorStarterFacade");
    }
  }
}
