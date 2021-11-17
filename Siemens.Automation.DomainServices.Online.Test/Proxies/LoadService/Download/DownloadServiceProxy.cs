using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices.LoadService;

namespace YZX.Tia.Proxies.LoadService.Download
{
  public class DownloadServiceProxy
  {
    DownloadService DownloadService;
    public DownloadServiceProxy(object downloadService)
    {
      DownloadService = downloadService as DownloadService;

    }
  }
}
