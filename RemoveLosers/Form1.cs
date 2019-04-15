using System;
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
            x = x.Replace(" если", ", если");
            x = x.Replace("пожалуйста", "пожалуйста,");
            x = x.Replace(",,", ","); // ха-ха
            return x;
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button1.Enabled = false;
                textBox1.Text = "дура введи текст )";
                await Task.Delay(2000);
                textBox1.Text = "";
                button1.Enabled = true;
                return;
            }
            if (clipboardCopy == false)
            { //line = File.ReadAllText(@"C:\Users\admin\Desktop\1.txt", Encoding.Default);
                line = textBox1.Text; //line = line.Replace("все", "всё").Replace("еще", "ещё").Replace(" если", ", если").Replace(",,", ","); //ха-ха
                line = ReplaceString(line);
                textBox1.Text = line; button1.Text = "Исправлено";
                await Task.Delay(2000); button1.Text = "Скопировать исправленный текст";
                clipboardCopy = true;
                return;
            }
            if (clipboardCopy == true)
            {
                Clipboard.SetDataObject(line);
                button1.Text = "Скопировано в буфер обмена";
                clipboardCopy = false;
                textBox1.Text = "Начинаем заново";
                await Task.Delay(2000);
                textBox1.Text = ""; button1.Text = "Жмякой сюды"; return;
            }
        }
    }
}