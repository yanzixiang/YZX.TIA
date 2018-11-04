using System.Collections;
using System.Collections.Generic;

using Siemens.Simatic.PlcLanguages.BlockLogic.OpenBlockHandling;
using Siemens.Automation.CommonServices;
using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.CommonServices.ProjectManagement.Private.Interfaces;
using Siemens.Automation.CommonServices.ProjectControl.UI;
using Siemens.Simatic.PlcLanguages.VatService;
using Siemens.Simatic.PlcLanguages.PLInterface.PLDebug;
using Siemens.Simatic.PlcLanguages.BlockLogic.PLDebug;
using Siemens.Simatic.HwConfiguration.BusinessLogic.Acf.Devices;
using Siemens.Automation.DomainServices;
using Siemens.Simatic.PlcLanguages.VatService.Navigator;
using Siemens.Simatic.PlcLanguages.BlockLogic.Online.OnlineReader;
using Siemens.Simatic.PlcLanguages.BlockLogic.Online;
using Siemens.Simatic.PlcLanguages.BlockLogic;
using Siemens.Automation.DomainServices.FolderService;
using Siemens.Simatic.PlcLanguages.Model;
using Siemens.Automation.ObjectFrame.Private;
using Siemens.Automation.ObjectFrame.BusinessLogic;
using Siemens.Automation.Basics.Synchronizer;
using Siemens.Automation.DomainServices.UI.GoOnline;
using Siemens.Simatic.HwConfiguration.Diagnostic.Services.Common;
using Siemens.Simatic.PlcLanguages.VatService.Businesslogic;
using Siemens.Automation.DomainServices.OnlineService;
using Siemens.Automation.ObjectFrame.Meta;
using Siemens.Simatic.HwConfiguration.Diagnostic.Services;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame.Editor.Commands;
using Siemens.Automation.DomainServices.UI.LoadService;

using YZX.Tia.Extensions;

namespace YZX.Tia
{
  public class TiaProcess
  {
    #region internal
    static CmdHandlerHelper CHH;

    IControllerTargetLookup QBCTL;
    OnlineServiceHelper onlineServiceHelper;
    IBlockLookup blockLookup;
    #endregion

    public static ICoreContextHandler cch;

    static TiaProcess(){

      CHH = new CmdHandlerHelper(App.ProjectManager);
    }






    public OnlineErrorState Connect(ICoreObject onlineTarget, 
      NeededProtectionLevel protectionLevel, 
      string connectionType, 
      bool showDialog)
    {
      if(onlineServiceHelper == null)
      {
        return OnlineErrorState.Error;
      }

      return onlineServiceHelper.Connect(onlineTarget, protectionLevel, connectionType, showDialog);
    }

    public object GetOnlineReader(ICoreObject cpu)
    {
      return OnlineReaderFactory.GetOnlineReader(cpu);
    }
  }
}
