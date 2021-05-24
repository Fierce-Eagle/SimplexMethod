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
        public int ArtificialVariableCount { get; set; }
        private double[,] _table;
        private int[] _freeVariableArray;
        private double[] _targetFunctionArray;


        public void Init(double[,] array, int[] freeVariableArray)
        {
            _freeVariableArray = freeVariableArray;
            _table = new double[array.GetLength(0), array.GetLength(1) + 1];
            _targetFunctionArray = new double[array.GetLength(1)];

            int lastRow = array.GetLength(0) - 1;
            int artificialVariableStart = BasicVariableCount + FreeVariableCount + 1;
            // заполнение таблицы
            for (int i = 0; i < lastRow; i++)           
                for (int j = 0; j < array.GetLength(1); j++)               
                    _table[i, j] = array[i, j];
            // подмена функции цели
            for (int i = 0; i < array.GetLength(1); i++)
            {
                _targetFunctionArray[i] = array[lastRow, i];
                if (i >= artificialVariableStart)               
                    _table[lastRow, i] = 1;
                else
                    _table[lastRow, i] = 0;
            }
                                 
        }
        /// <summary>
        /// Найти позицию минимального числа
        /// </summary>  
        /// <returns></returns>
        private int FindMainCollumn()
        {
            //int startArtificialVariable = BasicVariableCount + FreeVariableCount;
            //for (int i = 0; i < FreeVariableCount; i++)
            //    if (_freeVariableArray[i] > startArtificialVariable) // в базисе присутствуют искусственные переменные
            //        return FindMainCollumnInGradeArray();
            //return FindMainCollumnInTargetFunction();
            int colsize = BasicVariableCount + FreeVariableCount;
            int minPosition = 1;
            for (int j = 2; j <= colsize; j++)
                if (_table[FreeVariableCount, j] < _table[FreeVariableCount, minPosition])
                    minPosition = j;

            return minPosition;
        }
        ///// <summary>
        ///// Поиск минимального числа в функции цели
        ///// </summary>
        ///// <returns></returns>
        //private int FindMainCollumnInTargetFunction()
        //{
        //    int colsize = BasicVariableCount + FreeVariableCount;
        //    int minPosition = 1;
        //    for (int j = 2; j <= colsize; j++)
        //        if (_table[FreeVariableCount, j] < _table[FreeVariableCount, minPosition])
        //            minPosition = j;

        //    return minPosition;
        //}
        ///// <summary>
        ///// Поиск минимального числа в оценочном массиве
        ///// </summary>
        ///// <returns></returns>
        //private int FindMainCollumnInGradeArray()
        //{
        //    int minPosition = 1;
        //    for (int i = 2; i < _gradeArray.Length; i++)
        //    {
        //        if (_gradeArray[i] < _gradeArray[minPosition])
        //            minPosition = i;
        //    }
        //    return minPosition;
        //}
        /// <summary>
        /// Найти позицию минимального числа в оценочных отношениях
        /// </summary>
        /// <returns></returns>
        private int FindMainRow()
        {
            int valueRelationCol = _table.GetLength(1) - 1; // столбец с оценочными отношениями         
            int minPosition = -1;
            double min = Double.MaxValue;
            for (int i = 0; i < FreeVariableCount; i++)
            {
                if (_table[i, valueRelationCol] < min && _table[i, valueRelationCol] > 0)
                {
                    min = _table[i, valueRelationCol];
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
                if (_table[FreeVariableCount, i] < 0)
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
            double devision = _table[row, col];
            int temp = _table.GetLength(1) - 1; // чтобы не трогать столбец с оценочными отношениями
            for (int i = 0; i < temp; i++)
            {
                _table[row, i] /= devision;
            }
        }

        private void SubOtherStr(int mainRow, int mainCol)
        {
            double routine;
            int valueRelationCol = _table.GetLength(1) - 1;
            for (int i = 0; i < _table.GetLength(0); i++)
            {
                if (i == mainRow)
                    continue;
                routine = _table[i, mainCol];
                for (int j = 0; j < valueRelationCol; j++)
                {
                    _table[i, j] -= _table[mainRow, j] * routine;
                }
            }
        }

        /// <summary>
        /// Заполнить столбец оценочных отношений
        /// </summary>
        /// <param name="mainCol"></param>
        private void FillValueRelationCollumn(int mainCol)
        {
            int valueRelationCol = _table.GetLength(1) - 1;           
            for (int i = 0; i < FreeVariableCount; i++)
            {
                if (_table[i, mainCol] <= 0 || _table[i, 0] < 0)
                    _table[i, valueRelationCol] = Int32.MaxValue;
                else
                    _table[i, valueRelationCol] = _table[i, 0] / _table[i, mainCol];
            }
        }

        /// <summary>
        /// Решение (понятно из названия)
        /// </summary>
        /// <returns></returns>
        public string Solution()
        {
            int valueRelationCol = _table.GetLength(1) - 1;


            int mainRow, mainCol;

            // заполнить массив оценок
            FillGradeArray();
            while (!IsSolution())
            {
                // найти лидирующий столбец
                mainCol = FindMainCollumn();
                FillValueRelationCollumn(mainCol);
                // найти лидирующую строку
                mainRow = FindMainRow();
                DivStrOnRoutine(mainRow, mainCol);
                SubOtherStr(mainRow, mainCol);
                //
                double routine = _targetFunctionArray[mainCol];
                for (int j = 0; j < valueRelationCol; j++)
                {
                    _targetFunctionArray[j] -= _table[mainRow, j] * routine;
                }
                _freeVariableArray[mainRow] = mainCol - 1;
            }
            // если остались ненулевые искусственные переменные
            if (!IsNull(_table[_table.GetLength(0) - 1, 0]))
                return "Решений нет!";



            for (int i = 1; i <= BasicVariableCount /*+ FreeVariableCount + 1*/; i++)
            {
                if (_targetFunctionArray[i] < 0)
                {
                    if (Find(_freeVariableArray, i - 1) == -1 && _table[_table.GetLength(0) - 1, i] > 0 && IsNull(_table[_table.GetLength(0) - 1, i])) // если элемента нет в массиве
                        _targetFunctionArray[i] = 0; // то он не базисный и его можно вычеркнуть
                   // ChangeGradeFunctionOnTargetFunction();
                   // return GetResult();
                }
            }



            ChangeGradeFunctionOnTargetFunction();

            while (!IsSolution())
            {
                mainCol = FindMainCollumn();
                FillValueRelationCollumn(mainCol);
                mainRow = FindMainRow();
                DivStrOnRoutine(mainRow, mainCol);
                SubOtherStr(mainRow, mainCol);
                _freeVariableArray[mainRow] = mainCol - 1; 
            }
            return GetResult();
        }

        private bool IsNull(double item)
        {
            if (item < 0.00001 || item > -0.00001)
                return true;
            return false;
        }

        private void ChangeGradeFunctionOnTargetFunction()
        {
            int length = _table.GetLength(1) - 1;
            int lastRow = _table.GetLength(0) - 1;
            /*
             * int routine = 0;
             * for (int j = 0; j < length; j++)
            {
                for (int i = 0; i < FreeVariableCount; i++)
                {
                    if (_freeVariableArray[i] < BasicVariableCount)
                        _targetFunctionArray[j] -= _table[i, j] * ; // проходить нужно по всей строке олух и домножить не забудь!
                }
            }*/


         

            // подмена
            for (int i = 0; i < length; i++)           
                _table[lastRow, i] = _targetFunctionArray[i];            
        }

        /// <summary>
        /// Заполняет массив оценок
        /// </summary>
        private void FillGradeArray()
        {
            int length = _table.GetLength(1) - 1;
            int startArtificialVariable = BasicVariableCount + FreeVariableCount;
            int lastRow = _table.GetLength(0) - 1;
            for (int j = 0; j < length; j++)
            {               
                for (int i = 0; i < FreeVariableCount; i++)
                {
                    if (_freeVariableArray[i] > startArtificialVariable)
                        _table[lastRow, j] -= _table[i, j];
                }
            }
        }

        private int Find(int[] array, int index)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == index)
                {
                    return i;
                }
            }
            return -1;
        }
        private string GetResult()
        {
            string result = "";
            int temp;
            for (int i = 0; i < BasicVariableCount; i++)
            {
                temp = Find(_freeVariableArray, i);
                if (temp == -1)
                    result += "X" + (i + 1) + " = 0\t";
                else
                    result += "X" + (i + 1) + " = " + _table[temp, 0] + "\t";
            }
           // for (int i = 0; i < FreeVariableCount; i++)
            //{
            //    if (_freeVariableArray[i] < BasicVariableCount)
            //        result += "X" + (_freeVariableArray[i] + 1) + " = " + _table[i, 0] + "\t";
            //}
            result += "F = " + _table[FreeVariableCount, 0];
            return result;
        }
    }
}
