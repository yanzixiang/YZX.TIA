using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphEditor.View.DrawableElements;

namespace YZX.Tia.Proxies.Graph
{
  public class UIElementWrapperProxy : DrawableBoxElementProxy
  {
    internal UIElementWrapper UIElementWrapper;

    internal UIElementWrapperProxy(UIElementWrapper wrapper)
      : base(wrapper)
    {
      UIElementWrapper = wrapper as UIElementWrapper;
    }
  }
}
