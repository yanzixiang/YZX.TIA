using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

using Siemens.Automation.ObjectFrame;

using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.TagService;

using YZX.Tia.Extensions;

namespace YZX.Tia.Proxies
{
  public class RootTagCollectionProxy
  {
    RootTagCollection RTC;
    public ISynchronizeInvoke UsingSynchronizer;
    public RootTagCollectionProxy(IList rtc, ISynchronizeInvoke synchronizer = null)
    {
      RTC = rtc as RootTagCollection;
      UsingSynchronizer = synchronizer;
    }

    public InternalCoreObjectCollectionProxy CoreObjectCollection
    {
      get
      {
        return TiaStarter.RunInSynchronizer(UsingSynchronizer,
          (Func<InternalCoreObjectCollectionProxy>)(() =>
          {
            InternalCoreObjectCollectionProxy icocp = 
              new InternalCoreObjectCollectionProxy(RTC.CoreObjectCollection,UsingSynchronizer);
            return icocp;
          })) as InternalCoreObjectCollectionProxy;
      }
    }

    public List<IBLTag> Tags
    {
      get
      {
        return TiaStarter.RunInSynchronizer(UsingSynchronizer,
          (Func<List<IBLTag>>)(() =>
          {
            List<IBLTag> tags = new List<IBLTag>();
            for(int i = 0;i < CoreObjectCollection.Count; i++)
            {
              ICoreObject coreObject = CoreObjectCollection[i];
              IBLTag tag = coreObject.ToBLTag();
              tags.Add(tag);
            }
            return tags;
          })) as List<IBLTag>;

      }
    }
  }
}
