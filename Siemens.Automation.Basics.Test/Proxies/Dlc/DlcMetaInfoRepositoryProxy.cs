using System.Collections.Generic;

using Siemens.Automation.Basics;

namespace YZX.Tia.Proxies.Dlc
{
  public class DlcMetaInfoRepositoryProxy
  {
    public static IEnumerable<IDlcMetaInfo> Singleton
    {
      get
      {
        return DlcMetaInfoRepository.Singleton;
      }
    }

    private static List<IDlcMetaInfo> m_DlcMetaInfoList;
    public static List<IDlcMetaInfo> SingletonList
    {
      get
      {
        if (m_DlcMetaInfoList == null)
        {
          m_DlcMetaInfoList = new List<IDlcMetaInfo>(Singleton);
        }
        return m_DlcMetaInfoList;
      }
    }

    public static void UpdateList()
    {
      m_DlcMetaInfoList = new List<IDlcMetaInfo>(Singleton);
    }
  }
}
