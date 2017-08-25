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
    public partial class Pallet : Form
    {
        int figureType;     // 図形の種類

        // 図形の種類を取得する
        public int GetFigureType()
        {
            return figureType;
        }

        // ペンの太さを取得する
        public int GetPenSize()
        {
            int size;
            if (int.TryParse(this.penSizeBox.Text, out size))
            {
                return size;
            }
            else
            {
                return 1;
            }
        }

        // 描画色を取得する
        public Color GetColor()
        {
            return colorButton.BackColor;
        }

        // Palletクラスコンストラクタ
        public Pallet()
        {
            InitializeComponent();
            this.figureType = 1;
        }

        // 円ボタンがクリックされた
        private void CircleButtonClicked(object sender, EventArgs e)
        {
            this.figureType = 1;
        }

        // 四角形ボタンがクリックされた
        private void RectButtonClicked(object sender, EventArgs e)
        {
            this.figureType = 2;
        }

        // 直線ボタンがクリックされた
        private void LineButtonClicked(object sender, EventArgs e)
        {
            this.figureType = 3;
        }

        // 色変更ボタンがクリックされた
        private void ColorButtonClicked(object sender, EventArgs e)
        {
            // カラーダイアログを表示する
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // 選択した色をボタンに設定する
                colorButton.BackColor = colorDialog.Color;
            }
        }
    }
}
