using Siemens.Automation.DomainServices.LoadService;

namespace YZX.Tia
{
  public class BackupClassicUploadProxy
  {
    BackupClassicUpload BackupClassicUpload;

    public BackupClassicUploadProxy(object upload)
    {
      BackupClassicUpload = upload as BackupClassicUpload;
    }
  }
}