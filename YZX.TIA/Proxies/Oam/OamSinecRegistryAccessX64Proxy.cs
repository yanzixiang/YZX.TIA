using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.OnlineAccess.Sinec;

namespace YZX.Tia.Proxies
{
  public class OamSinecRegistryAccessX64Proxy
  {
    public static OamSinecRegistryAccessX64Proxy GetInstanceX64()
    {
      OamSinecRegistryAccess access = OamSinecRegistryAccessX64.GetInstanceX64();
      return new OamSinecRegistryAccessX64Proxy(access);
    }

    OamSinecRegistryAccess OamSinecRegistryAccess;
    public OamSinecRegistryAccessX64Proxy(IServiceProvider access)
    {
      OamSinecRegistryAccess = access as OamSinecRegistryAccess;
    }
  }
}
