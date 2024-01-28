using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeedNumberQuiz
{
    public partial class Form1 : Form
    {
        private int time = 30;
        private int score = 0;
        private int answer = -1;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            this.guessTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
        }

        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return && quizTimer.Enabled)
            {
                try
                {
                    if (answer == -1)
                    {
                        throw new Exception("New question has not been generated yet.");
                    }

                    if (CheckAnswer())
                    {
                        answer = -1;
                        score++;
                        scoreLabel.Text = score.ToString();
                        questionLabel.ForeColor = Color.Green;
                    } else
                    {
                        questionLabel.ForeColor = Color.Red;
                        throw new Exception("Wrong answer! Try again.");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                guessTB.Text = "";
            }
        }

        private void quizTimer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                timerLabel.Text = time.ToString();
                if (time == 0)
                {
                    questionLabel.ForeColor = Color.Black;
                    questionLabel.Text = "Time's up! Press \"Start\" to try again";
                    startButton.Visible = true;
                    quizTimer.Stop();
                    time = 30;
                    timerLabel.Text = time.ToString();
                } else if (answer == -1)
                {
                    GenerateQuestion();
                    questionLabel.ForeColor = Color.Black;
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            quizTimer.Start();
            startButton.Visible = false;
            score = 0;
            scoreLabel.Text = score.ToString();
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            int left = rnd.Next(5, 10);
            int right = rnd.Next(0, left);
            int op = rnd.Next(1, 4);

            switch(op)
            {
                case 1:
                    answer = right + left;
                    questionLabel.Text = left.ToString() + " + " + right.ToString();
                    break;
                case 2:
                    answer = left - right;
                    questionLabel.Text = left.ToString() + " - " + right.ToString();
                    break;
                case 3:
                    answer = right * left;
                    questionLabel.Text = left.ToString() + " * " + right.ToString();
                    break;
                default:
                    answer = 0;
                    questionLabel.Text = "0 + 0";
                    break;
            }
        }

        private bool CheckAnswer()
        {
            int guess = -1;
            if (int.TryParse(guessTB.Text, out guess))
            {
                if (guess == answer)
                {
                    return true;
                } 
                else
                {
                    return false;
                }
            }
            else
            {
                questionLabel.ForeColor = Color.Red;
                throw new Exception("Not a valid answer. Please Enter a number");
            }
        }
    }
}
