using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices.LoadService;

using Reflection;

namespace YZX.Tia
{
  public class BLS7ClassicBackupProxy
  {
    BLS7ClassicBackup BLS7ClassicBackup;
    public BLS7ClassicBackupProxy(object bl)
    {
      BLS7ClassicBackup = bl as BLS7ClassicBackup;
    }

    public BackupClassicCheckBeforeUploadProxy CreateInstanceCheckBeforeUpload()
    {
      BackupClassicCheckBeforeUpload upload = Reflector.RunInstanceMethodByName(BLS7ClassicBackup,
  "CreateInstanceCheckBeforeUpload", ReflectionWays.SystemReflection) as BackupClassicCheckBeforeUpload;
      return new BackupClassicCheckBeforeUploadProxy(upload);
    }

    public BackupClassicUploadProxy CreateInstanceUpload()
    {
      BackupClassicUpload upload = Reflector.RunInstanceMethodByName(BLS7ClassicBackup,
        "CreateInstanceUpload", ReflectionWays.SystemReflection) as BackupClassicUpload;
      return new BackupClassicUploadProxy(upload);
    }
  }
}
