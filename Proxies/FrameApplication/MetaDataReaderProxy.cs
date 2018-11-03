using System.Collections;
using System.Collections.Generic;

using Siemens.Automation.FrameApplication.WindowManager;

namespace YZX.Tia.Proxies.FrameApplication
{
  public class MetaDataReaderProxy
  {
    public static Hashtable NameToMetaDataMapping
    {
      get
      {
        return MetaDataReader.NameToMetaDataMapping;
      }
    }

    public static Dictionary<string,FrameBaseMetaProxy> NameToMetaDataProxy
    {
      get
      {
        Dictionary<string, FrameBaseMetaProxy> map = new Dictionary<string, FrameBaseMetaProxy>();
        foreach(string key in NameToMetaDataMapping.Keys)
        {
          FrameBaseMeta meta = NameToMetaDataMapping[key] as FrameBaseMeta;
          FrameBaseMetaProxy proxy = FrameBaseMetaProxy.ToProxy(meta);
          map[key] = proxy;
        }
        return map;
      }
    }
  }
}
