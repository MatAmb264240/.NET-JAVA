

using Matrix_namespace;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMatrixThreadsMultiplicationT()
        {
            Matrix matrix1 = new Matrix(2, 3);
            Matrix matrix2 = new Matrix(3, 2);


            matrix1[0, 0] = 1; matrix1[0, 1] = 2; matrix1[0, 2] = 3;
            matrix1[1, 0] = 4; matrix1[1, 1] = 5; matrix1[1, 2] = 6;

            matrix2[0, 0] = 7; matrix2[0, 1] = 8;
            matrix2[1, 0] = 9; matrix2[1, 1] = 10;
            matrix2[2, 0] = 11; matrix2[2, 1] = 12;

            Matrix result = Matrix.multiplication(matrix1, matrix2, 1);


            Assert.AreEqual(58, result[0, 0]);
            Assert.AreEqual(64, result[0, 1]);
            Assert.AreEqual(139, result[1, 0]);
            Assert.AreEqual(154, result[1, 1]);
        }
        [TestMethod]
        public void TestMatrixParallelsMultiplicationT()
        {
            Matrix matrix1 = new Matrix(2, 3);
            Matrix matrix2 = new Matrix(3, 2);


            matrix1[0, 0] = 1; matrix1[0, 1] = 2; matrix1[0, 2] = 3;
            matrix1[1, 0] = 4; matrix1[1, 1] = 5; matrix1[1, 2] = 6;

            matrix2[0, 0] = 7; matrix2[0, 1] = 8;
            matrix2[1, 0] = 9; matrix2[1, 1] = 10;
            matrix2[2, 0] = 11; matrix2[2, 1] = 12;

            Matrix result = Matrix.paralell_multiplication(matrix1, matrix2, 1);


            Assert.AreEqual(58, result[0, 0]);
            Assert.AreEqual(64, result[0, 1]);
            Assert.AreEqual(139, result[1, 0]);
            Assert.AreEqual(154, result[1, 1]);
        }
    }
}
