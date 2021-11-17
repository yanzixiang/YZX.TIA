using System;
using System.Collections.Generic;

using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.WindowManager;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class EditorFrameProxy:HierarchyFrameProxy
  {
    EditorFrame EditorFrame;

    public IEditorFrame IEditorFrame
    {
      get
      {
        return EditorFrame;
      }
    }

    IEditorFrameInternal IEditorFrameInternal
    {
      get
      {
        return EditorFrame;
      }
    }
    public EditorFrameProxy(IFrame frame) : base(frame)
    {
      EditorFrame = frame as EditorFrame;
    }

    public bool HideTabHeader
    {
      get
      {
        return IEditorFrame.HideTabHeader;
      }
    }

    public EditorTitle Title
    {
      get
      {
        return IEditorFrame.Title;
      }
    }

    public bool IsPinned
    {
      get
      {
        return IEditorFrameInternal.IsPinned;
      }
    }

    public ApplicationViewMode ViewModeAttachedTo
    {
      get
      {
        return IEditorFrameInternal.ViewModeAttachedTo;
      }
    }

    public IEditorStateService EditorStateService
    {
      get
      {
        return IEditorFrameInternal.EditorStateService;
      }
    }

    public bool IsFloating
    {
      get
      {
        return IEditorFrameInternal.IsFloating;
      }
    }

    public bool IsMinimized
    {
      get
      {
        return IEditorFrameInternal.IsMinimized;
      }
    }

    public void IndicateStatus(string function, bool state)
    {
      Type t = typeof(ControlBoxFunction);
      ControlBoxFunction f = (ControlBoxFunction)Enum.Parse(t, function);
      EditorFrame.IndicateStatus(f, state);
    }

    public object EditorViewModeProvider
    {
      get
      {
        return Reflector.GetInstanceFieldByName(EditorFrame,
          "m_EditorViewModeProvider", 
          ReflectionWays.SystemReflection);
      }
    }

    internal IEditorWorkedOnObjectService EditorWorkedOnObjectService
    {
      get
      {
        return Reflector.GetInstanceFieldByName(EditorFrame,
          "m_EditorWorkedOnObjectService", 
          ReflectionWays.SystemReflection) 
          as IEditorWorkedOnObjectService;
      }
    }

    public object WorkedOnObject
    {
      get
      {
        return EditorWorkedOnObjectService.WorkedOnObject;
      }
      set
      {
        EditorWorkedOnObjectService.WorkedOnObject = value;
      }
    }
  }
}
