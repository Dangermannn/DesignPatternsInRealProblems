namespace StrategyGameSimulation.Controls
{
    partial class BuildingAdder
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
            this.buyBtn = new System.Windows.Forms.Button();
            this.buildingName = new System.Windows.Forms.Label();
            this.buildingIncome = new System.Windows.Forms.Label();
            this.buildingPrice = new System.Windows.Forms.Label();
            this.incomeLbl = new System.Windows.Forms.Label();
            this.priceLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buyBtn
            // 
            this.buyBtn.Location = new System.Drawing.Point(39, 63);
            this.buyBtn.Name = "buyBtn";
            this.buyBtn.Size = new System.Drawing.Size(75, 23);
            this.buyBtn.TabIndex = 0;
            this.buyBtn.Text = "Zbuduj";
            this.buyBtn.UseVisualStyleBackColor = true;
            this.buyBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // buildingName
            // 
            this.buildingName.AutoSize = true;
            this.buildingName.Location = new System.Drawing.Point(4, 3);
            this.buildingName.Name = "buildingName";
            this.buildingName.Size = new System.Drawing.Size(38, 15);
            this.buildingName.TabIndex = 1;
            this.buildingName.Text = "label1";
            this.buildingName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buildingIncome
            // 
            this.buildingIncome.AutoSize = true;
            this.buildingIncome.Location = new System.Drawing.Point(55, 28);
            this.buildingIncome.Name = "buildingIncome";
            this.buildingIncome.Size = new System.Drawing.Size(38, 15);
            this.buildingIncome.TabIndex = 2;
            this.buildingIncome.Text = "label1";
            // 
            // buildingPrice
            // 
            this.buildingPrice.AutoSize = true;
            this.buildingPrice.Location = new System.Drawing.Point(55, 43);
            this.buildingPrice.Name = "buildingPrice";
            this.buildingPrice.Size = new System.Drawing.Size(38, 15);
            this.buildingPrice.TabIndex = 3;
            this.buildingPrice.Text = "label1";
            // 
            // incomeLbl
            // 
            this.incomeLbl.AutoSize = true;
            this.incomeLbl.Location = new System.Drawing.Point(-1, 28);
            this.incomeLbl.Name = "incomeLbl";
            this.incomeLbl.Size = new System.Drawing.Size(56, 15);
            this.incomeLbl.TabIndex = 4;
            this.incomeLbl.Text = "Przichōd:";
            // 
            // priceLbl
            // 
            this.priceLbl.AutoSize = true;
            this.priceLbl.Location = new System.Drawing.Point(-1, 43);
            this.priceLbl.Name = "priceLbl";
            this.priceLbl.Size = new System.Drawing.Size(37, 15);
            this.priceLbl.TabIndex = 5;
            this.priceLbl.Text = "Cyna:";
            // 
            // BuildingAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.priceLbl);
            this.Controls.Add(this.incomeLbl);
            this.Controls.Add(this.buildingPrice);
            this.Controls.Add(this.buildingIncome);
            this.Controls.Add(this.buildingName);
            this.Controls.Add(this.buyBtn);
            this.Name = "BuildingAdder";
            this.Size = new System.Drawing.Size(148, 93);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buyBtn;
        private System.Windows.Forms.Label buildingName;
        private System.Windows.Forms.Label buildingIncome;
        private System.Windows.Forms.Label buildingPrice;
        private System.Windows.Forms.Label incomeLbl;
        private System.Windows.Forms.Label priceLbl;
    }
}
