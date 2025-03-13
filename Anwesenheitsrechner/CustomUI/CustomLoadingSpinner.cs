using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI
{
    /// <summary>
    /// Custom loading spinner control with animated segments.
    /// </summary>
    public class CustomLoadingSpinner : Control
    {
        private readonly Timer timer;
        private int angle = 0;
        private const int NumberOfSegments = 12;

        /// <summary>
        /// Gets or sets the base color of the spinner.
        /// </summary>
        [Category("Colors")]
        public Color BaseColor { get; set; } = Color.Gray;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomLoadingSpinner"/> class.
        /// </summary>
        public CustomLoadingSpinner()
        {
            // Set the control size
            Size = new Size(100, 100);

            // Initialize the animation timer
            timer = new Timer
            {
                Interval = 50 // Adjust speed (lower = faster)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        /// <summary>
        /// Handles the timer tick event to update the spinner angle and redraw the control.
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            angle = (angle + 30) % 360; // Rotate the spinner
            Invalidate(); // Redraw the control
        }

        /// <summary>
        /// Paints the loading spinner control.
        /// </summary>
        /// <param name="e">The paint event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            float centerX = Width / 2f;
            float centerY = Height / 2f;
            float radius = Math.Min(centerX, centerY) - 10;

            for (int i = 0; i < NumberOfSegments; i++)
            {
                int alpha = (int)(255 * (i + 1) / (float)NumberOfSegments);
                Color color = Color.FromArgb(alpha, BaseColor);
                using (Pen pen = new Pen(color, 4))
                {
                    float angleStep = (360f / NumberOfSegments) * i;
                    float startAngle = angle + angleStep;
                    float x1 = centerX + (float)Math.Cos(startAngle * Math.PI / 180) * radius;
                    float y1 = centerY + (float)Math.Sin(startAngle * Math.PI / 180) * radius;
                    float x2 = centerX + (float)Math.Cos(startAngle * Math.PI / 180) * (radius - 10);
                    float y2 = centerY + (float)Math.Sin(startAngle * Math.PI / 180) * (radius - 10);

                    e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                }
            }
        }
    }
}