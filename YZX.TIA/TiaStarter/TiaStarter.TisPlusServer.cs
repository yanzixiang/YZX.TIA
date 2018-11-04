using System.Collections;
using System.Collections.Generic;

using Siemens.Simatic.PlcLanguages.TisPlusServer;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    private Server m_TisPlusServer;
    public Server TisPlusServer
    {
      get
      {
        if (this.m_TisPlusServer == null)
          this.m_TisPlusServer = m_BusinessLogicApplicationContext.DlcManager.Load("Siemens.Simatic.PlcLanguages.TisPlusServer") as Server;
        return this.m_TisPlusServer;
      }
    }

    public Device CreateTisPlusDevice(IConnection pConnection)
    {
      return TisPlusServer.CreateDevice(pConnection) as Device;
    }

    public DataAddress CreateTisPlusDataAddress()
    {
      return TisPlusServer.CreateDataAddress() as DataAddress;
    }

    public Value CreateTisPlusValue()
    {
      return TisPlusServer.CreateTisValue() as Value;
    }
  }
}
