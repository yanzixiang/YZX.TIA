using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices.UI.OnlineCommon;

using Reflection;

using YZX.Tia.Proxies;
using YZX.Tia.Proxies.FrameApplication;

namespace YZX.Tia.Extensions.FrameApplication
{
  public static class LifeListViewExtensions
  {
    public static LifeListDialogProxy GetLifeListDialogProxy(this LifeListView lifeListView)
    {
      LifeListDialog dialog = lifeListView.LifeListControl;
      var proxy = new LifeListDialogProxy(dialog);
      return proxy;
    }
  }
}
