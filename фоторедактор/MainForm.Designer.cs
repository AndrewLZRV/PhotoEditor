namespace фоторедактор
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePNGImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveJPGImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBMPImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.instrumentsPanel = new System.Windows.Forms.Panel();
            this.drawLineButton = new System.Windows.Forms.Button();
            this.selectModeButton = new System.Windows.Forms.Button();
            this.fillButton = new System.Windows.Forms.Button();
            this.colorsPanel = new System.Windows.Forms.Panel();
            this.changeColorsButton = new System.Windows.Forms.Button();
            this.secondColorPictureBox = new System.Windows.Forms.PictureBox();
            this.firstColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.coordLb = new System.Windows.Forms.Label();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.selectionDrawerTimer = new System.Windows.Forms.Timer(this.components);
            this.lineDrawTimer = new System.Windows.Forms.Timer(this.components);
            this.circleDrawModeButton = new System.Windows.Forms.Button();
            this.circleDrawTimer = new System.Windows.Forms.Timer(this.components);
            this.mainMenuStrip.SuspendLayout();
            this.instrumentsPanel.SuspendLayout();
            this.colorsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstColorPictureBox)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.Gainsboro;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.imageToolStripMenu});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1264, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьКакToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePNGImageMenuItem,
            this.saveJPGImageMenuItem,
            this.saveBMPImageMenuItem});
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            // 
            // savePNGImageMenuItem
            // 
            this.savePNGImageMenuItem.Name = "savePNGImageMenuItem";
            this.savePNGImageMenuItem.Size = new System.Drawing.Size(99, 22);
            this.savePNGImageMenuItem.Text = "PNG";
            this.savePNGImageMenuItem.Click += new System.EventHandler(this.savePNGImageMenuItem_Click);
            // 
            // saveJPGImageMenuItem
            // 
            this.saveJPGImageMenuItem.Name = "saveJPGImageMenuItem";
            this.saveJPGImageMenuItem.Size = new System.Drawing.Size(99, 22);
            this.saveJPGImageMenuItem.Text = "JPG";
            this.saveJPGImageMenuItem.Click += new System.EventHandler(this.saveJPGImageMenuItem_Click);
            // 
            // saveBMPImageMenuItem
            // 
            this.saveBMPImageMenuItem.Name = "saveBMPImageMenuItem";
            this.saveBMPImageMenuItem.Size = new System.Drawing.Size(99, 22);
            this.saveBMPImageMenuItem.Text = "BMP";
            this.saveBMPImageMenuItem.Click += new System.EventHandler(this.saveBMPImageMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(160, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitMenuItem.Text = "Выход";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // imageToolStripMenu
            // 
            this.imageToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageMenuItem,
            this.toolStripSeparator4});
            this.imageToolStripMenu.Name = "imageToolStripMenu";
            this.imageToolStripMenu.Size = new System.Drawing.Size(95, 20);
            this.imageToolStripMenu.Text = "Изображение";
            // 
            // loadImageMenuItem
            // 
            this.loadImageMenuItem.Name = "loadImageMenuItem";
            this.loadImageMenuItem.Size = new System.Drawing.Size(205, 22);
            this.loadImageMenuItem.Text = "Загрузить изображение";
            this.loadImageMenuItem.Click += new System.EventHandler(this.loadImageMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(202, 6);
            // 
            // instrumentsPanel
            // 
            this.instrumentsPanel.Controls.Add(this.circleDrawModeButton);
            this.instrumentsPanel.Controls.Add(this.drawLineButton);
            this.instrumentsPanel.Controls.Add(this.selectModeButton);
            this.instrumentsPanel.Controls.Add(this.fillButton);
            this.instrumentsPanel.Controls.Add(this.colorsPanel);
            this.instrumentsPanel.Controls.Add(this.label1);
            this.instrumentsPanel.Location = new System.Drawing.Point(0, 27);
            this.instrumentsPanel.Name = "instrumentsPanel";
            this.instrumentsPanel.Size = new System.Drawing.Size(228, 642);
            this.instrumentsPanel.TabIndex = 1;
            // 
            // drawLineButton
            // 
            this.drawLineButton.Location = new System.Drawing.Point(12, 124);
            this.drawLineButton.Name = "drawLineButton";
            this.drawLineButton.Size = new System.Drawing.Size(206, 22);
            this.drawLineButton.TabIndex = 4;
            this.drawLineButton.Text = "Нарисовать линию";
            this.drawLineButton.UseVisualStyleBackColor = true;
            this.drawLineButton.Click += new System.EventHandler(this.drawLineButton_Click);
            // 
            // selectModeButton
            // 
            this.selectModeButton.Location = new System.Drawing.Point(11, 54);
            this.selectModeButton.Name = "selectModeButton";
            this.selectModeButton.Size = new System.Drawing.Size(206, 22);
            this.selectModeButton.TabIndex = 3;
            this.selectModeButton.Text = "Выделение";
            this.selectModeButton.UseVisualStyleBackColor = true;
            this.selectModeButton.Click += new System.EventHandler(this.selectModeButton_Click);
            // 
            // fillButton
            // 
            this.fillButton.Location = new System.Drawing.Point(11, 96);
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(206, 22);
            this.fillButton.TabIndex = 2;
            this.fillButton.Text = "Заливка";
            this.fillButton.UseVisualStyleBackColor = true;
            this.fillButton.Click += new System.EventHandler(this.fillButton_Click);
            // 
            // colorsPanel
            // 
            this.colorsPanel.Controls.Add(this.changeColorsButton);
            this.colorsPanel.Controls.Add(this.secondColorPictureBox);
            this.colorsPanel.Controls.Add(this.firstColorPictureBox);
            this.colorsPanel.Location = new System.Drawing.Point(3, 553);
            this.colorsPanel.Name = "colorsPanel";
            this.colorsPanel.Size = new System.Drawing.Size(222, 86);
            this.colorsPanel.TabIndex = 1;
            // 
            // changeColorsButton
            // 
            this.changeColorsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeColorsButton.Location = new System.Drawing.Point(57, 24);
            this.changeColorsButton.Name = "changeColorsButton";
            this.changeColorsButton.Size = new System.Drawing.Size(108, 43);
            this.changeColorsButton.TabIndex = 2;
            this.changeColorsButton.Text = "Сменить";
            this.changeColorsButton.UseVisualStyleBackColor = true;
            this.changeColorsButton.Click += new System.EventHandler(this.changeColorsButton_Click);
            // 
            // secondColorPictureBox
            // 
            this.secondColorPictureBox.Location = new System.Drawing.Point(171, 24);
            this.secondColorPictureBox.Name = "secondColorPictureBox";
            this.secondColorPictureBox.Size = new System.Drawing.Size(43, 43);
            this.secondColorPictureBox.TabIndex = 1;
            this.secondColorPictureBox.TabStop = false;
            this.secondColorPictureBox.Click += new System.EventHandler(this.secondColorPictureBox_Click);
            // 
            // firstColorPictureBox
            // 
            this.firstColorPictureBox.Location = new System.Drawing.Point(8, 24);
            this.firstColorPictureBox.Name = "firstColorPictureBox";
            this.firstColorPictureBox.Size = new System.Drawing.Size(43, 43);
            this.firstColorPictureBox.TabIndex = 0;
            this.firstColorPictureBox.TabStop = false;
            this.firstColorPictureBox.Click += new System.EventHandler(this.firstColorPictureBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Панель инструментов";
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.LightGray;
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.mainPictureBox);
            this.mainPanel.Location = new System.Drawing.Point(234, 27);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1030, 642);
            this.mainPanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.coordLb);
            this.panel1.Location = new System.Drawing.Point(3, 577);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 62);
            this.panel1.TabIndex = 1;
            // 
            // coordLb
            // 
            this.coordLb.AutoSize = true;
            this.coordLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coordLb.Location = new System.Drawing.Point(3, 7);
            this.coordLb.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.coordLb.Name = "coordLb";
            this.coordLb.Size = new System.Drawing.Size(151, 24);
            this.coordLb.TabIndex = 0;
            this.coordLb.Text = "X: 1.121 Y: 1.124";
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.mainPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mainPictureBox.Location = new System.Drawing.Point(3, 3);
            this.mainPictureBox.Margin = new System.Windows.Forms.Padding(5);
            this.mainPictureBox.MaximumSize = new System.Drawing.Size(1024, 576);
            this.mainPictureBox.MinimumSize = new System.Drawing.Size(0, 576);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(1024, 576);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.WaitOnLoad = true;
            this.mainPictureBox.MouseLeave += new System.EventHandler(this.mainPictureBox_MouseLeave);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
            // 
            // selectionDrawerTimer
            // 
            this.selectionDrawerTimer.Interval = 10;
            this.selectionDrawerTimer.Tick += new System.EventHandler(this.selectionDrawerTimer_Tick);
            // 
            // lineDrawTimer
            // 
            this.lineDrawTimer.Interval = 10;
            this.lineDrawTimer.Tick += new System.EventHandler(this.lineDrawTimer_Tick);
            // 
            // circleDrawModeButton
            // 
            this.circleDrawModeButton.Location = new System.Drawing.Point(13, 153);
            this.circleDrawModeButton.Name = "circleDrawModeButton";
            this.circleDrawModeButton.Size = new System.Drawing.Size(204, 24);
            this.circleDrawModeButton.TabIndex = 5;
            this.circleDrawModeButton.Text = "Нарисовать круг";
            this.circleDrawModeButton.UseVisualStyleBackColor = true;
            this.circleDrawModeButton.Click += new System.EventHandler(this.circleDrawModeButton_Click);
            // 
            // circleDrawTimer
            // 
            this.circleDrawTimer.Interval = 10;
            this.circleDrawTimer.Tick += new System.EventHandler(this.circleDrawTimer_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.instrumentsPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FotoDrawer";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.instrumentsPanel.ResumeLayout(false);
            this.instrumentsPanel.PerformLayout();
            this.colorsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.secondColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstColorPictureBox)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.Panel instrumentsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Panel colorsPanel;
        private System.Windows.Forms.PictureBox firstColorPictureBox;
        private System.Windows.Forms.PictureBox secondColorPictureBox;
        private System.Windows.Forms.Button changeColorsButton;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.Button fillButton;
        private System.Windows.Forms.Button selectModeButton;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem loadImageMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label coordLb;
        private System.Windows.Forms.Timer selectionDrawerTimer;
        private System.Windows.Forms.ToolStripMenuItem savePNGImageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveJPGImageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBMPImageMenuItem;
        private System.Windows.Forms.Button drawLineButton;
        private System.Windows.Forms.Timer lineDrawTimer;
        private System.Windows.Forms.Button circleDrawModeButton;
        private System.Windows.Forms.Timer circleDrawTimer;
    }
}

