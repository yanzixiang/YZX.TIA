using System;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;

using Siemens.Automation.DomainServices;
using Siemens.Simatic.HwConfiguration.Basics.Utilities;
using Siemens.Automation.OnlineAccess.OnlineInterface;
using Siemens.Automation.OMSPlus.Managed;

using Reflection;

namespace YZX.Tia.Extensions
{
  public static class IOMSConnectionExtensions
  {
    public static SecurePassword GetSaltedPassword(this IOMSConnection conn, 
      SecurePassword plain)
    {
      byte[] bytes = Encoding.UTF8.GetBytes(plain.GetPlain());
      SecurePassword securePassword = plain;
      byte[] buffer = conn.UploadSalt();
      if (buffer == null)
        return securePassword;
      PcIdent pcIdent = new PcIdent(buffer);
      if (pcIdent.IsValid())
      {
        using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(bytes, pcIdent.Salt, pcIdent.Rounds))
          securePassword = SecurePassword.Create(Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(pcIdent.DerivedBytesLen)));
      }
      return securePassword;
    }
    public static byte[] UploadSalt(this IOMSConnection conn)
    {
      byte[] data = null;
      Rid rid = new Rid(37U);
      Aid aid = new Aid(2449U);
      Value obj = null;
      int requestID = -1;
      Error error = conn.ClientSession.GetVariableRemote(rid, aid, ref obj, ref requestID);
      if (error.Failed)
        return null;
      using (obj)
      {
        Blob blob = null;
        error = obj.GetValue(ref blob);
        if (error.Succeeded)
        {
          if (blob != null)
          {
            error = blob.GetData(ref data);
            blob.Dispose();
          }
        }
      }
      if (!error.Failed)
        return data;
      return null;
    }


  }
}
