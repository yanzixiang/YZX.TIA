using System;

using System.Net;

using Siemens.Automation.DomainServices;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public static class EthernetDiscoverNodeHelperProxy
  {
    public static bool GetVendorAndDeviceFromOam(INode oamNode, out int vendor, out int deviceID)
    {
      return EthernetDiscoverNodeHelper.GetVendorAndDeviceFromOam(oamNode, out vendor, out deviceID);
    }

    public static bool GetOemVendorAndDeviceFromOam(INode oamNode, out int vendor, out int deviceID)
    {
      return EthernetDiscoverNodeHelper.GetOemVendorAndDeviceFromOam(oamNode, out vendor, out deviceID);
    }

    public static bool SupportsIpAddress(INode oamNode)
    {
      return EthernetDiscoverNodeHelper.SupportsIpAddress(oamNode);
    }

    public static IPAddress GetIpAddress(INode oamNode)
    {
      return EthernetDiscoverNodeHelper.GetIpAddress(oamNode);
    }

    public static IPAddress GetSubnetMask(INode oamNode)
    {
      return EthernetDiscoverNodeHelper.GetSubnetMask(oamNode);
    }

    public static DhcpParameter GetDhcpParameter(INode oamNode)
    {
      return EthernetDiscoverNodeHelper.GetDhcpParameter(oamNode);
    }

    public static int UpdateStationParams(INode oamNode, bool forceRead)
    {
      return EthernetDiscoverNodeHelper.UpdateStationParams(oamNode, forceRead);
    }

    public static IOamMacAddress GetMacAddressFromEthernetDiscoverNode(INode oamNode)
    {
      return EthernetDiscoverNodeHelper.GetMacAddressFromEthernetDiscoverNode(oamNode);
    }

    public static DhcpParameter FillDhcpParameter(DhcpParameter dhcpParameter, IOamDhcpAddress dhcpAddress)
    {
      if ((int)dhcpAddress.OptionCode1 != 61)
        return null;
      if (dhcpAddress.OptionValues.Length == 1)
      {
        switch (dhcpAddress.OptionValues[0])
        {
          case 0:
            dhcpParameter.DhcpMode = DhcpOption.DhcpUseNameOfStation;
            break;
          case 1:
            dhcpParameter.DhcpMode = DhcpOption.DhcpUseMacAddress;
            break;
          default:
            dhcpParameter = null;
            break;
        }
      }
      else if (dhcpAddress.OptionValues.Length > 1)
      {
        if (dhcpAddress.OptionValues[0] != 0)
        {
          dhcpParameter = null;
        }
        else
        {
          dhcpParameter.DhcpMode = DhcpOption.DhcpUserDefinedClientId;
          int length = dhcpAddress.OptionValues.Length - 1;
          byte[] numArray = new byte[length];
          Array.Copy(dhcpAddress.OptionValues, 1, numArray, 0, length);
          dhcpParameter.UserClientId = numArray;
        }
      }
      else
        dhcpParameter = null;
      return dhcpParameter;
    }

    public static void GetStandardVendorAndDevice(IEthernetDiscoverNode discoverNode, out int vendor, out int deviceID)
    {
      vendor = discoverNode.DetailedTypeOfStationData[0] << 8 | discoverNode.DetailedTypeOfStationData[1];
      deviceID = discoverNode.DetailedTypeOfStationData[2] << 8 | discoverNode.DetailedTypeOfStationData[3];
    }

    private static bool GetOemVendorAndDevice(IEthernetDiscoverNode discoverNode, out int vendor, out int deviceID)
    {
      return ReadOemValues(GetOemDeviceIdDataSet(discoverNode), out vendor, out deviceID);
    }

    public static IOamIeDataset GetOemDeviceIdDataSet(IEthernetDiscoverNode discoverNode)
    {
      byte[] buffer = new byte[32];
      IOamMacAddress macAddress = GetMacAddress(discoverNode);
      return (discoverNode.Configuration.Network as IOamNetworkIe).Dataset.Create(2, 8, macAddress, buffer, true);
    }

    public static IOamMacAddress GetMacAddress(IEthernetDiscoverNode discoverNode)
    {
      return (discoverNode.Address as IEthernetDiscoverAddress).RemoteStationAddress;
    }

    public static bool ReadOemValues(IOamIeDataset oemDataset, out int vendor, out int deviceID)
    {
      vendor = 0;
      deviceID = 0;
      if (oemDataset.Read() != 0 || oemDataset.ReadBytes < 3L)
        return false;
      byte[] record = oemDataset.Record;
      vendor = (record[0] << 8) + record[1];
      deviceID = (record[2] << 8) + record[3];
      return true;
    }
  }
}
