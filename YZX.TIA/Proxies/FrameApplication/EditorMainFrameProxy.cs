using System.Collections.Generic;

using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.WindowManager;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class EditorMainFrameProxy:HierarchyFrameProxy
  {
    EditorMainFrame EditorMainFrame;
    IEditorMainFrame IEditorMainFrame
    {
      get
      {
        return EditorMainFrame as IEditorMainFrame;
      }
    }
    public EditorMainFrameProxy(IFrame frame) : base(frame)
    {
      EditorMainFrame = frame as EditorMainFrame;
    }

    EditorSplitManager EditorSplitManager
    {
      get
      {
        return EditorMainFrame.EditorSplitManager as EditorSplitManager;
      }
    }

    public IFrame DockedEditor
    {
      get
      {
        return EditorMainFrame.DockedEditor;
      }
    }

    public bool IsMaximized
    {
      get
      {
        return EditorMainFrame.IsMaximized;
      }
    }

    public IEditorFrame FolderPortalFrame
    {
      get
      {
        return EditorMainFrame.FolderPortalFrame;
      }
    }

    public IEnumerable<IEditorFrame> AllEditors
    {
      get
      {
        return EditorMainFrame.AllEditors;
      }
    }

    public bool CheckEditorWithInstanceNameExists(string editorInstanceId)
    {
      return EditorMainFrame.CheckEditorWithInstanceNameExists(editorInstanceId);
    }

    public bool CheckEditorIsFloating(string editorInstanceId)
    {
      return EditorMainFrame.CheckEditorIsFloating(editorInstanceId);
    }

    public void EditorFullScreen(IEditorFrame editorFrame, bool fullSizeState)
    {
      IEditorMainFrame.EditorFullScreen(editorFrame, fullSizeState);
    }

    public void CloseEditor(IEditorFrame editorFrame)
    {
      IEditorMainFrame.CloseEditor(editorFrame);
    }

    public void Minimize(IEditorFrame frameToMinimize, bool minimize)
    {
      IEditorMainFrame.Minimize(frameToMinimize, minimize);
    }
  }
}
