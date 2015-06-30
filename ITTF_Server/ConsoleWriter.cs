using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITTF_Server
{
    public class ControlWriter : TextWriter
    {
        private System.Object lockThis = new System.Object();
        private RichTextBox textbox;
        public ControlWriter(RichTextBox textbox)
        {
            this.textbox = textbox;
        }

        private void Scroll()
        {
            if (textbox.InvokeRequired)
            {
                textbox.Invoke(new MethodInvoker(() => 
                {
                    textbox.SelectionStart = textbox.Text.Length;
                    textbox.ScrollToCaret();
                }));
            }
            else
            {
                textbox.SelectionStart = textbox.Text.Length; //Set the current caret position at the end
                textbox.ScrollToCaret();
            }
        }

        public override void Write(char value)
        {
            lock(lockThis)
            {
                if (textbox.InvokeRequired)
                {
                    textbox.Invoke(new MethodInvoker(() =>
                    {
                        textbox.Text += value;
                    }));
                }
                else
                {
                    textbox.Text += value;
                }
                Scroll();
            }
        }

        public override void Write(string value)
        {
            lock (lockThis)
            {
                if (textbox.InvokeRequired)
                {
                    textbox.Invoke(new MethodInvoker(() =>
                    {
                        textbox.Text += value;
                    }));
                }
                else
                {
                    textbox.Text += value;
                }
                Scroll();
            }
        }

        public override void WriteLine(string value)
        {
            lock (lockThis)
            {
                if (textbox.InvokeRequired)
                {
                    textbox.Invoke(new MethodInvoker(() =>
                    {
                        textbox.Text += value + "\r\n";
                    }));
                }
                else
                {
                    textbox.Text += value + "\r\n";
                }
                Scroll();
            }
        }

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
}
