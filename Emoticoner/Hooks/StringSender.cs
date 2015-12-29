using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Emoticoner.Hooks
{
    /// <summary>
    /// Adapter class for System.Window.Form.SendKeys() that send unformated text
    /// </summary>
    static class StringSender
    {
        public static SendMethod Method = SendMethod.SendKeys;
        static private string WrapChar(char c)
        {
            if (c.ToString() != "(" && c.ToString() != ")" &&
                c.ToString() != "+" && c.ToString() != "%" &&
                c.ToString() != "~" && c.ToString() != "^")
                return c.ToString();
            else
                return "{" + c.ToString() + "}";
        }
        static public void SendWithSendKeys(string text)
        {
            string toSend = "";
            for (int i = 0; i < text.Length; i++)
                toSend += WrapChar(text.ToCharArray()[i]);
            SendKeys.SendWait(toSend);
        }

        static public void SendWithClipboard(string text)
        {
            var tmp = Clipboard.GetText();
            Clipboard.SetText(text);
            SendKeys.SendWait("^v");
            Clipboard.SetText(tmp);
        }

        static public void Send(string text)
        {
            if (Method == SendMethod.SendKeys)
            {
                SendWithSendKeys(text);
                return;
            }

            if (Method == SendMethod.Clipboard)
            {
                SendWithClipboard(text);
                return;
            }
            throw new Exception("Wrong method " + Method.ToString());
        }
    }

    public enum SendMethod : uint
    {
        SendKeys,
        Clipboard,
    }
}
