using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.FLGraphicEditor;
using Siemens.Simatic.PlcLanguages.GraphEditor.View.DrawableElements;

using YZX.Tia.Extensions.Graph;

namespace YZX.Tia.Proxies.Graph
{
  public class DrawableElementProxy
  {
    internal DrawableElement DrawableElement;



    internal DrawableElementProxy(DrawableElement element)
    {
      this.DrawableElement = element;
    }

    public List<DrawableElementProxy> ElementList
    {
      get
      {
        List<DrawableElementProxy> list = new List<DrawableElementProxy>();
        foreach(var element in DrawableElement.ElementList)
        {
          var proxy = element.ToProxy();
          list.Add(proxy); 
        }
        return list;
      }
    }

    


  }
}
