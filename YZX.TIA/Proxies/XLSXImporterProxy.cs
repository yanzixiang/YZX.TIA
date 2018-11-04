using System.ComponentModel;
using System.Collections.Generic;

using Siemens.Automation.ObjectFrame;
using Siemens.Simatic.PlcLanguages.TagTableViewer;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DataExchange.MassDataHandler;

using YZX.Tia.Extensions;

using Reflection;

namespace YZX.Tia.Proxies
{
  public class XLSXImporterProxy
  {
    public ICoreObject CPU;
    XLSXImporter XLSXImporter;
    public ISynchronizeInvoke Synchronizer;

    public XLSXImporterProxy(object importer)
    {
      XLSXImporter = importer as XLSXImporter;
    }
    public XLSXImporterProxy(
      ICoreObject cpu, 
      ISynchronizeInvoke synchronizer = null)
    {
      if (synchronizer == null)
      {
        Synchronizer = cpu.GetSynchronizer();
      }
      else
      {
        Synchronizer = synchronizer;
      }
      TiaStarter.RunInSynchronizer(Synchronizer, () =>
      {
        XLSXImporter = new XLSXImporter(cpu.GetTagService(),
         MassDataHandler.CreateWorkbook(null),
         cpu.GetDefaultTagTable(Synchronizer),
         XLSXImportExportOptions.IncludeTags | XLSXImportExportOptions.IncludeConstants,
         cpu.GetFolderService(),
         cpu.GetCommandProcessor(),
         null,
         null,
         cpu.GetNameService(),
         cpu.GetRangeCheck());
      });
    }

    public ICoreObject ResolveTagTableFromProperties(IDictionary<string, string> properties)
    {
      return TiaStarter.RunInSynchronizer(Synchronizer,
        (p_properties) =>
        {
          return Reflector.RunInstanceMethodByName(XLSXImporter,
            "ResolveTagTableFromProperties",
            ReflectionWays.SystemReflection,
            p_properties) as ICoreObject;
        }, properties) as ICoreObject;
    }

    public bool UpdateTag(IBLTag tag, Dictionary<string, string> properties, bool isConstant, int rowNumber)
    {
      return (bool)TiaStarter.RunInSynchronizer(Synchronizer,
        (p_tag, p_properties, p_isConstant) =>
        {
          return Reflector.RunInstanceMethodByName(XLSXImporter,
            "UpdateTag",
            ReflectionWays.SystemReflection,
            p_tag,
            p_properties,
            p_isConstant);
        }, tag, properties, isConstant);
    }

    /// <summary>
    /// 取得或创建变量表
    /// </summary>
    public ICoreObject GetOrCreateTagTable(string tagTablePath)
    {
      return TiaStarter.RunInSynchronizer(Synchronizer,
        (p_tagTablePath) =>
        {
          ICoreObject tagTable = Reflector.RunInstanceMethodByName(XLSXImporter,
              "GetOrCreateTagTable",
              ReflectionWays.SystemReflection,
              p_tagTablePath) as ICoreObject;
          return tagTable;
        }, tagTablePath) as ICoreObject;
    }

    public void AddUpdateTagOrConstant2TagTable(
      string[] propertyValues,
      string[] propertyNames,
      int typeIndex,
      bool isConstant
    )
    {
      TiaStarter.RunInSynchronizer(Synchronizer,
        () =>
        {
          Reflector.RunInstanceMethodByName(XLSXImporter,
            "AddUpdateTagOrConstant2TagTable",
            ReflectionWays.SystemReflection,
            propertyValues, propertyNames, typeIndex, isConstant, 0);
        });

    }
  }
}
