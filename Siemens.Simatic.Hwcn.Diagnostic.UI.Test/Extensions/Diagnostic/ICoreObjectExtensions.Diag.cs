using System.Windows.Forms;
using System.Collections.Generic;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.CommonServices;
using Siemens.Automation.FrameApplication;
using Siemens.Simatic.HwConfiguration.Diagnostic.Editor.Basics;
using Siemens.Simatic.HwConfiguration.Diagnostic.Common;
using Siemens.Simatic.HwConfiguration.Diagnostic.ToolWindows.DeviceInfoTable.Service;
using Siemens.Simatic.HwConfiguration.Diagnostic.ToolWindows.DeviceInfoTable.Controller;

using YZX.Tia.Dlc;
using YZX.Tia.Extensions.Diagnostic;
using YZX.Tia.Proxies.FrameApplication;
using YZX.Tia.Extensions.ObjectFrame;

namespace YZX.Tia.Extensions.Diagnostic
{
  public static partial class ICoreObjectExtensions
  {
    public static IDiagServiceProvider GetDiagServiceProvider(this ICoreObject coreObj)
    {
      return DiagServiceProviderAdminImpl.Instance.GetDiagServiceProviderFromCoreObject(coreObj);
    }

    public static DeviceInfoTableService GetDeviceInfoTableService(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      DeviceInfoTableService DeviceInfoTableService = idlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.DeviceInfoTableService")
        as DeviceInfoTableService;
      return DeviceInfoTableService;
    }

    public static DeviceInfoTableController GetDeviceInfoTableController(this ICoreObject coreObject)
    {
      IDlc idlc = (IDlc)coreObject.Context;
      IDlcManager idlcManager = idlc.WorkingContext.DlcManager;
      DeviceInfoTableController DeviceInfoTableController = idlcManager.Load("Siemens.Simatic.HwConfiguration.Diagnostic.DeviceInfoTableController")
        as DeviceInfoTableController;
      return DeviceInfoTableController;
    }

    public static Control ShowModuleState(this ICoreObject cpu)
    {
      var UIContextHolder = PrimaryProjectUiWorkingContextManagerProxy.Instance.IUIContextHolder;
      var ProjectUIContext = UIContextHolder.ProjectUIContext;
      IWorkingContext workingContext = cpu.FindWorkingContext();
      FrameGroupManager manager = ProjectUIContext.GetHwcnFrameGroupManager();
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
          var DoeInstanceAccess = doe as DoeInstanceAccess;
          var viewAccess = DoeInstanceAccess.GetDoeViewAccess() as DoeViewAccess;
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

    public static Control ShowLifelistNodeModuleState(ICoreObject cpu)
    {
      var workingContext = cpu.FindWorkingContext();
      var LifelistNodeUIContext = workingContext;//= cpu.GetUIWorkingContext();
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
    public static string GetObjectIdentification(this ICoreObject source)
    {
      return Helper.GetObjectIdentification(source);
    }
  }
}
