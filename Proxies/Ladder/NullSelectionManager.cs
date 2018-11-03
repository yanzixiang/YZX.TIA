using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View;
using Siemens.Simatic.PlcLanguages.FLGraphicEditor.View.Selection;

namespace YZX.Tia.Proxies.Ladder
{
  internal class NullSelectionManager: DefaultSelectionManager
  {
    internal NullSelectionManager(FLGView flgView, GraphicManager grManager) 
      :base(flgView,grManager)
    {
    }


  }
}
