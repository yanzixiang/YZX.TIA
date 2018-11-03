using System;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OamClientInfoEventArgsProxy: IOamClientInfoEventArgs
  {
    public IOamClientInfoEventArgs Args;
    public byte[] Buffer;
    public object OamSource;
    public object ClientSource;
    public OamClientInfoEventArgsProxy(IOamClientInfoEventArgs args)
    {
      Args = args;
    }

    public override TimeSpan ElapsedTime
    {
      get
      {
        return Args.ElapsedTime;
      }
    }

    public override int Flags
    {
      get
      {
        return Args.Flags;
      }
    }

    public override OamCallbackMessage Message
    {
      get
      {
        return Args.Message;
      }
    }

    public override int ReferenceCount
    {
      get
      {
        return Args.ReferenceCount;
      }
    }

    public override DateTime TimeStamp
    {
      get
      {
        return Args.TimeStamp;
      }
    }
  }
}
