using Microsoft.SqlServer.Server;
using System;

namespace MatrixCalculator
{
	class Program
	{
		
		public bool write = true;
		public bool dontWrite = false;
		public static int size = 0;

		static void Main(string[] args)
		{
			Program pr = new Program();

			Console.WriteLine("=============Welcome to the Matrix Calculator=============");
			Console.WriteLine();
			Console.WriteLine("OK, let's see what you can calculate");

			bool cont = true;
			while(cont) // To continue if we want
			{
				Console.WriteLine("[1] Multiplication by a matrix");
				Console.WriteLine("[2] Multiplication by a scalar");
				Console.WriteLine("[3] Determinant");
				Console.WriteLine("[4] Transpose");
				Console.WriteLine("[5] Adjoint");
				Console.WriteLine("[6] Inverse");
				Console.WriteLine("[7] Trace");
				Console.WriteLine();
				Console.Write("Write the number which calculation do you want: ");
				string ans = Console.ReadLine().Trim();
				Console.WriteLine();

				switch (ans)
				{
					case "1":
						MatrixMultiplication(GetUserMatrix(), GetUserMatrix2(), pr.write);
						break;
					case "2":
						Console.Write("What do you want to muliply by: ");
						float scalar = float.Parse(Console.ReadLine().Trim());
						MatrixMultiplicationByScalar(GetUserMatrix(), scalar, pr.write);
						break;
					case "3":
						Console.WriteLine("Determinant of your matrix is: {0}", MatrixDeterminant(GetUserMatrix()));
						break;
					case "4":
						MatrixTranspose(GetUserMatrix(), pr.write);
						break;
					case "5":
						MatrixAdjoint(GetUserMatrix(), pr.write);
						break;
					case "6":
						MatrixInverse(GetUserMatrix(), pr.write);
						break;
					case "7":
						Console.WriteLine("Trace of your matrix is: {0}", MatrixTrace(GetUserMatrix()));
						break;
				}

				Console.Write("Do you want to try again? (y/n) ");
				string contAns = Console.ReadLine().Trim();
				if (contAns == "y")
					cont = true;
				else
					break;
			}
			Console.ReadLine();
		}

		public static float[,] MatrixMultiplicationByScalar(float[,] matrix, float scalar, bool write)
		{
			float[,] tempMatrix = matrix;

			// Calculation
			for (int i = 0; i < tempMatrix.GetLength(0); i++)
			{
				for (int j = 0; j < tempMatrix.GetLength(1); j++)
				{
					tempMatrix[i, j] = tempMatrix[i, j] * scalar;
				}
			}
			// Writing
			if (write)
			{
				for (int i = 0; i < size; i++)
				{
					for (int j = 0; j < size; j++)
					{
						Console.Write(tempMatrix[i, j] + " ");
					}
					Console.WriteLine();
				}
			}
			return tempMatrix;
		}

		public static float[,] MatrixTranspose(float[,] matrix, bool write)
		{
			float[,] tempMatrix = new float[matrix.GetLength(0), matrix.GetLength(1)];

			// Calculation
			for (int i = 0; i < tempMatrix.GetLength(0); i++)
			{
				for (int j = 0; j < tempMatrix.GetLength(1); j++)
				{
					tempMatrix[j, i] = matrix[i, j];
				}
			}

			// Writing
			if (write)
			{
				for (int i = 0; i < size; i++)
				{
					for (int j = 0; j < size; j++)
					{
						Console.Write(tempMatrix[i, j] + " ");
					}
					Console.WriteLine();
				}
			}
			return tempMatrix;
		}

		public static float MatrixTrace(float[,] matrix)
		{
			float traceSum = 0;

			// Calculating
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
			// Check if matrix 2x2 or less
			if (matrix.GetLength(0) <= 2) 
				return MatrixSubDeterminant(matrix, 0, 0);

			float determinant = 0;

			// Calculation
			for (int i = 0; i < matrix.GetLength(1); i++)
			{
				determinant += MatrixSubDeterminant(matrix, 0, i) * (float)Math.Pow(-1, i);
			}
			return determinant;
		}

		public static float MatrixSubDeterminant(float[,] matrix, int x, int y)
		{
			// Calculation if matrix is 2x2
			if (matrix.GetLength(0) == 2)
			{
				return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
			}

			// Calculation
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
			var pr = new Program();

			// To know which by which matrix it is
			Console.Write("What size is your matrix: ");
			size = Convert.ToInt32(Console.ReadLine().Trim());
			Console.WriteLine();

			// Cannot be a matrix if it is 1x1 or less
			if (size <= 1)
			{
				Console.WriteLine("You entered wrong number.");
				Environment.Exit(0);
			}

			// Placing numbers to the matrix 
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

			// Writing
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

		public static float[,] GetUserMatrix2()
		{
			var pr = new Program();

			// Placing numbers to the matrix 
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

			// Writing
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

		public static float[,] MatrixInverse(float[,] matrix, bool write)
		{
			Program pr = new Program();

			float[,] tempMatrix = new float[matrix.GetLength(0), matrix.GetLength(1)];

			// If determinant is equals to zero matrix is not invertible
			// Check if it is invertible
			if (MatrixDeterminant(matrix) != 0)
			{
				// Calculation
				tempMatrix = MatrixMultiplicationByScalar(MatrixAdjoint(matrix, pr.dontWrite), (1 / MatrixDeterminant(matrix)),pr.dontWrite);

				// Writing
				if (write)
				{
					for (int i = 0; i < size; i++)
					{
						for (int j = 0; j < size; j++)
						{
							Console.Write(tempMatrix[j, i] + " ");
						}
						Console.WriteLine();
					}
				}
			}
			else
				Console.WriteLine("This matrix is not invertible because determinant is equals to zero.");

			return tempMatrix;
		}

		public static float[,] MatrixAdjoint(float[,] matrix, bool write)
		{
			Program pr = new Program();

			float[,] tempMatrix = new float[matrix.GetLength(0), matrix.GetLength(1)];

			// To calculate if matrix is 2x2
			if (tempMatrix.GetLength(0) == 2)
			{
				// Place numbers in calculation matrix
				for (int i = 0; i < tempMatrix.GetLength(0); i++)
				{
					for (int j = 0; j < tempMatrix.GetLength(1); j++)
					{
						tempMatrix[i, j] = matrix[i, j];
					}
				}

				// Calculation
				tempMatrix[0, 0] = matrix[1, 1];
				tempMatrix[0, 1] = -matrix[0, 1];
				tempMatrix[1, 0] = -matrix[1, 0];
				tempMatrix[1, 1] = matrix[0, 0];

				// Writing
				if (write)
				{
					for (int i = 0; i < tempMatrix.GetLength(0); i++)
					{
						for (int j = 0; j < tempMatrix.GetLength(1); j++)
						{
							Console.Write(tempMatrix[i, j] + " ");
						}
						Console.WriteLine();
					}
				}

				return tempMatrix;
			}

			// Calculation
			for (int i = 0; i < tempMatrix.GetLength(0); i++)
			{
				for (int j = 0; j < tempMatrix.GetLength(1); j++)
				{
					float[,] temp = GetSubArr(matrix, i, j);
					tempMatrix[i, j] = (float)Math.Pow(-1, i + j) * MatrixDeterminant(temp);
				}
			}

			// Writing
			if(write)
			{
				MatrixTranspose(tempMatrix, pr.write);
			}
			return tempMatrix;
		}

		public static float[,] MatrixMultiplication(float[,] matrix1, float[,] matrix2, bool write)
		{
			float[,] tempMatrix = new float[matrix1.GetLength(0), matrix1.GetLength(1)];

			//Calculation
			for (int i = 0; i < matrix1.GetLength(0); i++)
			{
				for (int j = 0; j < matrix1.GetLength(0); j++)
				{
					for (int k = 0; k < matrix1.GetLength(0); k++)
					{
						tempMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
					}
				}
			}

			//Writing
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					Console.Write(tempMatrix[i, j] + " ");
				}
				Console.WriteLine();
			}
			Console.WriteLine("====================================");

			return tempMatrix;
		}
	}
}