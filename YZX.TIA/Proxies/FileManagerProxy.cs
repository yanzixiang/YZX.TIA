using System;
using System.Xml;
using System.ComponentModel;

using Siemens.Automation.Basics;
using Siemens.Simatic.PlcLanguages.TagTableViewer;
using Siemens.Automation.DomainServices;
using Siemens.Automation.ObjectFrame;

using Reflection;

using YZX.Tia.Extensions;

namespace YZX.Tia.Proxies
{
  class FileManagerProxy
  {
    FileManager FM;
    ISynchronizeInvoke UsingSynchronizer;

    public FileManagerProxy(IWorkingContext wc, ISynchronizeInvoke synchronizer = null)
      :this(new FileManager(wc),synchronizer)
    {
    }

    public FileManagerProxy(FileManager fm, ISynchronizeInvoke synchronizer = null)
    {
      FM = fm;
      UsingSynchronizer = synchronizer;
    }

    public bool ImportXML(ICoreObject controller, string path)
    {
      XmlReader xmlReader = XmlReader.Create(path);
      return TiaStarter.RunInSynchronizer(UsingSynchronizer,
        () =>
        {
          return (bool)Reflector.RunInstanceMethodByName(FM,
            "ImportXML",
            ReflectionWays.SystemReflection,
            controller, xmlReader);
        });
    }


    private void AddTag2TagTable(ICoreObject parent,
     string tagName,
     string tagDataType,
     string tagAddr,
     string tagRemark,
     string hmiAccessible = "True",
     string hmiVisible = "True",
     string retain = "",
     ITagService tagService = null)
    {
      TiaStarter.RunActionInSynchronizer(UsingSynchronizer,
        () =>
        {
          Reflector.RunInstanceMethodByName(FM,
            "ImportXML",
            ReflectionWays.SystemReflection,
            tagName,
            tagDataType,
            tagAddr,
            tagRemark,
            hmiAccessible,
            hmiVisible,
            retain,
            tagService);
        });
    }
  }
}
