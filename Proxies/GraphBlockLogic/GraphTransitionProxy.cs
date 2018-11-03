using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphBlockLogic;

namespace YZX.Tia.Proxies.GraphBlockLogic
{
  public class GraphTransitionProxy
  {
    internal GraphTransition GraphTransition;

    internal GraphTransitionProxy(GraphTransition transition)
    {
      GraphTransition = transition;
    }
  }
}
