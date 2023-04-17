using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WhoWantstoBeaMil
{
    public partial class Form1 : Form
    {
        private Label[] labels = new Label[15];
        public Question[] questions { get; set; }
        public int current_question = 0;

        MainMenu MyMenu;
        MenuItem questions_edit;

        QuestionRedactor QuestionRedactor;
        public Form1()
        {
            questions= new Question[15];
            InitializeComponent();

            int summ = 1000000;
            for (int i = 0; i < 15; i++)
            {
                labels[i] = new Label();
                labels[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labels[i].Location = new System.Drawing.Point(566, 80+ i * 30);
                labels[i].Name = "labels" + i;
                labels[i].Size = new System.Drawing.Size(195, 26);
                labels[i].TabIndex = i;
                labels[i].Text = "" + (15 - i) + " - " + summ;
                labels[i].Enabled = true;
                Controls.Add(labels[i]);
                labels[i].BringToFront();
                summ /= 2;
            }
            labels[14-current_question].BackColor = Color.Green;
            labels[14- current_question].ForeColor = Color.White;
            labels[10].ForeColor = Color.Wheat;
            labels[5].ForeColor = Color.Wheat;
            labels[0].ForeColor = Color.Red;
            InitQuestions();
            LoadQuestion();

            MyMenu = new MainMenu();
            questions_edit = new MenuItem("Редактировать вопросы");
            questions_edit.Click += new EventHandler(EditMenu);
            MyMenu.MenuItems.Add(questions_edit);


            Menu = MyMenu;
        }
        private void InitQuestions()
        {
            questions[0] = new Question("Как называется место на берегу, где обитают тюлени?", "Лежбище", "Стойбище", "Пастбище", "Гульбище","A");
            questions[1] = new Question("Как мировая пресса называла премьер-министра Великобритании Маргарет Тэтчер?", "Стальная леди", "Железная леди", "Оловянный солдатик", "Крепкий орешек","B");
            questions[2] = new Question("Какой из этих городов южнее остальных?", "Лондон", "Токио", "Мадрид", "Каир", "D");
            questions[3] = new Question("Через какой город мира проходит нулевой меридиан? ", "Гринвич", "Гринсборо", "Глазго", "Гронинген","A");
            questions[4] = new Question("Какая птица является символом Новой Зеландии?", "Киви", "Жако", "Эму", "Казуар", "A");
            questions[5] = new Question("Какого короля англичане прозвали \"Львиное сердце\"?", "Вильгельм I", "Ричард I", "Карасик IV", "Генрих I", "B");
            questions[6] = new Question("Как в народе называются финансовые институты, обещающие вкладчикам золотые горы?", "Пирамиды", "Гробницы", "Захоронения", "Сфинксы","A");
            questions[7] = new Question("В каком году развалился СССР?", "1992", "1994", "1998", "1991", "D");
            questions[8] = new Question("В каком городе родился Вольфганг Амадей Моцарт?", "Киев", "Прага", "Зальцбург", "Вена", "C");
            questions[9] = new Question("Какую реку Юлий Цезарь перешел со словами \"Жребий брошен\"?", "Рубикон", "Припять", "Нил", "Евфрат","A");
            questions[10] = new Question("Как называется искусство аранжировки цветов?", "Икебана", "Суши", "Кэндо", "Харакири", "A");
            questions[11] = new Question("Какая страна является мировым лидером по производству кофе?", "Бразилия", "Венесуэла", "Украина", "Сан-Марино", "A");
            questions[12] = new Question("Что труднее всего дается не трезвому человеку?", "Вязать Лыко", "Потрогать траву", "Бить баклуши", "Кушать голубику", "A");
            questions[13] = new Question("Как называют японских мафиози?", "Джакузи", "Якуза", "Камиказдзе", "Коза Ностра", "A");
            questions[14] = new Question("Участник какого из перечисленных спортивных состязаний экипирован винтовкой?", "Биатлон", "Бейсбол", "Футбол", "SMB", "A");
        }

        private void EditMenu(object sender, EventArgs e)
        {
            QuestionRedactor = new QuestionRedactor();
            QuestionRedactor.par = this;
            QuestionRedactor.questions = questions;
            DialogResult res = QuestionRedactor.ShowDialog();
            for (int i = 0; i < questions.Length; i++)
            {
                QuestionRedactor.GetListBox().Items.Add(questions[i]);
            }
            if (res == DialogResult.OK)
            {
                //OilSumm = oil_form.OilSumm;
                //SummChanged();
            }
        }
        private void button7_Click(object sender, EventArgs e)//A
        {
            if (questions[current_question].correct_answer == "A")
            {
                AnswerHandler(sender, e);
            }
            else
            {
                MessageBox.Show("You lost!");
                button3_Click(sender, e);
            }
        }

        private void button8_Click(object sender, EventArgs e)//B
        {
            if (questions[current_question].correct_answer == "B")
            {
                AnswerHandler(sender, e);
            }
            else
            {
                MessageBox.Show("You lost!");
                button3_Click(sender,e);
            }
        }

        private void button9_Click(object sender, EventArgs e)//C
        {
            if (questions[current_question].correct_answer == "C")
            {
                AnswerHandler(sender, e);
            }
            else
            {
                MessageBox.Show("You lost!");
                button3_Click(sender, e);
            }
        }
        private void button10_Click(object sender, EventArgs e)//D
        {
            if (questions[current_question].correct_answer == "D")
            {
                AnswerHandler(sender, e);
            }
            else
            {
                MessageBox.Show("You lost!");
                button3_Click(sender, e);
            }
        }
        private void AnswerHandler(object sender, EventArgs e)
        {
            if (current_question == 14)
            {
                MessageBox.Show("You're a millionare!");
                button1_Click(sender, e);
            }
            else
            {
                LabelColourHandler();
                LoadQuestion();
            }
        }
        private void LabelColourHandler()
        {
            if (current_question == 14) return;
            labels[14 - current_question].BackColor = Color.Black;
            labels[14 - current_question].ForeColor = Color.Gold;
            current_question++;
            labels[14 - current_question].BackColor = Color.Green;
            labels[14 - current_question].ForeColor = Color.White;
        }
        private void LoadQuestion()
        {
            label1.Text = questions[current_question].question;
            button7.Text = questions[current_question].answer_a;
            button8.Text = questions[current_question].answer_b;
            button9.Text = questions[current_question].answer_c;
            button10.Text = questions[current_question].answer_d;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (questions[current_question].correct_answer == "A") MessageBox.Show("Зал склоняется к А и C!");
            else if (questions[current_question].correct_answer == "B") MessageBox.Show("Зал склоняется к B и D!");
            else if (questions[current_question].correct_answer == "C") MessageBox.Show("Зал склоняется к A и C!");
            else if(questions[current_question].correct_answer != "D") MessageBox.Show("Зал склоняется к B и D!");
            button6.Visible = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (questions[current_question].correct_answer != "A") button7.Text = "***";
            else
                button8.Text = "***";
            if (questions[current_question].correct_answer != "C") button9.Text = "***";
            else
                button10.Text = "***";
            button4.Visible = false;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (questions[current_question].correct_answer == "A") MessageBox.Show("Друг говорит - А!");
            else if (questions[current_question].correct_answer == "B") MessageBox.Show("Друг говорит - B!");
            else if (questions[current_question].correct_answer == "C") MessageBox.Show("Друг говорит - C!");
            else if (questions[current_question].correct_answer != "D") MessageBox.Show("Друг говорит - D!");
            button5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            current_question = 0;
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].BackColor = Color.Black;
                labels[i].ForeColor = Color.Gold;
            }
            labels[10].ForeColor = Color.Wheat;
            labels[5].ForeColor = Color.Wheat;
            labels[0].ForeColor = Color.Red;
            labels[14 - current_question].BackColor = Color.Green;
            labels[14 - current_question].ForeColor = Color.White;
            LoadQuestion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int summ = 0;
            if (current_question > 4) summ = 976;
            if (current_question > 9) summ = 31250;
            MessageBox.Show("You won " + summ);
            button1_Click(sender, e);

        }
    }
    public class Question
    {
        public string question { get; set; }
        public string answer_a { get; set; }
        public string answer_b { get; set;}
        public string answer_c { get; set;}
        public string answer_d { get; set;}
        public string correct_answer { get; set;}
        public Question(string question, string answer_a, string answer_b, string answer_c, string answer_d, string correct_answer)
        {
            this.question = question;
            this.answer_a = answer_a;
            this.answer_b = answer_b;
            this.answer_c = answer_c;
            this.answer_d = answer_d;
            this.correct_answer = correct_answer;
        }

        public Question()
        {
        }
    }
}
