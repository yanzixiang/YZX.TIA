using System.Configuration;
using System.Reflection;

namespace YZX.Tia.Extensions
{
  public static class OamTraceExtensions
  {
    public static  int ReadTraceLevelFromCfg()
    {
      int result = 0;
      Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
      if (configuration.HasFile && configuration.AppSettings.Settings.Count > 0)
      {
        KeyValueConfigurationElement configurationElement = configuration.AppSettings.Settings["OamTraceLevel"];
        if (configurationElement != null && !int.TryParse(configurationElement.Value, out result))
          result = 0;
      }
      return result;
    }
  }
}
