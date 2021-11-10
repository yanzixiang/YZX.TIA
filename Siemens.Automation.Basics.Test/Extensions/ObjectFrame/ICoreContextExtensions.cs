using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.PLCMessaging;
using Siemens.Simatic.PlcLanguages.BlockLogic;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Extensions.ObjectFrame
{
  public static class ICoreContextExtensions
  {
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
  }
}
