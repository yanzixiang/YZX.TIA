using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainModel;
using Siemens.Simatic.AlarmServices.Interfaces.Alarms;
using Siemens.Simatic.AlarmServices.Helper;

using Siemens.Automation.ObjectFrame.BusinessLogic;

namespace YZX.Tia.Extensions.ObjectFrame
{
  public static partial class ICoreObjectExtensions
  {
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

    public static T GetAttributes<T>(this ICoreObject o) where T : class
    {
      return (o != null ? o.GetAttributeSet(typeof(T)) : null) as T;
    }

    public static T GetBl<T>(this ICoreObject coreObject, string serviceId)
    {
      return (T)((IBusinessLogicConnector)coreObject).GetBusinessLogic(serviceId);
    }

    public static IBusinessLogicObject Connect(this ICoreObject coreObject, int cookie, IBusinessLogicObject bl)
    {
      ((IBusinessLogicConnector)coreObject).SetBusinessLogic(cookie, bl);
      return bl;
    }
  }
}
