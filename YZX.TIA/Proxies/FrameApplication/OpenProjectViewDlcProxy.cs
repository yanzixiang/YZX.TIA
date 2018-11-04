using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.Portal.Views;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class OpenProjectViewDlcProxy
  {
    internal OpenProjectViewDlc OpenProjectViewDlc;

    public IView IView
    {
      get
      {
        return OpenProjectViewDlc as IView;
      }
    }

    internal OpenProjectViewDlcProxy(OpenProjectViewDlc dlc)
    {
      OpenProjectViewDlc = dlc;
    }

    public IViewFrame ViewFrame
    {
      get
      {
        return IView.ViewFrame;
      }
    }

    public event EventHandler<PortalViewNotificationEventArgs> Notify
    {
      add
      {
        OpenProjectViewDlc.Notify += value;
      }
      remove
      {
        OpenProjectViewDlc.Notify -= value;
      }
    }
  }
}
