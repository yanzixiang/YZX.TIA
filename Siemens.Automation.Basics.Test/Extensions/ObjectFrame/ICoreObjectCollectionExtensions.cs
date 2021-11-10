using System;
using System.Collections.Generic;

using Siemens.Automation.ObjectFrame;

namespace YZX.Tia.Extensions.ObjectFrame
{
  public static class ICoreObjectCollectionExtensions
  {
    public static List<string> GetNames(this ICoreObjectCollection oc)
    {
      List<string> names = new List<string>();
      foreach(ICoreObject o in oc)
      {
        string name = o.GetObjectName();
        names.Add(name);
      }

      return names;
    }

    public static ICoreObject GetCoreObjectByName(this ICoreObjectCollection oc,string name)
    {
      foreach (ICoreObject o in oc)
      {
        if(o.GetObjectName() == name)
        {
          return o;
        }
      }
      return null;
    }
  }
}
