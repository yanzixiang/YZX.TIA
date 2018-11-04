using System;

using Siemens.Automation.OMSPlus.Managed;
using Siemens.Automation.DomainServices.LoadService;

namespace YZX.Tia.Proxies.Backup
{
  public class OmsBackupHelperProxy
  {
    OmsBackupHelper OmsBackupHelper;
    public OmsBackupHelperProxy(ClientSession clientSession, Func<string, bool> logDiagnosticsInformation)
    {
      OmsBackupHelper = new OmsBackupHelper(clientSession, logDiagnosticsInformation);
    }

    public bool ContinueReadNextBackupBinaryData
    {
      get
      {
        return OmsBackupHelper.ContinueReadNextBackupBinaryData;
      }
    }

    public static bool CheckIfOmsModelSupportsBackupObject(ClientSession clientSession)
    {
      return OmsBackupHelper.CheckIfOmsModelSupportsBackupObject(clientSession);
    }

    public UploadResult CreateOmsBackupObject()
    {
      BackupPlusUpload.UploadResult result = OmsBackupHelper.CreateOmsBackupObject();
      return (UploadResult)result;
    }

    public UploadResult DownloadOmsBackupObject()
    {
      BackupPlusUpload.UploadResult result = OmsBackupHelper.DownloadOmsBackupObject();
      return (UploadResult)result;
    }

    public byte[] ReadNextBackupBinaryData()
    {
      return OmsBackupHelper.ReadNextBackupBinaryData();
    }

    public enum UploadResult
    {
      None,
      NotSupportedByOfflineOmsModel,
      NotSupportedByOnlineOmsModel,
      WrongInterface,
      UploadOnlineBackupFailed,
      Canceled,
      Success,
    }
  }
}
