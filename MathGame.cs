using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject3
{
    public partial class MathGame : Form
    {
        public MathGame(string strPlayer,string strTime,string strQuestionsNumber, string strComboBoxLevel,
            string strComboBoxOperation)
        {
            InitializeComponent();
            GameStatus.PlyarName = strPlayer;
            lblTime.Text = strTime;
            lblQuestionsNumber.Text = strQuestionsNumber;
            DifficultyLevel = strComboBoxLevel;
            OperationType = strComboBoxOperation;
        }

        string DifficultyLevel, OperationType;
        public enum enLevel { Easy, Medium, Hard, Mixed };
        public enum enOpType { Addition, Subtraction, Multiplication, Division, Mixed };
        public enum enWinner { Player, Computer ,Draw};

        Random rnd = new Random();
        public struct stGameTurn
        {
            public int FirstNumber;
            public int SecondNumber;
            public char OpTypeChar;
            public int ResultTurn;
            
        }

        stGameTurn GameTurn;
        public struct stGameStatus
        {
           public byte QuestionsNumber;
           public byte QuestionTurn;
           public byte NumberTimesLoses;
           public byte NumberTimesWins;
           public enWinner Winner;
           public string PlyarName;

        }

        stGameStatus GameStatus;
        public void ChoiceLevel(enLevel Level)
        {
            switch (Level)
            {
                case enLevel.Easy:
                    {

                        GameTurn.FirstNumber = rnd.Next(0, 9);
                        GameTurn.SecondNumber = rnd.Next(0, 9);
                        break;
                    }

                case enLevel.Medium:
                    {
                        GameTurn.FirstNumber = rnd.Next(10, 99);
                        GameTurn.SecondNumber = rnd.Next(10, 99);
                        break;
                    }

                case enLevel.Hard:
                    {
                        GameTurn.FirstNumber = rnd.Next(100, 200);
                        GameTurn.SecondNumber = rnd.Next(100, 200);
                        break;
                    }

                default:
                    {
                        GameTurn.FirstNumber = rnd.Next(0, 200);
                        GameTurn.SecondNumber = rnd.Next(0, 200);
                        break;
                    }

            }
        }
        enOpType GetRandomOperationType()
        {
            int Op = rnd.Next(1, 5);
            return (enOpType)Op;
        }
        public void ChoiceOperationType(enOpType OpType)
        {
            
            switch (OpType)
            {
                case enOpType.Addition:
                    {

                        GameTurn.OpTypeChar= '+';
                        break;
                    }

                case enOpType.Subtraction:
                    {
                        GameTurn.OpTypeChar = '-';
                        break;
                    }

                case enOpType.Multiplication:
                    {
                        GameTurn.OpTypeChar = '*';
                        break;
                    }

                case enOpType.Division:
                    {
                        GameTurn.OpTypeChar = '/'; 
                        break;
                    }

                case enOpType.Mixed:
                    {
                        OpType = GetRandomOperationType();

                        if(OpType==enOpType.Addition)
                        {
                            GameTurn.OpTypeChar = '+';
                        }

                        else if(OpType==enOpType.Subtraction)
                        {
                            GameTurn.OpTypeChar = '-';
                        }

                        else if(OpType==enOpType.Multiplication)
                        {
                            GameTurn.OpTypeChar = '*';
                        }

                        else
                        {
                            GameTurn.OpTypeChar = '/';
                        }

                        break;
                    }

            }
        }
        private void MathGame_Load(object sender, EventArgs e)
        {
            

        }
        public void RandomFirstAndSecondNumbers()
        {
            switch (DifficultyLevel)
            {
                case "Easy":
                    {
                        ChoiceLevel(enLevel.Easy);
                        lblFirstNumber.Text = GameTurn.FirstNumber.ToString();
                        lblSecondNumber.Text = GameTurn.SecondNumber.ToString();
                        break;
                    }

                case "Medium":
                    {
                        ChoiceLevel(enLevel.Medium);
                        lblFirstNumber.Text = GameTurn.FirstNumber.ToString();
                        lblSecondNumber.Text = GameTurn.SecondNumber.ToString();
                        break;
                    }

                case "Hard":
                    {
                        ChoiceLevel(enLevel.Hard);
                        lblFirstNumber.Text = GameTurn.FirstNumber.ToString();
                        lblSecondNumber.Text = GameTurn.SecondNumber.ToString();
                        break;
                    }

                default:
                    {
                        ChoiceLevel(enLevel.Mixed);
                        lblFirstNumber.Text = GameTurn.FirstNumber.ToString();
                        lblSecondNumber.Text = GameTurn.SecondNumber.ToString();
                        break;
                    }
            }

    }
        public void GetOperationType()
        {
            switch (OperationType)
            {
                case "Addition":
                    {
                        ChoiceOperationType(enOpType.Addition);
                        lblOperationType.Text=GameTurn.OpTypeChar.ToString();
                        break;
                    }

                case "Subtraction":
                    {
                        ChoiceOperationType(enOpType.Subtraction);
                        lblOperationType.Text = GameTurn.OpTypeChar.ToString();
                        break;
                    }

                case "Multiplication":
                    {
                        ChoiceOperationType(enOpType.Multiplication);
                        lblOperationType.Text = GameTurn.OpTypeChar.ToString();
                        break;
                    }

                case "Division":
                    {
                        ChoiceOperationType(enOpType.Division);
                        lblOperationType.Text = GameTurn.OpTypeChar.ToString();
                        break;
                    }

                case "Mixed":
                    {
                        ChoiceOperationType(enOpType.Mixed);
                        lblOperationType.Text = GameTurn.OpTypeChar.ToString();
                        break;
                    }
            }

        }
        public void OperationProcess()
        {
            RandomFirstAndSecondNumbers();
            GetOperationType();
            CalculateResult();
            PrintResultInButtons();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            GameStatus.QuestionTurn = 1;
            GameStatus.QuestionsNumber = Convert.ToByte(lblQuestionsNumber.Text.ToString());
            OperationProcess();
            btnStart.Enabled = false;
            timer1.Start();
        }
        private void button_Click(object sender, EventArgs e)
        {
            WinOrLoseButton((Button)sender);
        }
        public void ShowMessageWinOrLoseTurn(Button btn)
        {
            if (btn.Text == GameTurn.ResultTurn.ToString())
            {
                MessageBox.Show("Correct", "Turn");
            }
            else
            {
                MessageBox.Show("False", "Turn");
            }
        }
        public void ChangeValuesDuringGame()
        {
            lblTimesWin.Text = GameStatus.NumberTimesWins.ToString();
            lblTimesLoses.Text = GameStatus.NumberTimesLoses.ToString();

            if (GameStatus.QuestionTurn < GameStatus.QuestionsNumber)
            {
                OperationProcess();
                GameStatus.QuestionTurn++;
                lblQuestionTurn.Text = GameStatus.QuestionTurn.ToString();
            }

            if ((GameStatus.NumberTimesWins+GameStatus.NumberTimesLoses) 
                ==GameStatus.QuestionsNumber)
            {
                WinConditions();
                GameWinner();
                DisabledButtons();
            }
        }
        public void WinOrLoseButton(Button btn)
        {
            if(btn.Text=="?")
            {
                return;
            }
            if (btn.Text == GameTurn.ResultTurn.ToString())
            {
                GameStatus.NumberTimesWins++;
            }
            else
            {
                GameStatus.NumberTimesLoses++;
            }
            ShowMessageWinOrLoseTurn(btn);
            ChangeValuesDuringGame();
        }
        public void DisabledButtons()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
        }
        public void CalculateResult()
        {
            switch(GameTurn.OpTypeChar)
            {
                case '+':
                    {
                        GameTurn.ResultTurn=GameTurn.FirstNumber + GameTurn.SecondNumber;
                        break;
                    }

                case '-':
                    {
                        GameTurn.ResultTurn=GameTurn.FirstNumber - GameTurn.SecondNumber;
                        break;
                    }

                case '*':
                    {
                        GameTurn.ResultTurn = GameTurn.FirstNumber * GameTurn.SecondNumber;
                        break;
                    }

                case '/':
                    {
                        GameTurn.ResultTurn = GameTurn.FirstNumber / GameTurn.SecondNumber;
                        break;
                    }

                default:
                    {
                        break;
                    }

            }
        }
        public int RandomNearNumbers1()
        {
            return  rnd.Next(-5 + GameTurn.ResultTurn, -1+GameTurn.ResultTurn);
        }
        public int RandomNearNumbers2()
        {
            return rnd.Next( 1+ GameTurn.ResultTurn, 5 + GameTurn.ResultTurn);
        }
        public int RandomNearNumbers3()
        {
            return rnd.Next(6 + GameTurn.ResultTurn, 10 + GameTurn.ResultTurn);
        }
        public void PrintResultInButtons()
        {
            int Tag = rnd.Next(1, 5);

                if (Tag == 1)
                {
                    btn1.Text = GameTurn.ResultTurn.ToString();
                    btn2.Text = RandomNearNumbers1().ToString();
                    btn3.Text = RandomNearNumbers2().ToString();
                    btn4.Text = RandomNearNumbers3().ToString();

                }

                else if (Tag == 2)
                {
                    btn2.Text = GameTurn.ResultTurn.ToString();
                    btn1.Text = RandomNearNumbers1().ToString();
                    btn3.Text = RandomNearNumbers3().ToString();
                    btn4.Text = RandomNearNumbers2().ToString();
                }

                else if (Tag == 3)
                {
                    btn3.Text = GameTurn.ResultTurn.ToString();
                    btn1.Text = RandomNearNumbers3().ToString();
                    btn2.Text = RandomNearNumbers2().ToString();
                    btn4.Text = RandomNearNumbers1().ToString();
                }

                else if(Tag==4)
                {
                    btn4.Text = GameTurn.ResultTurn.ToString();
                    btn1.Text = RandomNearNumbers2().ToString();
                    btn2.Text = RandomNearNumbers3().ToString();
                    btn3.Text = RandomNearNumbers1().ToString();
                    
                }
          
        }
        public void WinConditions()
        {
            if(lblTime.Text == "0")
            {
                GameStatus.Winner = enWinner.Computer;
                return;
            }
            else if (GameStatus.NumberTimesWins > GameStatus.NumberTimesLoses)
            {
                GameStatus.Winner = enWinner.Player;

            }
            else if (GameStatus.NumberTimesWins < GameStatus.NumberTimesLoses)
            {
                GameStatus.Winner = enWinner.Computer;
            }
            else
                GameStatus.Winner = enWinner.Draw;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int Counter = Convert.ToInt32(lblTime.Text.ToString());

            Counter--;
            if (Counter >= 0)
            {
                lblTime.Text = Counter.ToString();

                if (lblWinner.Text != "" &&
                  GameStatus.NumberTimesWins + GameStatus.NumberTimesLoses
                == GameStatus.QuestionsNumber)

                {
                    timer1.Stop();
                }
            }
            
            if(Counter==0)
            {
                WinConditions();
                GameWinner();
                DisabledButtons();
            }
        }
        public void GameWinner()
        {
            if(GameStatus.Winner == enWinner.Player)
            {
                lblWinner.Text = GameStatus.PlyarName;
                MessageBox.Show("You Win ^_^", "GameOver");
            }

            else if(GameStatus.Winner == enWinner.Computer)
            {
                lblWinner.Text = "Computer";
                MessageBox.Show("You Lose T_T", "GameOver");
            }
            else
            {
                lblWinner.Text = "Draw";
                MessageBox.Show("Draw", "GameOver");
            }
        }

    }
     
}
