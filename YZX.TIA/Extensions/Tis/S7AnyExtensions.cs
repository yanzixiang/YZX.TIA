using System.Collections.Generic;

using Siemens.Simatic.PlcLanguages.PLInterface;
using Siemens.Simatic.PlcLanguages.TisServer;

namespace YZX.Tia.Extensions
{
  public static class S7AnyExtensions
  {
    public static byte[] CreateRequestBuffer(this List<S7Any> s7anyList, ITisServer TisServer)
    {
      ITisEndianBuffer endianBuffer1 = TisServer.CreateEndianBuffer(false);
      foreach (S7Any anyPointer in s7anyList)
      {
        endianBuffer1.WriteUInt8(18);
        endianBuffer1.WriteUInt8(10);
        byte[] numArray = new byte[10]
        {
          anyPointer.syntax_id,
          anyPointer.datatyp,
          (byte)((uint) anyPointer.count >> 8),
          (byte)anyPointer.count,
          (byte)((uint) anyPointer.pointer_val.DbNumber >> 8),
          (byte)anyPointer.pointer_val.DbNumber,
          (byte)(anyPointer.pointer_val.Ptr >> 24),
          (byte)(anyPointer.pointer_val.Ptr >> 16),
          (byte)(anyPointer.pointer_val.Ptr >> 8),
          (byte)anyPointer.pointer_val.Ptr
        };
        endianBuffer1.WriteByteArray(numArray);
      }
      return endianBuffer1.Buffer;
    }
  }
}
