using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project
{
    /// <summary>
    /// Круговой массив.
    /// </summary>
    public class Task1
    {
        /// <summary>
        /// Размерность.
        /// </summary>
        private int n = -1;
        /// <summary>
        /// Длина обхода.
        /// </summary>
        private int m = -1;
        /// <summary>
        /// Основной массив.
        /// </summary>
        private int[] massiv;
        /// <summary>
        /// Путь.
        /// </summary>
        private string path = "";
        /// <summary>
        /// Список для хранения интервалов.
        /// </summary>
        List<int[]> Intervals = new List<int[]>();

        /// <summary>
        /// Основная работа.
        /// </summary>
        public void Work()
        {
            ClearElements();
            ReadValueN();
            ReadValueM();
            CreateMassive();
            BypassMassiv();
        }

        /// <summary>
        /// Очистка.
        /// </summary>
        private void ClearElements()
        {
            n = -1;
            m = -1;
            massiv = null;
            path = "";
            Intervals.Clear();
        }

        /// <summary>
        /// Чтение значение N.
        /// </summary>
        private void ReadValueN()
        {
            Console.WriteLine("Введите размерность массива,n = ");
            int.TryParse(Console.ReadLine(), out n);
            if(!CheckValues(n))
            {
                Console.WriteLine("Значение должно быть > 0");
                ReadValueN();
            }           
        }

        /// <summary>
        /// Чтение значения M.
        /// </summary>
        private void ReadValueM()
        {
            Console.WriteLine("Введите длину обхода массива,m = ");
            int.TryParse(Console.ReadLine(), out m);
            if (!CheckValues(m))
            {
                Console.WriteLine("Значение должно быть > 0");
                ReadValueM();
            }
        }

        /// <summary>
        /// Проверка введенных значений.
        /// </summary>
        /// <param name="_input">Проверяемое значение.</param>
        /// <returns></returns>
        private bool CheckValues(int _input)
        {
            if(_input>0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Создание массива.
        /// </summary>
        private void CreateMassive()
        {
            massiv = new int[n];
            for(int i=0; i< massiv.Length; i++)
            {
                massiv[i] = i + 1;
            }
        }

        /// <summary>
        /// Обход массива.
        /// </summary>
        private void BypassMassiv()
        {
            if (Intervals.Count == 0)
            {
                int[] mas = new int[m];
                Array.Copy(massiv, 0, mas, 0, m);
                Intervals.Add(mas);
                if (mas[mas.Length-1] == massiv[0])
                {
                    path = mas[0].ToString();
                    Console.WriteLine(path);
                }
            }
            int[] mass = new int[massiv.Length - Array.IndexOf(massiv, Intervals[Intervals.Count - 1][m - 1])];
            Array.Copy(massiv, Array.IndexOf(massiv, Intervals[Intervals.Count - 1][m - 1]), mass, 0, massiv.Length - Array.IndexOf(massiv, Intervals[Intervals.Count - 1][m - 1]));
            if(mass.Length < m)
            {
                Array.Resize(ref mass, m);
                Array.Copy(massiv,0,mass, massiv.Length - Array.IndexOf(massiv, Intervals[Intervals.Count - 1][m - 1]), m - (massiv.Length - Array.IndexOf(massiv, Intervals[Intervals.Count - 1][m - 1])));
            }

            Intervals.Add(mass);
            if (mass[mass.Length - 1] == massiv[0])
            {
                foreach(var val in Intervals)
                {
                    path += val[0].ToString();
                }
                Console.WriteLine(path);
                Console.WriteLine();
            }
            else
            {
                BypassMassiv();
            }
        }
    }
}
