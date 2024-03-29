using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using QuartzTypeLib;

namespace DirectShow
{
	/// <summary>
	/// Zusammendfassende Beschreibung f�r Form1.
	/// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel2;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.ComponentModel.IContainer components;

        private const int WM_APP = 0x8000;
        private const int WM_GRAPHNOTIFY = WM_APP + 1;
        private const int EC_COMPLETE = 0x01;
        private const int WS_CHILD = 0x40000000;
        private const int WS_CLIPCHILDREN = 0x2000000;

        private FilgraphManager m_objFilterGraph = null;
        private IBasicAudio m_objBasicAudio = null;
        private IVideoWindow m_objVideoWindow = null;
        private IMediaEvent m_objMediaEvent = null;
        private IMediaEventEx m_objMediaEventEx = null;
        private IMediaPosition m_objMediaPosition = null;
        private IMediaControl m_objMediaControl = null;
        private System.Windows.Forms.MenuItem menuItem5;

        enum MediaStatus { None, Stopped, Paused, Running };

        private MediaStatus m_CurrentStatus = MediaStatus.None;

        public Form1()
        {
            //
            // Erforderlich f�r die Windows Form-Designerunterst�tzung
            //
            InitializeComponent();

            //
            // TODO: F�gen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
            //
            UpdateStatusBar();
            UpdateToolBar();
        }

        /// <summary>
        /// Die verwendeten Ressourcen bereinigen.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            CleanUp();
            
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

		#region Windows Form Designer generated code
        /// <summary>
        /// Erforderliche Methode f�r die Designerunterst�tzung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor ge�ndert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.menuItem1,
                                                                                      this.menuItem5});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.menuItem2,
                                                                                      this.menuItem3,
                                                                                      this.menuItem4});
            this.menuItem1.Text = "&File";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItem2.Text = "&Open...";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "E&xit";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                        this.toolBarButton1,
                                                                                        this.toolBarButton2,
                                                                                        this.toolBarButton3});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(442, 25);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Enabled = false;
            this.toolBarButton1.ImageIndex = 0;
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Enabled = false;
            this.toolBarButton2.ImageIndex = 1;
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Enabled = false;
            this.toolBarButton3.ImageIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Red;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 421);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
                                                                                          this.statusBarPanel1,
                                                                                          this.statusBarPanel2,
                                                                                          this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(442, 22);
            this.statusBar1.TabIndex = 2;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.statusBarPanel1.Text = "Ready";
            this.statusBarPanel1.Width = 292;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanel2.Text = "00:00:00";
            this.statusBarPanel2.Width = 67;
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanel3.Text = "00:00:00";
            this.statusBarPanel3.Width = 67;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 396);
            this.panel1.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "&Info";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(442, 443);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.panel1,
                                                                          this.statusBar1,
                                                                          this.toolBar1});
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "DirectShow";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

        /// <summary>
        /// Der Haupteinstiegspunkt f�r die Anwendung.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Media Files|*.mpg;*.avi;*.wma;*.mov;*.wav;*.mp2;*.mp3|All Files|*.*";

            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                CleanUp();

                m_objFilterGraph = new FilgraphManager();
                m_objFilterGraph.RenderFile(openFileDialog.FileName);

                m_objBasicAudio = m_objFilterGraph as IBasicAudio;
                
                try
                {
                    m_objVideoWindow = m_objFilterGraph as IVideoWindow;
                    m_objVideoWindow.Owner = (int) panel1.Handle;
                    m_objVideoWindow.WindowStyle = WS_CHILD | WS_CLIPCHILDREN;
                    m_objVideoWindow.SetWindowPosition(panel1.ClientRectangle.Left,
                        panel1.ClientRectangle.Top,
                        panel1.ClientRectangle.Width,
                        panel1.ClientRectangle.Height);
                }
                catch (Exception)
                {
                    m_objVideoWindow = null;
                }

                m_objMediaEvent = m_objFilterGraph as IMediaEvent;

                m_objMediaEventEx = m_objFilterGraph as IMediaEventEx;
                m_objMediaEventEx.SetNotifyWindow((int) this.Handle,WM_GRAPHNOTIFY, 0);

                m_objMediaPosition = m_objFilterGraph as IMediaPosition;

                m_objMediaControl = m_objFilterGraph as IMediaControl;

                this.Text = "DirectShow - [" + openFileDialog.FileName + "]";

                m_objMediaControl.Run();
                m_CurrentStatus = MediaStatus.Running;

                UpdateStatusBar();
                UpdateToolBar();
            }
        }

        private void CleanUp()
        {
            if (m_objMediaControl != null)
                m_objMediaControl.Stop();

            m_CurrentStatus = MediaStatus.Stopped;

            if (m_objMediaEventEx != null)
                m_objMediaEventEx.SetNotifyWindow(0, 0, 0);

            if (m_objVideoWindow != null)
            {
                m_objVideoWindow.Visible = 0;
                m_objVideoWindow.Owner = 0;
            }

            if (m_objMediaControl != null) m_objMediaControl = null;
            if (m_objMediaPosition != null) m_objMediaPosition = null;
            if (m_objMediaEventEx != null) m_objMediaEventEx = null;
            if (m_objMediaEvent != null) m_objMediaEvent = null;
            if (m_objVideoWindow != null) m_objVideoWindow = null;
            if (m_objBasicAudio != null) m_objBasicAudio = null;
            if (m_objFilterGraph != null) m_objFilterGraph = null;
        }

        private void menuItem4_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void Form1_SizeChanged(object sender, System.EventArgs e)
        {
            if (m_objVideoWindow != null)
            {
                m_objVideoWindow.SetWindowPosition(panel1.ClientRectangle.Left,
                    panel1.ClientRectangle.Top,
                    panel1.ClientRectangle.Width,
                    panel1.ClientRectangle.Height);
            }
        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch(toolBar1.Buttons.IndexOf(e.Button))
            {
                case 0: m_objMediaControl.Run();
                        m_CurrentStatus = MediaStatus.Running;
                        break; 

                case 1: m_objMediaControl.Pause();
                        m_CurrentStatus = MediaStatus.Paused;
                        break; 

                case 2: m_objMediaControl.Stop();
                        m_objMediaPosition.CurrentPosition = 0;
                        m_CurrentStatus = MediaStatus.Stopped;
                        break; 
            }
            
            UpdateStatusBar();
            UpdateToolBar();                        
        }

        protected override void WndProc( ref Message m)
        {
            if (m.Msg == WM_GRAPHNOTIFY)
            {
                int lEventCode;
                int lParam1, lParam2;

                while (true)
                {
                    try
                    {
                        m_objMediaEventEx.GetEvent(out lEventCode, 
                            out lParam1,
                            out lParam2,
                            0); 
 
                        m_objMediaEventEx.FreeEventParams(lEventCode, lParam1, lParam2);

                        if (lEventCode == EC_COMPLETE)
                        {
                            m_objMediaControl.Stop();
                            m_objMediaPosition.CurrentPosition = 0;
                            m_CurrentStatus = MediaStatus.Stopped;
                            UpdateStatusBar();
                            UpdateToolBar();
                        }
                    } 
                    catch (Exception)
                    {
                        break;
                    }
                }
            }

            base.WndProc(ref m);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (m_CurrentStatus == MediaStatus.Running)
            {
                UpdateStatusBar();
            }
        }

        private void UpdateStatusBar()
        {
            switch (m_CurrentStatus)
            {
                case MediaStatus.None   : statusBarPanel1.Text = "Stopped"; break;
                case MediaStatus.Paused : statusBarPanel1.Text = "Paused "; break;
                case MediaStatus.Running: statusBarPanel1.Text = "Running"; break;
                case MediaStatus.Stopped: statusBarPanel1.Text = "Stopped"; break;
            }

            if (m_objMediaPosition != null)
            {
                int s = (int) m_objMediaPosition.Duration;
                int h = s / 3600;
                int m = (s  - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);
                
                statusBarPanel2.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);

                s = (int) m_objMediaPosition.CurrentPosition;
                h = s / 3600;
                m = (s  - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);
                
                statusBarPanel3.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
            }
            else
            {
                statusBarPanel2.Text = "00:00:00";
                statusBarPanel3.Text = "00:00:00";
            }
        }

        private void UpdateToolBar()
        {
            switch (m_CurrentStatus)
            {
                case MediaStatus.None   : toolBarButton1.Enabled = false;
                                          toolBarButton2.Enabled = false;
                                          toolBarButton3.Enabled = false;
                                          break;
                                          
                case MediaStatus.Paused : toolBarButton1.Enabled = true;
                                          toolBarButton2.Enabled = false;
                                          toolBarButton3.Enabled = true;
                                          break;
                                          
                case MediaStatus.Running: toolBarButton1.Enabled = false;
                                          toolBarButton2.Enabled = true;
                                          toolBarButton3.Enabled = true;
                                          break;
                                          
                case MediaStatus.Stopped: toolBarButton1.Enabled = true;
                                          toolBarButton2.Enabled = false;
                                          toolBarButton3.Enabled = false;
                                          break;
            }
        }

        private void menuItem5_Click(object sender, System.EventArgs e)
        {
            Form2 dlg = new Form2();
            dlg.ShowDialog();
        }
    }
}
