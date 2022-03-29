namespace ObjGrid
{
    partial class UcGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UcGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UcGrid";
            this.Size = new System.Drawing.Size(348, 214);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucGrid_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucGrid_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UcGrid_MouseUp);
            this.Resize += new System.EventHandler(this.ucGrid_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
