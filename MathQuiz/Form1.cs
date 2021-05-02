using System;
using System.Globalization;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {

        Random randomizer = new Random();

        //sum
        int addend1;
        int addend2;

        //difference
        int subtraction1;
        int subtraction2;

        //product
        int multiply1;
       int multiply2;

        //quotient
       int division1;
      int division2;

        //time left
        int timeLeft;

        public Form1()
        {
            InitializeComponent();

            currentDate.Text = DateTime.Now.ToString("d MMMM yyyy");
        }

         private void StartTheQuiz() {
            //add
        addend1 = randomizer.Next(51);
        addend2 = randomizer.Next(51);
        plusLeftLabel.Text = addend1.ToString();
        plusRightLabel.Text = addend2.ToString();
        sum.Value = 0;

            //subtract
            subtraction1 = randomizer.Next(1, 101);
            subtraction2 = randomizer.Next(1, subtraction1);
            minusLeftLabel.Text = subtraction1.ToString();
            minusRightLabel.Text = subtraction2.ToString();
            difference.Value = 0;

            // Fill in the multiplication problem.
            multiply1 = randomizer.Next(2, 11);
            multiply2 = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiply1.ToString();
            timesRightLabel.Text = multiply2.ToString();
            product.Value = 0;

            // Fill in the division problem.
            division2 = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            division1 = division2 * temporaryQuotient;
            dividedLeftLabel.Text = division1.ToString();
            dividedRightLabel.Text = division2.ToString();
            quotient.Value = 0;

            //start timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
       && (subtraction1 - subtraction2 == difference.Value)
                && (multiply1 * multiply2 == product.Value)
        && (division1 / division2 == quotient.Value))
                return true;
            else
                return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {
            var answer = ((NumericUpDown)sender).Value;
            if ((addend1 + addend2)== answer)
           {
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Users\sara-\Music\Free_Rewind-Swipe-1_REWSE01042.wav");
               simpleSound.Play();
            }
        }

        private void difference_ValueChanged(object sender, EventArgs e)
        {
              var answer = ((NumericUpDown)sender).Value;
              if ((subtraction1 + subtraction2) == answer)
               {
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Users\sara-\Music\Free_Rewind-Swipe-1_REWSE01042.wav");
                simpleSound.Play();
             }
        }




        private void startButton_Click(object sender, EventArgs e)
        {
          StartTheQuiz();
          startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer  
                // and show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
                timeLabel.BackColor = Control.DefaultBackColor;
            }

            else if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";

                if ( timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                // timeLabel.BackColor = Color.Red;
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = subtraction1 - subtraction2;
                product.Value = multiply1 * multiply2;
                quotient.Value = division1 / division2;
                startButton.Enabled = true;
                timeLabel.BackColor = Control.DefaultBackColor;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void product_ValueChanged(object sender, EventArgs e)
        {
              var answer = ((NumericUpDown)sender).Value;
              if ((multiply1 * multiply2) == answer)
              {
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Users\sara-\Music\Free_Rewind-Swipe-1_REWSE01042.wav");
               simpleSound.Play();
             }
        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {
              var answer = ((NumericUpDown)sender).Value;
              if ((division1 / division2) == answer)
               {
               SoundPlayer simpleSound = new SoundPlayer(@"c:\Users\sara-\Music\Free_Rewind-Swipe-1_REWSE01042.wav");
               simpleSound.Play();
             }
        }
    }
    
}
