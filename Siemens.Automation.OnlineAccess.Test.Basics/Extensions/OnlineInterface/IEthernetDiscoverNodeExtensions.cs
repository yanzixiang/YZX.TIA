using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Extensions.OnlineInterface
{
  public static class IEthernetDiscoverNodeExtensions
  {
    public static int GetProfinetDeviceId(this IEthernetDiscoverNode ethDiscoverNode)
    {
      int num = 0;
      if (ethDiscoverNode != null && ethDiscoverNode.DetailedTypeOfStation != 0)
        num = ethDiscoverNode.DetailedTypeOfStationData[2] << 8 | ethDiscoverNode.DetailedTypeOfStationData[3];
      return num;
    }
  }
}
