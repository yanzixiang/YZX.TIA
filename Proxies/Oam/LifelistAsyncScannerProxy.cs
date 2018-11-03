using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Basics.Synchronizer;
using Siemens.Automation.CommonServices;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.UI.OnlineCommon;

namespace YZX.Tia.Proxies.Oam
{
  public class LifelistAsyncScannerProxy
  {
    LifelistAsyncScanner scanner;
    public LifelistAsyncScannerProxy(ILifelistService lifeListService, 
      IFeedbackService feedbackService, 
      IJobbasedSynchronizeInvoke synchronizer)
    {
      scanner = new LifelistAsyncScanner(lifeListService, feedbackService, synchronizer);
    }
  }
}
