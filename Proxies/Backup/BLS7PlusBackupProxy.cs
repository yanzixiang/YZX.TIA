
using Siemens.Automation.DomainServices.LoadService;

using Reflection;

namespace YZX.Tia.Proxies
{
  public class BLS7PlusBackupProxy
  {
    BLS7PlusBackup BLS7PlusBackup;
    public BLS7PlusBackupProxy(object bl)
    {
      BLS7PlusBackup = bl as BLS7PlusBackup;
    }

    public BackupPlusCheckBeforeUploadProxy CreateInstanceCheckBeforeUpload()
    {
      BackupPlusCheckBeforeUpload upload = Reflector.RunInstanceMethodByName(BLS7PlusBackup,
        "CreateInstanceCheckBeforeUpload", ReflectionWays.SystemReflection) as BackupPlusCheckBeforeUpload;
      return new BackupPlusCheckBeforeUploadProxy(upload);
    }

    protected BackupPlusUploadProxy CreateInstanceUpload()
    {
      BackupPlusUpload upload = Reflector.RunInstanceMethodByName(BLS7PlusBackup,
        "CreateInstanceUpload", ReflectionWays.SystemReflection) as BackupPlusUpload;
      return new BackupPlusUploadProxy(upload);
    }
  }
}
