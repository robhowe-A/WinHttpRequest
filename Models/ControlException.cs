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

        public void createInfoToolTip( ref ToolTip toolTip, ref Control control, string caption)
        {
            this.toolTip = toolTip;
            this.control = control;
            this.caption = caption;

            this.control.ForeColor = Color.Black;
            this.toolTip.ToolTipIcon = ToolTipIcon.Info;
            this.toolTip.AutoPopDelay = 4000;
            this.toolTip.ShowAlways = true;

            control.MouseHover += setExceptionToolTip!;
        }

        public void createInfoToolTip(ref ToolTip toolTip, ref RichTextBox control, string caption)
        {
            this.toolTip = toolTip;
            this.control = control;
            this.caption = caption;

            this.control.ForeColor = Color.Black;
            this.toolTip.ToolTipIcon = ToolTipIcon.Info;
            this.toolTip.AutoPopDelay = 4000;
            this.toolTip.ShowAlways = true;

            control.MouseHover += setExceptionToolTip!;
        }

        public void createExceptionToolTip(ref ToolTip toolTip, ref Control control, string caption)
        {
            this.toolTip = toolTip;
            this.control = control;
            this.caption = caption;

            this.control.ForeColor = Color.Red;
            this.toolTip.ToolTipIcon = ToolTipIcon.Error;
            this.toolTip.AutoPopDelay = 4000;
            this.toolTip.ShowAlways = true;

            control.MouseHover += setExceptionToolTip!;
        }

        public void returnExceptionToolTip(ToolTip toolTip, Control control, string caption)
        {
            this.toolTip = toolTip;
            this.control = control;
            this.caption = caption;

            this.control.ForeColor = Color.Black;
            this.toolTip.SetToolTip(control, caption);
            this.toolTip.ToolTipIcon = ToolTipIcon.Info;
            control.MouseHover -= setExceptionToolTip!;
        }

        private void setExceptionToolTip(object s,EventArgs ev)
        {
           toolTip.SetToolTip(control, caption);
        }

    }
}
