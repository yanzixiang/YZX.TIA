using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Basics;
using Siemens.Automation.CommonServices.Internal.OemCustomization;

using Reflection;

namespace YZX.Tia.Proxies.OEM
{
  public class UIOemCustomizationServiceProxy
  {
    internal UIOemCustomizationServiceDlc UIOemCustomizationServiceDlc;
    internal UIOemCustomizationService UIOemCustomizationService;

    public UIOemCustomizationServiceProxy(IDlc dlc)
    {
      UIOemCustomizationServiceDlc = dlc as UIOemCustomizationServiceDlc;
      if(UIOemCustomizationServiceDlc != null)
      {
        UIOemCustomizationService = Reflector.GetInstanceFieldByName(UIOemCustomizationServiceDlc, 
          "m_UiOemCustomizationService",
          ReflectionWays.SystemReflection) as UIOemCustomizationService;
      }
    }
  }
}
