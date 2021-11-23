using System;
using System.Collections.Generic;

using Siemens.Automation.Basics;

using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Dlc
{
  public static class DlcManagerExtensions
  {
    public static IDlcLifetimeManager GetDlcLifetimeManager(this IDlcManager manager)
    {
      var lifetimeManager = Reflector.GetInstanceFieldByName(manager, "m_DlcLifetimeManager")
        as IDlcLifetimeManager;
      return lifetimeManager;
    }
  }
}
