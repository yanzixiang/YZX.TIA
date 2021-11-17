using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices.LoadService;

namespace YZX.Tia.Proxies.LoadService.Upload
{
  public class UploadOnlineAccessBaseProxy
  {
    UploadOnlineAccessBase UploadOnlineAccessBase;

    internal UploadOnlineAccessBaseProxy(UploadOnlineAccessBase access)
    {
      UploadOnlineAccessBase = access;
    }
  }
}
