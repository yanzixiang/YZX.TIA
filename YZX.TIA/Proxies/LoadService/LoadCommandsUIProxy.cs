using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Basics;
using Siemens.Automation.DomainServices.LoadService;
using Siemens.Automation.DomainServices.UI.LoadService;

namespace YZX.Tia.Proxies.LoadService
{
  public class LoadCommandsUIProxy
  {
    internal LoadCommandsUI LoadCommandsUI;

    public LoadCommandsUIProxy(IDlc dlc)
    {
      LoadCommandsUI = dlc as LoadCommandsUI;
    }


  }
}
