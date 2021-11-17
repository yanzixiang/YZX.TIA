using Siemens.Automation.Basics;
using System;
using System.Collections.Generic;

using Siemens.Automation.FrameApplication.ProjectWizard;

namespace YZX.Tia.Proxies.FrameApplication
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

    public static string OpenProjectDialog(string path,
      out bool openReadonly,
      IWorkingContext workingContext,
      bool showReadOnlyBox=true,
      bool defaultReadOnlyBoxState=true)
    {
      var handling = new CommonProjectHandling();
      return handling.OpenProjectDialog(path, showReadOnlyBox, defaultReadOnlyBoxState,
        out openReadonly, workingContext);
    }
  }
}
