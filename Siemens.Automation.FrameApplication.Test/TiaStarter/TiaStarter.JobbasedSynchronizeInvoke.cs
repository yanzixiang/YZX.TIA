using System.Threading;

using Siemens.Automation.Basics.Synchronizer;

using YZX.Tia.Dlc;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    public IJobbasedSynchronizeInvoke JobbasedSynchronizeInvoke
    {
      get
      {
        return m_ViewApplicationContext.GetRequiredDlc<IJobbasedSynchronizeInvoke>("Siemens.Automation.Basics.Synchronizer.ThreadSynchronizer");
      }
    }
  }
}
