using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.WindowManager;
using System;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class ApplicationFrameProxy:HierarchyFrameProxy
  {
    ApplicationFrame ApplicationFrame;

    IApplicationFrameInternal IApplicationFrameInternal
    {
      get
      {
        return ApplicationFrame as IApplicationFrameInternal;
      }
    }
    public ApplicationFrameProxy(IFrame frame) : base(frame)
    {
      ApplicationFrame = frame as ApplicationFrame;
    }

    public void ShowMenu()
    {
      IApplicationFrameInternal.ShowMenu();
    }

    public void HideMenu()
    {
      IApplicationFrameInternal.HideMenu();
    }

    public void ShowToolBar()
    {
      IApplicationFrameInternal.ShowToolBar();
    }

    public void HideToolBar()
    {
      IApplicationFrameInternal.HideToolBar();
    }

    public void SetBargeSign(bool activate)
    {
      ApplicationFrame.SetBargeSign(activate);
    }



  }
}
