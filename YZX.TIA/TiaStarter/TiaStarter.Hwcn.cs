using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Siemens.Automation.Basics;
using Siemens.Automation.CommonServices;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.FrameApplication;
using Siemens.Simatic.HwConfiguration.Diagnostic.Editor.Basics;

using YZX.Tia.Proxies;
using YZX.Tia.Extensions;
using YZX.Tia.Extensions.Hwcn;

namespace YZX.Tia
{
  partial class TiaStarter
  {

    public Control ShowModuleState(ICoreObject cpu)
    {
      UIContextHolder = PrimaryProjectUiWorkingContextManagerProxy.IUIContextHolder;
      ProjectUIContext = UIContextHolder.ProjectUIContext;
      IWorkingContext workingContext = cpu.GetWorkingContext();
      FrameGroupManager manager = ProjectUIContext.GetHwcnFrameGroupManager();
      ICommandProcessor processor = workingContext.GetCommandProcessor();
      ICommand command = processor.CreateCommand("Hwcn.Diagnostic.ShowModuleState", new object[1]
      {
        cpu
      }, new NameObjectCollection());
      command.Arguments.Add("DoeStartCategory", "DiagCategoryEventLog");
      CommandResult result = manager.Execute(command);
      if(result.ReturnCode == CommandReturnCodes.Handled)
      {
        object resultObject = result.ReturnValue;
        List<IDoeInstanceAccess> does = manager.GetDoeInstances();
        foreach(IDoeInstanceAccess doe in does)
        {
          DoeInstanceAccess DoeInstanceAccess = doe as DoeInstanceAccess;
          DoeViewAccess viewAccess = DoeInstanceAccess.GetDoeViewAccess() as DoeViewAccess;
          ICoreObject viewObject = doe.ViewObject;
          IEditorFrame frame = doe.EditorFrame;
          if(viewObject == cpu)
          {
            return frame.FrameControl;
          }
        }
      }
      return null;
    }

    public Control ShowLifelistNodeModuleState(ICoreObject cpu)
    {
      IWorkingContext LifelistNodeUIContext = cpu.GetUIWorkingContext();
      IWorkingContext workingContext = cpu.GetWorkingContext();
      FrameGroupManager manager = LifelistNodeUIContext.GetHwcnFrameGroupManager();
      ICommandProcessor processor = workingContext.GetCommandProcessor();
      ICommand command = processor.CreateCommand("Hwcn.Diagnostic.ShowModuleState", new object[1]
      {
        cpu
      }, new NameObjectCollection());
      command.Arguments.Add("DoeStartCategory", "DiagCategoryEventLog");
      CommandResult result = manager.Execute(command);
      if (result.ReturnCode == CommandReturnCodes.Handled)
      {
        object resultObject = result.ReturnValue;
        List<IDoeInstanceAccess> does = manager.GetDoeInstances();
        foreach (IDoeInstanceAccess doe in does)
        {
          DoeInstanceAccess DoeInstanceAccess = doe as DoeInstanceAccess;
          DoeViewAccess viewAccess = DoeInstanceAccess.GetDoeViewAccess() as DoeViewAccess;
          ICoreObject viewObject = doe.ViewObject;
          IEditorFrame frame = doe.EditorFrame;
          if (viewObject == cpu)
          {
            return frame.FrameControl;
          }
        }
      }
      return null;
    }
  }
}
