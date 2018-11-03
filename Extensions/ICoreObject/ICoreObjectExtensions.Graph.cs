using System;
using System.ComponentModel;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.GraphEditor.Frame;

using Reflection;

namespace YZX.Tia.Extensions
{
  partial class ICoreObjectExtensions
  {
    private delegate BlockEditorLogicBase GetGraphBlockEditorLogicDelegate(
      ICoreObject block,
      IWorkingContext ViewWorkingContext = null,
      ISynchronizeInvoke synchronizer = null);
    public static BlockEditorLogicBase GetGraphBlockEditorLogic(this ICoreObject block,
      IWorkingContext ViewWorkingContext = null,
      ISynchronizeInvoke synchronizer = null)
    {
      ISynchronizeInvoke UsingSynchronizer;
      if (synchronizer == null)
      {
        UsingSynchronizer = block.GetSynchronizer();
      }
      else
      {
        UsingSynchronizer = synchronizer;
      }
      if (UsingSynchronizer.InvokeRequired)
        return UnifiedSynchronizerAccess.Invoke(UsingSynchronizer,
          new GetGraphBlockEditorLogicDelegate(GetGraphBlockEditorLogic), new object[3]
        {
          block,
          ViewWorkingContext,
          synchronizer
        }).InvokeResult as BlockEditorLogicBase;


      GraphBlockEditorLogic pl = new GraphBlockEditorLogic();
      if (ViewWorkingContext == null)
      {
        IWorkingContext iwc = block.GetWorkingContext();
        pl.Attach(iwc);
      }
      else
      {
        pl.Attach(ViewWorkingContext);
      }

      pl.PostAttach();
      try
      {
        pl.SetPayload(block);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
      return pl;

    }

    private delegate BlockEditorControlBase GetGraphViewDelegate(
      ICoreObject block,
      IWorkingContext ViewWorkingContext = null,
      ISynchronizeInvoke synchronizer = null);

    public static BlockEditorControlBase GetGraphView(this ICoreObject block,
      IWorkingContext ViewWorkingContext = null,
      ISynchronizeInvoke synchronizer = null)
    {
      ISynchronizeInvoke UsingSynchronizer;
      if (synchronizer == null)
      {
        UsingSynchronizer = block.GetSynchronizer();
      }
      else
      {
        UsingSynchronizer = synchronizer;
      }
      if (UsingSynchronizer.InvokeRequired)
        return UnifiedSynchronizerAccess.Invoke(UsingSynchronizer,
          new GetGraphViewDelegate(GetGraphView), new object[3]
        {
          block,
          ViewWorkingContext,
          synchronizer
        }).InvokeResult as BlockEditorControlBase;

      GraphBlockEditorControl pl = new GraphBlockEditorControl();
      IWorkingContext iwc = block.GetWorkingContext();
      pl.Attach(iwc);
      BlockEditorLogicBase logic = block.GetGraphBlockEditorLogic();
      pl.SetDomainLogic(logic);
      pl.SetPayload(block);
      pl.InitializationFinished();
      pl.CreateVisuals();
      return pl;

    }
  }
}