using Siemens.Automation.FrameApplication;

namespace YZX.Tia.Proxies.FrameApplication
{
  partial class WindowManagerProxy
  {
    public const string ProjectNavigatorFrameID = "Siemens.Automation.FrameApplication.ApplicationNavigationContainer";
    public ProjectNavigatorFrameProxy GetProjectNavigatorFrameProxy()
    {
      IFrame frame = GetSingletonFrame(ProjectNavigatorFrameID);
      ProjectNavigatorFrameProxy proxy = new ProjectNavigatorFrameProxy(frame);
      return proxy;
    }
  }
}