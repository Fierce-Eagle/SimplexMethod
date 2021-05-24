using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form_ISO_Lr6
{
    class SimplexMethod
    {
        public int FreeVariableCount { get; set; }
        public int BasicVariableCount { get; set; }
        private double[,] table;
        private int[] freeVariableArray;


        public void Init(double[,] array)
        {
            freeVariableArray = new int[FreeVariableCount];
            table = new double[array.GetLength(0), array.GetLength(1) + 1];

            for (int i = 0; i < array.GetLength(0); i++)           
                for (int j = 0; j < array.GetLength(1); j++)               
                    table[i, j] = array[i, j];  
            
            for (int i = 0; i < FreeVariableCount; i++)          
                freeVariableArray[i] = BasicVariableCount + i;           
        }
        /// <summary>
        /// Найти позицию минимального числа в функции цели
        /// </summary>  
        /// <returns></returns>
        private int FindMainCollumn()
        {           
            int colsize = BasicVariableCount + FreeVariableCount;
            int minPosition = 1;
            for (int j = 2; j <= colsize; j++)           
                if (table[FreeVariableCount, j] < table[FreeVariableCount, minPosition])               
                    minPosition = j; 
            
            return minPosition;
        }
        ///// <summary>
        ///// Найти позицию минимального числа в оценочных отношениях
        ///// </summary>
        ///// <returns></returns>
        private int FindMainRow()
        {
            int valueRelationCol = table.GetLength(1) - 1; // столбец с оценочными отношениями         
            int minPosition = -1;
            double min = Double.MaxValue;
            for (int i = 0; i < FreeVariableCount; i++)
            {
                if (table[i, valueRelationCol] < min && table[i, valueRelationCol] > 0)
                {
                    min = table[i, valueRelationCol];
                    minPosition = i;
                }
            }
            return minPosition;
        }
        /// <summary>
        /// Оптимальное решение
        /// </summary>
        /// <returns></returns>
        private bool IsSolution()
        {
            int colSize = BasicVariableCount + FreeVariableCount + 1;
            for (int i = 0; i < colSize; i++)
            {
                if (table[FreeVariableCount, i] < 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Разделить строку на коэффициент
        /// </summary>
        /// <param name="row">строка</param>
        /// <param name="col">столбец с нужным коэффициентом</param>
        private void DivStrOnRoutine(int row, int col)
        {
            double devision = table[row, col];
            int temp = table.GetLength(1) - 1; // чтобы не трогать столбец с оценочными отношениями
            for (int i = 0; i < temp; i++)
            {
                table[row, i] /= devision;
            }
        }

        private void SubOtherStr(int mainRow, int mainCol)
        {
            double routine;
            int valueRelationCol = table.GetLength(1) - 1;
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (i == mainRow)
                    continue;
                routine = table[i, mainCol];
                for (int j = 0; j < valueRelationCol; j++)
                {
                    table[i, j] -= table[mainRow, j] * routine;
                }
            }
        }

        /// <summary>
        /// Заполнить столбец оценочных отношений
        /// </summary>
        /// <param name="mainCol"></param>
        private void FillValueRelationCollumn(int mainCol)
        {
            int valueRelationCol = table.GetLength(1) - 1;           
            for (int i = 0; i < FreeVariableCount; i++)
            {
                if (table[i, mainCol] <= 0 || table[i, 0] < 0)
                    table[i, valueRelationCol] = Int32.MaxValue;
                else
                    table[i, valueRelationCol] = table[i, 0] / table[i, mainCol];
            }
        }

        /// <summary>
        /// Решение (понятно из названия)
        /// </summary>
        /// <returns></returns>
        public string Solution()
        {
            int mainRow, mainCol;
            while (!IsSolution())
            {
                mainCol = FindMainCollumn();
                FillValueRelationCollumn(mainCol);
                mainRow = FindMainRow();
                DivStrOnRoutine(mainRow, mainCol);
                SubOtherStr(mainRow, mainCol);
                freeVariableArray[mainRow] = mainCol - 1; 
            }
            return GetResult();
        }

        private string GetResult()
        {
            string result = "";
            for (int i = 0; i < FreeVariableCount; i++)
            {
                if (freeVariableArray[i] < BasicVariableCount)
                    result += "X" + (freeVariableArray[i] + 1) + " = " + table[i, 0] + "\t";
            }
            result += "F = " + table[FreeVariableCount, 0];
            return result;
        }
    }
}
