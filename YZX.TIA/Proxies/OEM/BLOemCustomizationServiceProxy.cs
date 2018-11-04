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
  public class BLOemCustomizationServiceProxy
  {
    internal BLOemCustomizationServiceDlc BLOemCustomizationServiceDlc;
    internal BLOemCustomizationService BLOemCustomizationService;

    public BLOemCustomizationServiceProxy(IDlc dlc)
    {
      BLOemCustomizationServiceDlc = dlc as BLOemCustomizationServiceDlc;
      if(BLOemCustomizationServiceDlc != null)
      {
        BLOemCustomizationService = Reflector.GetInstanceFieldByName(BLOemCustomizationServiceDlc,
          "m_BlOemCustomizationService",
          ReflectionWays.SystemReflection) as BLOemCustomizationService;
      }
    }
  }
}
