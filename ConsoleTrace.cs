using System;

using Siemens.Automation.CommonTrace.TraceIntegrationDotNet;

namespace YZX.Tia
{
  public class ConsoleTrace: ITrace, IComponentTrace
  {
    public bool IsErrorAllowed
    {
      get
      {
        return false;
      }
    }

    public bool IsWarningAllowed
    {
      get
      {
        return false;
      }
    }

    public bool IsInfoAllowed
    {
      get
      {
        return false;
      }
    }

    public bool IsDebugAllowed
    {
      get
      {
        return false;
      }
    }

    public string AssemblyName
    {
      get
      {
        return "Siemens.Automation.CommonTrace.IntegrationDotNet";
      }
    }

    public string ComponentName
    {
      get
      {
        return "Siemens.Automation.CommonTrace.IntegrationDotNet.TraceMockup";
      }
    }

    public string AssemblyInfo
    {
      get
      {
        return null;
      }
      set
      {
      }
    }

    public string ClassName
    {
      get
      {
        return null;
      }
      set
      {
      }
    }

    public event TraceEventHandler ErrorMessageSent;
    public event TraceEventHandler WarningMessageSent;
    public event TraceEventHandler InformationMessageSent;
    public event TraceEventHandler DebugMessageSent;

    public void Error(string sourceMethod, string message)
    {
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, message));
    }

    public void Error(string sourceMethod, string format, object arg1)
    {
      String formattedString = String.Format(format, arg1);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, formattedString));
    }

    public void Error(string sourceMethod, string format, object arg1, object arg2)
    {
      String formattedString = String.Format(format, arg1, arg2);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, formattedString));
    }

    public void Error(string sourceMethod, string format, object arg1, object arg2, object arg3)
    {
      String formattedString = String.Format(format, arg1, arg2, arg3);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, formattedString));
    }

    public void Error(string sourceMethod, string format, params object[] args)
    {
      String formattedString = String.Format(format, args);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, formattedString));
    }

    public void Warning(string sourceMethod, string message)
    {
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, message));
    }

    public void Warning(string sourceMethod, string format, object arg1)
    {
      String formattedString = String.Format(format, arg1);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, formattedString));
    }

    public void Warning(string sourceMethod, string format, object arg1, object arg2)
    {
      String formattedString = String.Format(format, arg1, arg2);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, formattedString));
    }

    public void Warning(string sourceMethod, string format, object arg1, object arg2, object arg3)
    {
      String formattedString = String.Format(format, arg1, arg2, arg3);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, formattedString));
    }

    public void Warning(string sourceMethod, string format, params object[] args)
    {
      String formattedString = String.Format(format, args);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, formattedString));
    }

    public void Info(string sourceMethod, string message)
    {
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, message));
    }

    public void Info(string sourceMethod, string format, object arg1)
    {
      String formattedString = String.Format(format, arg1);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, formattedString));
    }

    public void Info(string sourceMethod, string format, object arg1, object arg2)
    {
      String formattedString = String.Format(format, arg1, arg2);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, formattedString));
    }

    public void Info(string sourceMethod, string format, object arg1, object arg2, object arg3)
    {
      String formattedString = String.Format(format, arg1, arg2, arg3);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, formattedString));
    }

    public void Info(string sourceMethod, string format, params object[] args)
    {
      String formattedString = String.Format(format, args);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, formattedString));
    }

    public void Debug(string sourceMethod, string message)
    {
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, message));
    }

    public void Debug(string sourceMethod, string format, object arg1)
    {
      String formattedString = String.Format(format, arg1);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, formattedString));
    }

    public void Debug(string sourceMethod, string format, object arg1, object arg2)
    {
      String formattedString = String.Format(format, arg1, arg2);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, formattedString));
    }

    public void Debug(string sourceMethod, string format, object arg1, object arg2, object arg3)
    {
      String formattedString = String.Format(format, arg1,arg2,arg3);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod, formattedString));
    }

    public void Debug(string sourceMethod, string format, params object[] args)
    {
      String formattedString = String.Format(format, args);
      Console.WriteLine(String.Format("{0},{1}", sourceMethod,formattedString));
    }

    ITrace IComponentTrace.GetTracerForClass(HierarchyName hierarchyName)
    {
      return new ConsoleTrace();
    }

    public bool IsTraceAllowed(int traceLevel)
    {
      return true;
    }

    public void PerformTracing(string className, string sourceMethod, int traceLevel, long traceTime, string format, params object[] args)
    {
    }
  }
}
