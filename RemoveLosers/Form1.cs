using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoveLosers
{
    public partial class Form1 : Form
    {
        public bool clipboardCopy = false;
        private string line;

        public Form1()
        {
            InitializeComponent();
        }

        private static string ReplaceString(string x)
        {
            x = x.Replace("еще", "ещё");
            x = x.Replace("все верно", "всё верно");
            x = x.Replace("все равно", "всё верно");
            x = x.Replace("все будет", "всё будет");
            x = x.Replace(" если", ", если");
            x = x.Replace(" елси", ", если");
            x = x.Replace("пожалуйста", "пожалуйста,");
            x = x.Replace(",,", ","); // ха-ха
            return x;
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            Action<byte, byte, byte> ColorAction = async (r, g, b) =>
          {
              while ((r <= 135 && g <= 206) & (b <= 250))
              {
                  label1.ForeColor = Color.FromArgb(r, g, b);
                  r = (byte)(r + 3);
                  g = (byte)(g + 4);
                  b = (byte)(b + 4);
                  await Task.Delay(40);
              }
              label1.ForeColor = Color.FromArgb(135, 206, 250);
              await Task.Delay(2000);
              textBox1.Text = "";
              button1.Text = "Жмякой сюды";
              button1.Enabled = true;
              label1.ForeColor = Color.FromArgb(70, 130, 180);
          };

            if (textBox1.Text == "")
            {
                button1.Enabled = false;
                label1.Text = "Дура введи текст )";
                ColorAction(70, 130, 180);
            }
            else if (!clipboardCopy)
            {
                line = textBox1.Text;
                line = ReplaceString(line);
                textBox1.Text = line;
                button1.Text = "Исправлено";
                await Task.Delay(2000);
                button1.Text = "Скопировать исправленный текст";
                clipboardCopy = true;
            }
            else if (clipboardCopy)
            {
                Clipboard.SetDataObject(line);
                button1.Text = "Скопировано в буфер обмена";
                clipboardCopy = false;
                label1.Text = "Начинаем заново";
                ColorAction(70, 130, 180);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}