using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphBlockLogic;

namespace YZX.Tia.Proxies.GraphBlockLogic
{
  public class GraphBranchProxy
  {
    GraphBranch GraphBranch;

    internal GraphBranchProxy(GraphBranch branch)
    {
      GraphBranch = branch;
    }
  }
}
