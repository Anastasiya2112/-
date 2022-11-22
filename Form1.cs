using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Свой_тип
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // считали значения с полей для ввода и сконвертили в числа
                var firstValue = double.Parse(txtFirst.Text);
                var secondValue = double.Parse(txtSecond.Text);

                // на основании значений создали экземпляры нашего класса Length 
                var firstLength = new Length(firstValue, MeasureType.C);
                var secondLength = new Length(secondValue, MeasureType.C);

                // сложили две длины
                var sumLength = firstLength + secondLength;

                // записали в поле txtResult длину в строковом виде
                txtResult.Text = sumLength.Verbose();
            }
            catch (FormatException)
            {
                // если тип преобразовать не смогли
            }
        }
    }
}
