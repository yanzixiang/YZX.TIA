using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices.OnlineService;

namespace YZX.Tia.Proxies.OnlineService
{
  public class LifelistDetailsQueueProxy
  {
    internal LifelistDetailsQueue LifelistDetailsQueue;
    internal LifelistDetailsQueueProxy(LifelistDetailsQueue queue)
    {
      LifelistDetailsQueue = queue;
    }
  }
}
