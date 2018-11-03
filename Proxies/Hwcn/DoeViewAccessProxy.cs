using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.HwConfiguration.Diagnostic.Editor.Basics;

namespace YZX.Tia.Proxies.Hwcn
{
  public class DoeViewAccessProxy
  {
    internal DoeViewAccess DoeViewAccess;

    public DoeViewAccessProxy(IDoeViewAccess viewAccess)
    {
      DoeViewAccess = viewAccess as DoeViewAccess;
    }
  }
}
