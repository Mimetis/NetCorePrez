using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Gauges;

namespace _4
{
    public partial class Form1 : Form
    {
        // represents 10 ms
        private float step1 = 9f;

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Form1()
        {
            this.InitializeComponent();

            lblVersion.Text = RuntimeInformation.FrameworkDescription.Substring(0, RuntimeInformation.FrameworkDescription.LastIndexOf(' '));
        }

        private async Task<long> GetFilesNumberAsync(string path)
        {
            var nbFiles = await Task.Factory.StartNew<long>(() =>
            {
                var files = Directory.GetFileSystemEntries(path, "*.*", SearchOption.AllDirectories);

                return files.Length;
            });

            return nbFiles;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Reset();

            this.timer.Start();

            var watch = Stopwatch.StartNew();
            var nbFiles = await this.GetFilesNumberAsync(this.txtDirName.Text);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;


            this.timer.Stop();

            lblFilesLength.Text = $"{nbFiles.ToString()} fichiers.";
            lblDuration.Text = $"{elapsedMs.ToString()} ms";

        }

        private void Reset()
        {
            var setting = new AnimatedPropertySetting(
               RadRadialGaugeElement.ValueProperty,
               radRadialGauge1.Value, 0f, 2, 10)
            {
                ApplyEasingType = RadEasingType.OutBounce
            };


            setting.ApplyValue(radRadialGauge1.GaugeElement);

            lblFilesLength.Text = "";
            lblDuration.Text = "";
        }

        private void radRadialGauge1_ValueChanged(object sender, EventArgs e)
        {

        }

        public static string GetNetCoreVersion()
        {
            var assembly = typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly;
            var assemblyPath = assembly.CodeBase.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            int netCoreAppIndex = Array.IndexOf(assemblyPath, "Microsoft.NETCore.App");
            if (netCoreAppIndex > 0 && netCoreAppIndex < assemblyPath.Length - 2)
                return assemblyPath[netCoreAppIndex + 1];
            return null;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.ApplyValueToGauge(this.radRadialGauge1, ref this.step1);
        }

        private void ApplyValueToGauge(RadRadialGauge radRadialGauge, ref float step)
        {
            var setting = new AnimatedPropertySetting(
                RadRadialGaugeElement.ValueProperty,
                radRadialGauge.Value,
                radRadialGauge.Value + step, 12, 10)
            {
                ApplyEasingType = RadEasingType.OutCubic
            };

            setting.ApplyValue(radRadialGauge.GaugeElement);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer.Interval = 100;
            this.timer.Tick += this.timer_Tick;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                this.txtDirName.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
