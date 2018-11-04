using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.DomainServices.UI.OnlineCommon;

namespace YZX.Tia.Proxies
{
  public class LifeListDialogProxy
  {
    internal LifeListDialog LifeListDialog;

    internal LifeListDialogProxy(LifeListDialog dialog)
    {
      LifeListDialog = dialog;
    }

    public event EventHandler<EventArgs> AllCommonControlsShown
    {
      add
      {
        LifeListDialog.AllCommonControlsShown += value;
      }
      remove
      {
        LifeListDialog.AllCommonControlsShown -= value;
      }
    }

    internal event EventHandler<OnlineCommonDialogButtonsEventArgs> DialogButtonEvent;

    public void AllSubControlsVisible()
    {
      LifeListDialog.AllSubControlsVisible();
    }

    public void InitializeDialogbuttons()
    {
      LifeListDialog.InitializeDialogbuttons();
    }

    public void Close()
    {
      LifeListDialog.Close();
    }


  }
}
