using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;

using Siemens.Automation.Basics.Browsing;
using Siemens.Automation.FrameApplication.BrowsableGridSupport.Logics;
using Siemens.Automation.FrameApplication.BrowsableGridSupport.StatesHandling;
using Siemens.Automation.FrameApplication.SessionMemory;
using Siemens.Automation.FrameApplication.Utilities;
using Siemens.Automation.UI.Controls.Grid;

using Siemens.Automation.FrameApplication.BrowsableGridSupport;


namespace YZX.Tia.Proxies.FrameApplication
{
  public static class BrowsableGridUtilitiesProxy
  {
    public static void EnsureBrowsableGrid(Grid grid)
    {
      BrowsableGridUtilities.EnsureBrowsableGrid(grid);
    }


  }
}
