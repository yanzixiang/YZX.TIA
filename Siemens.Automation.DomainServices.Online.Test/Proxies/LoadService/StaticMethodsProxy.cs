using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.CommonServices.ClipboardService;
using Siemens.Automation.DomainServices;
using Siemens.Automation.DomainServices.LoadService;
using Siemens.Automation.ObjectFrame;

namespace YZX.Tia.Proxies.LoadService
{
  public static class StaticMethodsProxy
  {
    public static ICoreObject GetCommandCoreObject(object commandObject)
    {
      return StaticMethods.GetCommandCoreObject(commandObject);
    }

    public static List<ICoreObject> GetTargetClipboardObjects(IFormatterCache formatterCache)
    {
      return StaticMethods.GetTargetClipboardObjects(formatterCache);
    }

    public static bool CheckClipboardConditions(IFormatterCache formatterCache)
    {
      return StaticMethods.CheckClipboardConditions(formatterCache);
    }

    public static ICoreObject FindOfflineDevice(ICoreObject startObject,
      IOnlineService onlineService)
    {
      return StaticMethods.FindOfflineDevice(startObject, onlineService);
    }

    public static void GetOfflineTargets(ICoreObject baseObject, List<ICoreObject> targets)
    {
      StaticMethods.GetOfflineTargets(baseObject, targets);
    }

    public static void GetSubOfflineTargets(ICoreObject baseObject,
      List<ICoreObject> involvedOfflineTargets)
    {
      StaticMethods.GetSubOfflineTargets(baseObject, involvedOfflineTargets);
    }

    public static IList ExpandGlobalFolderToDevice(IList commandObjects)
    {
      return StaticMethods.ExpandGlobalFolderToDevice(commandObjects);
    }

    public static string GetObjectTypeAndSubType(ICoreObject selectedObject)
    {
      return StaticMethods.GetObjectTypeAndSubType(selectedObject);
    }

    public static string GetBrowsableName(ICoreObject selectedObject)
    {
      return StaticMethods.GetBrowsableName(selectedObject);
    }

    public static string GetName(ICoreObject selectedObject)
    {
      return StaticMethods.GetName(selectedObject);
    }

    public static string HwcnModuleName(ILoadConnection loadConnection)
    {
      return StaticMethods.HwcnModuleName(loadConnection);
    }

    public static ICoreObject SearchAncestor(ICoreObject descendantObject,
      Type ancestorType)
    {
      return StaticMethods.SearchAncestor(descendantObject, ancestorType);
    }

    public static void SearchMinorFolderLoadObjects(ICoreObject minorFolderObject, 
      IList<ICoreObject> loadObjects)
    {
      StaticMethods.SearchMinorFolderLoadObjects(minorFolderObject, loadObjects);
    }

    public static string ChangeListToCommaSeparatedText(IList<string> stringList)
    {
      return StaticMethods.ChangeListToCommaSeparatedText(stringList);
    }

    public static List<string> ChangeCommaSeparatedTextToList(string commaSeparatedText)
    {
      return StaticMethods.ChangeCommaSeparatedTextToList(commaSeparatedText);
    }

    public static string LogFilePathName()
    {
      return StaticMethods.LogFilePathName();
    }

  }
}
