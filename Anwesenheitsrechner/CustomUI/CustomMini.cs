﻿using Anwesenheitsrechner.CustomUI.Drawing;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Anwesenheitsrechner.CustomUI
{
    public class CustomMini : Control
    {
        private MouseState State = MouseState.None;
        private int x;

        protected override void OnMouseEnter( EventArgs e )
        {
            base.OnMouseEnter( e );
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseDown( MouseEventArgs e )
        {
            base.OnMouseDown( e );
            State = MouseState.Down;
            Invalidate();
        }

        protected override void OnMouseLeave( EventArgs e )
        {
            base.OnMouseLeave( e );
            State = MouseState.None;
            Invalidate();
        }

        protected override void OnMouseUp( MouseEventArgs e )
        {
            base.OnMouseUp( e );
            State = MouseState.Over;
            Invalidate();
        }

        protected override void OnMouseMove( MouseEventArgs e )
        {
            base.OnMouseMove( e );
            x = e.X;
            Invalidate();
        }

        protected override void OnClick( EventArgs e )
        {
            base.OnClick( e );
            switch ( FindForm().WindowState )
            {
                case FormWindowState.Normal:
                    FindForm().WindowState = FormWindowState.Minimized;
                    break;

                case FormWindowState.Maximized:
                    FindForm().WindowState = FormWindowState.Minimized;
                    break;
            }
        }

        [Category( "Colors" )]
        public Color BaseColor { get; set; } = Color.FromArgb( 24, 22, 43 );

        [Category( "Colors" )]
        public Color TextColor { get; set; } = Color.FromArgb( 241, 203, 31 );

        protected override void OnResize( EventArgs e )
        {
            base.OnResize( e );
            Size = new Size( 18, 18 );
        }

        public CustomMini()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer, true );
            DoubleBuffered = true;
            BackColor = Color.White;
            Size = new Size( 18, 18 );
            Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Font = new Font( "Marlett", 14 );
        }

        protected override void OnPaint( PaintEventArgs e )
        {
            var B = new Bitmap( Width, Height );
            var G = Graphics.FromImage( B );

            var Base = new Rectangle( 0, 0, Width, Height );

            var _with5 = G;
            _with5.SmoothingMode = SmoothingMode.HighQuality;
            _with5.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _with5.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            _with5.Clear( BackColor );

            //-- Base
            _with5.FillRectangle( new SolidBrush( BaseColor ), Base );

            //-- Minimize
            _with5.DrawString( "i", Font, new SolidBrush( TextColor ), new Rectangle( 2, 1, Width, Height ),
                Helpers.CenterSF );

            //-- Hover/down
            switch ( State )
            {
                case MouseState.Over:
                    _with5.FillRectangle( new SolidBrush( Color.FromArgb( 30, Color.White ) ), Base );
                    break;

                case MouseState.Down:
                    _with5.FillRectangle( new SolidBrush( Color.FromArgb( 30, Color.Black ) ), Base );
                    break;
            }

            base.OnPaint( e );
            G.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled( B, 0, 0 );
            B.Dispose();
        }
    }
}