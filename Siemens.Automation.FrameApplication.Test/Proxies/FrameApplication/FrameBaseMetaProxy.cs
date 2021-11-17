using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Siemens.Automation.Basics;
using Siemens.Automation.FrameApplication.WindowManager;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class FrameBaseMetaProxy
  {
    FrameBaseMeta FrameBaseMeta;

    internal static FrameBaseMetaProxy ToProxy(FrameBaseMeta meta)
    {
      if(meta is HierarchyFrameMeta)
      {
        return HierarchyFrameMetaProxy.ToProxy(meta as HierarchyFrameMeta);
      }
      return new FrameBaseMetaProxy(meta);
    }
    internal FrameBaseMetaProxy(FrameBaseMeta meta)
    {
      FrameBaseMeta = meta;
    }

    public string ParentId
    {
      get
      {
        return FrameBaseMeta.ParentId;
      }
    }

    public string Id
    {
      get
      {
        return FrameBaseMeta.Id;
      }
    }

    public Size Size
    {
      get
      {
        return FrameBaseMeta.Size;
      }
    }

    public MultiLanguageString Caption
    {
      get
      {
        return FrameBaseMeta.Caption;
      }
    }

    public MultiLanguageString ShortCaption
    {
      get
      {
        return FrameBaseMeta.ShortCaption;
      }
    }

    public MultiLanguageString Name
    {
      get
      {
        return FrameBaseMeta.Name;
      }
    }

    public bool SplitterTopTransparent
    {
      get
      {
        return FrameBaseMeta.SplitterTopTransparent;
      }
    }

    public DockStyle Dock
    {
      get
      {
        return FrameBaseMeta.Dock;
      }
    }

    public bool CanCollapse
    {
      get
      {
        return FrameBaseMeta.CanCollapse;
      }
    }

    public bool Collapsed
    {
      get
      {
        return FrameBaseMeta.Collapsed;
      }
    }

    public int Index
    {
      get
      {
        return FrameBaseMeta.Index;
      }
    }

    public string[] ToolbarIds
    {
      get
      {
        return FrameBaseMeta.ToolbarIds;
      }
    }

    public UserResizableStyle UserResizable
    {
      get
      {
        return FrameBaseMeta.UserResizable;
      }
    }

    public Icon Icon
    {
      get
      {
        return FrameBaseMeta.Icon;
      }
    }

    public bool IgnorePersist
    {
      get
      {
        return FrameBaseMeta.IgnorePersist;
      }
    }

    public List<string> ShortcutIds
    {
      get
      {
        return FrameBaseMeta.ShortcutIds;
      }
    }

    public FrameBackground Background
    {
      get
      {
        return FrameBaseMeta.Background;
      }
    }
  }
}
