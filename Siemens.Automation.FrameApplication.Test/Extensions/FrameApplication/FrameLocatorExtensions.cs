using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.Undo;

using YZX.Tia.Proxies.FrameApplication;

namespace YZX.Tia.Extensions.FrameApplication
{
  public static partial class FrameLocatorExtensions
  {
    public static IViewFrame ProjectTreeViewFrame(this  IWorkingContext workingContext)
    {
      return FrameLocator.ProjectLibraryTreeViewFrame(workingContext);
    }

    public static IViewFrame FolderPortalViewFrame(this IWorkingContext workingContext)
    {
      return FrameLocator.FolderPortalViewFrame(workingContext);
    }

    public static IViewFrame DetailsViewFrame(this IWorkingContext workingContext)
    {
      return FrameLocator.DetailsViewFrame(workingContext);
    }

    public static IViewFrame ProjectLibraryTreeViewFrame(this IWorkingContext workingContext)
    {
      return FrameLocator.ProjectLibraryTreeViewFrame(workingContext);
    }

    public static IViewFrame GlobalLibraryTreeViewFrame(this IWorkingContext workingContext)
    {
      return FrameLocator.GlobalLibraryTreeViewFrame(workingContext);
    }

    public static IFrame ElementsFrame(this IWorkingContext workingContext)
    {
      return FrameLocator.ElementsFrame(workingContext);
    }

    public static IViewFrame PartsViewFrame(this IWorkingContext workingContext)
    {
      return FrameLocator.PartsViewFrame(workingContext);
    }

    public static bool IsWithinPortalViewFrameHierarchy(IFrame frame)
    {
      return FrameLocator.IsWithinPortalViewFrameHierarchy(frame);
    }

    public static bool IsPropertyViewFrame(IViewFrame viewFrame)
    {
      return FrameLocator.IsPropertyViewFrame(viewFrame);
    }

    public static IFrame GetFrame(this IWorkingContext workingContext, string frameId)
    {
      return FrameLocator.GetFrame(workingContext, frameId);
    }

    public static IFrame GetEditorMainFrame(this IWorkingContext workingContext)
    {
      return workingContext.GetFrame("EditorMainFrame");
    }

    public static EditorMainFrameProxy GetEditorMainFrameProxy(this IWorkingContext workingContext)
    {
      IFrame frame = workingContext.GetEditorMainFrame();
      var proxy = new EditorMainFrameProxy(frame);
      return proxy;
    }

    public static IFrame ActiveFrame(this IWorkingContext workingContext)
    {
      return FrameLocator.ActiveFrame(workingContext);
    }

    public static IEditorFrame ActiveEditor(this IWorkingContext workingContext)
    {
      return FrameLocator.ActiveEditor(workingContext);
    }

    public static IEditorPageFrame GetActiveEditorPageFrame(this IWorkingContext workingContext)
    {
      return FrameLocator.GetActiveEditorPageFrame(workingContext);
    }
  }
}
