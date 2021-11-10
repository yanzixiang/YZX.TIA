using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Siemens.Automation.Archiving.Private;

namespace YZX.Tia.Extensions.Archiving
{
  public static class ZlibExtensions
  {
    [DllImport("zlib128-tia.dll", EntryPoint = "unzCloseCurrentFile", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int UnzCloseCurrentFile(IntPtr handle);

    [DllImport("zlib128-tia.dll", EntryPoint = "unzClose", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int UnzClose(IntPtr handle);

    [DllImport("zlib128-tia.dll", EntryPoint = "unzGoToFirstFile", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int UnzGoToFirstFile(IntPtr handle);

    [DllImport("zlib128-tia.dll", EntryPoint = "unzGoToNextFile", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int UnzGoToNextFile(IntPtr handle);

    [DllImport("zlib128-tia.dll", EntryPoint = "unzGetCurrentFileInfo64", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int UnzGetCurrentFileInfo(IntPtr handle, out ZlibDllWrapper.UnzipFileInfo fileInfo, byte[] fileNameArray, uint fileNameBufferSize, IntPtr extraField, uint extraFieldBufferSize, IntPtr comment, uint commentBufferSize);
  }
}
