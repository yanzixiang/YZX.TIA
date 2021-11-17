using System;
using System.Windows.Forms;

namespace YZX.Tia
{
  partial class TiaStarter
  {
    public static void TIAInvokeAction(Action action,int timeout = 1000)
    {
      if(m_MainApplicationForm != null)
      {
        m_MainApplicationForm.Invoke(action);
      }
    }
    public static object TIAInvokeFunc(Func<object> func, int timeout = 1000)
    {
      if (m_MainApplicationForm != null)
      {
        return m_MainApplicationForm.Invoke(func);
      }
      else
      {
        return null;
      }
    }

    public static void SetForm(Form f)
    {
      m_MainApplicationForm = f;
    }
  }
}