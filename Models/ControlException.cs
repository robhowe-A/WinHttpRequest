using System;
using System.Drawing;
using System.Windows.Forms;

namespace ArticleJsonFetch.Models
{
    public class ControlException
    {
        private ToolTip toolTip = new ToolTip();
        private Control control = new Control();
        private string caption = string.Empty;
        private Control controlSibling = new();

        public ControlException()
        {
        }

        public void createRichTextToolTip( ref ToolTip toolTip, ref RichTextBox control, string caption, string type)
        {
            this.toolTip = toolTip;
            this.control = control;
            this.caption = caption;

            if(type == "error")
            {
                this.toolTip.ToolTipIcon = ToolTipIcon.Error;
                this.control.ForeColor = Color.Red;
            }
            else if (type == "warning")
            {
                this.toolTip.ToolTipIcon = ToolTipIcon.Warning;
                this.control.ForeColor = Color.Red;
            }
            else
            {
                this.toolTip.ToolTipIcon = ToolTipIcon.Info;
                this.control.ForeColor = Color.Black;
            }
            this.toolTip.ShowAlways = true;

            control.MouseHover += setExceptionToolTip!;
        }

        public void returnRichTextToolTip(ref ToolTip toolTip, ref RichTextBox control, string caption)
        {
            this.toolTip = toolTip;
            this.control = control;
            this.caption = caption;

            this.control.ForeColor = Color.Black;
            this.toolTip.ToolTipIcon = ToolTipIcon.Error;
            this.toolTip.ShowAlways = true;

            control.MouseHover -= setExceptionToolTip!;
        }

        public void createControlExceptionToolTip(ref ToolTip toolTip, ref Control control, string caption, string type)
        {
            this.toolTip = toolTip;
            this.control = control;
            this.caption = caption;

            if (type == "error")
            {
                this.toolTip.ToolTipIcon = ToolTipIcon.Error;
                this.control.ForeColor = Color.Red;
            }
            else if (type == "warning")
            {
                this.toolTip.ToolTipIcon = ToolTipIcon.Warning;
                this.control.ForeColor = Color.Red;
            }
            else
            {
                this.toolTip.ToolTipIcon = ToolTipIcon.Info;
                this.control.ForeColor = Color.Black;
            }
            this.toolTip.ShowAlways = true;

            control.MouseHover += setExceptionToolTip!;
        }

        public void returnControlExceptionToolTip(ref ToolTip toolTip, ref Control control, string caption)
        {
            this.toolTip = toolTip;
            this.control = control;
            this.caption = caption;

            this.control.ForeColor = Color.Black;
            this.toolTip.ToolTipIcon = ToolTipIcon.Info;
            control.MouseHover -= setExceptionToolTip!;
        }

        private void setExceptionToolTip(object s,EventArgs ev)
        {
           toolTip.SetToolTip(control, caption);
        }

    }
}
