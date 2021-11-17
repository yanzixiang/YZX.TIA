using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices.OnlineService;
using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies.OnlineService
{
  public class LifelistNodeDetailsFactoryProxy
  {
    public static LifelistNodeDetailsProxy GetNodeDetails(ICoreObject node)
    {
      LifelistNodeDetails details = LifelistNodeDetailsFactory.GetNodeDetails(node);
      return new LifelistNodeDetailsProxy(details);
    }

    public static LifelistDetailsQueueProxy GetDetailsQueue(ICoreObject node)
    {
      var queue = Reflector.RunStaticMethodByName(typeof(LifelistNodeDetailsFactory),
        "GetDetailsQueue",
        ReflectionWays.SystemReflection,
        node) as LifelistDetailsQueue;

      return new LifelistDetailsQueueProxy(queue);
    }

  }
}
