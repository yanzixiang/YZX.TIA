using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphEditor.View.DrawableElements;

namespace YZX.Tia.Proxies.Graph
{
  public class SelectableUIElementWrapperProxy:UIElementWrapperProxy
  {
    internal SelectableUIElementWrapper SelectableUIElementWrapper;

    internal SelectableUIElementWrapperProxy(SelectableUIElementWrapper wrapper)
      :base(wrapper)
    {
      SelectableUIElementWrapper = wrapper as SelectableUIElementWrapper;
    }
  }
}
