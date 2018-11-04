using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices.LoadService;

namespace YZX.Tia.Proxies.LoadService.Upload
{
  public class UploadOnlineAccessProjectProxy:UploadOnlineAccessBaseProxy
  {
    UploadOnlineAccessProject UploadOnlineAccessProject;

    internal UploadOnlineAccessProjectProxy(UploadOnlineAccessProject project)
      :base(project)
    {
      UploadOnlineAccessProject = project;
    }
  }
}
