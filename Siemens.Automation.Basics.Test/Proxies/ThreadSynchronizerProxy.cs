using System;
using System.Threading;
using System.ComponentModel;

using Siemens.Automation.Basics.Synchronizer;
using Siemens.Automation.UI.Controls;
using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies
{
  public class ThreadSynchronizerProxy
  {
    ThreadSynchronizer TS;

    public ISynchronizer Synchronize
    {
      get
      {
        return TS as ISynchronizer;
      }
    }

    public ThreadSynchronizerProxy(ISynchronizeInvoke isi)
    {
      ThreadSynchronizer ts = isi as ThreadSynchronizer;
      TS = ts;
    }

    public void SetMainThread(Thread thread)
    {
      Reflector.RunInstanceMethodByName(
        TS, 
        "SetMainThread", 
        ReflectionWays.SystemReflection, 
        thread);
    }

    public event EventHandler Runed;

    public void Run(Form f= null)
    {
      if(Synchronize == null)
      {
        return;
      }
      if (Synchronize.IsOperational)
      {

      }
      else
      {
        if(f == null)
        {
          Synchronize.Run();
        }
        else
        {
          Synchronize.Run(f);
        }
        Runed(this, null);
      }
    }
  }
}
