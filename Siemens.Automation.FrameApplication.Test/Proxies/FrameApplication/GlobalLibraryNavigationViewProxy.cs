using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication.Navigation.Library.GlobalLibrary;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class GlobalLibraryNavigationViewProxy
  {
    internal GlobalLibraryNavigationView GlobalLibraryNavigationView;
    public GlobalLibraryNavigationViewProxy(IDlc dlc)
    {
      GlobalLibraryNavigationView = dlc as GlobalLibraryNavigationView;
    }
  }
}