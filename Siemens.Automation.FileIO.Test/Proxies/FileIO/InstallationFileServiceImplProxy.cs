using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.FileIO;
using Siemens.Automation.FileIO.Private;

namespace YZX.Tia.Proxies.FileIO
{
  public class InstallationFileServiceImplProxy
  {
    InstallationFileServiceImpl InstallationFileServiceImpl;

    public InstallationFileServiceImplProxy(IFileService fileService)
    {
      InstallationFileServiceImpl = fileService as InstallationFileServiceImpl;
    }

  }
}
