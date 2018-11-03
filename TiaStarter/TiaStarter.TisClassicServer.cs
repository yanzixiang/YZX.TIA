using System.Collections;
using System.Collections.Generic;

using Siemens.Automation.OnlineAccess.OnlineInterface;
using Siemens.Simatic.PlcLanguages.TisServer;
using Siemens.Simatic.Lang.Model.Idents;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    private Server m_TisServer;
    public Server TisServer
    {
      get
      {
        if (this.m_TisServer == null)
          this.m_TisServer = m_BusinessLogicApplicationContext.DlcManager.Load("Siemens.Simatic.PlcLanguages.TisServer") as Server;
        return this.m_TisServer;
      }
    }

    public Device CreateTisDevice(IConnection pConnection)
    {
      ITisDevice itd = TisServer.CreateDevice(pConnection);
      Device d = itd as Device;
      return d;
    }

    public DataAddress CreateTisDataAddress()
    {
      ITisDataAddress itda = TisServer.CreateDataAddress();
      DataAddress da = itda as DataAddress;
      return da;
    }

    public TisValue CreateTisValue()
    {
      ITisValue itv = TisServer.CreateTisValue();
      TisValue tv = itv as TisValue;
      return tv;
    }

    public static readonly OperandRange[] TisRangeToOperandRange = new OperandRange[15]
      {
        OperandRange.None,
        OperandRange.Memory,
        OperandRange.Input,
        OperandRange.Output,
        OperandRange.PInput,
        OperandRange.POutput,
        OperandRange.Timer,
        OperandRange.Counter,
        OperandRange.Data,
        OperandRange.FC,
        OperandRange.None,
        OperandRange.None,
        OperandRange.None,
        OperandRange.Local,
        OperandRange.None
      };
  }
}
