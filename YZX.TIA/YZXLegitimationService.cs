using System;

using Siemens.Automation.DomainServices;
using Siemens.Automation.OMSPlus.Managed;
using Siemens.Automation.OnlineAccess.OnlineInterface;

namespace YZX.Tia
{
  public class YZXLegitimationService : ILegitimationService
  {
    public event EventHandler<TargetConnectionsPreDelegitimationEventArgs> TargetConnectionsPreDelegitimationEvent;

    public void Delegitimate(ClientSession drive)
    {
    }

    public void Delegitimate(IOamEpromDrive drive)
    {
    }

    public void Delegitimate(IConnection connection)
    {
    }

    public bool IsProtected(IOamEpromDrive drive)
    {
      return false;
    }

    public bool IsProtected(ClientSession drive)
    {
      return false;
    }

    public bool IsProtected(IConnection connection)
    {
      return false;
    }

    public bool Legitimate(IOamEpromDrive drive, NeededProtectionLevel desiredLevel, bool requestPasswordFromUser)
    {
      return true;
    }

    public bool Legitimate(ClientSession drive, NeededProtectionLevel desiredLevel, bool requestPasswordFromUser)
    {
      return true;
    }

    public bool Legitimate(IConnection connection, NeededProtectionLevel desiredLevel, bool requestPasswordFromUser)
    {
      return true;
    }
  }
}
