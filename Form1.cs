using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Form_ISO_Lr6
{
    public partial class Form1 : Form
    {
        SimplexMethod simplexMethod;
        public Form1()
        {
            InitializeComponent();           
        }
        /// <summary>
        /// Добавить выражение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreeVariablesButton_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Add();
            simplexMethod.FreeVariableCount++;
        }
        /// <summary>
        /// Добавить переменную
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddVariableButton_Click(object sender, EventArgs e)
        {
            int item = simplexMethod.BasicVariableCount + 1;
            dataGridView.Columns.Add("X" + item, "X" + item);
            dataGridView.Columns[item + 1].Width = 50;
            dataGridView1.Columns.Add("X" + item, "X" + item);
            dataGridView1.Columns[item + 1].Width = 50;
            simplexMethod.BasicVariableCount++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView.Rows.Add();
            dataGridView1.Rows.Add();
            simplexMethod = new SimplexMethod();
            simplexMethod.FreeVariableCount++;
        }
        /// <summary>
        /// Решение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SolutionButton_Click(object sender, EventArgs e)
        {
            double[,] array = new double[simplexMethod.FreeVariableCount + 1, simplexMethod.FreeVariableCount + simplexMethod.BasicVariableCount + 1];
            // заполнение базисными переменными
            FillArrayBasicVariable(array);
            // заполнение функции цели
            FillArrayTargetFunction(array);
            // заполнение столбцов со свободными переменными
            FillArrayCollumnsWithFreeVariables(array);
         
            simplexMethod.Init(array);
            textBox.Text = simplexMethod.Solution();
        }
        /// <summary>
        /// Заполнение базисными переменными
        /// </summary>
        /// <param name="array"></param>
        private void FillArrayBasicVariable(double[,] array)
        {
            for (int i = 0; i < simplexMethod.FreeVariableCount; i++)
            {
                for (int j = 1; j <= simplexMethod.BasicVariableCount; j++)
                {
                    array[i, j] = Convert.ToDouble(dataGridView[j + 1, i].Value);
                }
                array[i, 0] = Convert.ToDouble(dataGridView[0, i].Value); // заполнение столбца свободных членов
            }
        }
        /// <summary>
        /// Заполнение функции цели
        /// </summary>
        /// <param name="array"></param>
        private void FillArrayTargetFunction(double[,] array)
        {
            for (int j = 0; j <= simplexMethod.BasicVariableCount; j++)
            {
                array[simplexMethod.FreeVariableCount, j] = Convert.ToDouble(dataGridView1[j + 1, 0].Value) * -1;
            }
        }
        /// <summary>
        /// Заполнение столбцов со свободными переменными
        /// </summary>
        /// <param name="array"></param>
        private void FillArrayCollumnsWithFreeVariables(double[,] array)
        {
            for (int i = 0; i < simplexMethod.FreeVariableCount; i++)
                for (int j = 0; j < simplexMethod.FreeVariableCount; j++)
                    if (i == j)
                        array[i, j + simplexMethod.BasicVariableCount + 1] = 1;
        }

        /// <summary>
        /// Удалить переменную
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveVariableButton_Click(object sender, EventArgs e)
        {
            int item = simplexMethod.BasicVariableCount;
            if (item == 0)
                return;
            dataGridView.Columns.RemoveAt(item + 1);
            dataGridView1.Columns.RemoveAt(item + 1);

            simplexMethod.BasicVariableCount--;
        }

        private void RemoveFreeVariableButton_Click(object sender, EventArgs e)
        {
            if (simplexMethod.FreeVariableCount == 1)
                return;
            dataGridView.Rows.RemoveAt(simplexMethod.FreeVariableCount - 1);
            simplexMethod.FreeVariableCount--;
        }
    }
}
