using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.FrameApplication.WindowManager;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class ProjectNavigatorStateManagerProxy
  {
    ProjectNavigatorStateManager ProjectNavigatorStateManager;

    internal ProjectNavigatorStateManagerProxy(ProjectNavigatorStateManager manager)
    {
      manager = ProjectNavigatorStateManager = manager as ProjectNavigatorStateManager;
    }

    public void ToggleCurrent()
    {
      ProjectNavigatorStateManager.ToggleCurrent();
    }

    public void ChangeState()
    {
      ProjectNavigatorStateManager.ChangeState();
    }

    public void ShowSlide()
    {
      ProjectNavigatorStateManager.ShowSlide();
    }

    public void UpdateSlideWidth(int newSlideWidth)
    {
      ProjectNavigatorStateManager.UpdateSlideWidth(newSlideWidth);
    }

    public void EmbedAsCollapsedFromSliding()
    {
      ProjectNavigatorStateManager.EmbedAsCollapsedFromSliding();
    }

    public void SlideWithoutShow()
    {
      ProjectNavigatorStateManager.SlideWithoutShow();
    }

    public void HideSlideIfShown()
    {
      ProjectNavigatorStateManager.HideSlideIfShown();
    }
  }
}
