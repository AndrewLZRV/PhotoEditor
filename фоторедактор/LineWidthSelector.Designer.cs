namespace фоторедактор
{
    partial class LineWidthSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.widthTrack = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.widthTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(258, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // widthTrack
            // 
            this.widthTrack.LargeChange = 18;
            this.widthTrack.Location = new System.Drawing.Point(12, 43);
            this.widthTrack.Maximum = 30;
            this.widthTrack.Minimum = 1;
            this.widthTrack.Name = "widthTrack";
            this.widthTrack.Size = new System.Drawing.Size(436, 45);
            this.widthTrack.TabIndex = 1;
            this.widthTrack.Value = 3;
            this.widthTrack.Scroll += new System.EventHandler(this.widthTrack_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MingLiU-ExtB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ширина линии - 3";
            // 
            // LineWidthSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 144);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.widthTrack);
            this.Controls.Add(this.button1);
            this.Name = "LineWidthSelector";
            this.Text = "Определение ширины линии";
            ((System.ComponentModel.ISupportInitialize)(this.widthTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar widthTrack;
        private System.Windows.Forms.Label label1;
    }
}