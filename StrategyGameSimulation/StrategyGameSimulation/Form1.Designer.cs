namespace StrategyGameSimulation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.currentGoldLbl = new System.Windows.Forms.Label();
            this.overallIncomeLbl = new System.Windows.Forms.Label();
            this.currentGoldValue = new System.Windows.Forms.Label();
            this.overallIncomeValue = new System.Windows.Forms.Label();
            this.playerBuildings = new System.Windows.Forms.FlowLayoutPanel();
            this.availableBuildingsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.backBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // currentGoldLbl
            // 
            this.currentGoldLbl.AutoSize = true;
            this.currentGoldLbl.Location = new System.Drawing.Point(23, 13);
            this.currentGoldLbl.Name = "currentGoldLbl";
            this.currentGoldLbl.Size = new System.Drawing.Size(93, 15);
            this.currentGoldLbl.TabIndex = 0;
            this.currentGoldLbl.Text = "Posiadane złoto:";
            // 
            // overallIncomeLbl
            // 
            this.overallIncomeLbl.AutoSize = true;
            this.overallIncomeLbl.Location = new System.Drawing.Point(348, 13);
            this.overallIncomeLbl.Name = "overallIncomeLbl";
            this.overallIncomeLbl.Size = new System.Drawing.Size(98, 15);
            this.overallIncomeLbl.TabIndex = 1;
            this.overallIncomeLbl.Text = "Imyntny dochōd:";
            // 
            // currentGoldValue
            // 
            this.currentGoldValue.AutoSize = true;
            this.currentGoldValue.Location = new System.Drawing.Point(134, 13);
            this.currentGoldValue.Name = "currentGoldValue";
            this.currentGoldValue.Size = new System.Drawing.Size(38, 15);
            this.currentGoldValue.TabIndex = 2;
            this.currentGoldValue.Text = "label3";
            // 
            // overallIncomeValue
            // 
            this.overallIncomeValue.AutoSize = true;
            this.overallIncomeValue.Location = new System.Drawing.Point(453, 13);
            this.overallIncomeValue.Name = "overallIncomeValue";
            this.overallIncomeValue.Size = new System.Drawing.Size(38, 15);
            this.overallIncomeValue.TabIndex = 3;
            this.overallIncomeValue.Text = "label4";
            // 
            // playerBuildings
            // 
            this.playerBuildings.AutoScroll = true;
            this.playerBuildings.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.playerBuildings.Location = new System.Drawing.Point(2, 43);
            this.playerBuildings.Name = "playerBuildings";
            this.playerBuildings.Size = new System.Drawing.Size(618, 395);
            this.playerBuildings.TabIndex = 4;
            // 
            // availableBuildingsPanel
            // 
            this.availableBuildingsPanel.AutoScroll = true;
            this.availableBuildingsPanel.BackColor = System.Drawing.Color.PaleGreen;
            this.availableBuildingsPanel.Location = new System.Drawing.Point(626, 43);
            this.availableBuildingsPanel.Name = "availableBuildingsPanel";
            this.availableBuildingsPanel.Size = new System.Drawing.Size(173, 395);
            this.availableBuildingsPanel.TabIndex = 5;
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 7;
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.OrangeRed;
            this.backBtn.FlatAppearance.BorderSize = 0;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.backBtn.Location = new System.Drawing.Point(626, 9);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(162, 28);
            this.backBtn.TabIndex = 6;
            this.backBtn.Text = "Cŏfnij";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 465);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.availableBuildingsPanel);
            this.Controls.Add(this.playerBuildings);
            this.Controls.Add(this.overallIncomeValue);
            this.Controls.Add(this.currentGoldValue);
            this.Controls.Add(this.overallIncomeLbl);
            this.Controls.Add(this.currentGoldLbl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentGoldLbl;
        private System.Windows.Forms.Label overallIncomeLbl;
        private System.Windows.Forms.Label currentGoldValue;
        private System.Windows.Forms.Label overallIncomeValue;
        private System.Windows.Forms.FlowLayoutPanel playerBuildings;
        private System.Windows.Forms.FlowLayoutPanel availableBuildingsPanel;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Button backBtn;
    }
}

