using Siemens.Simatic.PlcLanguages.FLGraphicEditor.Logic;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View.UserInteraction;

namespace YZX.Tia.Proxies.Ladder
{
  public class GraphicObjectProxy
  {
    internal GraphicObject graphicObject;

    public GraphicObjectProxy(object graphicObject)
    {
      this.graphicObject = graphicObject as GraphicObject;
    }

    public Element LogicalObject
    {
      get
      {
        return graphicObject.LogicalObject;
      }
    }

    public bool SupportEdit
    {
      get
      {
        IEditFieldProvider provider = graphicObject as IEditFieldProvider;
        return provider != null;
      }
    }

    public IFLGEditBoxHandler EditBoxHandler {
      get
      {
        if (SupportEdit)
        {
          IEditFieldProvider provider = graphicObject as IEditFieldProvider;
          return provider.EditBoxHandler;
        }
        return null;
      }
    }
  }
}