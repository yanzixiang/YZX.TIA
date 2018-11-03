using System;
using System.ComponentModel;

using Siemens.Automation.DomainServices;

using IronPython.Runtime;
using IronPython.Runtime.Operations;

namespace YZX.Tia.Extensions
{
  public static class PythonSynAccess
  {
    public static void InvokeAction(ISynchronizeInvoke synchronizer,
      PythonFunction method)
    {
      Action action = () => {
        PythonCalls.Call(method);
      };
      UnifiedSynchronizerAccess.Invoke(synchronizer, action,null);
    }
    public static UnifiedInvokeResult InvokeFunc<T> (ISynchronizeInvoke synchronizer, 
      PythonFunction method)
    {
      Func<T> func = () => {
        return (T)PythonCalls.Call(method);
      };
      return UnifiedSynchronizerAccess.Invoke(synchronizer, func,null);
    }
  }
}
