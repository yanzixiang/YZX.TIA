
using Siemens.Automation.UI.Controls.WindowlessFramework;
using Siemens.Simatic.PlcLanguages.GraphEditor.View.UIElements;

namespace YZX.Tia.Proxies.Graph
{
  public class SequenceUIElementProxy
  {
    internal SequenceUIElement SequenceUIElement;

    public SequenceUIElementProxy(UIElement sequenceUIElement)
    {
      this.SequenceUIElement = sequenceUIElement as SequenceUIElement;
    }
  }
}