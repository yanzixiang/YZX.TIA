using Microsoft.Scripting.Runtime;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.Undo;

using YZX.Tia.Proxies.FrameApplication;

namespace YZX.Tia.Extensions
{
  partial class IWorkingContextExtensions
  {
    public static IViewFrame ProjectTreeViewFrame([NotNull] this  IWorkingContext workingContext)
    {
      return FrameLocator.ProjectLibraryTreeViewFrame(workingContext);
    }

    public static IViewFrame FolderPortalViewFrame([NotNull] this IWorkingContext workingContext)
    {
      return FrameLocator.FolderPortalViewFrame(workingContext);
    }

    public static IViewFrame DetailsViewFrame([NotNull] this IWorkingContext workingContext)
    {
      return FrameLocator.DetailsViewFrame(workingContext);
    }

    public static IViewFrame ProjectLibraryTreeViewFrame([NotNull] this IWorkingContext workingContext)
    {
      return FrameLocator.ProjectLibraryTreeViewFrame(workingContext);
    }

    public static IViewFrame GlobalLibraryTreeViewFrame([NotNull] this IWorkingContext workingContext)
    {
      return FrameLocator.GlobalLibraryTreeViewFrame(workingContext);
    }

    public static IFrame ElementsFrame([NotNull] this IWorkingContext workingContext)
    {
      return FrameLocator.ElementsFrame(workingContext);
    }

    public static IViewFrame PartsViewFrame([NotNull] this IWorkingContext workingContext)
    {
      return FrameLocator.PartsViewFrame(workingContext);
    }

    public static IViewFrame StatusBarFrame([NotNull] this IWorkingContext workingContext)
    {
      return FrameLocator.StatusBarFrame(workingContext);
    }

    public static bool IsWithinPortalViewFrameHierarchy(IFrame frame)
    {
      return FrameLocator.IsWithinPortalViewFrameHierarchy(frame);
    }

    public static bool IsPropertyViewFrame(IViewFrame viewFrame)
    {
      return FrameLocator.IsPropertyViewFrame(viewFrame);
    }

    public static IFrame GetFrame([NotNull] this IWorkingContext workingContext, string frameId)
    {
      return FrameLocator.GetFrame(workingContext, frameId);
    }

    public static IFrame GetEditorMainFrame([NotNull] this IWorkingContext workingContext)
    {
      return workingContext.GetFrame("EditorMainFrame");
    }

    public static EditorMainFrameProxy GetEditorMainFrameProxy([NotNull] this IWorkingContext workingContext)
    {
      IFrame frame = workingContext.GetEditorMainFrame();
      var proxy = new EditorMainFrameProxy(frame);
      return proxy;
    }

    public static IFrame ActiveFrame([NotNull] this IWorkingContext workingContext)
    {
      return FrameLocator.ActiveFrame(workingContext);
    }

    public static IEditorFrame ActiveEditor([NotNull] this IWorkingContext workingContext)
    {
      return FrameLocator.ActiveEditor(workingContext);
    }

    public static IEditorPageFrame GetActiveEditorPageFrame([NotNull] this IWorkingContext workingContext)
    {
      return FrameLocator.GetActiveEditorPageFrame(workingContext);
    }
  }
}
