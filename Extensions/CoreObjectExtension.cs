using Siemens.Automation.ObjectFrame;
using Siemens.Automation.ObjectFrame.BusinessLogic;

namespace YZX.Tia.Extensions
{
  public static class CoreObjectExtension
  {
    public static T GetAttributes<T>(this ICoreObject o) where T : class
    {
      return (o != null ? o.GetAttributeSet(typeof (T)) : null) as T;
    }

    public static T GetBl<T>(this ICoreObject coreObject, string serviceId)
    {
      return (T) ((IBusinessLogicConnector) coreObject).GetBusinessLogic(serviceId);
    }

    public static IBusinessLogicObject Connect(this ICoreObject coreObject, int cookie, IBusinessLogicObject bl)
    {
      ((IBusinessLogicConnector) coreObject).SetBusinessLogic(cookie, bl);
      return bl;
    }
  }
}
