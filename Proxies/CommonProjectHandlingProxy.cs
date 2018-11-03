using Siemens.Automation.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.FrameApplication.ProjectWizard;

namespace YZX.Tia.Proxies
{
  public class CommonProjectHandlingProxy
  {
    public static List<IStarterFileInfo> LastRecentProjects(IWorkingContext workingContext, 
      out int maxRecentlyUsedProjectsToShow)
    {
      return CommonProjectHandling.LastRecentProjects(workingContext, out maxRecentlyUsedProjectsToShow);
    }

    public static List<IStarterFileInfo> LastRecentProjects(IWorkingContext workingContext)
    {
      return CommonProjectHandling.LastRecentProjects(workingContext);
    }

    public static void DeleteProjectFromRecentList(IWorkingContext workingContext, string project)
    {
      CommonProjectHandling.DeleteProjectFromRecentList(workingContext, project);
    }

  }
}
