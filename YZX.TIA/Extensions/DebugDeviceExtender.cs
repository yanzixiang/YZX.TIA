using Siemens.Simatic.PlcLanguages.PLInterface.PLDebug;

namespace YZX.Tia.Extensions
{
  public static class DebugDeviceExtender
  {
    private const int s_PduSize300Plc = 240;
    private const int s_PduSize400Plc = 480;

    public static bool Is300Plc(this IDebugDevice debugDevice)
    {
      return debugDevice.TisCapabilities.iPduSize == 240;
    }

    public static bool Is400Plc(this IDebugDevice debugDevice)
    {
      return debugDevice.TisCapabilities.iPduSize == 480;
    }

    public static bool IsInHalt(this IDebugDevice debugDevice)
    {
      return debugDevice.GetCondition() == Condition.Halt;
    }

    public static bool IsOnline(this IDebugDevice debugDevice)
    {
      return debugDevice.ConnectionState == ConnectionState.Online;
    }
  }
}
