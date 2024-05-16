using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_namespace
{
   public class Matrix
    {
        private int[,] matrix;
        public int Rows { get; set; }
        public int Columns { get; set; }
        public static Mutex mutex = new Mutex();

        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Columns = cols;
            matrix = new int[rows, cols];

        }

        public void FillMatrix()
        {
            Random random = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    matrix[i, j] = random.Next(1, 10);
                }
            }
        }

        public override string ToString()
        {
            string matrixString = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    matrixString += matrix[i, j] + " ";
                }
                matrixString += Environment.NewLine;
            }
            return matrixString;
        }
        public int[] GetColumn(int i)
        {
            int[] res = new int[Rows];
            for (int j = 0; j < Rows; j++)
                res[j] = matrix[j, i];
            return res;
        }
        public int[] GetRow(int i)
        {
            int[] res = new int[Columns];
            for (int j = 0; j < Columns; j++)
                res[j] = matrix[i, j];
            return res;
        }
        public int this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }
        public static void VectorMult(int startRow, int endRow, Matrix a, Matrix b, Matrix result)
        {

            for (int i = startRow; i < endRow; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    int[] x = a.GetRow(i);
                    int[] y = b.GetColumn(j);

                    for (int k = 0; k < x.Length; k++)
                        result[i, j] += x[k] * y[k];
                }
            }

        }
        public static Matrix multiplication(Matrix matrix1, Matrix matrix2, int threadNum)
        {
            if (matrix1.Columns != matrix2.Rows)
                throw new Exception("The number of columns in the first matrix must be equal to the number of rows in the second matrix.");

            if (threadNum < 1)
                throw new Exception("The number of threads must be greater than 0.");

            Matrix result = new Matrix(matrix1.Rows, matrix2.Columns);
            Thread[] threads = new Thread[threadNum];

            int rowsPerThread = matrix1.Rows / threadNum;
            for (int t = 0; t < threadNum; t++)
            {
                int startRow = t * rowsPerThread;
                int endRow = (t == threadNum - 1) ? matrix1.Rows : (startRow + rowsPerThread);
                threads[t] = new Thread(() => VectorMult(startRow, endRow, matrix1, matrix2, result));
                threads[t].Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            return result;
        }
        /////////////////////////////////   PARALLEL /////////////////////////////////////
        
        public static Matrix paralell_multiplication(Matrix matrix1, Matrix matrix2, int threads)
        {
            if (matrix1.Columns != matrix2.Rows)
                throw new Exception("The number of columns in the first matrix must be equal to the number of rows in the second matrix.");

            if (threads < 1)
                throw new Exception("The number of threads must be greater than 0.");

            var resultMatrix = new Matrix(matrix1.Rows, matrix2.Columns);
            ParallelOptions opt = new ParallelOptions()
            {
                MaxDegreeOfParallelism =threads
            };
            Parallel.For(0, matrix1.Rows, row =>
            {
                for (byte j = 0; j < matrix2.Columns; j++)
                {
                    int sum = 0;
                    for (byte k = 0; k < matrix1.Columns; k++)
                    {
                        sum += matrix1[row, k] * matrix2[k, j];
                    }

                    resultMatrix[row, j]= sum;
                }
            });
            return resultMatrix;

        }
    }

}

