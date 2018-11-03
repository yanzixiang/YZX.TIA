using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View.Accessibility;

namespace YZX.Tia.Proxies.Ladder
{
  public class FLGViewAccessibleObjectProxy
  {
    internal IFLGAccessibleObject iFLGAccessibleObject;

    internal FLGViewAccessibleObjectProxy(IFLGAccessibleObject iFLGAccessibleObject)
    {
      this.iFLGAccessibleObject = iFLGAccessibleObject;
    }

    internal System.Windows.Forms.AccessibleObject GetAccessibleChildObject(IGraphicObject graphicObject)
    {
      return iFLGAccessibleObject.GetAccessibleChildObject(graphicObject);
    }

    public System.Windows.Forms.AccessibleObject GetAccessibleChildObject(GraphicObjectProxy graphicObject)
    {
      return GetAccessibleChildObject(graphicObject.graphicObject);
    }
  }
}
