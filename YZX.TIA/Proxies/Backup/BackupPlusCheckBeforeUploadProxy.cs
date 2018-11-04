using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices.LoadService;

namespace YZX.Tia.Proxies
{
  public class BackupPlusCheckBeforeUploadProxy
  {
    BackupPlusCheckBeforeUpload BackupPlusCheckBeforeUpload;

    public BackupPlusCheckBeforeUploadProxy(object upload)
    {
      BackupPlusCheckBeforeUpload = upload as BackupPlusCheckBeforeUpload;
    }

  }
}
