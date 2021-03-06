﻿using System;
using System.Windows.Forms;
using System.Drawing;

using BizHawk.Client.Common;

namespace BizHawk.Client.EmuHawk
{
	public partial class RewindConfig : Form
	{
		private long _stateSize;
		private int _mediumStateSize;
		private int _largeStateSize;
		private int _stateSizeCategory = 1; //1 = small, 2 = med, 3 = larg //TODO: enum
		public RewindConfig()
		{
			InitializeComponent();
		}

		private void RewindConfig_Load(object sender, EventArgs e)
		{
			if (Global.Rewinder.HasBuffer)
			{
				FullnessLabel.Text = String.Format("{0:0.00}", Global.Rewinder.FullnessRatio * 100) + "%";
				RewindFramesUsedLabel.Text = Global.Rewinder.Count.ToString();
			}
			else
			{
				FullnessLabel.Text = "N/A";
				RewindFramesUsedLabel.Text = "N/A";
			}


			DiskBufferCheckbox.Checked = Global.Config.Rewind_OnDisk;
			RewindIsThreadedCheckbox.Checked = Global.Config.Rewind_IsThreaded;
			_stateSize = Global.Emulator.SaveStateBinary().Length;
			BufferSizeUpDown.Value = Global.Config.Rewind_BufferSize;

			_mediumStateSize = Global.Config.Rewind_MediumStateSize;
			_largeStateSize = Global.Config.Rewind_LargeStateSize;

			UseDeltaCompression.Checked = Global.Config.Rewind_UseDelta;

			SmallSavestateNumeric.Value = Global.Config.RewindFrequencySmall;
			MediumSavestateNumeric.Value = Global.Config.RewindFrequencyMedium;
			LargeSavestateNumeric.Value = Global.Config.RewindFrequencyLarge;

			SmallStateEnabledBox.Checked = Global.Config.RewindEnabledSmall;
			MediumStateEnabledBox.Checked = Global.Config.RewindEnabledMedium;
			LargeStateEnabledBox.Checked = Global.Config.RewindEnabledLarge;

			SetSmallEnabled();
			SetMediumEnabled();
			SetLargeEnabled();

			SetStateSize();

			var medium_state_size_kb = Global.Config.Rewind_MediumStateSize / 1024;
			var large_state_size_kb = Global.Config.Rewind_LargeStateSize / 1024;

			MediumStateTrackbar.Value = medium_state_size_kb;
			MediumStateUpDown.Value = medium_state_size_kb;
			LargeStateTrackbar.Value = large_state_size_kb;
			LargeStateUpDown.Value = large_state_size_kb;

			nudCompression.Value = Global.Config.SaveStateCompressionLevelNormal;

			rbStatesDefault.Checked = Global.Config.SaveStateType == Config.SaveStateTypeE.Default;
			rbStatesBinary.Checked = Global.Config.SaveStateType == Config.SaveStateTypeE.Binary;
			rbStatesText.Checked = Global.Config.SaveStateType == Config.SaveStateTypeE.Text;
		}

		private void SetStateSize()
		{
			double num = _stateSize / 1024.0;

			if (num >= 1024)
			{
				num /= 1024.0;
				StateSizeLabel.Text = String.Format("{0:0.00}", num) + " mb";
			}
			else
			{
				StateSizeLabel.Text = String.Format("{0:0.00}", num) + " kb";
			}


			SmallLabel1.Text = "Small savestates (less than " + (_mediumStateSize / 1024) + "kb)";
			MediumLabel1.Text = "Medium savestates (" + (_mediumStateSize / 1024)
				+ " - " + (_largeStateSize / 1024) + "kb)";
			LargeLabel1.Text = "Large savestates (" + (_largeStateSize / 1024) + "kb or more)";

			if (_stateSize >= _largeStateSize)
			{
				_stateSizeCategory = 3;
				SmallLabel1.Font = new Font(SmallLabel1.Font, FontStyle.Regular);
				MediumLabel1.Font = new Font(SmallLabel1.Font, FontStyle.Regular);
				LargeLabel1.Font = new Font(SmallLabel1.Font, FontStyle.Italic);
			}
			else if (_stateSize >= _mediumStateSize)
			{
				_stateSizeCategory = 2;
				SmallLabel1.Font = new Font(SmallLabel1.Font, FontStyle.Regular);
				MediumLabel1.Font = new Font(SmallLabel1.Font, FontStyle.Italic);
				LargeLabel1.Font = new Font(SmallLabel1.Font, FontStyle.Regular);
			}
			else
			{
				_stateSizeCategory = 1;
				SmallLabel1.Font = new Font(SmallLabel1.Font, FontStyle.Italic);
				MediumLabel1.Font = new Font(SmallLabel1.Font, FontStyle.Regular);
				LargeLabel1.Font = new Font(SmallLabel1.Font, FontStyle.Regular);
			}

			CalculateEstimates();
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			GlobalWin.OSD.AddMessage("Rewind config aborted");
			Close();
		}

		private void OK_Click(object sender, EventArgs e)
		{
			GlobalWin.OSD.AddMessage("Rewind settings saved");

			Global.Config.RewindFrequencySmall = (int)SmallSavestateNumeric.Value;
			Global.Config.RewindFrequencyMedium = (int)MediumSavestateNumeric.Value;
			Global.Config.RewindFrequencyLarge = (int)LargeSavestateNumeric.Value;

			Global.Config.RewindEnabledSmall = SmallStateEnabledBox.Checked;
			Global.Config.RewindEnabledMedium = MediumStateEnabledBox.Checked;
			Global.Config.RewindEnabledLarge = LargeStateEnabledBox.Checked;
			Global.Rewinder.DoRewindSettings();
			Global.Config.Rewind_UseDelta = UseDeltaCompression.Checked;
			Global.Config.Rewind_MediumStateSize = (int)(MediumStateUpDown.Value * 1024);
			Global.Config.Rewind_LargeStateSize = (int)(LargeStateUpDown.Value * 1024);
			Global.Config.Rewind_OnDisk = DiskBufferCheckbox.Checked;
			Global.Config.Rewind_BufferSize = (int)BufferSizeUpDown.Value;
			Global.Config.SaveStateCompressionLevelNormal = (int)nudCompression.Value;

			if (rbStatesDefault.Checked) Global.Config.SaveStateType = Config.SaveStateTypeE.Default;
			if (rbStatesBinary.Checked) Global.Config.SaveStateType = Config.SaveStateTypeE.Binary;
			if (rbStatesText.Checked) Global.Config.SaveStateType = Config.SaveStateTypeE.Text;

			if (Global.Config.Rewind_IsThreaded != RewindIsThreadedCheckbox.Checked)
			{
				GlobalWin.MainForm.FlagNeedsReboot();
				Global.Config.Rewind_IsThreaded = RewindIsThreadedCheckbox.Checked;
			}

			Close();
		}

		private void SetSmallEnabled()
		{
			SmallLabel1.Enabled = SmallLabel2.Enabled
				= SmallSavestateNumeric.Enabled = SmallLabel3.Enabled
				= SmallStateEnabledBox.Checked;
		}

		private void SetMediumEnabled()
		{
			MediumLabel1.Enabled = MediumLabel2.Enabled
				= MediumSavestateNumeric.Enabled = MediumLabel3.Enabled
				= MediumStateEnabledBox.Checked;
		}

		private void SetLargeEnabled()
		{
			LargeLabel1.Enabled = LargeLabel2.Enabled
				= LargeSavestateNumeric.Enabled = LargeLabel3.Enabled
				= LargeStateEnabledBox.Checked;
		}

		private void SmallStateEnabledBox_CheckStateChanged(object sender, EventArgs e)
		{
			SetSmallEnabled();
		}

		private void MediumStateEnabledBox_CheckStateChanged(object sender, EventArgs e)
		{
			SetMediumEnabled();
		}

		private void LargeStateEnabledBox_CheckStateChanged(object sender, EventArgs e)
		{
			SetLargeEnabled();
		}

		private void LargeLabel1_Click(object sender, EventArgs e)
		{
			LargeStateEnabledBox.Checked ^= true;
		}

		private void MediumLabel1_Click(object sender, EventArgs e)
		{
			MediumStateEnabledBox.Checked ^= true;
		}

		private void SmallLabel1_Click(object sender, EventArgs e)
		{
			SmallStateEnabledBox.Checked ^= true;
		}

		private void MediumStateTrackbar_ValueChanged(object sender, EventArgs e)
		{
			MediumStateUpDown.Value = (sender as TrackBar).Value;
			if (MediumStateUpDown.Value > LargeStateUpDown.Value)
			{
				LargeStateUpDown.Value = MediumStateUpDown.Value;
				LargeStateTrackbar.Value = (int)MediumStateUpDown.Value;
			}
			_mediumStateSize = MediumStateTrackbar.Value * 1024;
			_largeStateSize = LargeStateTrackbar.Value * 1024;
			SetStateSize();
		}

		private void MediumStateUpDown_ValueChanged(object sender, EventArgs e)
		{
			MediumStateTrackbar.Value = (int)(sender as NumericUpDown).Value;
			if (MediumStateUpDown.Value > LargeStateUpDown.Value)
			{
				LargeStateUpDown.Value = MediumStateUpDown.Value;
				LargeStateTrackbar.Value = (int)MediumStateUpDown.Value;
			}
			_mediumStateSize = MediumStateTrackbar.Value * 1024;
			_largeStateSize = LargeStateTrackbar.Value * 1024;
			SetStateSize();
		}

		private void LargeStateTrackbar_ValueChanged(object sender, EventArgs e)
		{
			if (LargeStateTrackbar.Value < MediumStateTrackbar.Value)
			{
				LargeStateTrackbar.Value = MediumStateTrackbar.Value;
				LargeStateUpDown.Value = MediumStateTrackbar.Value;
			}
			else
			{
				LargeStateUpDown.Value = (sender as TrackBar).Value;
			}
			_mediumStateSize = MediumStateTrackbar.Value * 1024;
			_largeStateSize = LargeStateTrackbar.Value * 1024;
			SetStateSize();
		}

		private void LargeStateUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (LargeStateUpDown.Value < MediumStateUpDown.Value)
			{
				LargeStateTrackbar.Value = MediumStateTrackbar.Value;
				LargeStateUpDown.Value = MediumStateTrackbar.Value;
			}
			else
			{
				LargeStateTrackbar.Value = (int)(sender as NumericUpDown).Value;
			}
			_mediumStateSize = MediumStateTrackbar.Value * 1024;
			_largeStateSize = LargeStateTrackbar.Value * 1024;
			SetStateSize();
		}

		private void CalculateEstimates()
		{
			long avg_state_size;

			if (UseDeltaCompression.Checked || _stateSize == 0)
			{

				if (Global.Rewinder.Count > 0)
				{
					avg_state_size = Global.Rewinder.Size / Global.Rewinder.Count;
				}
				else
				{
					avg_state_size = Global.Emulator.SaveStateBinary().Length;
				}
			}
			else
			{
				avg_state_size = _stateSize;
			}

			var buffer_size = (long)(BufferSizeUpDown.Value);
			buffer_size *= 1024 * 1024;
			var est_frames = buffer_size / avg_state_size;



			long est_frequency = 0;
			switch (_stateSizeCategory)
			{
				case 1:
					est_frequency = (long)SmallSavestateNumeric.Value;
					break;
				case 2:
					est_frequency = (long)MediumSavestateNumeric.Value;
					break;
				case 3:
					est_frequency = (long)LargeSavestateNumeric.Value;
					break;
			}
			long est_total_frames = est_frames * est_frequency;
			double minutes = est_total_frames / 60 / 60;

			AverageStoredStateSizeLabel.Text = String.Format("{0:n0}", avg_state_size) + " bytes";
			ApproxFramesLabel.Text = String.Format("{0:n0}", est_frames) + " frames";
			EstTimeLabel.Text = String.Format("{0:n}", minutes) + " minutes";
		}

		private void BufferSizeUpDown_ValueChanged(object sender, EventArgs e)
		{
			CalculateEstimates();
		}

		private void UseDeltaCompression_CheckedChanged(object sender, EventArgs e)
		{
			CalculateEstimates();
		}

		private void SmallSavestateNumeric_ValueChanged(object sender, EventArgs e)
		{
			CalculateEstimates();
		}

		private void MediumSavestateNumeric_ValueChanged(object sender, EventArgs e)
		{
			CalculateEstimates();
		}

		private void LargeSavestateNumeric_ValueChanged(object sender, EventArgs e)
		{
			CalculateEstimates();
		}

		private void trackBar1_ValueChanged(object sender, EventArgs e)
		{

		}

		private void nudCompression_ValueChanged(object sender, EventArgs e)
		{
			trackBarCompression.Value = (int)(sender as NumericUpDown).Value;
		}

		private void trackBarCompression_ValueChanged(object sender, EventArgs e)
		{
			//TODO - make a UserControl which is trackbar and NUD combined
			nudCompression.Value = (sender as TrackBar).Value;
		}

		private void btnResetCompression_Click(object sender, EventArgs e)
		{
			nudCompression.Value = Config.DefaultSaveStateCompressionLevelNormal;

		}

	}
}
