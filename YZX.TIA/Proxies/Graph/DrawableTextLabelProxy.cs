using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphEditor.View.DrawableElements;

namespace YZX.Tia.Proxies.Graph
{
  public class DrawableTextLabelProxy:DrawableBoxElementProxy
  {
    internal DrawableTextLabel DrawableTextLabel;

    internal DrawableTextLabelProxy(DrawableTextLabel label):base(label)
    {
      DrawableTextLabel = label;
    }
  }
}
