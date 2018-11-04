using Siemens.Automation.DomainServices.LoadService;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices;

using Reflection;

namespace YZX.Tia.Proxies
{
  public class BackupPlusUploadProxy
  {
    BackupPlusUpload BackupPlusUpload;

    public BackupPlusUploadProxy(object upload)
    {
      BackupPlusUpload = upload as BackupPlusUpload;
    }

    public ICoreContext CoreContext
    {
      get
      {
        return Reflector.GetInstanceFieldByName(BackupPlusUpload,
          "m_CoreContext", ReflectionWays.SystemReflection) as ICoreContext;
      }
    }

    public ILoadConnection LoadConnection
    {
      get
      {
        return Reflector.GetInstanceFieldByName(BackupPlusUpload,
          "m_LoadConnection", ReflectionWays.SystemReflection) as ILoadConnection;
      }
    }

    public ILoadData LoadData
    {
      get
      {
        return Reflector.GetInstanceFieldByName(BackupPlusUpload,
          "m_LoadData", ReflectionWays.SystemReflection) as ILoadData;
      }
    }
  }
}