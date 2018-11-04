using Siemens.Automation.FrameApplication;
using Siemens.Automation.ObjectFrame;

using YZX.Tia.Extensions;

namespace YZX.Tia
{
  partial class TiaStarter
  {
      }
    }

    public void OpenVatTable(ICoreObject vatTable)
    {
      ViewManager.Show("Siemens.Simatic.PlcLanguages.VATViewer.VATViewerView", vatTable);
    }
  }
}