using Siemens.Automation.DomainServices.DomainGrid;
using Siemens.Simatic.PlcLanguages.VATViewer;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static class VATViewerViewExtensions
  {
    public static DomainGrid GetDomainGrid(this VATViewerView vatViewerView)
    {
      return Reflector.GetInstanceFieldByName(vatViewerView, "m_DomainGrid", 
        ReflectionWays.SystemReflection)
        as DomainGrid;
    }
  }
}
