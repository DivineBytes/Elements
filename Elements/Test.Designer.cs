namespace Elements
{
    partial class Test
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
            this.components = new System.ComponentModel.Container();
            this.gradient1 = new Elements.Components.Gradient.Gradient(this.components);
            this.SuspendLayout();
            // 
            // gradient1
            // 
            this.gradient1.AutoSize = true;
            this.gradient1.BottomLeft = System.Drawing.Color.Black;
            this.gradient1.BottomRight = System.Drawing.Color.Red;
            this.gradient1.Control = null;
            this.gradient1.Size = new System.Drawing.Size(25, 25);
            this.gradient1.TopLeft = System.Drawing.Color.Green;
            this.gradient1.TopRight = System.Drawing.Color.Yellow;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "Test";
            this.Size = new System.Drawing.Size(487, 347);
            this.ResumeLayout(false);

        }

        #endregion

        private Components.Gradient.Gradient gradient1;
    }
}
