using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.LoadService;

namespace YZX.Tia.Proxies
{
  public class LoadConnectionOnlineProxy
  {
    LoadConnectionOnline LoadConnectionOnline;

    public LoadConnectionOnlineProxy(ILoadConnection connection)
    {
      LoadConnectionOnline = connection as LoadConnectionOnline;
    }


  }
}
