using System;

namespace DIMASIK
{
    class Program
    {
        static void Main(string[] args)
        {
			//входной массив для сортировки
			int[] data = { 7, 2, 5, 3 };
			string str = "";
			for (int i = 0; i < data.Length; i++)
            {
				str += data[i].ToString() + ' ';
            }
			Console.WriteLine("Input array: " + str + "\n------");
			BeadSort(ref data);
		}

		//ф-ия для вывода матрицы в консоль
		public static void print_matrix(byte[,] matrix, int n, int m)
        {
			for (int i = 0; i < n; i++)
			{
				string str = "";
				for (int j = 0; j < m; j++)
				{
					str += matrix[i, j] + " ";
				}
				Console.WriteLine(str + "\n");
			}
		}


		/* ф-ия одной итерации сортировки
		 * если в столбце матрицы присутствуют нули под единицами
		 * то они меняются местами
		*/
		public static void sort_iteration(byte[,] matrix, int n, int m)
        {
			byte buffer = 0;
			for (int j = 0; j < m; j++)
			{
				for (int i = n - 1; i > 0; i--)
				{
					if (matrix[i, j] < matrix[i - 1, j])
					{
						buffer = matrix[i, j];
						matrix[i, j] = matrix[i - 1, j];
						matrix[i - 1, j] = buffer;
					}
				}
			}
		}
		public static void BeadSort(ref int[] data)
		{
			int max = data[0];

			//поиск максимума в массиве
			for (int i=0; i < data.Length; i++)
            {
				if (data[i] > max)
                {
					max = data[i];
                }
            }

			//создание матрицы
			byte[,] matrix = new byte[data.Length,max];
			
			//заполнение матрицы 
			for (int i = 0; i < data.Length; i++)
            {
				for (int j = 0; j < max; j++)
                {
					if (data[i] > j)
                    {
						matrix[i, j] = 1;
                    }
                }
			}

			print_matrix(matrix, data.Length, max);
			Console.WriteLine("----");
			
			/*проверка существуют ли в матрице нули под единицами
			 * и если да, то запуск ф-ии одной итерации сортировки
			 */

			for (int i=0; i < data.Length - 1; i++)
            {
				for (int j = 0; j < max; j++)
                {
					if (matrix[i,j] > matrix[i+1, j])
                    {
						sort_iteration(matrix, data.Length, max);
					}
                }
			}
			
			print_matrix(matrix, data.Length, max);

			//зануление исходного массива
			for (int i = 0; i < data.Length; i++)
            {
				data[i] = 0;
            }


			/* заполение массива суммированием строк матрицы
			 * в прямом порядке
			 */
			for (int i = 0; i < data.Length; i++)
			{
				for (int j = 0; j < max; j++)
				{
					data[i] += matrix[i, j];
				}
			}

			//вывод массива отсортированного
			string str = "";
			for (int i = 0; i < data.Length; i++)
			{
				str += data[i].ToString() + ' ';
			}

			Console.WriteLine("Sorted array: " + str);
		}
	}
}