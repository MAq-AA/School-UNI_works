using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;
namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		public static double X { get; set; }
        public static double A { get; set; }
        public static double Y { get; set; }
		public static int Z { get; set; } 
		public List<string> equs = [];
		public List<Series> sercol = [];
		Series series = new();
		public Form1()
		{
			InitializeComponent();

			
		}
	   

		private void Button2_Click(object sender, EventArgs e)
		{
			equation.Text = "";
			if (Z > 0)
			{
				series = null;
                chart.Series[Z - 1].Points.Clear();
				equs[Z-1] = "";
				Z--;
				A++;
				if(Z == 0)
				{
					chart.ChartAreas[0].AxisX.Minimum = Convert.ToInt32(min.Text);
                }
			}
		}
		

		private void Download_Click(object sender, EventArgs e)
		{
			Random rnd = new(Convert.ToInt32(textBox4.Text));
			if (razbros.Text != "")
			{
				string fileName = "chart.png";
				string path = Path.Combine(Environment.CurrentDirectory, @"Charts\", fileName);
				chart.SaveImage(path, ChartImageFormat.Png); 

				for (int i = 0; i < Convert.ToInt32(razbros.Text)-1; i++)
				{
					int value = rnd.Next(0, 100);
					int j = Z;
					Z = 0;
					while (j > Z)
					{
						chart.Series[j-1].Points.Clear();
						Make_series(equs[j-1] + "+" + Convert.ToString(value));
						label3.Text = equs[j-1] + "+" + Convert.ToString(value);
					}
					fileName = "chart" + i + 1 + ".png";
					path = Path.Combine(Environment.CurrentDirectory, @"Charts\", fileName);
					chart.SaveImage(path, ChartImageFormat.Png);
				}
			}
			else
			{
				string fileName = "chart.png";
				string path = Path.Combine(Environment.CurrentDirectory, @"Charts\", fileName);
				chart.SaveImage(path, ChartImageFormat.Png);
			}
			Z = 0;
			
        }


		private void Make_Click(object sender, EventArgs e)
		{
			if ((equation.Text == "") || (right.Text == "") || (min.Text == ""))
			{
				MessageBox.Show("НЕТ ДАННЫХ!!!!", "ВНИМАНИЕ");
				return;
			}

			equs.Add(equation.Text);

			Make_series(equation.Text);
            

            chart.ChartAreas[0].AxisY.Title = osi1.Text;
			chart.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Center; 
			chart.ChartAreas[0].AxisY.TitleAlignment = (StringAlignment)Docking.Bottom;
			chart.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Horizontal;

			chart.ChartAreas[0].AxisX.Maximum = Convert.ToInt32(right.Text);

			
			chart.ChartAreas[0].AxisX.Title = osi2.Text;
			chart.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center; 
			chart.ChartAreas[0].AxisX.TitleAlignment = (StringAlignment)Docking.Bottom;
			chart.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Horizontal;
        }


		public void Make_series(string formula)
		{
			A++;
			Form1.X = double.Parse(min.Text);
			double max = double.Parse(right.Text);
			Mather mather = new(formula);
			series = new("series" + A)

			{
				ChartType = SeriesChartType.Spline,
				BorderWidth = 3,
				BorderColor = Color.Red

			};
            chart.Series.Add(series);

            while (X <= max)
			{
				Form1.Y = mather.Calc();
				chart.Series[Z].Points.AddXY(Form1.X, Form1.Y);
                chart.Series[Z].Color = Color.Red;
                chart.Series[Z].BorderWidth = 3;
                chart.Series[Z].ChartType = SeriesChartType.Spline;
                Form1.X++;
			}
			Z++;
		}


		private void TextBox1_TextChanged_1(object sender, EventArgs e)
		{
			string less = " " + textBox3.Text;
			if((char.IsDigit((less[less.Length - 1]))) && (textBox3.Text != ""))
            {
				chart.ChartAreas[0].AxisY.Interval = Convert.ToInt32(textBox3.Text);
			}
		}


		private void TextBox2_TextChanged(object sender, EventArgs e)
		{
            string less = " " + textBox3.Text;
			if ((char.IsDigit((less[less.Length - 1]))) && (textBox2.Text != "")) {
				chart.ChartAreas[0].AxisX.Interval = Convert.ToInt32(textBox2.Text); 
			}
		}


		private void Button1_Click(object sender, EventArgs e)
		{
			string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
			userName = userName.Substring(16);

			string adres = "C:\\Users\\" + userName + "\\Desktop\\WindowsFormsApp1\\WindowsFormsApp1\\bin\\Debug\\Charts";
			Process.Start("explorer.exe", adres);
		}
		

		private void Form1_Load(object sender, EventArgs e)
		{

		}
		private void Label1_Click(object sender, EventArgs e)
		{

		}
		private void TextBox3_TextChanged(object sender, EventArgs e)
		{

		}
		private void Osi1_TextChanged(object sender, EventArgs e)
		{

		}
		private void Label6_Click(object sender, EventArgs e)
		{

		}
		private void TextBox1_TextChanged(object sender, EventArgs e)
		{

		}
		private void Chart1_Click(object sender, EventArgs e)
		{

		}
		private void Label8_Click(object sender, EventArgs e)
		{

		}
		private void Label3_Click(object sender, EventArgs e)
		{

		}
		private void TextBox2_TextChanged_1(object sender, EventArgs e)
		{

		}
		private void Label9_Click(object sender, EventArgs e)
		{

		}
		private void Label5_Click(object sender, EventArgs e)
		{

		}
		private void Label4_Click(object sender, EventArgs e)
		{

		}
		private void Right_TextChanged(object sender, EventArgs e)
		{
			if ((right.Text != "") || (Convert.ToInt32(right.Text) < chart.ChartAreas[0].AxisX.Maximum))
			{
				chart.ChartAreas[0].AxisX.Maximum = Convert.ToInt32(right.Text);
			}
		}
		private void Label7_Click(object sender, EventArgs e)
		{

		}
		private void Label3_Click_1(object sender, EventArgs e)
		{

		}
		private void GroupBox2_Enter(object sender, EventArgs e)
		{

		}
		private void BextBox1_TextChanged_2(object sender, EventArgs e)
		{

		}
		private void Button15_Click(object sender, EventArgs e)
		{
			equation.Text += "-";
		}
		private void Button_1_Click(object sender, EventArgs e)
		{
			equation.Text += "1";
		}
		private void Button_2_Click(object sender, EventArgs e)
		{
			equation.Text += "2";
		}
		private void Button_3_Click(object sender, EventArgs e)
		{
			equation.Text += "3";
		}
		private void Button_4_Click(object sender, EventArgs e)
		{
			equation.Text += "4";
		}
		private void Button_5_Click(object sender, EventArgs e)
		{
			equation.Text += "5";
		}
		private void Button_6_Click(object sender, EventArgs e)
		{
			equation.Text += "6";
		}
		private void Button_7_Click(object sender, EventArgs e)
		{
			equation.Text += "7";
		}
		private void Button_8_Click(object sender, EventArgs e)
		{
			equation.Text += "8";
		}
		private void Button_9_Click(object sender, EventArgs e)
		{
			equation.Text += "9";
		}
		private void LSKOB_Click(object sender, EventArgs e)
		{
			equation.Text += "(";
		}
		private void RSKOB_Click(object sender, EventArgs e)
		{
			equation.Text += ")";
		}
		private void STEPEN_Click(object sender, EventArgs e)
		{
			equation.Text += "^";
		}
		private void DELEN_Click(object sender, EventArgs e)
		{
			equation.Text += "/";
		}
		private void UMNO_Click(object sender, EventArgs e)
		{
			equation.Text += "*";
		}
		private void PLUS_Click(object sender, EventArgs e)
		{
			equation.Text += "+";
		}
		private void NAZAD_Click(object sender, EventArgs e)
		{
			equation.Text = equation.Text.Remove(equation.Text.Length - 1); ;
		}
		private void KOREN_Click(object sender, EventArgs e)
		{
			equation.Text += ",";
		}
		private void NEGATIV_Click(object sender, EventArgs e)
		{
			equation.Text += "x";
		}
		private void Min_TextChanged(object sender, EventArgs e)
		{
			string less = Convert.ToString(min.Text);
			Console.WriteLine(less);
            if ((less != "") && char.IsDigit(less[less.Length-1]) || (chart.ChartAreas[0].AxisX.Minimum > Convert.ToInt32(less)))
            {
                chart.ChartAreas[0].AxisX.Minimum = Convert.ToInt32(min.Text);
                Console.WriteLine(chart.ChartAreas[0].AxisX.Minimum);
            }
        }

        private void Button_0_Click(object sender, EventArgs e)
        {
            equation.Text += "0";
        }
    }   
}
