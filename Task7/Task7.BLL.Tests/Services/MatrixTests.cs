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
			var matrix = new Matrix(3, 5);

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
			var matrix = new Matrix(3, 0);
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
	}
}
