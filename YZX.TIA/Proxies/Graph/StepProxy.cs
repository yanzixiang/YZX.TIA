using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphEditor.Model.GraphElements;

namespace YZX.Tia.Proxies.Graph
{
  public class StepProxy:LogicalElementProxy
  {
    Step Step;

    internal StepProxy(Step step):base(step)
    {
      Step = step;
    }
  }
}
