using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        List<List<TextBox>> textBoxes;
        Logic logic = new Logic();
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            SetTextBoxes();

        }

        private void SetTextBoxes()
        {
            textBoxes = new List<List<TextBox>>
            {
                new List<TextBox>{ textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 },
                new List<TextBox>{ textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16 },
                new List<TextBox>{ textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24 },
                new List<TextBox>{ textBox25, textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32 },
                new List<TextBox>{ textBox33, textBox34, textBox35, textBox36, textBox37, textBox38, textBox39, textBox40 },
                new List<TextBox>{ textBox41, textBox42, textBox43, textBox44, textBox45, textBox46, textBox47, textBox48 },
                new List<TextBox>{ textBox49, textBox50, textBox51, textBox52, textBox53, textBox54, textBox55, textBox56 },
                new List<TextBox>{ textBox57, textBox58, textBox59, textBox60, textBox61, textBox62, textBox63, textBox64 },
                new List<TextBox>{ textBox65, textBox66, textBox67, textBox68, textBox69, textBox70, textBox71, textBox72 },
                new List<TextBox>{ textBox73, textBox74, textBox75, textBox76, textBox77, textBox78, textBox79, textBox80 },
                new List<TextBox>{ textBox81, textBox82, textBox83, textBox84, textBox85, textBox86, textBox87, textBox88 },
                new List<TextBox>{ textBox89, textBox90, textBox91, textBox92, textBox93, textBox94, textBox95, textBox96 },
                new List<TextBox>{ textBox97, textBox98, textBox99, textBox100, textBox101, textBox102, textBox103, textBox104 },
                new List<TextBox>{ textBox105, textBox106, textBox107, textBox108, textBox109, textBox110, textBox111, textBox112 }
            };
            for(int i = 1; i < textBoxes.Count; i++)
            {
                textBoxes[i].Reverse();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<NumericUpDown> numericUpDowns = new List<NumericUpDown> { numericUpDown1, numericUpDown2
                , numericUpDown3, numericUpDown4, numericUpDown5, numericUpDown6, numericUpDown7
                , numericUpDown8, numericUpDown9, numericUpDown10, numericUpDown11, numericUpDown12
                , numericUpDown13, numericUpDown14};
            

            EnableNumericUpDowns(numericUpDowns);
            for(int i = 0; i < numericUpDowns.Count; i++)
            {
                EnableElementColumns(textBoxes[i], numericUpDowns[i]);
            }
        }

        private void EnableNumericUpDowns(List<NumericUpDown> numericUpDowns)
        {
            for (int i = 0; i < amountOfElements.Value; i++)
            {
                if (!numericUpDowns[i].Visible)
                {
                    numericUpDowns[i].Visible = true;
                }
            }
            for (int i = (int)amountOfElements.Value; i < numericUpDowns.Count; i++)
            {
                if (numericUpDowns[i].Visible)
                {
                    numericUpDowns[i].Visible = false;
                }
            }
        }

        private void EnableElementColumns(List<TextBox> textBoxes, NumericUpDown numericUpDown)
        {
            if (!numericUpDown.Visible)
            {
                for (int i = 0; i < numericUpDown.Maximum; i++)
                {
                    if (textBoxes[i].Visible)
                    {
                        textBoxes[i].Visible = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < numericUpDown.Value; i++)
                {
                    if (!textBoxes[i].Visible)
                    {
                        textBoxes[i].Visible = true;
                    }
                }
                for (int i = (int)numericUpDown.Value; i < textBoxes.Count; i++)
                {
                    if (textBoxes[i].Visible)
                    {
                        textBoxes[i].Visible = false;
                    }
                }
            }
        }

        private void getElementsButton_Click(object sender, EventArgs e)
        {
            if (amountOfElements.Value > 0)
            {
                List<List<string>> values = new List<List<string>>();

                for (int i = 0; i < textBoxes.Count; i++)
                {
                    if (textBoxes[i][0].Visible)
                        values.Add(new List<string>());
                    else
                        break;
                    for (int j = 0; j < textBoxes[i].Count; j++)
                    {
                        if (textBoxes[i][j].Visible)
                        {
                            values[i].Add(textBoxes[i][j].Text);
                        }
                        else
                            break;
                    }

                }

                logic.Values = values;
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            logic.GetUnique();


            Matrix2.Text = "";
            foreach (var x in logic.Answer)
            {
                foreach (var y in x)
                {
                    Matrix2.Text += y.ToString() + " ";
                }
                Matrix2.Text += Environment.NewLine;
            }
            MatrixText.Text = "";
            foreach (var x in logic.Nvalues)
            {
                foreach (var y in x)
                {
                    MatrixText.Text += y.ToString() + " ";
                }
                MatrixText.Text += Environment.NewLine;
            }

            groupedAnswerText.Text = "";
            foreach(var x in logic.GroupedAnswer)
            {
                foreach(var y in x)
                {
                    groupedAnswerText.Text += y.ToString() + " ";
                }
                groupedAnswerText.Text += Environment.NewLine;
            }

            Form2 form2 = new Form2(logic.Modules, logic.finalModules);
            form2.Show();
        }
    }
}
