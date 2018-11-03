using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.UI.Controls;
using Siemens.Simatic.PlcLanguages.BlockEditorFrame;
using Siemens.Simatic.PlcLanguages.GraphEditor.Frame;
using Siemens.Simatic.PlcLanguages.GraphEditor.View;

using Reflection;

namespace YZX.Tia.Proxies.Graph
{
  public class MainControlContainerProxy
  {
    internal MainControlContainer mainControlContainer;

    public MainControlContainerProxy(UserControl mainControlContainer)
    {
      this.mainControlContainer = mainControlContainer as MainControlContainer;
    }

    public AbstractGraphViewProxy CurrentView
    {
      get
      {
        return new AbstractGraphViewProxy(mainControlContainer.CurrentView);
      }
    }

    public GraphBlockEditorControlProxy GraphBlockEditorControl
    {
      get
      {
        GraphBlockEditorControl control = Reflector.GetInstancePropertyByName(mainControlContainer, 
          "GraphBlockEditorControl", 
          ReflectionWays.SystemReflection) as GraphBlockEditorControl;
        return new GraphBlockEditorControlProxy(control);
      }
    }

    public List<IUIControl> GetChildUIControls()
    {
      return mainControlContainer.GetChildUIControls();
    }

    public List<DetailedSequenceViewProxy> GetDetailedSequenceView()
    {

      List<DetailedSequenceViewProxy> list = new List<DetailedSequenceViewProxy>();
      foreach (var child in mainControlContainer.Controls)
      {
        if(child is DetailedSequenceView)
        {
          DetailedSequenceView view = child as DetailedSequenceView;
          DetailedSequenceViewProxy proxy = new DetailedSequenceViewProxy(view);
          list.Add(proxy);
        }
      }
      return list;
    }


  }
}
