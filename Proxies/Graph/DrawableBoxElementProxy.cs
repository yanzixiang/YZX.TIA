using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siemens.Simatic.PlcLanguages.GraphEditor.View.DrawableElements;

namespace YZX.Tia.Proxies.Graph
{
  public class DrawableBoxElementProxy : DrawableElementProxy
  {
    internal DrawableBoxElement box;

    internal DrawableBoxElementProxy(DrawableBoxElement box)
      :base(box)
    {
      this.box = box;
    }
  }
}
