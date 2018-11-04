using System.ComponentModel;

using Siemens.Automation.Basics.Synchronizer;

namespace YZX.Tia.Proxies
{
  public class ThreadSynchronizerPerformanceMeasurementProxy
  {
    private ThreadSynchronizerPerformanceMeasurement tspm;

    public ThreadSynchronizerPerformanceMeasurementProxy(ThreadSynchronizerProxy tsp)
      :this(tsp.Synchronize as ISynchronizeInvoke)
    {
    }
    public ThreadSynchronizerPerformanceMeasurementProxy(ISynchronizeInvoke isi)
    {
      ThreadSynchronizer ts = isi as ThreadSynchronizer;
      tspm = new ThreadSynchronizerPerformanceMeasurement(ts, ts);
    }

    public void DumpStatistics()
    {
      tspm.DumpStatistics();
    }
  }
}
