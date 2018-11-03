using System;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OamInfoEventProxy
  {
    public OamInfoCallback oic;
    public OamInfoEventProxy()
    {
      oic = new OamInfoCallback(OnOamInfoCallback);
    }

    public event OamJobInfoHandler OnCallback;

    public void OnOamInfoCallback(
      OamCallbackMessage message, 
      int Flags, 
      int referenceCount, 
      byte[] buffer, 
      DateTime timeStamp, 
      TimeSpan elapsedTime, 
      object oamSource, 
      object ClientSource)
    {
      //Console.WriteLine($"OamInfoEventProxy.OnOamInfoCallback() {message} {Flags} {referenceCount} {timeStamp} {elapsedTime}");
      if(OnCallback != null)
      {
        OamClientInfoEventArgs args = new OamClientInfoEventArgs(message, Flags, referenceCount, buffer, timeStamp, elapsedTime);
        OamClientInfoEventArgsProxy argsProxy = new OamClientInfoEventArgsProxy(args);
        argsProxy.Buffer = buffer;
        argsProxy.OamSource = oamSource;
        argsProxy.ClientSource = ClientSource;
        OnCallback(this,argsProxy);
      }
    }
  }
}
