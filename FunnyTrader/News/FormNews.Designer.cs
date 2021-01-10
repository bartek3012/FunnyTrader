namespace FunnyTrader.News
{
    partial class FormNews
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
            this.pictureBoxNews = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelNewsText = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNews)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxNews
            // 
            this.pictureBoxNews.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxNews.Location = new System.Drawing.Point(12, 23);
            this.pictureBoxNews.Name = "pictureBoxNews";
            this.pictureBoxNews.Size = new System.Drawing.Size(379, 290);
            this.pictureBoxNews.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxNews.TabIndex = 0;
            this.pictureBoxNews.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelTitle.Location = new System.Drawing.Point(397, 26);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(342, 73);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Tytuł artykułu dfgfgfg dfdfdf ";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNewsText
            // 
            this.labelNewsText.AllowDrop = true;
            this.labelNewsText.BackColor = System.Drawing.Color.Transparent;
            this.labelNewsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNewsText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNewsText.Location = new System.Drawing.Point(397, 99);
            this.labelNewsText.Name = "labelNewsText";
            this.labelNewsText.Size = new System.Drawing.Size(342, 183);
            this.labelNewsText.TabIndex = 2;
            this.labelNewsText.Text = "Jakaś treścadsdfdfdfd dfdf sdf sdf sdfsdfsdfd dfdfdf";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonClose.Location = new System.Drawing.Point(512, 285);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(122, 41);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Zamknij";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // FormNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FunnyTrader.Properties.Resources.BackgroundNews;
            this.ClientSize = new System.Drawing.Size(751, 335);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelNewsText);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBoxNews);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNews";
            this.Text = "Wiadomości";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNews)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxNews;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelNewsText;
        private System.Windows.Forms.Button buttonClose;
    }
}