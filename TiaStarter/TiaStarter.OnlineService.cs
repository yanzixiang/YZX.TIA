using System;

using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.OnlineService;
using Siemens.Automation.ObjectFrame;

using YZX.Tia.Extensions;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    private OnlineServiceProvider m_OnlineService;
    public OnlineServiceProvider OnlineService
    {
      get
      {
        if (m_OnlineService == null)
        {
          IOnlineService ios = projectWorkingContext.DlcManager.Load("Siemens.Automation.DomainServices.OnlineService") as IOnlineService;

          m_OnlineService = ios.ToOnlineServiceProvider();
        }
        return m_OnlineService;
      }
    }

    internal OnlineNavigator OnlineNavigator
    {
      get
      {
        return OnlineService.Navigator;
      }
    }

    public bool DoOperationFlash(ICoreObject target, out int errorCode, out int errorServiceID, IDiagFlashJob job)
    {
      bool flag = false;
      errorCode = 0;
      errorServiceID = 0;
      if (target != null)
      {
        IOnlineItemAccess onlineItemProxy = OnlineService.FindOnlineItemProxy(target);
        if (onlineItemProxy != null)
        {
          try
          {
            onlineItemProxy.DoOperation("Flash", job);
            flag = true;
          }
          catch (OnlineException ex)
          {
            errorCode = ex.ErrorCode;
            errorServiceID = ex.ErrorServiceID;
          }
          catch (NotSupportedException ex)
          {
            errorCode = 0;
            errorServiceID = 241;
          }
        }
      }
      return flag;
    }

    public ICoreObject GetOnlineObject(
      ICoreObject offlineObject, 
      bool initializeState, 
      OnlineCreateMode mode)
    {
      ICoreObject ico = OnlineService.GetOnlineObject(offlineObject, initializeState, mode);
      return ico;
    }

    public void GoOnline(ICoreObject offlineTarget)
    {
      OnlineService.GoOnline(offlineTarget);
    }

    public void GoOffline()
    {
      OnlineService.GoOffline();
    }

    
  }
}
