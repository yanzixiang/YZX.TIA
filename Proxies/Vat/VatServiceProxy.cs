using Siemens.Simatic.PlcLanguages.VatService;

namespace YZX.Tia.Proxies
{
  public class VatServiceProxy
  {
    private VatService m_VatService = null;

    public VatServiceProxy(VatService vs)
    {
      m_VatService = vs;
    }
  }
}
