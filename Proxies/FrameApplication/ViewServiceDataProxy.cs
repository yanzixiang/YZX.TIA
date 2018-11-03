using System.Collections;
using System.Drawing;

using Siemens.Automation.FrameApplication.ViewManager;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class ViewServiceDataProxy
  {
    ViewServiceData ViewServiceData;
    internal ViewServiceDataProxy(ViewServiceData data)
    {
      ViewServiceData = data;
    }

    public string ViewId
    {
      get
      {
        return ViewServiceData.ViewId;
      }
    }

    public string ViewFrame
    {
      get
      {
        return ViewServiceData.ViewFrame;
      }
    }

    public string ViewDlc
    {
      get
      {
        return ViewServiceData.ViewDlc;
      }
    }

    public string DomainLogicDlc
    {
      get
      {
        return ViewServiceData.DomainLogicDlc;
      }
    }

    public string LoadInfo
    {
      get
      {
        return ViewServiceData.LoadInfo;
      }
    }

    public bool IsEditor
    {
      get
      {
        return ViewServiceData.IsEditor;
      }
    }

    public bool IsActive
    {
      get
      {
        return ViewServiceData.IsActive;
      }
    }

    public ArrayList SelectionSource
    {
      get
      {
        return ViewServiceData.SelectionSource;
      }
    }

    public ArrayList SelectionTarget
    {
      get
      {
        return ViewServiceData.SelectionTarget;
      }
    }

    public Size MinSize
    {
      get
      {
        return ViewServiceData.MinSize;
      }
    }

    public Size MaxSize
    {
      get
      {
        return ViewServiceData.MaxSize;
      }
    }

    public string ToolbarID
    {
      get
      {
        return ViewServiceData.ToolbarID;
      }
    }
  }
}
