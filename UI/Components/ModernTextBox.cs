using System;
using System.Drawing;
using System.Windows.Forms;

namespace Daniel_Rosas_Cruz.UI.Components
{
    public class ModernTextBox : UserControl
    {
        private TextBox _innerTextBox;
        private Color _borderColor = Color.FromArgb(220, 220, 220); // Soft Gray
        private Color _focusColor = Color.FromArgb(0, 120, 215); // SaaS Blue
        private bool _isFocused = false;

        public string TextValue
        {
            get => _innerTextBox.Text;
            set => _innerTextBox.Text = value;
        }

        public ModernTextBox()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.Padding = new Padding(8, 8, 8, 8);
            this.Size = new Size(200, 35);
        }

        private void InitializeComponent()
        {
            _innerTextBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(45, 45, 45),
                Font = new Font("Segoe UI", 10F),
                Dock = DockStyle.Fill
            };

            _innerTextBox.Enter += (s, e) => { _isFocused = true; Invalidate(); };
            _innerTextBox.Leave += (s, e) => { _isFocused = false; Invalidate(); };
            _innerTextBox.TextChanged += (s, e) => OnTextChanged(e);

            this.Controls.Add(_innerTextBox);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Color currentColor = _isFocused ? _focusColor : _borderColor;
            int borderThickness = _isFocused ? 2 : 1;

            using (Pen pen = new Pen(currentColor, borderThickness))
            {
                // Draw rounded-like rectangle border
                g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        public void Clear() => _innerTextBox.Clear();
    }
}
