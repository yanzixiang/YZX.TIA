using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.TisPlusServer;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static class TisPlusServerExtensions
  {
    public static void ReplaceTracer(this Server server)
    {
      ConsoleTrace ct = new ConsoleTrace();
      TisLogger tl = new TisLogger(ct);

      Reflector.SetInstanceFieldByName(server, "m_tisTracer", 
        tl, ReflectionWays.SystemReflection);
    }
  }
}
