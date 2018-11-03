using System.Collections.Generic;

using Siemens.Automation.OnlineAccess;

using Reflection;

namespace YZX.Tia.Proxies
{
  public class OamThreadPoolProxy
  {
    OamThreadPool OamThreadPool;

    public static OamThreadPoolProxy Default
    {
      get
      {
        return new OamThreadPoolProxy(OamThreadPool.Default);
      }
    }
    private OamThreadPoolProxy(OamThreadPool pool)
    {
      OamThreadPool = pool;
    }

    //public Dictionary<int, object> ThreadList
    //{
    //  get
    //  {
        
    //  }
    //}
  }
}
