using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices.UI.OnlineCommon;

namespace YZX.Tia.Proxies.OnlineService
{
  public class PGAddressHelperProxy
  {
    internal PGAddressHelper PGAddressHelper;

    public PGAddressHelperProxy(object helper)
    {
      PGAddressHelper = helper as PGAddressHelper;
    }



    public bool AddPGAddressWithDialogNotCheckingProjectIP(bool allowSetTemporaryAddress)
    {
      return PGAddressHelper.AddPGAddressWithDialogNotCheckingProjectIP(allowSetTemporaryAddress);
    }

    internal bool AddPGAddressWithDialogNotCheckingProjectIP(bool allowSetTemporaryAddress, 
      List<OnlineCommonNode> nodes)
    {
      return PGAddressHelper.AddPGAddressWithDialogNotCheckingProjectIP(allowSetTemporaryAddress, nodes);
    }

    internal bool RequiresNewPGAddress(ICoreObject boardConfiguration, 
      OnlineCommonNode node, 
      bool allowTemporaryTargetAddress)
    {
      return PGAddressHelper.RequiresNewPGAddress(boardConfiguration, node, allowTemporaryTargetAddress);
    }

    internal bool SetNewPGAddressOfflineRequired(List<OnlineCommonNode> projectNodes, 
      ICoreObject boardConfiguration)
    {
      return PGAddressHelper.SetNewPGAddressOfflineRequired(projectNodes, boardConfiguration);
    }

    internal bool AddPGAddressWithDialogIncludeCheckingProjectIP(OnlineCommonNode node, 
      List<OnlineCommonNode> projectNodes, 
      ICoreObject boardConfiguration)
    {
      return PGAddressHelper.AddPGAddressWithDialogIncludeCheckingProjectIP(node, projectNodes, boardConfiguration);
    }


  }
}
