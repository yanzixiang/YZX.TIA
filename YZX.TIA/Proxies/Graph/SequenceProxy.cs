using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Basics;
using Siemens.Simatic.PlcLanguages.GraphEditor.Model.GraphElements;

namespace YZX.Tia.Proxies.Graph
{
  public class SequenceProxy
  {
    Sequence Sequence;

    internal SequenceProxy(Sequence sequence)
    {
      Sequence = sequence;
    }

    public StepProxy GetFirstStep()
    {
      Step step = Sequence.GetFirstStep();
      return new StepProxy(step);
    }

    public string GetTitle()
    {
      return Sequence.GetTitle();
    }

    public MultiLanguageString GetDefaultTitle()
    {
      return Sequence.GetDefaultTitle();
    }

    public List<LogicalElementProxy> GetAllContainedElements()
    {
      List<LogicalElement> list = Sequence.GetAllContainedElements();
      List<LogicalElementProxy> proxies = new List<LogicalElementProxy>();
      foreach(LogicalElement le in list)
      {
        LogicalElementProxy proxy = new LogicalElementProxy(le);
        proxies.Add(proxy);
      }
      return proxies;
    }
  }
}
