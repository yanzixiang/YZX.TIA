using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.FrameApplication;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class RootObjectHostServiceProxy
  {
    internal RootObjectHostService RootObjectHostService;

    internal RootObjectHostServiceProxy(RootObjectHostService service)
    {
      RootObjectHostService = service;
    }

    public RootCollectionHolderProxy RootCollectionHolder
    {
      get
      {
        return new RootCollectionHolderProxy(RootObjectHostService.RootCollectionHolder);
      }
    }


  }
}
