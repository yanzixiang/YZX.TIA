using System.ServiceProcess;

namespace YZX.Tia
{
  public class S7DOS
  {
    /// <summary>
    /// Returns the Service name of the S7DOS-Service correspondig to operating system.
    /// s7oiehsx on 32 Bit an s7oiehsx64 on 64 Bit
    /// </summary>
    /// <returns>The Service name of the  S7DOS-Service, or Empty if could not be determined.</returns>
    public static string GetS7DOSHelperServiceName()
    {
      string machineName = ".";   // local
      ServiceController[] services = null;
      try
      {
        services = ServiceController.GetServices(machineName);
      }
      catch
      {
        return string.Empty;
      }
      for (int i = 0; i < services.Length; i++)
      {
        if (services[i].ServiceName == "s7oiehsx")
        {
          return services[i].ServiceName;
        }
        else if (services[i].ServiceName == "s7oiehsx64")
        {
          return services[i].ServiceName;
        }
      }
      return string.Empty;
    }
  }
}
