using System;
using System.Windows.Forms;

namespace MpkExtractor
{
  static class Program
  {
    [STAThread]
    static int Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      Application.Run(new MpkExtractorForm());

      return 0;
    }
  }
}
