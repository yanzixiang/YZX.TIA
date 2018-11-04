using System;

using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.WindowManager;

namespace YZX.Tia.Proxies.FrameApplication
{
  partial class WindowManagerProxy
  {

    public event EventHandler<AdditionalFramesEventArgs> FrameCreated
    {
      add
      {
        WindowManager.FrameCreated += value;
      }
      remove
      {
        WindowManager.FrameCreated -= value;
      }
    }

    public event EventHandler<FrameAddEventArgs> FrameAdding
    {
      add
      {
        WindowManager.FrameAdding += value;
      }
      remove
      {
        WindowManager.FrameAdding -= value;
      }
    }

    public event EventHandler<FrameAddEventArgs> FrameAdded
    {
      add
      {
        WindowManager.FrameAdded += value;
      }
      remove {
        WindowManager.FrameAdded -= value;
      }
    }

    public event EventHandler<CancelFrameEventArgs> FrameClosing
    {
      add
      {
        WindowManager.FrameClosing += value;
      }
      remove
      {
        WindowManager.FrameClosing -= value;
      }
    }

    public event EventHandler<FrameEventArgs> FrameClosed
    {
      add
      {
        WindowManager.FrameClosed += value;
      }
      remove
      {
        WindowManager.FrameClosed -= value;
      }
    }

    public event EventHandler InitializationCompleted
    {
      add
      {
        WindowManager.InitializationCompleted += value;
      }
      remove
      {
        WindowManager.InitializationCompleted -= value;
      }
    }

    public event EventHandler<FrameCreatingEventArgs> FrameCreating
    {
      add
      {
        WindowManager.FrameCreating += value;
      }
      remove
      {
        WindowManager.FrameCreating -= value;
      }
    }
  }
}