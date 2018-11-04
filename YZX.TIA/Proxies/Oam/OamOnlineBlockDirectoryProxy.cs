using System;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.SPS7;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OamOnlineBlockDirectoryProxy
  {
    OamOnlineBlockDirectory OamOnlineBlockDirectory;
    public OamOnlineBlockDirectoryProxy(IOamOnlineBlockDirectory dir)
    {
      OamOnlineBlockDirectory = dir as OamOnlineBlockDirectory;
    }
  }
}
