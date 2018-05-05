using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7.BLL.Services
{
	public class Matrix
	{
		public double[,] MatrixInstance { get; private set; }

		public int M => MatrixInstance.GetLength(0); 
		public int N => MatrixInstance.GetLength(1);

		public Matrix(double[,] arr)
		{
			MatrixInstance = arr ?? throw new ArgumentException
			("Argguments can not be == null");
		}

		public Matrix(int m, int n)
		{
			if (m <= 0 || n <= 0)
			{
				throw new ArgumentException
					("Argguments can not be <= 0");
			}

			InitMatrix(m, n);
		}


		private void InitMatrix(int m, int n)
		{
			if (m <= 0 && n <= 0)
			{
				throw new Exception();
			}

			MatrixInstance = new double[m, n];

			var rnd = new Random();
			var max = m * n;
			var min = -m * n;

            for(var i = 0 ; i < m; i++)
			{
				for (var j = 0; j < n; j++)
				{
					MatrixInstance[i, j] = rnd.NextDouble() *
					                       (max - min) + min;
				}
			}
		}

		public override string ToString()
		{
			var sb = new StringBuilder();

			for (var i = 0; i < M; i++)
			{
				
				for (var j = 0; j < N; j++)
				{
					sb.Append($"{MatrixInstance[i, j],-15:f2}");
				}

				sb.AppendLine();
			}

			return sb.ToString();
		}
	}
}
