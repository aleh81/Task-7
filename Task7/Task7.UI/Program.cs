using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7.BLL.Services;
using Exception = System.Exception;

namespace Task7.UI
{
	class Program
	{
		static void Main(string[] args)
		{
			var matrix = new Matrix(3, 5);

			Console.WriteLine(matrix);

			double[,] arr1 = { { 1, 10 }, 
				{-11.02, 5.2} };

			var matrix2 = new Matrix(arr1);

			Console.WriteLine(matrix2);

			Console.ReadKey();
			try
			{

			}
			catch (Exception e)
			{
				
			}
		}
	}
}
