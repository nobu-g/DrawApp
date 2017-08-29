using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DrawApp
{
    [Serializable]
    class Figure
    {
        int figureType;
        Point startPos, endPos;
        Color color;
        int penSize;

        public Point EndPos
        {
            set { endPos = value; }
        }

        public Figure(int figureType, Point startPos, Point endPos, Color color, int penSize)
        {
            this.figureType = figureType;
            this.startPos = startPos;
            this.endPos = endPos;
            this.color = color;
            this.penSize = penSize;
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (figureType == 1)          // 円を描画
            {
                // startPosからendPosの範囲で円を描画する
                SolidBrush brush = new SolidBrush(color);

                int width = this.endPos.X - this.startPos.X;
                int height = this.endPos.Y - this.startPos.Y;

                e.Graphics.FillEllipse(brush, this.startPos.X, this.startPos.Y, width, height);
            }
            else if (figureType == 2)     // 長方形を描画
            {
                SolidBrush brush = new SolidBrush(color);

                int x = Math.Min(this.startPos.X, this.endPos.X);
                int y = Math.Min(this.startPos.Y, this.endPos.Y);
                int width = Math.Abs(this.endPos.X - this.startPos.X);
                int height = Math.Abs(this.endPos.Y - this.startPos.Y);

                e.Graphics.FillRectangle(brush, x, y, width, height);
            }

            else if (figureType == 3)     // 直線を描画
            {
                Pen pen = new Pen(color, penSize);

                e.Graphics.DrawLine(pen, this.startPos.X, this.startPos.Y, this.endPos.X, this.endPos.Y);
            }

        }

        public bool IsVoid
        {
            get { return startPos == endPos; }
        }
    }
}
