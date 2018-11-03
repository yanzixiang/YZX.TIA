using System;

using Siemens.Automation.ProjectManager.Impl.Tia;

using YZX.Tia.Proxies;

using Reflection;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    TiaProjectManager TiaProjectManager
    {
      get
      {
        Type type = typeof(TiaProjectManagerDlc);
        TiaProjectManager TiaProjectManager =
          Reflector.RunStaticMethodByName(type, "CreateProjectManager", m_BusinessLogicApplicationContext)
          as TiaProjectManager;
        return TiaProjectManager;
      }
    }
    
    public TiaProjectManagerProxy TiaProjectManagerProxy
    {
      get
      {
        TiaProjectManagerProxy proxy = new TiaProjectManagerProxy(TiaProjectManager);
        return proxy;
      }
    }
  }
}
