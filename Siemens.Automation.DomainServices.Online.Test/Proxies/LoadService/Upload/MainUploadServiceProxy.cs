using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Basics;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.LoadService;

namespace YZX.Tia.Proxies.LoadService.Upload
{
  public class MainUploadServiceProxy
  {
    MainUploadService MainUploadService;

    public MainUploadServiceProxy(IWorkingContext workingContext)
    {
      MainUploadService = new MainUploadService(workingContext);
    }
    public MainUploadServiceProxy(object mus)
    {
      MainUploadService = mus as MainUploadService;
    }

    public ILoadConnection LoadConnection
    {
      get
      {
        return MainUploadService.LoadConnection;
      }
    }

    public int ErrorCount
    {
      get
      {
        return MainUploadService.ErrorCount;
      }
    }

    public int WarningCount
    {
      get
      {
        return MainUploadService.WarningCount;
      }
    }
  }
}
