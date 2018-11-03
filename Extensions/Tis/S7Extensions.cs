using System;

using Siemens.Simatic.PlcLanguages.PLInterface;

namespace YZX.Tia.Extensions
{
  public static class S7Extensions
  {
    public static byte[] GetBytes(this S7Any val)
    {
      byte[] arr = new byte[10];
      arr[0] = val.syntax_id;
      arr[1] = val.datatyp;
      CopyFrom(arr, 2, GetBytes(val.count));
      CopyFrom(arr, 4, GetBytes(val.pointer_val.DbNumber));
      CopyFrom(arr, 6, GetBytes(val.pointer_val.Ptr));
      return arr;
    }

    public static S7Any ToS7Any(this byte[] bytes)
    {
      if (bytes == null)
        throw new ArgumentException("Expect array of 10 bytes");
      if (bytes.Length != 10)
        throw new ArgumentException("Expect array of 10 bytes");
      return new S7Any()
      {
        syntax_id = bytes[0],
        datatyp = bytes[1],
        count = ToUInt16(bytes, 2),
        pointer_val = {
          DbNumber = ToUInt16(bytes, 4),
          Ptr = ToUInt32(bytes, 6)
        }
      };
    }

    public static byte[] GetBytes(this S7Pointer val)
    {
      byte[] arr = new byte[6];
      CopyFrom(arr, 0, GetBytes(val.DbNumber));
      CopyFrom(arr, 2, GetBytes(val.Ptr));
      return arr;
    }

    public static S7Pointer ToS7Pointer(this byte[] bytes)
    {
      if (bytes == null)
        throw new ArgumentException("Expect array of 6 bytes");
      if (bytes.Length != 6)
        throw new ArgumentException("Expect array of 6 bytes");
      return new S7Pointer()
      {
        DbNumber = ToUInt16(bytes, 0),
        Ptr = ToUInt32(bytes, 2)
      };
    }

    public static byte[] GetBytes(this S7DateLTime val)
    {
      byte[] arr = new byte[12];
      CopyFrom(arr, 0, GetBytes(val.year));
      arr[2] = val.month;
      arr[3] = val.day;
      arr[4] = val.weekday;
      arr[5] = val.hours;
      arr[6] = val.minutes;
      arr[7] = val.seconds;
      CopyFrom(arr, 8, GetBytes(val.nanoseconds));
      return arr;
    }

    public static S7DateLTime ToS7DateLTime(this byte[] bytes)
    {
      if (bytes == null)
        throw new ArgumentException("Expect array of 12 bytes");
      if (bytes.Length != 12)
        throw new ArgumentException("Expect array of 12 bytes");
      return new S7DateLTime()
      {
        year = ToUInt16(bytes, 0),
        month = bytes[2],
        day = bytes[3],
        weekday = bytes[4],
        hours = bytes[5],
        minutes = bytes[6],
        seconds = bytes[7],
        nanoseconds = ToUInt32(bytes, 8)
      };
    }

    public static DateTime ToDateTime(this S7DateLTime s7datetime)
    {
      DateTime dt = new DateTime(s7datetime.year, s7datetime.month, s7datetime.day, 
        s7datetime.hours, s7datetime.minutes, s7datetime.seconds);
      return dt;
    }

    public static byte[] GetBytes(this S7DateTime val)
    {
      return new byte[8]
      {
        val.year,
        val.month,
        val.day,
        val.hours,
        val.minutes,
        val.seconds,
        val.msecs,
        val.ms_wd
      };
    }

    public static S7DateTime ToS7DateTime(this byte[] bytes)
    {
      if (bytes == null)
        throw new ArgumentException("Expect array of 8 bytes");
      if (bytes.Length != 8)
        throw new ArgumentException("Expect array of 8 bytes");
      return new S7DateTime()
      {
        year = bytes[0],
        month = bytes[1],
        day = bytes[2],
        hours = bytes[3],
        minutes = bytes[4],
        seconds = bytes[5],
        msecs = bytes[6],
        ms_wd = bytes[7]
      };
    }

    private static byte[] GetBytes(this ushort val)
    {
      return BitConverter.GetBytes(val);
    }

    private static byte[] GetBytes(this uint val)
    {
      return BitConverter.GetBytes(val);
    }

    private static byte[] Revert(this byte[] arr)
    {
      Array.Reverse(arr);
      return arr;
    }

    private static byte[] CopyFrom(this byte[] arr, int pos, byte[] src)
    {
      Array.Copy(src, 0, arr, pos, src.Length);
      return arr;
    }

    private static ushort ToUInt16(this byte[] arr, int startIndex)
    {
      return BitConverter.ToUInt16(arr, startIndex);
    }

    private static uint ToUInt32(this byte[] arr, int startIndex)
    {
      return BitConverter.ToUInt32(arr, startIndex);
    }

    private static byte[] SubArray(this byte[] arr, int startIndex, int len)
    {
      byte[] numArray = new byte[len];
      Array.Copy(arr, startIndex, numArray, 0, numArray.Length);
      return numArray;
    }
  }
}
