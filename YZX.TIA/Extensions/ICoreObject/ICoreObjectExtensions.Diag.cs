using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.HwConfiguration.Diagnostic.Common;
using Siemens.Simatic.HwConfiguration.Diagnostic.ToolWindows.DeviceInfoTable.Service;
using Siemens.Simatic.HwConfiguration.Diagnostic.ToolWindows.DeviceInfoTable.Controller;

namespace YZX.Tia.Extensions
{
  partial class ICoreObjectExtensions
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
  }
}
