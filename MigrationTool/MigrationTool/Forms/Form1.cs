using MigrationTool.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using MigrationTool.Models;
using MigrationTool.Settings;
using MigrationTool.Utils;

namespace MigrationTool
{
	public partial class Form1 : Form
	{
		private AppSettings _settings;
		private MigrationService _serv;

		public Form1()
		{
			InitializeComponent();

			Version ver = Assembly.GetExecutingAssembly().GetName().Version;
			string shortVer = $"{ver.Major}.{ver.Minor}.{ver.Build}";
			this.Text = $"MigrationTool v{shortVer}";
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				_settings = new AppSettings();
				Logger.Configure(_settings.LogDirectory, _settings.LogFileName);
				_serv = new MigrationService(this, _settings);
			}
			catch (Exception ex)
			{
				Logger.LogError(ex);
				MessageBox.Show("設定ファイルに問題があります。アプリケーションを終了します。", "設定エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
		}

		private void btnExecute_Click(object sender, EventArgs e)
		{
			DateTime from = TargetFrom.Value.Date;
			DateTime to = TargetTo.Value.Date.AddDays(1).AddSeconds(-1); // 00:00:00 -> 23:59:59

			ExecuteResult result = null;

			// 撮影条件のデータ移行
			if (radioShotCondition.Checked)
			{
				result = _serv.MigrateShotCondition(from, to);
			}
			// 依頼科依頼医のデータ移行
			else if(radioRequestDepartment.Checked)
			{
				result = _serv.MigrateRequestDepartment(from, to);
			}

			InsertedCountLabel.Text = "移行件数：";
			InsertedCount.Text = result.InsertedCount.ToString();
		}

		public void ShowRecordCount(int count)
		{
			if (InvokeRequired)
			{
				// 例外対策
				Invoke(new Action(() => {
					RecordCountLabel.Text = "移行対象件数：";
					RecordCount.Text = count.ToString();
				}));
			}
			else
			{
				RecordCountLabel.Text = "移行対象件数：";
				RecordCount.Text = count.ToString();
			}
			// 画面強制更新
			Application.DoEvents();
		}

		public void SetFakeProgressVisible(bool isVisible)
		{
			if (InvokeRequired)
			{
				// 例外対策
				Invoke(new Action(() => {
					FakeInsertProgressBar.Visible = isVisible;
				}));
			}
			else
			{
				FakeInsertProgressBar.Visible = isVisible;
			}
			// 画面強制更新
			Application.DoEvents();
		}
	}
}
