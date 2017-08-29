namespace DrawApp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NewItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DisplayMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PalletWindowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.DisplayMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(793, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewItemMenu,
            this.OpenMenu,
            this.SaveMenu,
            this.ExportMenu});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(75, 29);
            this.FileMenu.Text = "ファイル";
            // 
            // NewItemMenu
            // 
            this.NewItemMenu.Name = "NewItemMenu";
            this.NewItemMenu.Size = new System.Drawing.Size(223, 30);
            this.NewItemMenu.Text = "新規作成";
            this.NewItemMenu.Click += new System.EventHandler(this.NewItemMenuClicked);
            // 
            // OpenMenu
            // 
            this.OpenMenu.Name = "OpenMenu";
            this.OpenMenu.Size = new System.Drawing.Size(223, 30);
            this.OpenMenu.Text = "開く";
            this.OpenMenu.Click += new System.EventHandler(this.OpenMenuClicked);
            // 
            // SaveMenu
            // 
            this.SaveMenu.Name = "SaveMenu";
            this.SaveMenu.Size = new System.Drawing.Size(223, 30);
            this.SaveMenu.Text = "保存";
            this.SaveMenu.Click += new System.EventHandler(this.SaveMenuClicked);
            // 
            // ExportMenu
            // 
            this.ExportMenu.Name = "ExportMenu";
            this.ExportMenu.Size = new System.Drawing.Size(223, 30);
            this.ExportMenu.Text = "pngでエクスポート";
            // 
            // EditMenu
            // 
            this.EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoMenu,
            this.RedoMenu});
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(60, 29);
            this.EditMenu.Text = "編集";
            // 
            // UndoMenu
            // 
            this.UndoMenu.Enabled = false;
            this.UndoMenu.Name = "UndoMenu";
            this.UndoMenu.Size = new System.Drawing.Size(161, 30);
            this.UndoMenu.Text = "元に戻す";
            this.UndoMenu.Click += new System.EventHandler(this.UndoMenuClicked);
            // 
            // RedoMenu
            // 
            this.RedoMenu.Enabled = false;
            this.RedoMenu.Name = "RedoMenu";
            this.RedoMenu.Size = new System.Drawing.Size(161, 30);
            this.RedoMenu.Text = "やり直す";
            this.RedoMenu.Click += new System.EventHandler(this.RedoMenuClicked);
            // 
            // DisplayMenu
            // 
            this.DisplayMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PalletWindowMenu});
            this.DisplayMenu.Name = "DisplayMenu";
            this.DisplayMenu.Size = new System.Drawing.Size(60, 29);
            this.DisplayMenu.Text = "表示";
            // 
            // PalletWindowMenu
            // 
            this.PalletWindowMenu.Name = "PalletWindowMenu";
            this.PalletWindowMenu.Size = new System.Drawing.Size(213, 30);
            this.PalletWindowMenu.Text = "パレットウインドウ";
            this.PalletWindowMenu.Click += new System.EventHandler(this.PalletWindowMenuClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(793, 543);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "DrawApp";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawFigures);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MousePressed);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseDragged);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUnpressed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem NewItemMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenMenu;
        private System.Windows.Forms.ToolStripMenuItem SaveMenu;
        private System.Windows.Forms.ToolStripMenuItem ExportMenu;
        private System.Windows.Forms.ToolStripMenuItem EditMenu;
        private System.Windows.Forms.ToolStripMenuItem UndoMenu;
        private System.Windows.Forms.ToolStripMenuItem RedoMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DisplayMenu;
        private System.Windows.Forms.ToolStripMenuItem PalletWindowMenu;
    }
}
