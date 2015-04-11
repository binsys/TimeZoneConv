using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeZones
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();

			cbSrcTimeZone.DisplayMember = "DisplayName";
			cbDestTimeZone.DisplayMember = "DisplayName";

			cbSrcTimeZone.BeginUpdate();
			cbDestTimeZone.BeginUpdate();

			foreach (TimeZoneInfo tzi in TimeZoneInfo.GetSystemTimeZones().OrderBy(x=>x.BaseUtcOffset))
			{
				cbSrcTimeZone.Items.Add(tzi);
				cbDestTimeZone.Items.Add(tzi);

				if (tzi.Id == TimeZoneInfo.Local.Id)
				{
					cbSrcTimeZone.SelectedItem = tzi;
					cbDestTimeZone.SelectedItem = tzi;
 
				}
				
			}

			
			cbSrcTimeZone.EndUpdate();
			cbDestTimeZone.EndUpdate();

			string aaa = sb.ToString();


			this.dtpSrcTime.Format = DateTimePickerFormat.Custom;
			this.dtpSrcTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
		}

		private void btnSrcTimeNow_Click(object sender, EventArgs e)
		{
			this.dtpSrcTime.Value = DateTime.Now;
		}

		private void btnConv_Click(object sender, EventArgs e)
		{
			DateTime drSrc = new DateTime(dtpSrcTime.Value.Ticks);

			DateTime dt = TimeZoneInfo.ConvertTime(drSrc, cbSrcTimeZone.SelectedItem as TimeZoneInfo, cbDestTimeZone.SelectedItem as TimeZoneInfo);
			lblResult.Text = dt.ToString("yyyy-MM-dd HH:mm:ss");
		}

	}
}
