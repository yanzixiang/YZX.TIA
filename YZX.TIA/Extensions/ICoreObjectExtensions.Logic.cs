using System;
using System.ComponentModel;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.NetworkEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.GraphEditor.Frame;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Online;
using Siemens.Simatic.Lang.Model.Idents;
using Siemens.Simatic.Lang.Model.Blocks;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Starter;
using Siemens.Simatic.PlcLanguages.PLInterface;
using Siemens.Simatic.PlcLanguages.Utilities.Toolbox;

using YZX.Tia.Proxies;

using Reflection;

namespace YZX.Tia.Extensions
{
  partial class ICoreObjectExtensions
  {
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
      return TiaStarter.RunInSynchronizer(UsingSynchronizer,
        () =>
        {
          PLBlockEditorLogic pl = new PLBlockEditorLogic();
          IWorkingContext iwc = block.GetWorkingContext();
          pl.Attach(iwc);
          pl.PostAttach();


          EditorPayload ep = new EditorPayload(block, ViewWorkingContext, serviceContainer);
          pl.SetPayload(ep);
          OnlineManagerBase OnlineManager = pl.OnlineManager;
          return pl;
        }) as BlockEditorLogicBase;
    }

    public static BlockEditorLogicBase GetGraphBlockEditorLogic(this ICoreObject block,
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
        }) as BlockEditorLogicBase;

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
