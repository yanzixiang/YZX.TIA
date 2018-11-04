using System;
using System.ComponentModel;

using Siemens.Automation.ObjectFrame;
using Siemens.Automation.ObjectFrame.Meta;
using Siemens.Automation.CommonServices;
using Siemens.Automation.DomainServices;
using Siemens.Simatic.PlcLanguages.Utilities;
using Siemens.Simatic.PlcLanguages.TagTableViewer;

using Reflection;

using YZX.Tia.Extensions;

namespace YZX.Tia.Proxies
{
  public class EAMTZTagTableViewLogicProxy
  {
    TagsTableViewLogic TagsTableViewLogic;
    ISynchronizeInvoke UsingSynchronizer;
    public EAMTZTagTableViewLogicProxy(TagsTableViewLogic ttvl, ISynchronizeInvoke synchronizer = null)
    {
      TagsTableViewLogic = ttvl;
      UsingSynchronizer = synchronizer;
    }

    public CommandReturnCodes PrepareImport(ICoreObject parentObject, string sourceFile)
    {
      return (CommandReturnCodes)TiaStarter.RunInSynchronizer(UsingSynchronizer,
        (Func<CommandReturnCodes>)(() =>
        {
          return (CommandReturnCodes)Reflector.RunInstanceMethodByName(
            TagsTableViewLogic,
            "PrepareImport", 
            ReflectionWays.SystemReflection, 
            parentObject, 
            sourceFile);
        }));
    }

    public bool ImportFile(ITagService TagService,string file, ICoreObject parentObject)
    {
      return (bool)TiaStarter.RunInSynchronizer(UsingSynchronizer,
        (Func<bool>)(() =>
        {
          TagService.SuspendCollectionEvents();
          using (OnDispose.Invoke(() => TagService.ResumeCollectionEvents()))
          {
            using (new ObjectFrameBulkOperationMode(parentObject))
            {
              return (bool)Reflector.RunInstanceMethodByName(
              TagsTableViewLogic,
              "ImportFile",
              ReflectionWays.SystemReflection,
              file,
              parentObject);
            }
          }
        }));
    }

    public CommandReturnCodes PrepareExport(ICoreObject parentObject, string sourceFile)
    {
      return (CommandReturnCodes)TiaStarter.RunInSynchronizer(UsingSynchronizer,
        (Func<CommandReturnCodes>)(() =>
        {
          return (CommandReturnCodes)Reflector.RunInstanceMethodByName(
            TagsTableViewLogic,
            "PrepareExport",
            ReflectionWays.SystemReflection,
            parentObject,
            sourceFile);
        }));
    }

    public bool ExportFile(string file, ICoreObject parentObject)
    {
      return (bool)TiaStarter.RunInSynchronizer(UsingSynchronizer,
        (Func<bool>)(() =>
        {
          return (bool)Reflector.RunInstanceMethodByName(
            TagsTableViewLogic,
            "ExportFile",
            ReflectionWays.SystemReflection,
            file,
            parentObject);
        }));
    }
  }
}
