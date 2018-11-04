using Siemens.Automation.FrameApplication.WindowManager;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class HierarchyFrameMetaProxy:FrameBaseMetaProxy
  {
    HierarchyFrameMeta HierarchyFrameMeta;

    internal static HierarchyFrameMetaProxy ToProxy(HierarchyFrameMeta meta)
    {
      return new HierarchyFrameMetaProxy(meta);
    }
    internal HierarchyFrameMetaProxy(HierarchyFrameMeta meta):base(meta)
    {
      HierarchyFrameMeta = meta;
    }

    public bool Singleton
    {
      get
      {
        return HierarchyFrameMeta.Singleton;
      }
    }

    public LayoutBehavior Layout
    {
      get
      {
        return HierarchyFrameMeta.Layout;
      }
    }

    public bool UserClose
    {
      get
      {
        return HierarchyFrameMeta.UserClose;
      }
    }

    public bool ShowCaption
    {
      get
      {
        return HierarchyFrameMeta.ShowCaption;
      }
    }
  }
}
