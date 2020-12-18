namespace StrategyGameSimulation.Controls
{
    partial class Building
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
            this.buildingName = new System.Windows.Forms.Label();
            this.buildingIncome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buildingName
            // 
            this.buildingName.Dock = System.Windows.Forms.DockStyle.Top;
            this.buildingName.Location = new System.Drawing.Point(0, 0);
            this.buildingName.Name = "buildingName";
            this.buildingName.Size = new System.Drawing.Size(118, 39);
            this.buildingName.TabIndex = 0;
            this.buildingName.Text = "label1";
            this.buildingName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buildingIncome
            // 
            this.buildingIncome.AutoSize = true;
            this.buildingIncome.Location = new System.Drawing.Point(40, 51);
            this.buildingIncome.Name = "buildingIncome";
            this.buildingIncome.Size = new System.Drawing.Size(38, 15);
            this.buildingIncome.TabIndex = 1;
            this.buildingIncome.Text = "label1";
            // 
            // Building
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LawnGreen;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buildingIncome);
            this.Controls.Add(this.buildingName);
            this.Name = "Building";
            this.Size = new System.Drawing.Size(118, 78);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label buildingName;
        private System.Windows.Forms.Label buildingIncome;
    }
}
