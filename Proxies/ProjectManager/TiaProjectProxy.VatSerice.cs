using System.Collections.Generic;

using Siemens.Automation.Basics;
using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.PlcLanguages.VatService;
using Siemens.Simatic.PlcLanguages.VatService.Navigator;
using Siemens.Simatic.HwConfiguration.BusinessLogic.Acf.Devices;
using Siemens.Simatic.PlcLanguages.VatService.Businesslogic;
using Siemens.Simatic.PlcLanguages.VatService.Views;

using YZX.Tia.Extensions;

namespace YZX.Tia.Proxies
{
  partial class TiaProjectProxy
  {
    private VatService m_VatService = null;
    public VatService VatService
    {
      get
      {
        if (m_VatService == null)
        {
          m_VatService = new VatService();
          IDlc dlc_VatService = m_VatService;
          dlc_VatService.PreDetach();
          dlc_VatService.Attach(ProjectWorkingContext);

          m_VatService.SetDebugService(DebugService);
          dlc_VatService.PostAttach();
        }
        return m_VatService;
      }
    }
    public VatServiceProxy VatServiceProxy
    {
      get
      {
        VatServiceProxy vsp = new VatServiceProxy(VatService);
        return vsp;
      }
    }
    #region VatDevice
    public IVatDevice GetVatDevice(ICoreObject controllerTarget)
    {
      return VatService.GetVatDevice(controllerTarget) as VatDevice;
    }
    public IVatDevice GetVatDevice(string str)
    {
      return VatService.GetVatDevice(str) as VatDevice;
    }

    internal VarTableViewModifyExtension VarTableViewModifyExtension
    {
      get
      {
        return ProjectWorkingContext.DlcManager.Load("PlcLanguages.VarTableViewModifyExtension") as VarTableViewModifyExtension;
      }
    }

    #endregion

    #region VatServiceNavigator
    internal VatServiceNavigator VatServiceNavigator
    {
      get
      {
        return VatService.Navigator as VatServiceNavigator;
      }
    }

    public List<IVarTableInfo> GetWatchTables(ICoreObject cpu)
    {
      if (this.VatService == null)
      {
        return null;
      }
      List<IVarTableInfo> vtiList = new List<IVarTableInfo>();
      IVarTableInfo[] tableArray = VatServiceNavigator.GetWatchTables(cpu);
      foreach (IVarTableInfo table in tableArray)
      {
        VarTableInfo vti = (VarTableInfo)table;
        vtiList.Add(vti);
      }
      return vtiList;
    }

    public ICoreObject GetTableCoreObjectByName(string tableName,ICoreObject cpu)
    {
      ICoreObject table = VatServiceNavigator.GetTableCoreObjectByName(tableName, cpu);
      return table;
    }

    public IVarTableInfo GetTable(string tableName,ICoreObject cpu)
    {
      IVarTableInfo ivti = VatServiceNavigator.GetTable(tableName, cpu);
      VarTableInfo vti = ivti as VarTableInfo;
      return vti;
    }

    public IVarTableInfo GetTableByCPUAndTableName(string cpuName,string tableName)
    {
      ICoreObject cpu = FindCPU(cpuName);
      IVarTableInfo vti = GetTable(tableName, cpu);
      return vti;
    }
    #endregion
  }
}
