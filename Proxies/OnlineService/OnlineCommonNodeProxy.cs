using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices.UI.OnlineCommon;
using Siemens.Automation.DomainServices.UI.OnlineCommon.DataBinding;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies.OnlineService
{
  public class OnlineCommonNodeProxy
  {
    internal OnlineCommonNode OnlineCommonNode;

    internal OnlineCommonNodeProxy(OnlineCommonNode node)
    {
      OnlineCommonNode = node;
    }

    public bool IsLifelistOfflineSibling
    {
      get
      {
        return OnlineCommonNode.IsLifelistOfflineSibling;
      }
      set
      {
        OnlineCommonNode.IsLifelistOfflineSibling = value;
      }
    }

    public bool LifelistSiblingInfoUpdatesTriggered
    {
      get
      {
        return OnlineCommonNode.LifelistSiblingInfoUpdatesTriggered;
      }
      set
      {
        OnlineCommonNode.LifelistSiblingInfoUpdatesTriggered = value;
      }
    }

    public bool InfoUpdatesTriggered
    {
      get
      {
        return OnlineCommonNode.InfoUpdatesTriggered;
      }
      set
      {
        OnlineCommonNode.InfoUpdatesTriggered = value;
      }
    }

    public string IPAddressString
    {
      get
      {
        return OnlineCommonNode.IPAddressString;
      }
      set
      {
        OnlineCommonNode.IPAddressString = value;
      }
    }

    public string MACAddressString
    {
      get
      {
        return OnlineCommonNode.MACAddressString;
      }
      set
      {
        OnlineCommonNode.MACAddressString = value;
      }
    }

    public string IPAddressStringWithProtocol
    {
      get
      {
        return OnlineCommonNode.IPAddressStringWithProtocol;
      }
    }

    public string MACAddressStringWithProtocol
    {
      get
      {
        return OnlineCommonNode.MACAddressStringWithProtocol;
      }
    }

    public bool HasIPAddress
    {
      get
      {
        return OnlineCommonNode.HasIPAddress;
      }
    }

    public string ProtocolString
    {
      get
      {
        return OnlineCommonNode.ProtocolString;
      }

      set
      {
        OnlineCommonNode.ProtocolString = value;
      }
    }

    public string AddressStringWithProtocol
    {
      get
      {
        return OnlineCommonNode.AddressStringWithProtocol;
      }
    }

    public ICoreObject DeviceNode
    {
      get
      {
        return OnlineCommonNode.DeviceNode;
      }
    }

    public ICoreObject OnlineDeviceNode
    {
      get
      {
        return OnlineCommonNode.OnlineDeviceNode;
      }
    }

    public ICoreObject TargetNode
    {
      get
      {
        return OnlineCommonNode.TargetNode;
      }
    }

    public bool ConnectionPossible
    {
      get
      {
        return OnlineCommonNode.ConnectionPossible;
      }
    }

    public string DeviceName
    {
      get
      {
        return OnlineCommonNode.DeviceName;
      }
      set
      {
        OnlineCommonNode.DeviceName = value;
      }
    }

    public string DeviceTypeName
    {
      get
      {
        return OnlineCommonNode.DeviceTypeName;
      }
      set
      {
        OnlineCommonNode.DeviceTypeName = value;
      }
    }

    public ICoreObject OnlineDeviceTarget
    {
      get
      {
        return OnlineCommonNode.OnlineDeviceTarget;
      }
    }

    public string TargetName
    {
      get
      {
        return OnlineCommonNode.TargetName;
      }
      set
      {
        OnlineCommonNode.TargetName = value;
      }
    }

    public void SetDeviceOrTargetInfoUpdateReady()
    {
      OnlineCommonNode.SetDeviceOrTargetInfoUpdateReady();
    }

    internal static OnlineCommonNode Create(OnlineCommonLifeListFacade lifeListFacade, 
      ICoreObject accessibleNode, 
      OnlineCommonHelper helper)
    {
      return OnlineCommonNode.Create(lifeListFacade, accessibleNode, helper);
    }

    internal static OnlineCommonNode CreateExtendedDownloadNode(OnlineCommonLifeListFacade lifeListFacade, 
      string address, 
      IOamAddress defaultAddress, 
      OnlineCommonHelper helper, 
      OnlineCommonNodeClass nodeClass, 
      bool isReachable)
    {
      return OnlineCommonNode.CreateExtendedDownloadNode(lifeListFacade, 
        address, defaultAddress, helper, nodeClass, isReachable);
    }

    internal static OnlineCommonNode CreateWithAddressAsLifelistNode(OnlineCommonLifeListFacade lifeListFacade, 
      IOamAddress address, 
      OnlineCommonHelper helper, 
      bool isReachable)
    {
      return OnlineCommonNode.CreateWithAddressAsLifelistNode(lifeListFacade, address, helper, isReachable);
    }

    internal static OnlineCommonNode CreateWithOfflineTarget(OnlineCommonLifeListFacade lifeListFacade, 
      IOamAddress address,
      OnlineCommonHelper helper, 
      bool isReachable)
    {
      return OnlineCommonNode.CreateWithOfflineTarget(lifeListFacade, address, helper, isReachable);
    }






  }
}
