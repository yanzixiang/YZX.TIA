using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices.DirectoryMappingService;

namespace YZX.Tia.Proxies
{
  public class OmsSessionProxy
  {
    OmsSession OmsSession;

    public OmsSessionProxy(IDisposable omsSession)
    {
      OmsSession = OmsSession as OmsSession;
    }


  }
}
