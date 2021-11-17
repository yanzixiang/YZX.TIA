using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Basics;
using Siemens.Automation.UI.Controls;
using Siemens.Automation.FrameApplication;
using Siemens.Automation.FrameApplication.StatusBar;
using Siemens.Automation.FrameApplication.TaskCards;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class TaskCardServiceProxy
  {
    internal TaskCardService TaskCardService;

    public TaskCardServiceProxy(ITaskCardService dlc)
    {
      TaskCardService = dlc as TaskCardService;
    }
  }
}
