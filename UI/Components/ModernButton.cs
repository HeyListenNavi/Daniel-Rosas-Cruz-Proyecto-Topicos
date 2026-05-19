using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Daniel_Rosas_Cruz.UI.Components
{
    public class ModernButton : Button
    {
        private Color _normalColor = Color.FromArgb(0, 120, 215); // SaaS Blue
        private Color _hoverColor = Color.FromArgb(0, 102, 204);
        private Color _pressedColor = Color.FromArgb(0, 80, 170);
        private bool _isHovered = false;
        private bool _isPressed = false;

        public Color NormalColor
        {
            get => _normalColor;
            set { _normalColor = value; Invalidate(); }
        }

        public ModernButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = _normalColor;
            this.ForeColor = Color.White;
            this.Cursor = Cursors.Hand;
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.Size = new Size(120, 35);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            _isPressed = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            _isPressed = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color currentBackColor = _normalColor;
            if (_isPressed) currentBackColor = _pressedColor;
            else if (_isHovered) currentBackColor = _hoverColor;

            // SaaS Look: Rounded corners (simulated or just clean rectangles)
            using (SolidBrush brush = new SolidBrush(currentBackColor))
            {
                g.Clear(this.Parent?.BackColor ?? Color.White);
                g.FillRectangle(brush, 0, 0, this.Width, this.Height);
            }

            // Text with better rendering
            TextRenderer.DrawText(g, this.Text, this.Font, this.ClientRectangle, this.ForeColor, 
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
