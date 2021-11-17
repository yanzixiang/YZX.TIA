using System;
using System.ComponentModel;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Starter;
using Siemens.Simatic.PlcLanguages.PLInterface;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Online;
using Siemens.Simatic.PlcLanguages.NetworkEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.NetworkEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.Utilities.Toolbox;
using Siemens.Simatic.Lang.Model.Idents;
using Siemens.Simatic.Lang.Model.Blocks;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

using YZX.Tia.Extensions.ObjectFrame;

namespace YZX.Tia.Extensions.NetworkEditorFrame
{
  public static partial class ICoreObjectExtensions
  {
    private delegate BlockEditorLogicBase GetPLBlockEditorLogicDelegate(
      ICoreObject block,
      IWorkingContext ViewWorkingContext = null,
      LanguageServiceContainer serviceContainer = null,
      ISynchronizeInvoke synchronizer = null
      );
    public static BlockEditorLogicBase GetPLBlockEditorLogic(this ICoreObject block,
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
      if (UsingSynchronizer.InvokeRequired)
        return UnifiedSynchronizerAccess.Invoke(UsingSynchronizer,
          new GetPLBlockEditorLogicDelegate(GetPLBlockEditorLogic), new object[4]
        {
          block,
          ViewWorkingContext,
          serviceContainer,
          synchronizer
        }).InvokeResult as BlockEditorLogicBase;

      PLBlockEditorLogic pl = new PLBlockEditorLogic(EditorMode.Normal);
      IWorkingContext iwc = block.GetWorkingContext();
      pl.Attach(iwc);
      //pl.Attach(ViewWorkingContext);
      pl.PostAttach();


      EditorPayload ep = new EditorPayload(block, ViewWorkingContext, serviceContainer);
      pl.SetPayload(ep);

      //Reflector.RunInstanceMethodByName(pl, "CreateOnlineManager");


      OnlineManagerBase OnlineManager = pl.OnlineManager;
      return pl;
    }

    private delegate BlockEditorControlBase GetPLViewDelegate(
      ICoreObject block,
      BlockEditorLogicBase logic,
      IWorkingContext ViewWorkingContext = null,
      LanguageServiceContainer serviceContainer = null,
      ISynchronizeInvoke synchronizer = null);

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

      if (UsingSynchronizer.InvokeRequired)
        return UnifiedSynchronizerAccess.Invoke(UsingSynchronizer,
          new GetPLViewDelegate(GetPLView), new object[4]
        {
          block,
          ViewWorkingContext,
          serviceContainer,
          synchronizer
        }).InvokeResult as BlockEditorControlBase;
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
    }

    public static void GetBlockTypeAndLanguage(this ICoreObject coreObject,
      out BlockType blockType,
      out ProgrammingLanguage blockLanguage)
    {
      blockType = BlockType.Undef;
      blockLanguage = ProgrammingLanguage.Undef;
      Reflector.RunStaticMethodByName(typeof(EditorStarterFacade),
        "GetBlockTypeAndLanguage",
        ReflectionWays.SystemReflection,
        coreObject, blockType, blockLanguage);
    }
  }
}