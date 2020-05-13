namespace Moondo
{
    partial class LocationResultForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.subtitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("12롯데마트행복Bold", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "나의 MBTI 유형은?";
            // 
            // subtitle
            // 
            this.subtitle.AutoSize = true;
            this.subtitle.Font = new System.Drawing.Font("12롯데마트드림Medium", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.subtitle.Location = new System.Drawing.Point(32, 73);
            this.subtitle.Name = "subtitle";
            this.subtitle.Size = new System.Drawing.Size(131, 29);
            this.subtitle.TabIndex = 1;
            this.subtitle.Text = "SUBTITLE";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("12롯데마트드림Medium", 20.25F);
            this.label2.Location = new System.Drawing.Point(32, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(724, 245);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // LocationResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subtitle);
            this.Controls.Add(this.label1);
            this.Name = "LocationResultForm";
            this.Text = "검사결과_2 LOCATION";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label subtitle;
        private System.Windows.Forms.Label label2;
    }
}