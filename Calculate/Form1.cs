using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;          

        }

        //1)
        // Добавить в textBox каждый текст кнопки которая была нажата 
        // Если нажать кнопку с текстом 1 то в textBox добавиться текст 1
        private void button21_Click(object sender, EventArgs e)
        {
            this.resultbox.Text += (sender as Button).Text;
            ChangeTextFont();

        }
        //Кнопка запятая ,
        private void button22_Click(object sender, EventArgs e)
        {
            if (this.resultbox.Text.Length > 0)
            {
                this.resultbox.Text += (sender as Button).Text;
            }
        }
        //Очистка textBox и textnum(сверху) при нажатии на C
        private void button3_Click(object sender, EventArgs e)
        {
            this.resultbox.Clear();
            this.textnum.Text = "0";
        }
        //Очистка данного текста в textBox'е CE
        private void button2_Click(object sender, EventArgs e)
        {
            if (resultbox.Text.Length > 0) this.resultbox.Text = this.resultbox.Text.Remove(0);
        }
        //Удалить один последний элемент textBox при нажатии на del
        private void button1_Click(object sender, EventArgs e)
        {
            this.resultbox.Text = this.resultbox.Text.Remove(this.resultbox.Text.Length - 1);
        }
        //Удалить плюс или добавить минус
        private void button4_Click(object sender, EventArgs e)
        {
            if (this.resultbox.Text.Length > 0)
            {
                if (this.resultbox.Text[0] == '-') this.resultbox.Text = this.resultbox.Text.Remove(0, 1);
                else this.resultbox.Text = '-' + this.resultbox.Text;
            }
        }
        //Операции + - / * корень и проценты
        double firstnum, secondnum, result;
        char znak;
        //Написать метод который отправляет данные текста поле и сохраняет в переменную firstnum
        //Добавить в znak элемент кнопки [0] 
        //Так же подписать метод ко всех событиям + - / *
        private void plusbtn_Click(object sender, EventArgs e)
        {
            znak = (sender as Button).Text[0];
            firstnum = double.Parse(this.resultbox.Text);
            this.resultbox.Clear();
            this.textnum.Text = $"{firstnum}{znak}";
        }
        //Кнопка ровно 
        private void button20_Click(object sender, EventArgs e)
        {
            secondnum = double.Parse(this.resultbox.Text);
            this.resultbox.Clear();
            switch (znak)
            {
                case '+':
                    result = firstnum + secondnum; break;
                case '-':
                    result = firstnum - secondnum; break;
                case '*':
                    result = firstnum * secondnum; break;
                case '/':
                    result = firstnum / secondnum; if (secondnum == 0) MessageBox.Show("На ноль нельзя делить"); break;
            }
            this.resultbox.Text = Convert.ToString(result);
            this.textnum.Text = string.Format($"{firstnum}{znak}{secondnum}=");
            ChangeTextFont();
            if (firstnum == 1881625 || secondnum == 1881625)
            {
                for (int i = 0; i < 10; i++)
                {
                    MessageBox.Show("АЛИЯ Я ЛЮБЛЮ ТЕБЯ");
                }
            }
        }

        //Изменить font
        private void ChangeTextFont()
        {
            if (this.resultbox.Text.Length > 11) this.resultbox.Font = new Font("Segoe UI Semilight", 16);
            if (this.resultbox.Text.Length > 22) this.resultbox.Font = new Font("Segoe UI Semilight", 12);
            if (this.resultbox.Text.Length < 11) this.resultbox.Font = new Font("Gadugi", 21, FontStyle.Bold);
        }

        //Запретить писать буквы
        private void resultbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Корень
        private void button5_Click(object sender, EventArgs e)
        {
            if (this.resultbox.Text.Length > 0)
            {
                this.textnum.Text = "√" + this.resultbox.Text;
                this.resultbox.Text =  Math.Sqrt(int.Parse(this.resultbox.Text)).ToString();
            }
        }

        private void resultbox_TextChanged(object sender, EventArgs e)
        {

        }

        //Вычеслить проценты
        private void button9_Click(object sender, EventArgs e)
        {
            if (znak=='*'&&this.resultbox.Text.Length>0)
            {
                secondnum = double.Parse(this.resultbox.Text);
                this.resultbox.Text = Convert.ToString((firstnum * secondnum) / 100);
                this.textnum.Text = Convert.ToString(secondnum)+$"% от {firstnum}=";
            }
            else
            {
                this.resultbox.Text = "";
            }
        }
        //Удалить один последний элемент
        private void resultbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.resultbox.Text.Length > 0 && e.KeyCode == Keys.Back) this.resultbox.Text = this.resultbox.Text.Remove(this.resultbox.Text.Length - 1);
            ChangeTextFont();
        }
    }
}
