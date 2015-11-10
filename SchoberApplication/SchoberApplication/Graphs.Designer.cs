namespace SchoberApplication
{
    partial class Graphs
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartSalariesIncome = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBoxGraphMain = new System.Windows.Forms.ComboBox();
            this.btnRunQuery = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalariesIncome)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSalariesIncome
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSalariesIncome.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSalariesIncome.Legends.Add(legend1);
            this.chartSalariesIncome.Location = new System.Drawing.Point(88, 96);
            this.chartSalariesIncome.Name = "chartSalariesIncome";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Sale Profits";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Monthly Wage Expenditure";
            this.chartSalariesIncome.Series.Add(series1);
            this.chartSalariesIncome.Series.Add(series2);
            this.chartSalariesIncome.Size = new System.Drawing.Size(486, 353);
            this.chartSalariesIncome.TabIndex = 1;
            this.chartSalariesIncome.Text = "chart1";
            // 
            // comboBoxGraphMain
            // 
            this.comboBoxGraphMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGraphMain.FormattingEnabled = true;
            this.comboBoxGraphMain.Items.AddRange(new object[] {
            "Compare overall sales for each store",
            "Compare overall sales for each country",
            "Compare sales of last 30 days to employee wage expenses",
            "Compare overall sales of each product type",
            "Compare overall sales of products\' activity grouping",
            "Compare sales of waterproof vs. non-waterproof items for each country"});
            this.comboBoxGraphMain.Location = new System.Drawing.Point(88, 43);
            this.comboBoxGraphMain.Name = "comboBoxGraphMain";
            this.comboBoxGraphMain.Size = new System.Drawing.Size(366, 21);
            this.comboBoxGraphMain.TabIndex = 2;
            this.comboBoxGraphMain.SelectedIndexChanged += new System.EventHandler(this.comboBoxGraphMain_SelectedIndexChanged);
            // 
            // btnRunQuery
            // 
            this.btnRunQuery.Location = new System.Drawing.Point(460, 42);
            this.btnRunQuery.Name = "btnRunQuery";
            this.btnRunQuery.Size = new System.Drawing.Size(75, 23);
            this.btnRunQuery.TabIndex = 3;
            this.btnRunQuery.Text = "Run Query";
            this.btnRunQuery.UseVisualStyleBackColor = true;
            this.btnRunQuery.Click += new System.EventHandler(this.btnRunQuery_Click);
            // 
            // Graphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 461);
            this.Controls.Add(this.btnRunQuery);
            this.Controls.Add(this.comboBoxGraphMain);
            this.Controls.Add(this.chartSalariesIncome);
            this.Name = "Graphs";
            this.Text = "Graphs";
            ((System.ComponentModel.ISupportInitialize)(this.chartSalariesIncome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalariesIncome;
        private System.Windows.Forms.ComboBox comboBoxGraphMain;
        private System.Windows.Forms.Button btnRunQuery;
    }
}