using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawApp
{
    public partial class Form1 : Form
    {
        Pallet pallet;
        List<Figure> figures = new List<Figure>();

        // メイン画面のコンストラクタ
        public Form1()
        {
            InitializeComponent();
            this.pallet = new Pallet();
            pallet.Show();
        }

        // ペイントイベントハンドラ
        private void DrawFigures(object sender, PaintEventArgs e)
        {
            // 図形を描画
            foreach (var f in figures)
            {
                f.Draw(e);
            }
        }

        // マウスクリックイベントハンドラ
        private void MousePressed(object sender, MouseEventArgs e)
        {
            figures.Add(
                new Figure(
                    this.pallet.GetFigureType(),
                    new Point(e.X, e.Y),
                    new Point(e.X, e.Y), 
                    this.pallet.GetColor(), 
                    this.pallet.GetPenSize()
                    )
                );
        }

        // マウスドラッグイベントハンドラ
        private void MouseDragged(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 終点座標を更新する
                figures.Last().EndPos = new Point(e.X, e.Y);

                Invalidate();
            }
        }
    }
}
