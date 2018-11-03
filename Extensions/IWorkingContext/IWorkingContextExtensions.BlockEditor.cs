using System;

using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Simatic.PlcLanguages.PLInterface;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Starter;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {

    public static BlockEditorStarter GetBlockEditorStarter([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<BlockEditorStarter>("Siemens.Simatic.PlcLanguages.PLInterface.BlockEditorStarter");
    }

    public static CodeBlockEditorStarterDlcBase GetNetworkEditorStarterDlc([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetRequiredDlc<CodeBlockEditorStarterDlcBase>("Siemens.Simatic.PlcLanguages.NetworkEditorFrame.EditorStarter");
    }

    public static object GetBlockEditorController([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.DlcManager.Load("Siemens.Simatic.PlcLanguages.BlockEditorFrame.EditorController");
    }
  }
}
