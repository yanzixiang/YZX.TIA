using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.OnlineAccess;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia.Proxies
{
  public class OamSimaticScannerProxy
  {
    OamSimaticScanner OamSimaticScanner;

    public OamSimaticScannerProxy(IOamScanner<IOamLocalBoard> scanner)
    {
      OamSimaticScanner = scanner as OamSimaticScanner;
    }

    public IEnumerable<IOamLocalBoard> Scan()
    {
      return OamSimaticScanner.Scan();
    }
  }
}
