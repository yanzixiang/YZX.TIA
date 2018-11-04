using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphEditor.View.DrawableElements;

namespace YZX.Tia.Proxies.Graph
{
  public class DrawableLangModTogglerDSVProxy:DrawableBoxElementProxy
  {
    internal DrawableLangModTogglerDSV DrawableLangModTogglerDSV;

    internal DrawableLangModTogglerDSVProxy(DrawableLangModTogglerDSV dsv)
      :base(dsv)
    {
      DrawableLangModTogglerDSV = dsv as DrawableLangModTogglerDSV;
    }


  }
}
