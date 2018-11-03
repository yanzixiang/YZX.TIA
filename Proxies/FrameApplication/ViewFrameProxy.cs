using Siemens.Automation.FrameApplication;

using Siemens.Automation.FrameApplication.WindowManager;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class ViewFrameProxy:FrameBaseProxy
  {
    ViewFrame ViewFrame;

    public new static ViewFrameProxy ToProxy(IFrame frame)
    {
      return new ViewFrameProxy(frame);
    }
    public ViewFrameProxy(IFrame viewFrame):base(viewFrame)
    {
      ViewFrame = viewFrame as ViewFrame;
    }


  }
}
