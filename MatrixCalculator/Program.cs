using System;

namespace MatrixCalculator
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("=============Welcome to the Matrix Calculator=============");
			Console.WriteLine();
			Console.WriteLine("OK, let's see what you can do");

			bool cont = true;
			while(cont)
			{
				Console.WriteLine("[1] Multiplication by a scalar");
				Console.WriteLine("[2] Trace");
				Console.WriteLine("[3] Transpose");
				Console.WriteLine("[4] Determinant");
				Console.Write("Write the number which calculation do you want: ");
				string ans = Console.ReadLine().Trim();
				Console.WriteLine();

				switch (ans)
				{
					case "1":
						Console.Write("What do you want to muliply by: ");
						float scalar = float.Parse(Console.ReadLine().Trim());
						MatrixMultiplicationByScalar(GetUserMatrix(), scalar);
						break;
					case "2":
						Console.WriteLine("Trace of your matrix is: {0}", MatrixTrace(GetUserMatrix()));
						break;
					case "3":
						MatrixTranspose(GetUserMatrix());
						break;
					case "4":
						Console.WriteLine("Determinant of your matrix is: {0}", MatrixDeterminant(GetUserMatrix()));
						break;
				}

				Console.Write("Do you want to try again? (y/n)");
				string contAns = Console.ReadLine().Trim();
				if (contAns == "y")
					cont = true;
				else
					break;
			}

			Console.ReadLine();
		}

		public static float[,] MatrixMultiplicationByScalar(float[,] matrix, float scalar)
		{
			float[,] tempMatrix = matrix;

			for (int i = 0; i < tempMatrix.GetLength(0); i++)
			{
				for (int j = 0; j < tempMatrix.GetLength(1); j++)
				{
					Console.Write(tempMatrix[i, j] * scalar + " ");
				}
				Console.WriteLine();
			}
			return tempMatrix;
		}

		public static float[,] MatrixTranspose(float[,] matrix)
		{
			float[,] tempMatrix = matrix;

			for (int i = 0; i < tempMatrix.GetLength(0); i++)
			{
				for (int j = 0; j < tempMatrix.GetLength(1); j++)
				{
					Console.Write(tempMatrix[j, i] + " ");
				}
				Console.WriteLine();
			}
			return tempMatrix;
		}

		public static float MatrixTrace(float[,] matrix)
		{
			float traceSum = 0;

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					if (i == j)
					{
						traceSum += matrix[i, j];
					}
				}
			}
			return traceSum;
		}

		public static float MatrixDeterminant(float[,] matrix)
		{
			if (matrix.GetLength(0) <= 2) 
				return MatrixSubDeterminant(matrix, 0, 0);

			float determinant = 0;

			for (int i = 0; i < matrix.GetLength(1); i++)
			{
				determinant += MatrixSubDeterminant(matrix, 0, i) * (float)Math.Pow(-1, i);
			}
			return determinant;
		}

		public static float MatrixSubDeterminant(float[,] matrix, int x, int y)
		{
			if (matrix.GetLength(0) == 2)
			{
				return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
			}

			return matrix[x, y] * MatrixDeterminant(GetSubArr(matrix, x, y));
		}

		public static float[,] GetSubArr(float[,] arr, int x, int y)
		{
			if (arr.GetLength(0) <= 1)
				return arr;

			float[,] temp = new float[arr.GetLength(0) - 1, arr.GetLength(1) - 1];

			for (int i = 0; i < arr.GetLength(0); i++)
			{
				if (i == x)
					continue;

				for (int j = 0; j < arr.GetLength(1); j++)
				{
					if (j == y)
						continue;

					temp[i < x ? i : i - 1, j < y ? j : j - 1] = arr[i, j];
				}
			}

			return temp;
		}

		public static float[,] GetUserMatrix()
		{
			Console.Write("What size is your matrix: ");
			int size = Convert.ToInt32(Console.ReadLine().Trim());
			if (size <= 1)
			{
				Console.WriteLine("You entered wrong number.");
				Environment.Exit(0);
			}
			float[,] userMatrix = new float[size, size];
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					Console.Write("Please enter your value at [{0},{1}]: ", i + 1, j + 1);
					userMatrix[i, j] = float.Parse(Console.ReadLine().Trim());
				}
			}
			Console.WriteLine("====================================");
			Console.WriteLine("Here is your matrix");
			Console.WriteLine();

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					Console.Write(userMatrix[i, j] + " ");
				}
				Console.WriteLine();
			}
			Console.WriteLine("====================================");
			return userMatrix;
		}

		//Will be done later
		public static void MatrixInverse(float[,] matrix)
		{
			if (MatrixDeterminant(matrix) != 0)
			{

			}
			else
				Console.WriteLine("This matrix in invertible because determinant is equals to zero.");
		}


	}
}
