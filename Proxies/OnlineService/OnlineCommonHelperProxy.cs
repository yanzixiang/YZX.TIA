using System;
using System.Collections.Generic;

using Siemens.Automation.DomainServices.UI.OnlineCommon;
using OCH = Siemens.Automation.DomainServices.UI.OnlineCommon.OnlineCommonHelper;

using YZX.Tia.Converter;

namespace YZX.Tia.Proxies.OnlineService
{
  public class OnlineCommonHelperProxy
  {
    internal OCH och;

    internal OnlineCommonHelperProxy(OCH helper)
    {
      och = helper;
    }

    public OnlineCommonHelperProxy(OnlineCommonParameter parameter, 
      string dialogmode)
    {
      OnlineCommonDialogType ocdt = OnlineCommonDialogType.Undefined;
      switch (dialogmode)
      {
        case "Undefined":
          break;
        case "GoOnline":
          ocdt = OnlineCommonDialogType.GoOnline;
          break;
        case "ExtendedDownload":
          ocdt = OnlineCommonDialogType.ExtendedDownload;
          break;
        case "LifeList":
          ocdt = OnlineCommonDialogType.LifeList;
          break;
        case "HardwareDetection":
          ocdt = OnlineCommonDialogType.HardwareDetection;
          break;
        case "SelectTarget":
          ocdt = OnlineCommonDialogType.SelectTarget;
          break;
        case "ShowHideInterfaces":
          ocdt = OnlineCommonDialogType.ShowHideInterfaces;
          break;
        case "GlobalConnectionSettings":
          ocdt = OnlineCommonDialogType.GlobalConnectionSettings;
          break;
      }
      och = new OCH(parameter, ocdt);
    }
    public List<OnlineCommonNodeProxy> GetUsableProjectNodes()
    {
      var nodes = och.GetUsableProjectNodes();
      return nodes.ConvertAll(new Converter<OnlineCommonNode, OnlineCommonNodeProxy>(
          OnlineServiceConverters.OnlineCommonNodeProxy));
    }
  }
}
