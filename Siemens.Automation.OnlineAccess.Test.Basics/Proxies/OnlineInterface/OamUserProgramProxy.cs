using System;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;
using Siemens.Automation.OnlineAccess.SPS7;

namespace YZX.Tia.Proxies
{
  public class OamUserProgramProxy
  {
    OamUserProgram OamUserProgram;
    public OamUserProgramProxy(IOamUserProgram program)
    {
      OamUserProgram = program as OamUserProgram;
    }
  }
}
