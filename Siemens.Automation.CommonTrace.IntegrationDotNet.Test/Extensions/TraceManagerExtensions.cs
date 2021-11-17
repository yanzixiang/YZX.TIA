using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.CommonTrace.TraceIntegrationDotNet;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia
{
  public class TraceManagerExtensions
  {
    public static ITraceObserver GetTrace(string componentName, string className)
    {
      var manager = TraceManager.Instance;
      var TracerStore = Reflector.GetInstanceFieldByName(TraceManager.Instance,"m_TracerStore") 
        as Dictionary<string, IComponentTrace>;
      foreach(var k in TracerStore.Keys)
      {
        if(k== componentName)
        {
          HierarchyName hierarchyName = new HierarchyName(componentName, className, null);
          var componentTrace = TracerStore[k];
          var trace = componentTrace.GetTracerForClass(hierarchyName);
          return trace as ITraceObserver;
        }
      }
      return null;
    }
  }
}
