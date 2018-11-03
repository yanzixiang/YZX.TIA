using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Simatic.PlcLanguages.GraphEditor.View.DrawableElements;
using Siemens.Simatic.PlcLanguages.GraphEditor.View.DrawableElements.DrawableLanguageModules;

namespace YZX.Tia.Proxies.Graph
{
  public class DrawableLanguageModuleProxy : UIElementWrapperProxy
  {
    internal DrawableLanguageModule DrawableLanguageModule;

    internal DrawableLanguageModuleProxy(DrawableLanguageModule wrapper)
      : base(wrapper)
    {
      DrawableLanguageModule = wrapper as DrawableLanguageModule;
    }
  }
}

