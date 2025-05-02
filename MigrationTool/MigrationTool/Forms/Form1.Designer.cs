
namespace MigrationTool
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.Execute = new System.Windows.Forms.Button();
			this.TargetFrom = new System.Windows.Forms.DateTimePicker();
			this.TargetTo = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.RecordCountLabel = new System.Windows.Forms.Label();
			this.InsertedCountLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.RecordCount = new System.Windows.Forms.Label();
			this.InsertedCount = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.FakeInsertProgressBar = new System.Windows.Forms.ProgressBar();
			this.panel2 = new System.Windows.Forms.Panel();
			this.radioRequestDepartment = new System.Windows.Forms.RadioButton();
			this.radioShotCondition = new System.Windows.Forms.RadioButton();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// Execute
			// 
			this.Execute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Execute.AutoSize = true;
			this.Execute.Location = new System.Drawing.Point(303, 3);
			this.Execute.Name = "Execute";
			this.Execute.Size = new System.Drawing.Size(62, 22);
			this.Execute.TabIndex = 4;
			this.Execute.Text = "実行";
			this.Execute.UseVisualStyleBackColor = true;
			this.Execute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// TargetFrom
			// 
			this.TargetFrom.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.TargetFrom.Location = new System.Drawing.Point(3, 5);
			this.TargetFrom.Name = "TargetFrom";
			this.TargetFrom.Size = new System.Drawing.Size(115, 19);
			this.TargetFrom.TabIndex = 1;
			// 
			// TargetTo
			// 
			this.TargetTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.TargetTo.Location = new System.Drawing.Point(148, 54);
			this.TargetTo.Name = "TargetTo";
			this.TargetTo.Size = new System.Drawing.Size(124, 19);
			this.TargetTo.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 12);
			this.label1.TabIndex = 5;
			this.label1.Text = "移行対象期間";
			// 
			// RecordCountLabel
			// 
			this.RecordCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.RecordCountLabel.AutoSize = true;
			this.RecordCountLabel.Location = new System.Drawing.Point(60, 107);
			this.RecordCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.RecordCountLabel.Name = "RecordCountLabel";
			this.RecordCountLabel.Size = new System.Drawing.Size(83, 12);
			this.RecordCountLabel.TabIndex = 6;
			this.RecordCountLabel.Text = "移行対象件数：";
			// 
			// InsertedCountLabel
			// 
			this.InsertedCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.InsertedCountLabel.AutoSize = true;
			this.InsertedCountLabel.Location = new System.Drawing.Point(84, 95);
			this.InsertedCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.InsertedCountLabel.Name = "InsertedCountLabel";
			this.InsertedCountLabel.Size = new System.Drawing.Size(59, 12);
			this.InsertedCountLabel.TabIndex = 7;
			this.InsertedCountLabel.Text = "移行件数：";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(122, 10);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(17, 12);
			this.label4.TabIndex = 8;
			this.label4.Text = "～";
			// 
			// RecordCount
			// 
			this.RecordCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.RecordCount.AutoSize = true;
			this.RecordCount.Location = new System.Drawing.Point(147, 95);
			this.RecordCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.RecordCount.Name = "RecordCount";
			this.RecordCount.Size = new System.Drawing.Size(11, 12);
			this.RecordCount.TabIndex = 9;
			this.RecordCount.Text = "1";
			// 
			// InsertedCount
			// 
			this.InsertedCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.InsertedCount.AutoSize = true;
			this.InsertedCount.Location = new System.Drawing.Point(147, 107);
			this.InsertedCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.InsertedCount.Name = "InsertedCount";
			this.InsertedCount.Size = new System.Drawing.Size(11, 12);
			this.InsertedCount.TabIndex = 10;
			this.InsertedCount.Text = "1";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.Execute, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.InsertedCount, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.RecordCount, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.InsertedCountLabel, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.RecordCountLabel, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.FakeInsertProgressBar, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.TargetTo, 1, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 10);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(356, 197);
			this.tableLayoutPanel1.TabIndex = 11;
			// 
			// panel1
			// 
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.panel1.AutoSize = true;
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.Controls.Add(this.TargetFrom);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Location = new System.Drawing.Point(2, 50);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(141, 27);
			this.panel1.TabIndex = 2;
			// 
			// FakeInsertProgressBar
			// 
			this.FakeInsertProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.FakeInsertProgressBar, 3);
			this.FakeInsertProgressBar.Location = new System.Drawing.Point(8, 149);
			this.FakeInsertProgressBar.Margin = new System.Windows.Forms.Padding(8, 2, 8, 2);
			this.FakeInsertProgressBar.Name = "FakeInsertProgressBar";
			this.FakeInsertProgressBar.Size = new System.Drawing.Size(352, 18);
			this.FakeInsertProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.FakeInsertProgressBar.TabIndex = 12;
			this.FakeInsertProgressBar.Visible = false;
			// 
			// panel2
			// 
			this.panel2.AutoSize = true;
			this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel2.Controls.Add(this.radioRequestDepartment);
			this.panel2.Controls.Add(this.radioShotCondition);
			this.panel2.Location = new System.Drawing.Point(147, 2);
			this.panel2.Margin = new System.Windows.Forms.Padding(2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(107, 44);
			this.panel2.TabIndex = 5;
			// 
			// radioRequestDepartment
			// 
			this.radioRequestDepartment.AutoSize = true;
			this.radioRequestDepartment.Location = new System.Drawing.Point(10, 26);
			this.radioRequestDepartment.Margin = new System.Windows.Forms.Padding(2);
			this.radioRequestDepartment.Name = "radioRequestDepartment";
			this.radioRequestDepartment.Size = new System.Drawing.Size(95, 16);
			this.radioRequestDepartment.TabIndex = 1;
			this.radioRequestDepartment.TabStop = true;
			this.radioRequestDepartment.Text = "依頼科依頼医";
			this.radioRequestDepartment.UseVisualStyleBackColor = true;
			// 
			// radioShotCondition
			// 
			this.radioShotCondition.AutoSize = true;
			this.radioShotCondition.Checked = true;
			this.radioShotCondition.Location = new System.Drawing.Point(10, 6);
			this.radioShotCondition.Margin = new System.Windows.Forms.Padding(2);
			this.radioShotCondition.Name = "radioShotCondition";
			this.radioShotCondition.Size = new System.Drawing.Size(71, 16);
			this.radioShotCondition.TabIndex = 0;
			this.radioShotCondition.TabStop = true;
			this.radioShotCondition.Text = "撮影条件";
			this.radioShotCondition.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(375, 218);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Execute;
		private System.Windows.Forms.DateTimePicker TargetFrom;
		private System.Windows.Forms.DateTimePicker TargetTo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label RecordCountLabel;
		private System.Windows.Forms.Label InsertedCountLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label RecordCount;
		private System.Windows.Forms.Label InsertedCount;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ProgressBar FakeInsertProgressBar;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton radioRequestDepartment;
		private System.Windows.Forms.RadioButton radioShotCondition;
	}
}

