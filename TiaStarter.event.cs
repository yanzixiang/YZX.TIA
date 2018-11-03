using System;

using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.WindowManager;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    #region IWindowManagerInternal
    internal event EventHandler<ApplicationViewModeChangedEventArgs> ApplicationViewModeChanged {
      add {
        this.WindowManager.ApplicationViewModeChanged += value;
      }
      remove {
        this.WindowManager.ApplicationViewModeChanged -= value;
      }
    }
    public event EventHandler<FrameAddEventArgs> FrameAdded {
      add {
        this.WindowManager.FrameAdded += value;
      }
      remove {
        this.WindowManager.FrameAdded -= value;
      }
    }
    public event EventHandler<FrameEventArgs> FrameClosed {
      add {
        this.WindowManager.FrameClosed += value;
      }
      remove {
        this.WindowManager.FrameClosed -= value;
      }
    }
    public event EventHandler<CancelFrameEventArgs> FrameClosing {
      add {
        this.WindowManager.FrameClosing += value;
      }
      remove {
        this.WindowManager.FrameClosing -= value;
      }
    }
    public event EventHandler<AdditionalFramesEventArgs> FrameCreated
    {
      add {
        this.WindowManager.FrameCreated += value;
      }
      remove {
        this.WindowManager.FrameCreated -= value;
      }
    }
    public event EventHandler<FrameCreatingEventArgs> FrameCreating
    {
      add {
        this.WindowManager.FrameCreating += value;
      }
      remove {
        this.WindowManager.FrameCreating -= value;
      }
    }
    public event EventHandler InitializationCompleted
    {
      add {
        this.WindowManager.InitializationCompleted += value;
      }
      remove {
        this.WindowManager.InitializationCompleted -= value;
      }
    }
    #endregion
  }
}
