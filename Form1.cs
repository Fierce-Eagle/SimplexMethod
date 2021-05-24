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
        SimplexMethod _simplexMethod;
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
            _simplexMethod.FreeVariableCount++;
            dataGridView[1, _simplexMethod.FreeVariableCount - 1].Value = "=>";
        }
        /// <summary>
        /// Добавить переменную
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddVariableButton_Click(object sender, EventArgs e)
        {
            int item = _simplexMethod.BasicVariableCount + 1;
            dataGridView.Columns.Add("X" + item, "X" + item);
            dataGridView.Columns[item + 1].Width = 50;
            dataGridView1.Columns.Add("X" + item, "X" + item);
            dataGridView1.Columns[item + 1].Width = 50;
            _simplexMethod.BasicVariableCount++;
        }
        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView.Rows.Add();
            dataGridView1.Rows.Add();
            _simplexMethod = new SimplexMethod();
            _simplexMethod.FreeVariableCount++;
            dataGridView1[0, 0].Value = "Max";
            dataGridView[1, _simplexMethod.FreeVariableCount - 1].Value = "=>";
        }
        /// <summary>
        /// Удалить переменную
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveVariableButton_Click(object sender, EventArgs e)
        {
            int item = _simplexMethod.BasicVariableCount;
            if (item == 0)
                return;
            dataGridView.Columns.RemoveAt(item + 1);
            dataGridView1.Columns.RemoveAt(item + 1);

            _simplexMethod.BasicVariableCount--;
        }

        private void RemoveFreeVariableButton_Click(object sender, EventArgs e)
        {
            if (_simplexMethod.FreeVariableCount == 1)
                return;
            dataGridView.Rows.RemoveAt(_simplexMethod.FreeVariableCount - 1);
            _simplexMethod.FreeVariableCount--;
        }
        /// <summary>
        /// Решение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SolutionButton_Click(object sender, EventArgs e)
        {
            // избавиться от отрицательных элементов в столбце свободных членов
            CorrectStartTable();
            _simplexMethod.ArtificialVariableCount = GetArtificialVariableCount();
            double[,] array = new double[_simplexMethod.FreeVariableCount + 1, _simplexMethod.FreeVariableCount + _simplexMethod.BasicVariableCount + _simplexMethod.ArtificialVariableCount + 1];
            // заполнение базисными переменными
            FillArrayBasicVariable(array);
            // заполнение функции цели
            FillArrayTargetFunction(array);
            // заполнение столбцов со свободными переменными
            FillArrayCollumnsWithFreeVariables(array, GetSignArray());
            // заполнение столбцов с искусственными переменными
            FillArrayCollumnsWithArtificialVariables(array, GetFreeVariableCollumn());

            _simplexMethod.Init(array, GetFreeVariableCollumn());
            textBox.Text = _simplexMethod.Solution();
        }
        /// <summary>
        /// Возвращает столбец свободных переменных для инициализации
        /// </summary>
        /// <returns></returns>
        private int[] GetFreeVariableCollumn()
        {
            int[] array = new int[_simplexMethod.FreeVariableCount];
            for (int i = 0, k = 1; i < _simplexMethod.FreeVariableCount; i++)
            { 
                if (dataGridView[1, i].Value.ToString() != "=>")
                {
                    array[i] = _simplexMethod.BasicVariableCount + _simplexMethod.FreeVariableCount + k;
                    k++;
                }
                else
                    array[i] = _simplexMethod.BasicVariableCount + i;
            }
            return array;
        }

        /// <summary>
        /// Массив знаков (1 - =>, -1 - <=, 0 - =)
        /// </summary>
        /// <returns></returns>
        private int[] GetSignArray()
        {
            int[] array = new int[_simplexMethod.FreeVariableCount];
            for (int i = 0; i < array.Length; i++)
            {
                if (dataGridView[1, i].Value.ToString() == "=>")               
                    array[i] = 1;               
                else if (dataGridView[1, i].Value.ToString() == "<=")               
                    array[i] = -1;               
            }
            return array;
        }

        /// <summary>
        /// Заполнение базисными переменными
        /// </summary>
        /// <param name="array"></param>
        private void FillArrayBasicVariable(double[,] array)
        {
            for (int i = 0; i < _simplexMethod.FreeVariableCount; i++)
            {
                for (int j = 1; j <= _simplexMethod.BasicVariableCount; j++)
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
            int value = 1;
            if (dataGridView1[0,0].Value.ToString() == "Max")
                value = -1;
            for (int j = 1; j <= _simplexMethod.BasicVariableCount; j++)
            {
                array[_simplexMethod.FreeVariableCount, j] = Convert.ToDouble(dataGridView1[j + 1, 0].Value) * value;
            }
            array[_simplexMethod.FreeVariableCount, 0] = Convert.ToDouble(dataGridView1[1, 0].Value);
        }
        /// <summary>
        /// Заполнение столбцов со свободными переменными
        /// </summary>
        /// <param name="array"></param>
        private void FillArrayCollumnsWithFreeVariables(double[,] array, int[] signArray)
        {
            for (int i = 0; i < _simplexMethod.FreeVariableCount; i++)
                for (int j = 0; j < _simplexMethod.FreeVariableCount; j++)
                    if (i == j)
                        array[i, j + _simplexMethod.BasicVariableCount + 1] = signArray[i];
        }
        /// <summary>
        /// Заполнение массива искусственными переменными
        /// </summary>
        /// <param name="array"></param>
        /// <param name="freeVariableCollumn"></param>
        private void FillArrayCollumnsWithArtificialVariables(double[,] array, int[] freeVariableCollumn)
        {
            int temp = _simplexMethod.FreeVariableCount + _simplexMethod.BasicVariableCount;
            for (int i = 0; i < _simplexMethod.FreeVariableCount; i++)
                    if (freeVariableCollumn[i] > temp)
                        array[i, freeVariableCollumn[i]] = 1;          
        }
        /// <summary>
        /// Корректировка таблицы при необходимости
        /// </summary>
        private void CorrectStartTable()
        {
            double temp;
            for (int i = 0; i < _simplexMethod.FreeVariableCount; i++)
            {
                if (Convert.ToDouble(dataGridView[0, i].Value.ToString()) < 0)
                {
                    for (int j = 0; j < _simplexMethod.BasicVariableCount; j++)
                    {
                        temp = Convert.ToDouble(dataGridView[j + 2, i].Value.ToString());
                        temp *= -1;
                        dataGridView[j + 2, i].Value = temp;
                    }
                    if (dataGridView[1, i].Value.ToString() == "<=")                   
                        dataGridView[1, i].Value = "=>";                    
                    else if (dataGridView[1, i].Value.ToString() == "=>")
                        dataGridView[1, i].Value = "<=";
                }
            }
        }
        /// <summary>
        /// Возвращает количество искусственных переменных
        /// </summary>
        /// <returns></returns>
        private int GetArtificialVariableCount()
        {
            int count = 0;
            for (int i = 0; i < _simplexMethod.FreeVariableCount; i++)           
                if (dataGridView[1, i].Value.ToString() != "=>")               
                    count++;
            return count;
        }
    }
}
