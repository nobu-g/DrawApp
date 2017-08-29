using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DrawApp
{
    public partial class Form1 : Form
    {
        Pallet pallet;
        List<Figure> figures = new List<Figure>();
        Figure drawingFigure;
        Stack<Figure> garbage = new Stack<Figure>();

        // メイン画面のコンストラクタ
        public Form1()
        {
            InitializeComponent();
            this.pallet = new Pallet();
            pallet.Show();

            string[] commandLine = Environment.GetCommandLineArgs();
            if(2 <= commandLine.Count())
            {
                OpenFile(commandLine[1]);
            }
        }

        // ペイントイベントハンドラ
        private void DrawFigures(object sender, PaintEventArgs e)
        {
            // 過去の図形を描画
            foreach (var f in figures)
            {
                f.Draw(e);
            }
            // 現在の図形を描画
            if (drawingFigure != null)
                drawingFigure.Draw(e);
        }

        // マウスクリック
        private void MousePressed(object sender, MouseEventArgs e)
        {
            drawingFigure = new Figure(
                this.pallet.GetFigureType(),
                new Point(e.X, e.Y),
                new Point(e.X, e.Y),
                this.pallet.GetColor(),
                this.pallet.GetPenSize()
                );
        }

        // マウスが離された
        private void MouseUnpressed(object sender, MouseEventArgs e)
        {
            if(drawingFigure == null)
            {
                return;
            }

            if (!drawingFigure.IsVoid)
            {
                figures.Add(drawingFigure);
                drawingFigure = null;
                UndoMenu.Enabled = true;
                garbage.Clear();
                RedoMenu.Enabled = false;
            }            
        }

        // マウスドラッグ
        private void MouseDragged(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (drawingFigure != null)
                {
                    // 終点座標を更新する
                    drawingFigure.EndPos = new Point(e.X, e.Y);

                    Invalidate();
                }
            }
        }

        // 新規作成ボタン
        private void NewItemMenuClicked(object sender, EventArgs e)
        {
            figures.Clear();
            garbage.Clear();
            UndoMenu.Enabled = false;
            RedoMenu.Enabled = false;
            Invalidate();
        }
        
        // 元に戻すボタン
        private void UndoMenuClicked(object sender, EventArgs e)
        {
            garbage.Push(figures.Last());
            figures.Remove(figures.Last());

            RedoMenu.Enabled = true;
            if(figures.Count == 0)
            {
                UndoMenu.Enabled = false;
            }

            Invalidate();
        }

        // やり直すボタン
        private void RedoMenuClicked(object sender, EventArgs e)
        {
            figures.Add(garbage.Pop());
            UndoMenu.Enabled = true;
            if(garbage.Count == 0)
            {
                RedoMenu.Enabled = false;
            }

            Invalidate();
        }

        // パレットウインドウを表示
        private void PalletWindowMenuClicked(object sender, EventArgs e)
        {
            if (pallet.IsDisposed)
            {
                pallet = new Pallet();
                pallet.Show();
            }

            pallet.Activate();
        }

        // 保存ボタン
        private void SaveMenuClicked(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                FileName = "無題.fig",
                Filter = "DrawAppファイル(*.fig)| *.fig",
                Title = "保存先のファイルを選択してください",
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream stream = saveFileDialog.OpenFile())
                {
                    if (stream != null)
                    {
                        using (var writer = new StreamWriter(stream))
                        {
                            var binaryFormatter = new BinaryFormatter();
                            try
                            {
                                binaryFormatter.Serialize(stream, figures);
                            }
                            catch(SerializationException exp)
                            {
                                MessageBox.Show("保存に失敗しました\n" + exp.Message,
                                    "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        // 開くボタン
        private void OpenMenuClicked(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "DrawAppファイル (*.fig)|*.fig|すべてのファイル (*.*)|(*.*)"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFile(openFileDialog.FileName);
            }
        }

        // ファイルを開く
        private void OpenFile(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(stream))
            {
                var binaryFormatter = new BinaryFormatter();
                try
                {
                    figures = (List<Figure>)binaryFormatter.Deserialize(stream);
                }
                catch (SerializationException exp)
                {
                    MessageBox.Show("読み取りに失敗しました\n" + exp.Message,
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                Invalidate();
            }
        }
    }
}
