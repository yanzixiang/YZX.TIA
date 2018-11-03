using Siemens.Automation.DomainServices.LoadService;

using Reflection;

namespace YZX.Tia
{
  public class BackupClassicCheckBeforeUploadProxy
  {
    BackupClassicCheckBeforeUpload BackupClassicCheckBeforeUpload;

    public BackupClassicCheckBeforeUploadProxy(object upload)
    {
      BackupClassicCheckBeforeUpload = upload as BackupClassicCheckBeforeUpload;
    }
  }
}