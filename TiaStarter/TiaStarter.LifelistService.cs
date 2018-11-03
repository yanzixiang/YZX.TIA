using Siemens.Automation.DomainServices;

using YZX.Tia.Extensions;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    public ILifelistService LifelistService
    {
      get
      {
        return m_BusinessLogicApplicationContext.GetLifelist();
      }
    }
  }
}
