using System.ComponentModel;

using Siemens.Automation.ObjectFrame;

namespace YZX.Tia.Proxies
{
  public class InternalCoreObjectCollectionProxy
  {
    InternalCoreObjectCollection ICOC;
    public ISynchronizeInvoke UsingSynchronizer;
    public InternalCoreObjectCollectionProxy(ICoreObjectCollection icoc, ISynchronizeInvoke synchronizer = null)
    {
      ICOC = icoc as InternalCoreObjectCollection;
      UsingSynchronizer = synchronizer;
    }

    public ICoreObject this[int index]
    {
      get
      {
        return TiaStarter.RunInSynchronizer(UsingSynchronizer,
          () =>
          {
            if (index <= ICOC.Count - 1)
            {
              return ICOC[index] as ICoreObject;
            }
            else
            {
              return null;
            }

          }) as ICoreObject;
      }
    }

    public int Count
    {
      get
      {
        return ICOC.Count;
      }
    }

  }
}
