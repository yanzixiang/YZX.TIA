using System;
using System.Collections;

using Siemens.Simatic.PlcLanguages.BlockLogic.Online.Plus;
using Siemens.Automation.OMSPlus.Managed;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.Basics;

namespace YZX.Tia.Proxies.BlockLogic
{
  public class OMSpFactoryProxy
  {
    OMSpFactory OMSpFactory;

    public OMSpFactoryProxy(ClientSession clientSession, 
      IWorkingContext workingContext, 
      ICoreObject controllerTarget)
    {
      OMSpFactory = new OMSpFactory(clientSession, workingContext, controllerTarget);
    }

    public ICollection GetTrimmerOnlineBlocks()
    {
      return OMSpFactory.GetTrimmerOnlineBlocks();
    }

    public ICollection GetTrimmerOnlineDBs()
    {
      return OMSpFactory.GetTrimmerOnlineDBs();
    }
  }
}
