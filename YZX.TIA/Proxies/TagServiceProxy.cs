using System;

using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.TagService;
using Siemens.Simatic.PlcLanguages.TagTableViewer;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.ObjectFrame.Meta;

using Reflection;

using YZX.Tia.Extensions;

namespace YZX.Tia.Proxies
{
  public class TagServiceProxy
  {
    internal TagService TagService;

    private TagServiceCore core;
    internal TagServiceCore TSC
    {
      get
      {
        if(core == null)
        {
          core = TagService.GetTagServiceCore();
        }
        return core;
      }
    }

    public TagServiceProxy(ITagService ts)
    {
      TagService = ts as TagService;
    }

    public object GetStrategyForItem(ICoreObject coreObject, bool throwOnError)
    {
      return Reflector.RunInstanceMethodByName(
        TSC,
        "GetStrategyForItem", 
        ReflectionWays.SystemReflection, 
        coreObject, 
        throwOnError);
    }

    public ICoreObject CreateTagTable(
      ICoreObject folder,
      IObjectTypeInfo tagTableType,
      bool defaultTagTable = false,
      string name = "")
    {
      using (new ObjectFrameBulkOperationMode(folder))
      {
        return Reflector.RunInstanceMethodByName(
          TSC,
          "CreateTagTable",
          ReflectionWays.SystemReflection,
          folder,
          tagTableType,
          defaultTagTable,
          name) as ICoreObject;
      }
    }
  }
}
