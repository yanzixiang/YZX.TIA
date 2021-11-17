using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.ConnectionService;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class ConnectionParamsProxy
  {
    internal ConnectionParams CP;
    public ConnectionParamsProxy()
    {
      CP = new ConnectionParams();
    }

    public ICoreObject OnlineTarget
    {
      get
      {
        return CP.OnlineTarget;
      }
      set
      {
        CP.OnlineTarget = value;
      }
    }

    public ICoreObject OfflineTarget
    {
      get
      {
        return CP.OfflineTarget;
      }
      set
      {
        CP.OfflineTarget = value;
      }
    }

    public string ConnectionType
    {
      get
      {
        return CP.ConnectionType;
      }
      set
      {
        CP.ConnectionType = value;
      }
    }

    public OnlineConnectionModes ConnectionMode
    {
      get
      {
        return CP.ConnectionMode;
      }
      set
      {
        CP.ConnectionMode = value;
      }
    }

    public object ConfigurationData
    {
      get
      {
        return CP.ConfigurationData;
      }
      set
      {
        CP.ConfigurationData = value;
      }
    }

    public object ConnectSpecificData
    {
      get
      {
        return CP.ConnectSpecificData;
      }
      set
      {
        CP.ConnectSpecificData = value;
      }
    }

    public bool ThrowOnError
    {
      get
      {
        return CP.ThrowOnError;
      }
      set
      {
        CP.ThrowOnError = value;
      }
    }

    public bool IsLifelistNode
    {
      get
      {
        return CP.IsLifelistNode;
      }
      set
      {
        CP.IsLifelistNode = value;
      }
    }

    public int GeneralErrorCode
    {
      get
      {
        return CP.GeneralErrorCode;
      }
      set
      {
        CP.GeneralErrorCode = value;
      }
    }

    public int FeedbackErrorService
    {
      get
      {
        return CP.FeedbackErrorService;
      }
      set
      {
        CP.FeedbackErrorService = value;
      }
    }

    public int FeedbackErrorNumber
    {
      get
      {
        return CP.FeedbackErrorNumber;
      }
      set
      {
        CP.FeedbackErrorNumber = value;
      }
    }

    public IOamAddress OnlineAddress
    {
      get
      {
        return CP.OnlineAddress;
      }
      set
      {
        CP.OnlineAddress = value;
      }
    }
  }
}
