using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainModel;
using Siemens.Simatic.PLCMessaging;
using Siemens.Simatic.PlcLanguages.BlockLogic;
using Siemens.Simatic.AlarmServices.Interfaces.Alarms;
using Siemens.Simatic.AlarmServices.Helper;
using Siemens.Simatic.AlarmServices.Gui.ControllerAlarmView;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static class ICoreContextExtensions
  {
    public static string GetObjectName(this ICoreObject element)
    {
      ICoreAttributes coreAttributes = element.GetAttributeSet(typeof(ICoreAttributes)) as ICoreAttributes;
      if (coreAttributes == null)
        return "";
      return coreAttributes.Name;
    }
    public static ICoreObject CreateTempControllerTarget(this ICoreContext projectContext,
      string configObjectTypeName, string plcName)
    {
      return Reflector.RunStaticMethodByName(typeof(BLBlockProcessor),
        "CreateTempControllerTarget",
        ReflectionWays.SystemReflection,
        projectContext, configObjectTypeName, plcName) as ICoreObject;
    }

    public static PLCMsgConnector GetPlcmService(this ICoreContext coreContext)
    {
      return ((IDlc)coreContext).WorkingContext.DlcManager.Load("Siemens.Simatic.PLCMessaging.PLCMsgConnector") as PLCMsgConnector;
    }

    public static int GetPnoIdent(ICoreObject lifelistNode)
    {
      ILifelistNodeInfo lifelistNodeInfo = lifelistNode.GetAttributeSet(typeof(ILifelistNodeInfo)) as ILifelistNodeInfo;
      if (lifelistNodeInfo != null)
        return lifelistNodeInfo.PnoIdentifier;
      return 0;
    }

    public static int GetProfinetVendorId(this ICoreObject lifelistNode)
    {
      ILifelistNodeInfo lifelistNodeInfo = lifelistNode.GetAttributeSet(typeof(ILifelistNodeInfo)) as ILifelistNodeInfo;
      if (lifelistNodeInfo != null)
        return lifelistNodeInfo.PnoIdentifier >> 16;
      return 0;
    }

    public static int GetProfinetDeviceId(this ICoreObject lifelistNode)
    {
      ILifelistNodeInfo lifelistNodeInfo = lifelistNode.GetAttributeSet(typeof(ILifelistNodeInfo)) as ILifelistNodeInfo;
      if (lifelistNodeInfo != null)
        return lifelistNodeInfo.PnoIdentifier & ushort.MaxValue;
      return 0;
    }

    public static IControllerAlarm GetControllerAlarm(this ICoreObject coreObject)
    {
      IControllerAlarm alarm = 
        BusinessLogicConnectorHelper.GetBusinessLogic<IControllerAlarm>(
          coreObject,
         "Siemens.Simatic.AlarmServices.AlarmBusinessLogicFactory");
      return alarm;
    }
  }
}
