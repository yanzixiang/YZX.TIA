using System.Collections.Generic;

using Siemens.Automation.CommonTrace.TraceIntegrationDotNet;

namespace YZX.Tia.Proxies
{
  public class ITraceProxy
  {
    Tracer Tracer;

    public ITraceObserver TraceObserver
    {
      get
      {
        return Tracer as ITraceObserver;
      }
    }

    public ITraceProxy(ITrace trace)
    {
      Tracer = trace as Tracer;
    }

    public event TraceEventHandler ErrorMessageSent
    {
      add
      {
        if (TraceObserver != null)
        {
          TraceObserver.ErrorMessageSent += value;
        }
      }
      remove
      {
        if (TraceObserver != null)
        {
          TraceObserver.ErrorMessageSent -= value;
        }
      }
    }

    public event TraceEventHandler WarningMessageSent
    {
      add
      {
        if (TraceObserver != null)
        {
          TraceObserver.WarningMessageSent += value;
        }
      }
      remove
      {
        if (TraceObserver != null)
        {
          TraceObserver.WarningMessageSent -= value;
        }
      }
    }

    public event TraceEventHandler InformationMessageSent
    {
      add
      {
        if (TraceObserver != null)
        {
          TraceObserver.InformationMessageSent += value;
        }
      }
      remove
      {
        if (TraceObserver != null)
        {
          TraceObserver.InformationMessageSent -= value;
        }
      }
    }

    public event TraceEventHandler DebugMessageSent
    {
      add
      {
        if (TraceObserver != null)
        {
          TraceObserver.DebugMessageSent += value;
        }
      }
      remove
      {
        if (TraceObserver != null)
        {
          TraceObserver.DebugMessageSent -= value;
        }
      }
    }
  }
}
