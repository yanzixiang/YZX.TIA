using System;

using Siemens.Automation.Basics;

namespace YZX.Tia.Dlc
{
  public static partial class IWorkingContextExtensions
  {
    public static T GetOptionalDlc<T>(this IWorkingContext workingContext,
  string serviceId)
  where T : class
    {
      return GetDlcInternal<T>(workingContext, serviceId, false);
    }

    public static T GetRequiredDlc<T>(this IWorkingContext workingContext,
      string serviceId)
      where T : class
    {
      return GetDlcInternal<T>(workingContext, serviceId, true);
    }

    public static T GetDlcInternal<T>(this IWorkingContext workingContext,
      string serviceId,
      bool throwExceptionOnFailure)
      where T : class
    {
      if (workingContext == null)
        throw new ArgumentNullException("workingContext");
      if (string.IsNullOrEmpty(serviceId))
        throw new ArgumentNullException("serviceId");
      object obj1 = workingContext.DlcManager.Load(serviceId, throwExceptionOnFailure);
      if (obj1 == null && throwExceptionOnFailure)
        throw new DlcManagerException(string.Format("Could not load Dlc with service id '{0}'.", serviceId));
      T obj2 = ServiceProviderHelper.AccessService<T>(obj1);
      if (obj2 == null && throwExceptionOnFailure)
        throw new DlcManagerException(string.Format("Dlc with service id '{0}' does not implement '{1}'.", serviceId, typeof(T).FullName));
      return obj2;
    }
  }
}
