using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices.OnlineService;
using Siemens.Automation.ObjectFrame;

namespace YZX.Tia.Proxies.OnlineService
{
  public class LifelistNodeDetailsProxy
  {
    LifelistNodeDetails LifelistNodeDetails;

    public LifelistNodeDetailsProxy(object detail)
    {
      LifelistNodeDetails = detail as LifelistNodeDetails;
    }

    public ICoreObject Node
    {
      get
      {
        return LifelistNodeDetails.Node;
      }
    }

    public bool OnlineInfoUpdated
    {
      get
      {
        return LifelistNodeDetails.OnlineInfoUpdated;
      }
    }

    public ICoreObject OnlineDeviceNode
    {
      get
      {
        return LifelistNodeDetails.OnlineDeviceNode;
      }
    }

    public string DeviceFamily
    {
      get
      {
        return LifelistNodeDetails.DeviceFamily;
      }
    }

    public string DeviceName
    {
      get
      {
        return LifelistNodeDetails.DeviceName;
      }
    }

    public string Address
    {
      get
      {
        return LifelistNodeDetails.Address;
      }
    }

    public string DeviceTypeName
    {
      get
      {
        return LifelistNodeDetails.DeviceTypeName;
      }
    }

    public string MLFB
    {
      get
      {
        return LifelistNodeDetails.MLFB;
      }
    }

    public string TIAPortalConfigured
    {
      get
      {
        return LifelistNodeDetails.TIAPortalConfigured;
      }
    }

    public string Firmware
    {
      get
      {
        return LifelistNodeDetails.Firmware;
      }
    }

    public event EventHandler<EventArgs> UpdateEvent
    {
      add
      {
        LifelistNodeDetails.UpdateEvent += value;
      }
      remove
      {
        LifelistNodeDetails.UpdateEvent -= value;
      }
    }

    public void UpdateOnlineInfo()
    {
      LifelistNodeDetails.UpdateOnlineInfo();
    }


  }
}
