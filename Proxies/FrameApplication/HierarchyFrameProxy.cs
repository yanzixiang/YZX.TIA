using System;
using System.Collections.Generic;

using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.WindowManager;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class HierarchyFrameProxy:FrameBaseProxy
  {
    HierarchyFrame HierarchyFrame;
    IHierarchyFrame IHierarchyFrame
    {
      get
      {
        return HierarchyFrame as IHierarchyFrame;
      }
    }

    public new static HierarchyFrameProxy ToProxy(IFrame frame)
    {
      if (frame is ApplicationFrame)
      {
        return new ApplicationFrameProxy(frame);
      }
      if (frame is EditorMainFrame)
      {
        return new EditorMainFrameProxy(frame);
      }
      if (frame is EditorFrame)
      {
        return new EditorFrameProxy(frame);
      }
      return new HierarchyFrameProxy(frame);
    }

    public HierarchyFrameProxy(IFrame frame) : base(frame)
    {
      HierarchyFrame = frame as HierarchyFrame;
    }

    public List<FrameBaseProxy> ChildFramesCompleteList
    {
      get
      {
        List<FrameBase> frames = new List<FrameBase>(HierarchyFrame.ChildFramesCompleteList);
        return frames.ConvertAll(new Converter<FrameBase, FrameBaseProxy>(ToProxy));
      }
    }
  }
}
