using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;

using Siemens.Automation.ObjectFrame.Meta;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.OnlineService;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    IOnlineServiceManager OnlineServiceManager
    {
      get
      {
        return OnlineMetaManagerFactory.GetServiceManager(projectWorkingContext);
      }
    }

    #region OnlineServiceManager
    public IOnlineFunctionProvider GetOnlineProvider(IObjectTypeInfo targetType, string onlineFunction)
    {
      return OnlineServiceManager.GetOnlineProvider(targetType, onlineFunction);
    }
    #endregion
  }
}
