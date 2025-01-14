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
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        const uint WM_SETTEXT = 0x0C;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, uint Msg, int wParam,
        [MarshalAs(UnmanagedType.LPStr)] string lParam);

        List<Process> Processes = new List<Process>();

        int Counter = 0;
        public Form1()
        {
            InitializeComponent();
            LoadAvailableAssemblies();
        }

        void LoadAvailableAssemblies()
        {
            string except = new FileInfo(Application.ExecutablePath).Name;
            except = except.Substring(0, except.IndexOf("."));

            string[] files = Directory.GetFiles(Application.StartupPath, "*.exe");

            foreach (string file in files)
            {
                string fileName = new FileInfo(file).Name;
                if (fileName.IndexOf(except) == -1)
                    AvailableAssemblies.Items.Add(fileName);
            }

        }

        void RunProcess(string AssemblyName)
        {
            Process process = Process.Start(AssemblyName);
            Processes.Add(process);

            if (Process.GetCurrentProcess().Id == GetParentProcessID(process.Id))
                MessageBox.Show(process.ProcessName + " является дочерним текущего процесса");

            process.EnableRaisingEvents = true;

            process.Exited += process_Exited;

            SetChildWindowText(process.MainWindowHandle, "Child process #" + (++Counter));

            if (!ActiveAssemblies.Items.Contains(process.ProcessName))
                ActiveAssemblies.Items.Add(process.ProcessName);
            AvailableAssemblies.Items.
            Remove(AvailableAssemblies.SelectedItem);
        }

        int GetParentProcessID(int Id)
        {
            int parentId = 0;

            using (ManagementObject obj = new ManagementObject("win32_process.handle=" +
                Id.ToString()))
            {
                obj.Get();

                parentId = Convert.ToInt32(obj["ParentProcessId"]);
            }

            return parentId;
        }

        void process_Exited(object sender, EventArgs e)
        {
            Process process = sender as Process;

            if (process == null || process.HasExited)
                return;

            ActiveAssemblies.Items.Remove(process.ProcessName);
            AvailableAssemblies.Items.Add(process.ProcessName);
            Processes.Remove(process);

            Counter = 0;
            foreach (var item in Processes)
            {
                SetChildWindowText(item.MainWindowHandle, $"Child process #{++Counter}");
            }
        }

        void SetChildWindowText(IntPtr Handle, string Text)
        {
            SendMessage(Handle, WM_SETTEXT, 0, Text);
        }

        delegate void ProcessDelegate(Process process);

        void ExecuteOnProcessByName(string ProcessName, ProcessDelegate func)
        {
            Process[] processes = Process.GetProcessesByName(ProcessName);

            foreach (var process in processes)
            {
                if (Process.GetCurrentProcess().Id == GetParentProcessID(process.Id))
                    func(process);
            }

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            RunProcess(AvailableAssemblies.SelectedItem.ToString());
        }

        void Kill(Process process)
        {
            process.Kill();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessByName(ActiveAssemblies.SelectedItem.ToString(), Kill);
            ActiveAssemblies.Items.Remove(ActiveAssemblies.SelectedItem);
        }

        void CloseMainWindow(Process process)
        {
            process.CloseMainWindow();
        }

        private void closeWindowButton_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessByName(ActiveAssemblies.SelectedItem.ToString(), CloseMainWindow);
            ActiveAssemblies.Items.Remove(ActiveAssemblies.SelectedItems);
        }

        void Refresh(Process p)
        {
            p.Refresh();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessByName(ActiveAssemblies.SelectedItem.ToString(),
                Refresh);
        }

        private void notebookButton_Click(object sender, EventArgs e)
        {
            RunProcess("notepad.exe");
        }

        private void Active_Selected(object sender, EventArgs e)
        {
            if (ActiveAssemblies.SelectedItems.Count == 0)
            {
                stopButton.Enabled = false;
                closeWindowButton.Enabled = false;
                refreshButton.Enabled = false;
            }
            else
            {
                stopButton.Enabled = true;
                closeWindowButton.Enabled = true;
                refreshButton.Enabled = ActiveAssemblies.SelectedItems.Count > 0;
            }
        }

        private void Available_Selected(object sender, EventArgs e)
        {
            if (AvailableAssemblies.SelectedItems.Count == 0)
            {
                startButton.Enabled = false;
            }
            else
            {
                startButton.Enabled = true;
            }
        }

        private void MainWindow_FormClose(object sender, FormClosingEventArgs e)
        {
            foreach (var item in Processes.ToList()) 
            {
                if (!item.HasExited)
                {
                    try
                    {
                        item.Kill();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка завершения процесса {item.ProcessName}: {ex.Message}");
                    }
                }
            }
        }
    }
}
