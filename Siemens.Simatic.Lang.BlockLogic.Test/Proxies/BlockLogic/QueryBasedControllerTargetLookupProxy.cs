using System;

using Siemens.Simatic.PlcLanguages.BlockLogic.OpenBlockHandling;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.ObjectFrame.Filter;
using Siemens.Automation.ObjectFrame.Meta;
using Siemens.Simatic.Hmi.Utah.Common.Base.Reflection;

namespace YZX.Tia.Proxies.BlockLogic
{
  public class QueryBasedControllerTargetLookupProxy
  {
    IControllerTargetLookup lookup;

    private IAttributeSetInfo m_CoreAttributeSetInfo;
    public IAttributeSetInfo CoreAttributeSetInfo {
      get
      {
        if (m_CoreAttributeSetInfo == null)
        {
          m_CoreAttributeSetInfo = Reflector.GetInstanceFieldByName(lookup,
            "m_CoreAttributeSetInfo", ReflectionWays.SystemReflection)
            as IAttributeSetInfo;
        }
        return m_CoreAttributeSetInfo;
      }
    }
    public ICoreContext m_CoreContext;
    public ICoreContext CoreContext
    {
      get
      {
        if (m_CoreContext == null)
        {
          m_CoreContext = Reflector.GetInstanceFieldByName(lookup,
            "m_CoreContext", ReflectionWays.SystemReflection)
            as ICoreContext;
        }
        return m_CoreContext;
      }
    }
    public IObjectTypeInfo m_ControllerTargetTypeInfo;
    public IObjectTypeInfo ControllerTargetTypeInfo
    {
      get
      {
        if (m_ControllerTargetTypeInfo == null)
        {
          m_ControllerTargetTypeInfo = Reflector.GetInstanceFieldByName(lookup,
            "m_ControllerTargetTypeInfo", ReflectionWays.SystemReflection)
            as IObjectTypeInfo;
        }
        return m_ControllerTargetTypeInfo;
      }
    }

    public QueryBasedControllerTargetLookupProxy(ICoreContext coreContext)
    {
      lookup = new QueryBasedControllerTargetLookup(coreContext);
    }

    public ICoreObject FindControllerTargetByName(string name)
    {
      return lookup.FindControllerTargetByName(name);
    }

    public ICoreObjectCollection ListAllControllerTarget()
    {
      try
      {
        var typeIterator = new TypeIterator(ControllerTargetTypeInfo, true, false);
        var selectClause = new ObjectReferenceExpression(typeIterator, CoreAttributeSetInfo);
        var name =
          new NotEqualExpression(
            new AttributeReferenceExpression(CoreContext, typeof(ICoreAttributes), "Name", typeIterator),
            new ConstantExpression(string.Empty)
          );

        var whereClause = new FilterCondition(CoreContext, name);
        var query = CoreContext.CreateObjectQuery(selectClause, typeIterator,
          whereClause,
          SortCondition.Empty);
        var objectCollection =
          CoreContext.GetCoreObjectCollection(query, CollectionFlag.SnapShot);
        return objectCollection;

      } catch (Exception ex)
      {
        return null;
      }
    }
  }
}
