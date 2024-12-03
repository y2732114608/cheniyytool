using System;
using System.Drawing;
using System.Windows.Forms;

namespace cheniyytool
{
    public partial class Form2 : Form
    {
        private RichTextBox chatDisplay;
        private TextBox inputBox;
        private Button sendButton;

        public Form2()
        {
            InitializeComponent();
            InitializeCustomComponents();
            this.Text = "聊天窗口";
            this.Load += Form2_Load; // 订阅 Load 事件
        }

        private void InitializeCustomComponents()
        {
            // 初始化聊天显示区
            chatDisplay = new RichTextBox();
            chatDisplay.Dock = DockStyle.Top;
            chatDisplay.Height = 300;
            chatDisplay.ReadOnly = true;
            chatDisplay.BackColor = Color.White;
            chatDisplay.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            this.Controls.Add(chatDisplay);

            // 初始化输入框
            inputBox = new TextBox();
            inputBox.Dock = DockStyle.Bottom;
            inputBox.Height = 30;
            inputBox.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            this.Controls.Add(inputBox);

            // 初始化发送按钮
            sendButton = new Button();
            sendButton.Text = "发送";
            sendButton.Dock = DockStyle.Bottom;
            sendButton.Height = 30;
            sendButton.Click += SendButton_Click;
            this.Controls.Add(sendButton);
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string userMessage = inputBox.Text.Trim();
            if (!string.IsNullOrEmpty(userMessage))
            {
                chatDisplay.AppendText("用户: " + userMessage + Environment.NewLine);
                inputBox.Clear();

                // 模拟ChatGPT回复
                string botResponse = GetChatBotResponse(userMessage);
                chatDisplay.AppendText("ChatGPT: " + botResponse + Environment.NewLine);
            }
        }

        private string GetChatBotResponse(string message)
        {
            // 模拟回复内容
            return "这是一个模拟回复。";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // 可在此处添加加载时的初始化代码
        }
    }
}