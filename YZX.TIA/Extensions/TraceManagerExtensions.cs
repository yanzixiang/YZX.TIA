using System;
using System.Collections.Generic;

using Siemens.Automation.CommonTrace.TraceIntegrationDotNet;

using Reflection;

using YZX.Tia.Proxies;

namespace YZX.Tia.Extensions
{
  public static class TraceManagerExtensions
  {
    public static List<string> GetTracerNames()
    {
      List<string> names = new List<string>();

      TraceManager tm = TraceManager.Instance as TraceManager;
      if (tm != null)
      {

        Dictionary<string, IComponentTrace> m_TracerStore =
          Reflector.GetInstanceFieldByName(tm, "m_TracerStore", ReflectionWays.SystemReflection)
          as Dictionary<string, IComponentTrace>;

        foreach (var kct in m_TracerStore)
        {
          names.Add(kct.Key);
        }

      }
      return names;
    }

    public static ITraceProxy GetTracer(string traceName)
    {
      ITraceManager tm = TraceManager.Instance as ITraceManager;
      ITrace trace = tm.CreateTracer(traceName);
      ITraceProxy traceProxy = new ITraceProxy(trace);
      return traceProxy;
    }

    public static List<ITraceProxy> GetTracers()
    {
      List<ITraceProxy> tracers = new List<ITraceProxy>();
      List<string> names = GetTracerNames();
      foreach(string name in names)
      {
        ITraceProxy proxy = GetTracer(name);
        tracers.Add(proxy);
      }
      return tracers;
    }
  }
}
