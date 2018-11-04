using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Siemens.Simatic.PlcLanguages.TagTableViewer;
using Siemens.Automation.ObjectFrame.Meta;
using Siemens.Automation.ObjectFrame;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.FolderService;
using Siemens.Automation.ObjectFrame.BusinessLogic;

using YZX.Tia.Proxies;

using Reflection;

namespace YZX.Tia.Extensions
{
  partial class ICoreObjectExtensions
  {
    /// <summary>
    /// 取得变量表文件夹 
    /// </summary>
    /// <param name="cpu">控制器</param>
    public static ICoreObject GetTagsFolder(this ICoreObject cpu,
      ISynchronizeInvoke synchronizer = null)
    {
      ISynchronizeInvoke UsingSynchronizer;
      if (synchronizer == null)
      {
        UsingSynchronizer = cpu.GetSynchronizer();
      }
      else
      {
        UsingSynchronizer = synchronizer;
      }
      return TiaStarter.RunInSynchronizer(UsingSynchronizer,
        (c) =>
        {
          IFolderService folderService = cpu.GetFolderService();
          IObjectTypeInfo tagTableType = GetTagTableType(cpu);
          return folderService.GetAppropriateFolder(cpu, tagTableType, false);
        }, cpu) as ICoreObject;
    }

    public static readonly Type XLSXImporterType = typeof(XLSXImporter);

    public static ICoreObject GetTagTableByName(this ICoreObject tagsFolder,
      string Name,
      ISynchronizeInvoke synchronizer = null)
    {
      ISynchronizeInvoke UsingSynchronizer;
      if (synchronizer == null)
      {
        UsingSynchronizer = tagsFolder.GetSynchronizer();
      }
      else
      {
        UsingSynchronizer = synchronizer;
      }
      return TiaStarter.RunInSynchronizer(UsingSynchronizer,
        (p_tagsFolder, p_Name) =>
        {
          IDictionary<string, ICoreObject> tables = GetTagTables(tagsFolder, UsingSynchronizer);
          ICoreObject table;
          tables.TryGetValue(p_Name, out table);
          return table;
        }, tagsFolder,Name) as ICoreObject;
    }

    /// <summary>
    /// 取得指定文件夹下所有变量表
    /// </summary>
    public static IDictionary<string, ICoreObject> GetTagTables(this ICoreObject tagsFolder,
      ISynchronizeInvoke synchronizer = null)
    {
      ISynchronizeInvoke UsingSynchronizer;
      if (synchronizer == null)
      {
        UsingSynchronizer = tagsFolder.GetSynchronizer();
      }
      else
      {
        UsingSynchronizer = synchronizer;
      }
      return TiaStarter.RunInSynchronizer(UsingSynchronizer,
        (folder) =>
        {
          return Reflector.RunStaticMethodByName(
          XLSXImporterType,
          "GetTagTables",
          ReflectionWays.SystemReflection,
          tagsFolder) as IDictionary<string, ICoreObject>;
        }, tagsFolder) as IDictionary<string, ICoreObject>;
    }

    /// <summary>
    /// 取得默认变量表
    /// </summary>
    public static ICoreObject GetDefaultTagTable(this ICoreObject cpu,
      ISynchronizeInvoke synchronizer = null)
    {
      ISynchronizeInvoke UsingSynchronizer;
      if (synchronizer == null)
      {
        UsingSynchronizer = cpu.GetSynchronizer();
      }
      else
      {
        UsingSynchronizer = synchronizer;
      }
      ICoreObject tagFolder = cpu.GetTagsFolder();
      IDictionary<string, ICoreObject> tagTables = tagFolder.GetTagTables();
      ICoreObject defaultTagTable = null;
      tagTables.TryGetValue("默认变量表",out defaultTagTable);
      return defaultTagTable;
    }

    public static IObjectTypeInfo GetTagTableType(this ICoreObject tagTable)
    {
      return tagTable.Context.Meta.GetObjectType("Siemens.Automation.DomainModel.EAMTZTagTableData");
    }

    public static IObjectTypeInfo GetTagType(this ICoreObject tagTable)
    {
      return tagTable.Context.Meta.GetObjectType("Siemens.Automation.DomainModel.EAMTZTagData");
    }

    public static IObjectTypeInfo GetConstantType(this ICoreObject tagTable)
    {
      return tagTable.Context.Meta.GetObjectType("Siemens.Automation.DomainModel.SimaticConstantTagData");
    }

    /// <summary>
    /// 按名称查找变量
    /// </summary>
    /// <param name="cpu">控制器</param>
    /// <param name="tagName">变量名称</param>
    public static IBLTag FindRootTagByName(
      this ICoreObject cpu,
      string tagName,
      ISynchronizeInvoke synchronizer = null)
    {
      ISynchronizeInvoke UsingSynchronizer;
      if (synchronizer == null)
      {
        UsingSynchronizer = cpu.GetSynchronizer();
      }
      else
      {
        UsingSynchronizer = synchronizer;
      }
      return TiaStarter.RunInSynchronizer(UsingSynchronizer,
        (p_cpu, p_tagName) =>
        {
          ITagService tagService = cpu.GetTagService();
          return tagService.FindRootTagByName(p_tagName, p_cpu, "InverseTarget", true);
        }, cpu, tagName) as IBLTag;
    }

    /// <summary>
    /// 按地址查找变量
    /// </summary>
    /// <param name="cpu">控制器</param>
    /// <param name="address">地址</param>
    public static IBLTag FindRootTagByAddress(this ICoreObject cpu,
      string address,
      ISynchronizeInvoke synchronizer = null)
    {
      ISynchronizeInvoke UsingSynchronizer;
      if (synchronizer == null)
      {
        UsingSynchronizer = cpu.GetSynchronizer();
      }
      else
      {
        UsingSynchronizer = synchronizer;
      }
      return TiaStarter.RunInSynchronizer(UsingSynchronizer,
        (p_cpu, p_address, p_synchronizer) =>
        {
          ITagService tagService = p_cpu.GetTagService();
          RootTagCollectionProxy rtcp = p_cpu.FindRootTags(p_synchronizer);
          List<IBLTag> tags = rtcp.Tags;
          foreach (IBLTag tag in tags)
          {
            if (tag.LogicalAddress == p_address)
            {
              return tag;
            }
          }
          return null;
        }, cpu, address,UsingSynchronizer) as IBLTag;
    }

    /// <summary>
    /// 取得控制器所有变量
    /// </summary>
    public static RootTagCollectionProxy FindRootTags(this ICoreObject cpu,
      ISynchronizeInvoke synchronizer = null)
    {
      ISynchronizeInvoke UsingSynchronizer;
      if (synchronizer == null)
      {
        UsingSynchronizer = cpu.GetSynchronizer();
      }
      else
      {
        UsingSynchronizer = synchronizer;
      }
      return TiaStarter.RunInSynchronizer(UsingSynchronizer,
        (p_cpu) =>
        {
          ITagService tagService = cpu.GetTagService();
          IList list = tagService.FindRootTags(p_cpu, cpu.GetTagType(), "InverseTarget", true);

          RootTagCollectionProxy rtcp = new RootTagCollectionProxy(list, UsingSynchronizer);
          return rtcp;
        }, cpu) as RootTagCollectionProxy;
    }

    /// <summary>
    /// 创建变量
    /// </summary>
    /// <param name="cpu">控制器</param>
    /// <param name="tagTable">变量表</param>
    /// <param name="properties">变量数据</param>
    /// <param name="isConstant">是否静态变量</param>
    public static IBLTag CreateRootTagInTagTable(
      this ICoreObject cpu,
      ICoreObject tagTable,
      Dictionary<string, string> properties,
      bool isConstant = false,
      ISynchronizeInvoke synchronizer = null
    )
    {
      ISynchronizeInvoke UsingSynchronizer;
      if (synchronizer == null)
      {
        UsingSynchronizer = cpu.GetSynchronizer();
      }
      else
      {
        UsingSynchronizer = synchronizer;
      }

      return TiaStarter.RunInSynchronizer(UsingSynchronizer,
        () =>
        {
          IObjectTypeInfo iot = null;
          if (isConstant)
          {
            iot = tagTable.GetConstantType();
          }
          else
          {
            iot = tagTable.GetTagType();
          }

          ITagService tagService = cpu.GetTagService();

          using (new ObjectFrameBulkOperationMode(tagTable))
          {
            return tagService.CreateRootTag(
              cpu,
              iot,
              Enumerable.ToDictionary(properties,
              kvp => kvp.Key, (Func<KeyValuePair<string, string>, object>)(kvp => kvp.Value))) as IBLTag;
          }
        }) as IBLTag;
    }

    /// <summary>
    /// 更新变量
    /// </summary>
    /// <param name="tagTable">变量表</param>
    /// <param name="tag">变量</param>
    /// <param name="properties">变量数据</param>
    /// <param name="isConstant">是否静态变量</param>
    public static bool UpdateTagReal(
      this ICoreObject tagTable,
      IBLTag tag,
      Dictionary<string, string> properties,
      bool isConstant = false)
    {
      if (tag == null)
        throw new ArgumentNullException("tag");
      if (properties == null)
        throw new ArgumentNullException("properties");
      string str = null;
      if (properties.TryGetValue("Siemens.Automation.DomainServices.IBLTag.DataTypeNameStructureRef", out str)
        && !tag.IsAttributeReadOnly("DataTypeNameStructureRef"))
        tag.SetStringAttribute("DataTypeNameStructureRef", str);
      if (properties.TryGetValue("Siemens.Automation.DomainServices.IBLTag.LogicalAddress", out str)
        && !tag.IsAttributeReadOnly("LogicalAddress"))
        tag.LogicalAddress = str;
      if (properties.TryGetValue("Siemens.Automation.DomainServices.IBLTag.Comment", out str)
        && !tag.IsAttributeReadOnly("Comment"))
        tag.Comment = str;
      if (properties.TryGetValue("Siemens.Automation.DomainServices.IBLTag.HmiStructureTypeRelevant", out str))
      {
        bool result;
        if (!bool.TryParse(str, out result))
          return false;
        if (!tag.IsAttributeReadOnly("HmiStructureTypeRelevant"))
          tag.HmiStructureTypeRelevant = result;
      }
      if (properties.TryGetValue("Siemens.Automation.DomainServices.IBLTag.HmiVisible", out str))
      {
        bool result;
        if (!bool.TryParse(str, out result))
          return false;
        if (!tag.IsAttributeReadOnly("HmiVisible"))
          tag.HmiVisible = result;
      }
      if (properties.TryGetValue("Siemens.Automation.DomainServices.IBLTag.Value", out str) && !tag.IsAttributeReadOnly("Value"))
        tag.Value = str;
      if (!tag.IsAttributeReadOnly("TagTable"))
      {
        tag.TagTable = tagTable;
        return true;
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// 更新变量
    /// </summary>
    /// <param name="tagTable">变量表</param>
    /// <param name="tag">变量</param>
    /// <param name="properties">变量数据</param>
    /// <param name="isConstant">是否静态变量</param>
    public static IBLTag UpdateTag(
      this ICoreObject tagTable,
      IBLTag tag,
      Dictionary<string, string> properties,
      bool isConstant = false,
      ISynchronizeInvoke synchronizer = null)
    {
      ISynchronizeInvoke UsingSynchronizer;
      if (synchronizer == null)
      {
        UsingSynchronizer = tagTable.GetSynchronizer();
      }
      else
      {
        UsingSynchronizer = synchronizer;
      }
      return TiaStarter.RunFuncInSynchronizer(UsingSynchronizer,
        () =>
        {
          bool result = UpdateTagReal(tagTable, tag, properties, isConstant);
          return FindRootTagByName(tagTable.GetParent(), tag.Name);
        }) as IBLTag;
    }

    public static IBLTag ToBLTag(this ICoreObject tagRef, 
      ISynchronizeInvoke synchronizer = null)
    {
      ISynchronizeInvoke UsingSynchronizer;
      if (synchronizer == null)
      {
        UsingSynchronizer = tagRef.GetSynchronizer();
      }
      else
      {
        UsingSynchronizer = synchronizer;
      }

      return TiaStarter.RunFuncInSynchronizer(UsingSynchronizer,
        (p_tag) =>
          {
            if (p_tag == null)
            {
              return null;
            }
            IBusinessLogicConnector businessLogicConnector = tagRef as IBusinessLogicConnector;
            if (businessLogicConnector == null)
            {
              return null;
            }
            return businessLogicConnector.GetBusinessLogic("Siemens.Automation.DomainServices.TagService") as IBLTag;
          }, tagRef) as IBLTag;
    }

    public static readonly string[] TagPropertyNames = new string[]{
      "Siemens.Automation.DomainServices.IBLTag.Name",
      "Path",
      "Siemens.Automation.DomainServices.IBLTag.DataTypeNameStructureRef",
      "Siemens.Automation.DomainServices.IBLTag.LogicalAddress",
      "Siemens.Automation.DomainServices.IBLTag.Comment",
      "Siemens.Automation.DomainServices.IBLTag.HmiVisible",
      "Siemens.Automation.DomainServices.IBLTag.HmiStructureTypeRelevant"
    };

    public static Dictionary<string, string> CreateTagProperties(string[] propertyValues)
    {
      return Reflector.RunStaticMethodByName(typeof(XLSXImporter),
        "CreateProperties", ReflectionWays.SystemReflection, TagPropertyNames, propertyValues)
        as Dictionary<string, string>;
    }

    public static ICoreObject CreateTagTable(this ICoreObject folder,
      string Name,
      ISynchronizeInvoke synchronizer = null)
    {
      ISynchronizeInvoke UsingSynchronizer;
      if (synchronizer == null)
      {
        UsingSynchronizer = folder.GetSynchronizer();
      }
      else
      {
        UsingSynchronizer = synchronizer;
      }
      return TiaStarter.RunFuncInSynchronizer(UsingSynchronizer, (Func<ICoreObject>)
        (() => {
          ITagService tagService = folder.GetTagService();
          TagServiceProxy tsp = new TagServiceProxy(tagService);
          return tsp.CreateTagTable(folder, folder.GetTagTableType(), false, Name);
        })) as ICoreObject;
    }

    /// <summary>
    /// 取得或创建变量表
    /// </summary>
    /// <param name="cpu">控制器</param>
    /// <param name="Path">变量表路径</param>
    public static ICoreObject GetOrCreateTagTable(
      this ICoreObject cpu,
      string Path,
      ISynchronizeInvoke synchronizer = null)
    {
      ISynchronizeInvoke UsingSynchronizer;
      if (synchronizer == null)
      {
        UsingSynchronizer = cpu.GetSynchronizer();
      }
      else
      {
        UsingSynchronizer = synchronizer;
      }
      return TiaStarter.RunInSynchronizer(UsingSynchronizer,(Func<ICoreObject>)
        (() => {
          ICoreObject tagFolder = cpu.GetTagsFolder();
          ICoreObject table = GetTagTableByName(tagFolder, Path);
          if(table == null)
          {
            table = CreateTagTable(tagFolder, Path);
          }
          return table;
      })) as ICoreObject;

    }

    public static IBLTag UpdateOrCreateTag(
      this ICoreObject cpu,
      string Name,
      string Path,
      string DataType,
      string address,
      string Comment,
      bool isConstant = false,
      ISynchronizeInvoke synchronizer = null)
    {
      ISynchronizeInvoke UsingSynchronizer;
      if (synchronizer == null)
      {
        UsingSynchronizer = cpu.GetSynchronizer();
      }
      else
      {
        UsingSynchronizer = synchronizer;
      }

      return TiaStarter.RunInSynchronizer(UsingSynchronizer,
        (Func<ICoreObject,string,string,string,string,string,bool,IBLTag>)
        ((p_cpu,p_Name,p_Path,p_DataType,p_address,p_Comment,p_isConstant) =>
        {
          string[] values = new string[]{
            p_Name,p_Path,p_DataType,p_address,p_Comment,"True","True"
          };
          Dictionary<string, string> properties = CreateTagProperties(values);


          IBLTag findTag = FindRootTagByName(p_cpu, p_Name, UsingSynchronizer);

          ICoreObject tagTable = GetOrCreateTagTable(p_cpu,p_Path,UsingSynchronizer);

          IBLTag newTag = null;

          if (findTag == null)
          {
            newTag = CreateRootTagInTagTable(p_cpu, tagTable, properties, isConstant);

          }
          else
          {
            newTag = UpdateTag(tagTable, findTag, properties, isConstant, UsingSynchronizer);
          }

          return newTag;
        }), cpu,Name,Path, DataType, address,Comment,isConstant) as IBLTag;
    }
  }
}
