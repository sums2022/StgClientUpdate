using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace StgClientUpdater
{
    public partial class frmMain : Form
    {
        const string updateJson = "update.json";
        const string serverUri = "https://github.com/sums2022/StgClientUpdate/raw/main/";

        public frmMain()
        {
            InitializeComponent();
            LoadProject();
        }

        private void LoadProject()
        {
            using (StreamReader r = new StreamReader(updateJson))
            {
                string json = r.ReadToEnd();
                Global.listItems = JsonConvert.DeserializeObject<List<ClsProjItem>>(json);
            }


            lbProject.Items.Clear();
            foreach (var item in Global.listItems)
            {
                lbProject.Items.Add(item.appID);
            }

            if (lbProject.Items.Count > 0)
                lbProject.SelectedIndex = 0;
        }

        private void lbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string project = lbProject.Text;
            if (project != "")
            {
                UpdateProjectInfo(project);
            }
        }

        private void UpdateProjectInfo(string project)
        {
            ClsProjItem item = Global.getItem(project);
            if (item == null) return;

            tbDescript.Text = item.description;
            lbRemote.Text = item.version;
            lbLocal.Text = GetFlutterVersion(item.projPath);
        }

        private static string GetVersion(string exename)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(exename);
            Version ver = new Version(versionInfo.ProductVersion);
            DateTime buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(TimeSpan.TicksPerDay * ver.Build)); // days since 1 January 2000
            return string.Format("v{0:yy.MM.dd}.{1:00000}", buildDateTime, ver.Revision);
        }

        private void MakeProject(string project, bool copyfile = true)
        {
            /*
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(updateXml);

            XmlNode xnode = xdoc.SelectSingleNode("//update[@appID='" + project + "']");
            if (xnode == null)
            {
                MessageBox.Show("Cannot make project " + project);
                return;
            }

            string projPath = xnode["projPath"].InnerText;
            string apkFile = Path.Combine(projPath, "build/app/outputs/apk/release/app-release.apk");
            if (!File.Exists(apkFile))
            {
                MessageBox.Show("Cannot make project " + project);
                return;
            }

            this.remoteVer = this.localVer;
            lbRemote.Text = this.remoteVer;
            string dstFile1 = string.Format("{0}/{1}.apk", project, project);
            string dstFile2 = string.Format("{0}/{1}_{2}.apk", project, project, remoteVer);
            if (copyfile)
            {
                File.Copy(apkFile, dstFile1, true);
                File.Copy(apkFile, dstFile2, true);
            }
            devUrlpath = serverUri + dstFile2.Replace('\\', '/');
            devSha256 = CalcSha256(apkFile);

            // Update XML
            xnode["remoteVersion"].InnerText = remoteVer;
            xnode["url"].InnerText = devUrlpath;
            xnode["description"].InnerText = tbDescript.Text;
            xnode["sha256"].InnerText = devSha256;

            xdoc.Save(updateXml);
            */
        }

        private string CalcSha256(string fname)
        {
            string sha256;
            using (Stream s = new FileStream(fname, FileMode.Open))
            {
                byte[] hash = SHA256.Create().ComputeHash(s);
                sha256 = BitConverter.ToString(hash).Replace("-", String.Empty).ToLower();
            }
            return sha256;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            string project = lbProject.Text;
            if (project != "")
            {
                MakeProject(project);
                SummitProject();
                await UpdateFirebaseRemote();
            }
        }

        private async Task<int> UpdateFirebaseRemote()
        {
            return 0;
        }

        private void SummitProject(bool pause=true)
        {
            // string comment = tbDescript.Text;
            string comment = "";
            string argument = "/C choice /C Y /N /D Y /T 4 & git add -A & git commit {0} & git pull & git push";
            if (pause) argument += " & pause";

            if (tbDescript.Lines.Length == 0)
            {
                comment = string.Format("-m \"{0}_{1}\"", lbProject.Text, lbRemote.Text);
            }
            else
            {
                foreach (string line in tbDescript.Lines)
                {
                    comment += string.Format("-m \"{0}\" ", line);
                }
            }

            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = String.Format(argument, comment);
            // Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info);
            // MessageBox.Show(string.Format("Project {0} has been submit", lbProject.Text));
        }

        private void BuildProject(string project, bool pause = true)
        {
            /*
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(updateXml);

            XmlNode xnode = xdoc.SelectSingleNode("//update[@appID='" + project + "']");
            if (xnode == null)
            {
                MessageBox.Show("Cannot build project " + project);
                return;
            }

            string projPath = xnode["projPath"].InnerText;
            localVer = GetFlutterVersion(projPath, true);
            lbLocal.Text = localVer;

            string cmd = string.Format("/C echo BUILD Version={0} & cd \"{1}\" & flutter build apk",
                this.localVer, projPath);
            if (pause) cmd += " & pause";

            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = cmd;
            Info.FileName = "cmd.exe";
            Info.CreateNoWindow = true;
            Process.Start(Info);
            */
        }

        private String GetFlutterVersion(string projPath, bool inc = false)
        {
            string pubspec = Path.Combine(projPath, "pubspec.yaml");
            StringBuilder sb = new StringBuilder();
            String line;
            String ver = "";
            using (StreamReader sr = new StreamReader(pubspec))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    string vv = CheckVersion(line, inc);
                    if (vv!="")
                    {
                        ver = vv;
                        if (!inc) return ver.Replace('+', '.');
                        line = "version: " + ver; 
                    }
                    sb.AppendLine(line);
                }
            }
            File.WriteAllText("ver.txt", sb.ToString());
            File.Copy("ver.txt", pubspec, true);

            return ver.Replace('+', '.');
        }

        private string CheckVersion(string line, bool inc=false)
        {
            if (line.Length < 10) return "";
            if (line.Substring(0, 8) != "version:") return "";

            string[] vers = line.Substring(8).Split(new char[] { '.', '+' });
            int nver = 0;
            for (int i=0; i<vers.Length; ++i)
            {
                nver += int.Parse(vers[i]);
                if (i < 2) nver *= 10;
                else if (i == 2) nver *= 100;
            }

            if (inc) nver += 1;
            string strVer = string.Format("{0}.{1}.{2}+{3}",
                nver / 10000, nver / 1000 % 10, nver / 100 % 10, nver % 100);

            return strVer;
        }

        private void BuildAndSubmit(string project)
        {
            var item = Global.getItem(project);

            string localVer = GetFlutterVersion(item.projPath, true);

            string curdir = Directory.GetCurrentDirectory();
            string cmd = string.Format("/C echo BUILD Version={0} & cd \"{1}\" & flutter build apk & cd \"{2}\"",
                localVer, item.projPath, curdir);

            string apkFile = Path.Combine(item.projPath, "build\\app\\outputs\\apk\\release\\app-release.apk");
            apkFile = apkFile.Replace('/', '\\');
            string dstFile1 = string.Format("{0}\\{1}.apk", project, project);
            string dstFile2 = string.Format("{0}\\{1}_{2}.apk", project, project, localVer);
            string copyfile = string.Format("copy /y {0} {1} & copy /y {0} {2} ", 
                apkFile, dstFile1, dstFile2);

            string comment = "";
            if (tbDescript.Lines.Length == 0)
            {
                comment = string.Format("-m \"{0}_{1}\"", lbProject.Text, lbRemote.Text);
            }
            else
            {
                foreach (string line in tbDescript.Lines)
                {
                    comment += string.Format("-m \"{0}\" ", line);
                }
            }
            String submit = string.Format("choice /C Y /N /D Y /T 4 & git add -A & git commit {0} & git pull & git push & pause", comment);

            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = cmd + " & " + copyfile + " & " + submit;
            Info.FileName = "cmd.exe";
            Info.CreateNoWindow = true;
            Process.Start(Info);
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            string[] lines = tbDescript.Lines;
            tbDescript.Text = lbRemote.Text + ":\r\n";
            for (int i = 1; i < lines.Length; ++i)
            {
                string ln = lines[i].Trim();
                if (ln != "") tbDescript.Text += ln + "\r\n";
            }
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            string project = lbProject.Text;
            if (project != "")
            {
                BuildProject(project);
            }
        }

        private async void btnRelease_Click(object sender, EventArgs e)
        {
            string project = lbProject.Text;
            if (project != "")
            {
                await MakeRelease();
                UpdateXml(project);
            }
        }

        private async void btnAllInOne_Click(object sender, EventArgs e)
        {
            string project = lbProject.Text;
            if (project != "")
            {
                BuildAndSubmit(project);
                /*
                await Task.Delay(10000);
                MakeProject(project, false);
                await UpdateFirebaseRemote();
                await MakeRelease();
                UpdateXml(project, false);
                */
            }
        }

        private void UpdateXml(string project, bool dlg = true)
        {
            /*
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(updateXml);

            XmlNode xnode = xdoc.SelectSingleNode("//update[@appID='" + project + "']");
            if (xnode != null)
            {
                releaseVer = remoteVer;
                lbRelease.Text = releaseVer;
                xnode["releaseVersion"].InnerText = releaseVer;
                xdoc.Save(updateXml);
            }

            if (dlg)
            {
                MessageBox.Show(string.Format("Release {0} has been published.", releaseVer));
            }
            */
        }

        private async Task<int> MakeRelease()
        {
            return 0;
        }
    }
}
