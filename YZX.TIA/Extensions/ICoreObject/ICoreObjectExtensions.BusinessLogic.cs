using System;
using System.ComponentModel;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.ObjectFrame.BusinessLogic;
using Siemens.Simatic.Lang.Model.Idents;
using Siemens.Simatic.Lang.Model.Blocks;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Starter;
using Siemens.Simatic.PlcLanguages.PLInterface;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Services.Online;
using Siemens.Simatic.PlcLanguages.NetworkEditorFrame.Editor.Logic;
using Siemens.Simatic.PlcLanguages.NetworkEditorFrame.Editor.View;
using Siemens.Simatic.PlcLanguages.GraphEditor.Frame;

using Reflection;

namespace YZX.Tia.Extensions
{
  partial class ICoreObjectExtensions
  {
    public static IBusinessLogicObject CreateBusinessLogicObject(this ICoreObject coreObject)
    {
      return Siemens.Automation.ObjectFrame.Private.BusinessLogicHelper.CreateBusinessLogicObject(coreObject);
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
