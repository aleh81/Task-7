using System;
using NUnit.Framework;
using Task7.BLL.Services;

namespace Task7.BLL.Tests.Services
{
	[TestFixture]
	class MatrixTests
	{
		[Test]
		public void Constructor_m_n()
		{
			var matrix = new Matrix(3, 5, true);

			Assert.Multiple(() =>
			{
				Assert.AreEqual(5, matrix.N, "Argument n");
				Assert.AreEqual(3, matrix.M, "Argument m");

				Assert.Catch<ArgumentException>(Constructor_m_n_LessOrEqualThen_0,
					"Constructor exeption when arguments <= 0");
			});
		}

		public void Constructor_m_n_LessOrEqualThen_0()
		{
			var matrix = new Matrix(3, 0, true);
		}

		[Test]
		public void Constructor_arr()
		{
			Assert.Multiple(() =>
			{
				Assert.Catch<ArgumentException>(Constructor_arr_IsEqualNull,
					"Constructor exeption when argument == null");
			});
		}

		public void Constructor_arr_IsEqualNull()
		{
			var matrix = new Matrix(null);
		}

		[Test]
		public void OperatorMatrixSumDouble()
		{
			var matrix1 = new Matrix(3, 3, true);

			var valueArgument = 1;

			var matrixResult = matrix1 + valueArgument;

			for (var i = 0; i < matrixResult.M; i++)
			{
				for (var j = 0; j < matrixResult.N; j++)
				{
					Assert.AreEqual(matrixResult.MatrixInstance[i, j], matrix1.MatrixInstance[i, j] + valueArgument);
				}
			}
		}

		[Test]
		public void OperatorDoubleSumMatrix()
		{
			var matrix1 = new Matrix(3, 3, true);

			var valueArgument = 1;

			var matrixResult = valueArgument + matrix1;
			for (var i = 0; i < matrixResult.M; i++)
			{
				for (var j = 0; j < matrixResult.N; j++)
				{
					Assert.AreEqual(matrixResult.MatrixInstance[i, j], matrix1.MatrixInstance[i, j] + valueArgument);
				}
			}
		}
	}
}
