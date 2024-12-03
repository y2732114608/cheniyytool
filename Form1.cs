using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Diagnostics;

namespace cheniyytool
{
    public partial class Form1 : Form
    {
        private SplitContainer splitContainer;
        private ListBox menuListBox;
        private Panel contentPanel;
        private Button explainButton;
        private Label explanationLabel;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
            this.Text = "cheniyytool";
            //this.Icon = new Icon("tubiao.ico");
        }

        private void InitializeCustomComponents()
        {
            // 初始化 SplitContainer
            splitContainer = new SplitContainer();
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Orientation = Orientation.Vertical;
            splitContainer.SplitterDistance = 150;
            splitContainer.IsSplitterFixed = true; // 禁止用户调整分隔条
            splitContainer.FixedPanel = FixedPanel.Panel1; // 固定左侧面板

            // 初始化菜单 ListBox
            menuListBox = new ListBox();
            menuListBox.Dock = DockStyle.Fill;
            menuListBox.Items.AddRange(new string[] { "简介", "设置优化", "aichat" });
            menuListBox.SelectedIndexChanged += MenuListBox_SelectedIndexChanged;
            menuListBox.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            menuListBox.BackColor = Color.LightGray;
            menuListBox.ItemHeight = 30; // 调整菜单项高度

            // 初始化内容 Panel
            contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;

            // 将控件添加到 SplitContainer
            splitContainer.Panel1.Controls.Add(menuListBox);
            splitContainer.Panel2.Controls.Add(contentPanel);

            // 将 SplitContainer 添加到窗体
            this.Controls.Add(splitContainer);

            // 默认选中第一个菜单项
            menuListBox.SelectedIndex = 0;
        }

        private void MenuListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                contentPanel.Controls.Clear();

                if (menuListBox.SelectedItem.ToString() == "简介")
                {
                    // 显示简介文字
                    Label introLabel = new Label();
                    introLabel.Text = "这是cheniyy制作的第一款软件工具。版本1.0";
                    introLabel.Font = new Font("微软雅黑", 12, FontStyle.Regular);
                    introLabel.AutoSize = true;
                    introLabel.Location = new Point(20, 20);
                    contentPanel.Controls.Add(introLabel);

                    // 创建第一个按钮
                    Button button1 = new Button();
                    button1.Text = "我的博客";
                    button1.Size = new Size(100, 30);
                    button1.Location = new Point(20, 60);
                    button1.Click += (s, args) =>
                    {
                        try
                        {
                            Process.Start(new ProcessStartInfo("https://www.cheniyy.top/") { UseShellExecute = true });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("无法打开网页: " + ex.Message);
                        }
                    };

                    // 创建第二个按钮
                    Button button2 = new Button();
                    button2.Text = "github项目";
                    button2.Size = new Size(100, 30);
                    button2.Location = new Point(130, 60);
                    button2.Click += (s, args) =>
                    {
                        try
                        {
                            Process.Start(new ProcessStartInfo("https://github.com/y2732114608/cheniyytool") { UseShellExecute = true });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("无法打开网页: " + ex.Message);
                        }
                    };

                    // 添加按钮到 contentPanel
                    contentPanel.Controls.Add(button1);
                    contentPanel.Controls.Add(button2);
                }
                else if (menuListBox.SelectedItem.ToString() == "设置优化")
                {
                    // 添加按钮和输入框
                    Button optionButton = new Button();
                    optionButton.Text = "Win32PrioritySeparation";
                    optionButton.Size = new Size(200, 30);
                    optionButton.Location = new Point(20, 20);
                    optionButton.Click += OptionButton_Click; // 添加点击事件处理程序
                    contentPanel.Controls.Add(optionButton);

                    TextBox inputBox = new TextBox();
                    inputBox.Size = new Size(100, 30);
                    inputBox.Location = new Point(230, 20);
                    inputBox.Name = "inputBox"; // 设置输入框的名称，方便在事件处理程序中访问
                    contentPanel.Controls.Add(inputBox);

                    // 添加控制显示/隐藏解释的按钮
                    explainButton = new Button();
                    explainButton.Text = "显示解释";
                    explainButton.Size = new Size(100, 30);
                    explainButton.Location = new Point(340, 20);
                    explainButton.Click += ExplainButton_Click;
                    contentPanel.Controls.Add(explainButton);

                    // 添加用于显示解释的标签，初始状态为不可见
                    explanationLabel = new Label();
                    explanationLabel.Text = "用于在后台任务和程序之间分配优先级的参数。默认值2";
                    explanationLabel.Font = new Font("微软雅黑", 12, FontStyle.Regular);
                    explanationLabel.AutoSize = true;
                    explanationLabel.Location = new Point(20, 60);
                    explanationLabel.Visible = false;
                    contentPanel.Controls.Add(explanationLabel);
                }
                else if (menuListBox.SelectedItem.ToString() == "aichat")
                {
                    // 创建第一个按钮
                    Button button1 = new Button();
                    button1.Text = "跳转窗口1";
                    button1.Size = new Size(100, 30);
                    button1.Location = new Point(20, 20);
                    button1.Click += (s, args) =>
                    {
                        this.Hide();
                        Form2 form2 = new Form2();
                        form2.ShowDialog();
                        this.Show();
                    };

                    // 创建第二个按钮
                    Button button2 = new Button();
                    button2.Text = "跳转窗口2";
                    button2.Size = new Size(100, 30);
                    button2.Location = new Point(130, 20);
                    button2.Click += (s, args) =>
                    {
                        this.Hide();
                        Form3 form3 = new Form3();
                        form3.ShowDialog();
                        this.Show();
                    };

                    // 添加按钮到 contentPanel
                    contentPanel.Controls.Add(button1);
                    contentPanel.Controls.Add(button2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载内容时出错: " + ex.Message);
            }
        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            // 获取输入框的值
            TextBox inputBox = contentPanel.Controls["inputBox"] as TextBox;
            if (inputBox != null)
            {
                int value;
                if (int.TryParse(inputBox.Text, out value))
                {
                    try
                    {
                        // 修改注册表中的值
                        Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\PriorityControl", true);
                        if (key != null)
                        {
                            key.SetValue("Win32PrioritySeparation", value, Microsoft.Win32.RegistryValueKind.DWord);
                            key.Close();
                            MessageBox.Show("Win32PrioritySeparation 已更新为 " + value);
                        }
                        else
                        {
                            MessageBox.Show("无法打开注册表项");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("修改注册表时出错: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("请输入有效的数字");
                }
            }
        }

        private void ExplainButton_Click(object sender, EventArgs e)
        {
            if (explanationLabel.Visible)
            {
                explanationLabel.Visible = false;
                explainButton.Text = "显示解释";
            }
            else
            {
                explanationLabel.Visible = true;
                explainButton.Text = "收起";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (!IsRunAsAdmin())
            {
                // 重新启动应用程序并请求管理员权限
                var processInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = Application.ExecutablePath,
                    Verb = "runas"
                };

                try
                {
                    Process.Start(processInfo);
                }
                catch (Exception)
                {
                    MessageBox.Show("此操作需要管理员权限。请重新启动应用程序并授予管理员权限。");
                    return;
                }

                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1()); // 替换为你的主窗体类
            }
        }

        private static bool IsRunAsAdmin()
        {
            var wi = WindowsIdentity.GetCurrent();
            var wp = new WindowsPrincipal(wi);
            return wp.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}