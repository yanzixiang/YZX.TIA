using System;
using System.ComponentModel;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.GraphEditor.Frame;
using Siemens.Simatic.PlcLanguages.NetworkEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Starter;
using Siemens.Simatic.PlcLanguages.PLInterface;

using YZX.Tia.Proxies;

using Reflection;

namespace YZX.Tia.Extensions
{
  partial class ICoreObjectExtensions
  {
    public static BlockEditorControlBase GetPLView(this ICoreObject block,
      BlockEditorLogicBase logic,
      IWorkingContext ViewWorkingContext = null,
      LanguageServiceContainer serviceContainer = null,
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
      return TiaStarter.RunInSynchronizer(UsingSynchronizer,
        () =>
        {
          PLBlockEditorControlElement pl = new PLBlockEditorControlElement();
          if (ViewWorkingContext == null)
          {
            IWorkingContext iwc = block.GetWorkingContext();
            pl.Attach(iwc);
          }
          else
          {
            pl.Attach(ViewWorkingContext);
          }
          EditorPayload ep = new EditorPayload(block, ViewWorkingContext, serviceContainer);
          pl.SetPayload(ep);
          pl.SetDomainLogic(logic);
          logic.SetView(pl);
          logic.InitializationFinished();
          return pl;
        }) as BlockEditorControlBase;
    }

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
      return TiaStarter.RunInSynchronizer(UsingSynchronizer,
        () =>
        {
          GraphBlockEditorControl pl = new GraphBlockEditorControl();
          IWorkingContext iwc = block.GetWorkingContext();
          pl.Attach(iwc);
          BlockEditorLogicBase logic = block.GetGraphBlockEditorLogic();
          pl.SetDomainLogic(logic);
          pl.SetPayload(block);
          pl.InitializationFinished();
          pl.CreateVisuals();
          return pl;
        }) as BlockEditorControlBase;

    }
  }
}
