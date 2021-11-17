using Siemens.Automation.OnlineAccess.S7SDDnet;

namespace YZX.Tia.Proxies
{
  public class S7JobProxy
  {
    internal S7Job S7Job { get; private set; }

    internal S7JobProxy(S7Job job)
    {
      S7Job = job;
    }


  }
}
