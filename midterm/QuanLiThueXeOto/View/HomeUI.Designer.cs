namespace QuanLiThueXeOto.View
{
    partial class HomeUI
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartBrand = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timeChart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRevenueBrand = new System.Windows.Forms.Label();
            this.lbQuantityBrand = new System.Windows.Forms.Label();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lbQuantityType = new System.Windows.Forms.Label();
            this.lbRevenueType = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbQuantityTime = new System.Windows.Forms.Label();
            this.lbRevenueTime = new System.Windows.Forms.Label();
            this.labelnull = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.timeStart = new System.Windows.Forms.DateTimePicker();
            this.timeEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartBrand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTime)).BeginInit();
            this.SuspendLayout();
            // 
            // chartBrand
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBrand.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBrand.Legends.Add(legend1);
            this.chartBrand.Location = new System.Drawing.Point(48, 328);
            this.chartBrand.Name = "chartBrand";
            series1.ChartArea = "ChartArea1";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Số lượng";
            this.chartBrand.Series.Add(series1);
            this.chartBrand.Size = new System.Drawing.Size(449, 348);
            this.chartBrand.TabIndex = 0;
            this.chartBrand.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Số lượng xe được đặt theo hãng";
            this.chartBrand.Titles.Add(title1);
            this.chartBrand.Click += new System.EventHandler(this.chartBrand_Click);
            // 
            // chartTime
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTime.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTime.Legends.Add(legend2);
            this.chartTime.Location = new System.Drawing.Point(692, 328);
            this.chartTime.Name = "chartTime";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Doanh thu";
            this.chartTime.Series.Add(series2);
            this.chartTime.Size = new System.Drawing.Size(476, 339);
            this.chartTime.TabIndex = 1;
            this.chartTime.Text = "chart2";
            title2.Name = "Doanh thu năm";
            title2.Text = "Doanh thu năm";
            this.chartTime.Titles.Add(title2);
            // 
            // timeChart
            // 
            this.timeChart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeChart.CustomFormat = "yyyy";
            this.timeChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeChart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeChart.Location = new System.Drawing.Point(944, 293);
            this.timeChart.Name = "timeChart";
            this.timeChart.Size = new System.Drawing.Size(224, 29);
            this.timeChart.TabIndex = 2;
            this.timeChart.ValueChanged += new System.EventHandler(this.timeChart_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(579, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thống kê";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(902, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Năm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(74, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Số lượng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(74, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Doanh thu";
            // 
            // lbRevenueBrand
            // 
            this.lbRevenueBrand.AutoSize = true;
            this.lbRevenueBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRevenueBrand.Location = new System.Drawing.Point(206, 213);
            this.lbRevenueBrand.Name = "lbRevenueBrand";
            this.lbRevenueBrand.Size = new System.Drawing.Size(25, 25);
            this.lbRevenueBrand.TabIndex = 7;
            this.lbRevenueBrand.Text = "0";
            // 
            // lbQuantityBrand
            // 
            this.lbQuantityBrand.AutoSize = true;
            this.lbQuantityBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantityBrand.Location = new System.Drawing.Point(206, 157);
            this.lbQuantityBrand.Name = "lbQuantityBrand";
            this.lbQuantityBrand.Size = new System.Drawing.Size(25, 25);
            this.lbQuantityBrand.TabIndex = 8;
            this.lbQuantityBrand.Text = "0";
            // 
            // cbBrand
            // 
            this.cbBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Location = new System.Drawing.Point(65, 93);
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(203, 33);
            this.cbBrand.TabIndex = 9;
            this.cbBrand.SelectedIndexChanged += new System.EventHandler(this.cbBrand_SelectedIndexChanged);
            // 
            // cbType
            // 
            this.cbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(355, 93);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(203, 33);
            this.cbType.TabIndex = 14;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // lbQuantityType
            // 
            this.lbQuantityType.AutoSize = true;
            this.lbQuantityType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantityType.Location = new System.Drawing.Point(509, 157);
            this.lbQuantityType.Name = "lbQuantityType";
            this.lbQuantityType.Size = new System.Drawing.Size(25, 25);
            this.lbQuantityType.TabIndex = 13;
            this.lbQuantityType.Text = "0";
            // 
            // lbRevenueType
            // 
            this.lbRevenueType.AutoSize = true;
            this.lbRevenueType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRevenueType.Location = new System.Drawing.Point(509, 213);
            this.lbRevenueType.Name = "lbRevenueType";
            this.lbRevenueType.Size = new System.Drawing.Size(25, 25);
            this.lbRevenueType.TabIndex = 12;
            this.lbRevenueType.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(377, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Doanh thu";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(377, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "Số lượng";
            // 
            // lbQuantityTime
            // 
            this.lbQuantityTime.AutoSize = true;
            this.lbQuantityTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantityTime.Location = new System.Drawing.Point(1016, 179);
            this.lbQuantityTime.Name = "lbQuantityTime";
            this.lbQuantityTime.Size = new System.Drawing.Size(25, 25);
            this.lbQuantityTime.TabIndex = 20;
            this.lbQuantityTime.Text = "0";
            // 
            // lbRevenueTime
            // 
            this.lbRevenueTime.AutoSize = true;
            this.lbRevenueTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRevenueTime.Location = new System.Drawing.Point(1016, 235);
            this.lbRevenueTime.Name = "lbRevenueTime";
            this.lbRevenueTime.Size = new System.Drawing.Size(25, 25);
            this.lbRevenueTime.TabIndex = 19;
            this.lbRevenueTime.Text = "0";
            // 
            // labelnull
            // 
            this.labelnull.AutoSize = true;
            this.labelnull.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnull.Location = new System.Drawing.Point(758, 235);
            this.labelnull.Name = "labelnull";
            this.labelnull.Size = new System.Drawing.Size(120, 25);
            this.labelnull.TabIndex = 18;
            this.labelnull.Text = "Doanh thu";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(758, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 25);
            this.label10.TabIndex = 17;
            this.label10.Text = "Số lượng";
            // 
            // timeStart
            // 
            this.timeStart.CustomFormat = "dd/MM/yyyy";
            this.timeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeStart.Location = new System.Drawing.Point(918, 77);
            this.timeStart.Name = "timeStart";
            this.timeStart.Size = new System.Drawing.Size(237, 31);
            this.timeStart.TabIndex = 21;
            this.timeStart.Value = new System.DateTime(2023, 11, 2, 0, 0, 0, 0);
            this.timeStart.ValueChanged += new System.EventHandler(this.timeStart_ValueChanged);
            // 
            // timeEnd
            // 
            this.timeEnd.CustomFormat = "dd/MM/yyyy";
            this.timeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeEnd.Location = new System.Drawing.Point(918, 113);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.Size = new System.Drawing.Size(237, 31);
            this.timeEnd.TabIndex = 22;
            this.timeEnd.Value = new System.DateTime(2023, 11, 7, 0, 0, 0, 0);
            this.timeEnd.ValueChanged += new System.EventHandler(this.timeEnd_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(736, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "Ngày kết thúc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(736, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 25);
            this.label6.TabIndex = 23;
            this.label6.Text = "Ngày bắt đầu";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(127, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 25);
            this.label9.TabIndex = 25;
            this.label9.Text = "Hãng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(440, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 25);
            this.label11.TabIndex = 26;
            this.label11.Text = "Loại";
            // 
            // HomeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.timeEnd);
            this.Controls.Add(this.timeStart);
            this.Controls.Add(this.lbQuantityTime);
            this.Controls.Add(this.lbRevenueTime);
            this.Controls.Add(this.labelnull);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.lbQuantityType);
            this.Controls.Add(this.lbRevenueType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbBrand);
            this.Controls.Add(this.lbQuantityBrand);
            this.Controls.Add(this.lbRevenueBrand);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeChart);
            this.Controls.Add(this.chartTime);
            this.Controls.Add(this.chartBrand);
            this.Name = "HomeUI";
            this.Size = new System.Drawing.Size(1382, 717);
            this.Load += new System.EventHandler(this.HomeUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartBrand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartBrand;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTime;
        private System.Windows.Forms.DateTimePicker timeChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbRevenueBrand;
        private System.Windows.Forms.Label lbQuantityBrand;
        private System.Windows.Forms.ComboBox cbBrand;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lbQuantityType;
        private System.Windows.Forms.Label lbRevenueType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbQuantityTime;
        private System.Windows.Forms.Label lbRevenueTime;
        private System.Windows.Forms.Label labelnull;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker timeStart;
        private System.Windows.Forms.DateTimePicker timeEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
    }
}
