using System.Collections.Generic;

using Siemens.Simatic.PlcLanguages.PLInterface;
using Siemens.Simatic.PlcLanguages.VatService.Navigator;
using Siemens.Simatic.HwConfiguration.BusinessLogic.Acf.Devices;

namespace YZX.Tia.Extensions
{
  public static class VarTableInfoExtensions
  {
    public static List<S7Any> GetS7AnyList(this IVarTableInfo vti)
    {
      List<S7Any> s7anyList = new List<S7Any>();
      foreach(VarLineInfo vli in vti.Lines)
      {
        //byte[] cap = vli.ClassicAnyPointer;
        //if (cap != null)
        //{
        //  if (cap.Length == 10)
        //  {
        //    S7Any s7any = cap.ToS7Any();
        //    s7anyList.Add(s7any);
        //  }
        //}
        S7Any? s7any = null;
        // s7any = vli.S7Any;
        if(s7any.HasValue)
        {
          s7anyList.Add(s7any.Value);
        }
      }
      return s7anyList;
    }
  }
}
