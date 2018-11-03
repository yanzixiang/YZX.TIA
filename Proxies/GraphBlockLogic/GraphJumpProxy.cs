using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphBlockLogic;

namespace YZX.Tia.Proxies.GraphBlockLogic
{
  public class GraphJumpProxy
  {
    internal GraphJump GraphJump;

    internal GraphJumpProxy(GraphJump jump)
    {
      GraphJump = jump;
    }

      
  }
}
