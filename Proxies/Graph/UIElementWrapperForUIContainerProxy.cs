using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphEditor.View.DrawableElements;

namespace YZX.Tia.Proxies.Graph
{
  public class UIElementWrapperForUIContainerProxy:SelectableUIElementWrapperProxy
  {
    internal UIElementWrapperForUIContainer UIElementWrapperForUIContainer;

    internal UIElementWrapperForUIContainerProxy(UIElementWrapperForUIContainer container)
      :base(container)
    {
      UIElementWrapperForUIContainer = container as UIElementWrapperForUIContainer;
    }
  }
}
