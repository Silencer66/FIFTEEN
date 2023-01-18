using System;
using System.Windows.Forms;

namespace FIFTEEN
{
    public partial class FormGame15 : Form
    {
        Game game;
        int count = 0, time = 0;
        public FormGame15()
        {
            InitializeComponent();
            game = new Game(4);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            count++;
            int position = Convert.ToInt32(((Button)sender).Tag); //получаем с помощью sender какая кнопка нажата
            //button(position).Text = position.ToString(); //присваеваем текст нажатой кнопке
            //MessageBox.Show(position.ToString());
            game.shift(position);
            Refresh();
            if (game.check_numbers())
            {
                MessageBox.Show($"Победа! Ходов: {count}, За время: {time}секунд. ");
                timer1.Enabled = false;
                start_game();
            }
        }
        private Button button(int position)
        {
            switch (position)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }
        //запуск формы
        private void FormGame15_Load(object sender, EventArgs e)
        {
            start_game();
        }
        // кнопкв начать игру 
        private void menu_start_Click(object sender, EventArgs e)
        {
            start_game();
        }

        private void start_game()
        {
            game.start();
            for (int j = 0; j < 110; j++)
                game.shift_random();
            Refresh();
            count = 0;
            timer1.Enabled = true;
            time = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
        }

        private void Refresh()
        {
            for (int position = 0; position < 16; position++)
            {
                int number = game.get_number(position);
                button(position).Text = number.ToString();
                button(position).Visible = (number > 0);
            }
        }
    }
}
