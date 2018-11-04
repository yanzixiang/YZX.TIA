using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.FrameApplication;
using Siemens.Automation.Basics.Browsing;
using Siemens.Automation.Basics;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class RootCollectionHolderProxy
  {
    internal RootCollectionHolder RootCollectionHolder;

    internal IRootObjectHostService IRootObjectHostService
    {
      get
      {
        return RootCollectionHolder as IRootObjectHostService;
      }
    }

    internal RootCollectionHolderProxy(RootCollectionHolder holder)
    {
      RootCollectionHolder = holder;
    }

    public IBrowsableCollection RootObjectCollection
    {
      get
      {
        return RootCollectionHolder.RootObjectCollection;
      }
    }

    public IWorkingContext CollectionWorkingContext
    {
      get
      {
        return RootCollectionHolder.CollectionWorkingContext;
      }
    }

    public IDictionary<int, BrowsableCollection> CollectionPositionList
    {
      get
      {
        return RootCollectionHolder.CollectionPositionList;
      }
    }

    public IBrowsableCollection GetRootObjectCollection(IWorkingContext workingContext)
    {
      return IRootObjectHostService.GetRootObjectCollection(workingContext);
    }

    public IBrowsableCollection GetLowestPrioRootObjectCollection(IWorkingContext workingContext)
    {
      return IRootObjectHostService.GetLowestPrioRootObjectCollection(workingContext);
    }





  }
}
