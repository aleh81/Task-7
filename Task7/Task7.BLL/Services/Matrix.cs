using System;
using System.Text;

namespace Task7.BLL.Services
{
	public class Matrix 
	{
		public double[,] MatrixInstance { get; private set; }

		public int M => MatrixInstance.GetLength(0); 
		public int N => MatrixInstance.GetLength(1);

		private static readonly Func<double, double, double> Sum
			= (a, b) => a + b;
		private static readonly Func<double, double, double> Sub
			= (a, b) => a - b;
		private static readonly Func<double, double, double> Mult
			= (a, b) => a * b;

		public Matrix(double[,] arr)
		{
			MatrixInstance = arr ?? throw new ArgumentException
			("Arggument cannot be null", $"arr");
		}

		public Matrix(int m, int n, bool initMatrixRandom)
		{
			switch (initMatrixRandom)
			{
				case false:
					MatrixInstance = new double[m, n];
					break;
				case true:
					InitMatrix(m, n);
					break;
			}
		}


		private void InitMatrix(int m, int n)
		{
			if (m <= 0 || n <= 0)
			{
				throw new ArgumentException
					("Argguments can not be <= 0", $"m or n");
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

		public static Matrix operator +(Matrix matrix, double num) =>
			Operate(matrix, num, Sum);

		public static Matrix operator +(double num, Matrix matrix) =>
			Operate(matrix, num, Sum);

		public static Matrix operator +(Matrix matrixA, Matrix matrixB) =>
			Operate(matrixA, matrixB, Sum);

		public static Matrix operator -(Matrix matrix, double num) =>
			Operate(matrix, num, Sub);

		public static Matrix operator -(double num, Matrix matrix) =>
			Operate(matrix, num, Sub);

		public static Matrix operator -(Matrix matrixA, Matrix matrixB) =>
			Operate(matrixA, matrixB, Sub);

		public static Matrix operator *(Matrix matrix, double num) =>
			Operate(matrix, num, Mult);

		public static Matrix operator *(double num, Matrix matrix) =>
			Operate(matrix, num, Mult);

		public static Matrix operator *(Matrix matrixA, Matrix matrixB) =>
			Operate(matrixA, matrixB, Mult);

		private static void CorrectnessArgumentsOperate(Matrix matrix, double num)
		{
			if (matrix == null)
			{
				throw new NullReferenceException
					("Object Matrix in Method Operate(Matrix, Double) is null");
			}

			if (num <= 0)
			{
				throw new ArgumentException
					("Argument num in Operate method cannot be <= 0");
			}
		}

		private static void CorrectnessArgumentsOperate(Matrix matrixA, Matrix matrixB)
		{
			if (matrixA == null || matrixB == null)
			{
				throw new NullReferenceException
					("Object Matrix in Method Operate(Matrix, MAtrix) is null");
			}
			if (!MatrixEqualitySize(matrixA, matrixB))
			{
				throw new ArgumentException("matrixA != matrixB");
			}
		}

		private static Matrix Cycle(Matrix matrix, double num,
			Func<double, double, double> retFunc)
		{

			var res = new Matrix(matrix.M, matrix.N, false);

			for (var i = 0; i < matrix.M; i++)
			{
				for (var j = 0; j < matrix.N; j++)
				{
					res.MatrixInstance[i, j] =
						retFunc(matrix.MatrixInstance[i, j], num);
				}
			}

			return res;
		}

		private static Matrix Cycle(Matrix matrixA, Matrix matrixB,
			Func<double, double, double> retFunc)
		{
			var m = matrixA.M;
			var n = matrixA.N;

			var res = new Matrix(m, n, false);

			for (var i = 0; i < m; i++)
			{
				for (var j = 0; j < n; j++)
				{
					res.MatrixInstance[i, j] =
						retFunc(matrixA.MatrixInstance[i, j],
							matrixB.MatrixInstance[i, j]);
				}
			}

			return res;
		}

		private static Matrix Operate(Matrix matrix, double num,
			Func<double, double, double> retFunc)
		{
			CorrectnessArgumentsOperate(matrix, num);

			return Cycle(matrix, num, retFunc);
		}

		private static Matrix Operate(Matrix matrixA, Matrix matrixB,
			Func<double, double, double> retFunc)
		{
			CorrectnessArgumentsOperate(matrixA, matrixB);

			return Cycle(matrixA, matrixB, retFunc);
		}

		private static bool MatrixEqualitySize(Matrix a, Matrix b) =>
			a.M == b.M && a.N == b.N;

		public static bool MatrixEqualityElements(Matrix a, Matrix b)
		{
			if (!MatrixEqualitySize(a, b))
			{
				throw new Exception();
			}

			for (var i = 0; i < a.M; i++)
			{
				for (var j = 0; j < a.N; j++)
				{
					if (a.MatrixInstance[i, j] !=
					    b.MatrixInstance[i, j])
					{
						return false;
					}
				}
			}

			return true;
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
