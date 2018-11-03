using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices.LoadService;

namespace YZX.Tia.Proxies.LoadService.Download
{
  public class DownloadCommandServiceProxy
  {
    DownloadCommandService DownloadCommandService;

    public DownloadCommandServiceProxy(object downloadCommandService)
    {
      DownloadCommandService = downloadCommandService as DownloadCommandService;
    }

  }
}
