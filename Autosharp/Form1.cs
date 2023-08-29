using System.Diagnostics;
using System.Net;

namespace Autosharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            versionLabel.Text = "v" + Application.ProductVersion.ToString();
        }

        private void folderDialogButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
            {
                folderPathTextBox.Text = dialog.SelectedPath;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressBar.Visible = true;

            if (projectTextBox.Text != string.Empty)
            {
                projectTextBox.Text = projectTextBox.Text.Substring(0, 1).ToUpper() + projectTextBox.Text.Substring(1).ToLower();

                if (folderPathTextBox.Text != string.Empty)
                {
                    try
                    {
                        string newProjectFolder = folderPathTextBox.Text + "\\" + projectTextBox.Text;

                        if (!Directory.Exists(newProjectFolder))
                        {
                            Directory.CreateDirectory(newProjectFolder);
                            progressBar.Value = 10;

                            if (codeTemplateCheckBox.Checked) { /* Not implemented, yet. */ }

                            string srcFolder = newProjectFolder + "\\" + "src";
                            Directory.CreateDirectory(srcFolder);
                            progressBar.Value = 40;

                            string cmdText = "/C dotnet new console --name " + projectTextBox.Text;
                            DotNet dn = new DotNet(cmdText, srcFolder);
                            _ = dn.Start();
                            progressBar.Value = 60;

                            cmdText = "/C dotnet new classlib --name Library";
                            dn.SetArgs(cmdText);
                            _ = dn.Start();
                            progressBar.Value = 80;

                            cmdText = "/C dotnet add ./" + projectTextBox.Text + "/" + projectTextBox.Text + ".csproj reference ./Library/Library.csproj";
                            dn.SetArgs(cmdText);
                            _ = dn.Start();
                            progressBar.Value = 100;

                            if (codeTemplateCheckBox.Checked)
                            {
                                string programCsPath = srcFolder + "\\" + projectTextBox.Text + "/Program.cs";
                                
                                File.Delete(programCsPath);
                                using (StreamWriter writer = new StreamWriter(programCsPath))
                                {
                                    writer.Write(@"using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(""Hello, world!"");
        }
    }
}");
                                }

                                string defaultClassPath = srcFolder + "\\" + "Library\\Class1.cs";

                                File.Delete(defaultClassPath);
                                using (StreamWriter writer = new StreamWriter(defaultClassPath))
                                {
                                    writer.Write(@"using System;

namespace Library;

public class Class1
{
    public Class1() {}
}");
                                }
                            }

                            if (openVSCheckBox.Checked) { dn.OpenVisual(); }

                        }
                        else
                        {
                            MessageBox.Show("A folder already exists with the same name as project name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something happened while creating the project.\n\nError:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Project path missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Project name is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            progressBar.Visible = false;
        }
    }

    public class DotNet
    {
        private System.Diagnostics.ProcessStartInfo StartInfo;

        private string FileName, Args, WorkingDirectory;
        public DotNet(string args, string dir)
        {
            this.StartInfo = new System.Diagnostics.ProcessStartInfo();

            this.FileName = "cmd.exe";
            this.Args = args;
            this.WorkingDirectory = dir;

            StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            StartInfo.FileName = FileName;
            StartInfo.Arguments = Args;
            StartInfo.WorkingDirectory = WorkingDirectory;
        }

        public void SetFileName(string fileName)
        {
            this.FileName = fileName;
            this.StartInfo.FileName = fileName;
        }
        public void SetArgs(string args)
        {
            this.Args = args;
            this.StartInfo.Arguments = args;
        }
        public void SetWorkingDirectory(string dir)
        {
            this.WorkingDirectory = dir;
            this.StartInfo.WorkingDirectory = dir;
        }

        public string GetFileName() { return this.FileName; }
        public string GetArgs() { return this.Args; }
        public string GetWorkingDirectory() { return this.WorkingDirectory; }

        public void OpenVisual()
        {
            string actualArgs = this.Args;

            this.SetArgs("/C code . && exit");
            this.Start(false);

            this.SetArgs(actualArgs);
        }
        public bool Start(bool wait = true)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();

                process.StartInfo = this.StartInfo;
                process.Start();
                if (wait) { process.WaitForExit(); }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}