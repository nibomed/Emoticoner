using System.Windows.Forms;

namespace Emoticoner.Hooks
{
    /// <summary>
    /// Adapter class for System.Window.Form.SendKeys() that send unformated text
    /// </summary>
    static class StringSender
    {
        static private string WrapChar(char c)
        {
            // TODO: work smarter with char and string
            if (c.ToString() != "(" && c.ToString() != ")" &&
                c.ToString() != "+" && c.ToString() != "%" &&
                c.ToString() != "~" && c.ToString() != "^")
                return c.ToString();
            else
                return "{" + c.ToString() + "}";
        }
        static public void Send(string text)
        {
            string toSend ="";
            for (int i = 0; i < text.Length; i++)
                toSend += WrapChar(text.ToCharArray()[i]);
            SendKeys.SendWait(toSend);
        }
    }
}
