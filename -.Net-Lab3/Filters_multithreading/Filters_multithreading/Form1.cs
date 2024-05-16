using System;
using App;

namespace Filters_multithreading
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog;
        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void load_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox5.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void parallel_Click(object sender, EventArgs e)
        {
            if(openFileDialog == null)
            {
                MessageBox.Show("Please load an image first");
                return;
            }
            string file_path = openFileDialog.FileName;

            Bitmap[] images = new Bitmap[4]; // Inicjalizacja tablicy obiektów typu Bitmap

            for (int i = 0; i < 4; i++)
            {
                images[i] = new Bitmap(file_path); // Tworzenie i wczytywanie obrazu dla ka¿dego elementu tablicy
            }
            var task1 = Task<Bitmap>.Factory.StartNew(() => Image_processing.Thresholding(images[0]));
            var task2 = Task<Bitmap>.Factory.StartNew(() => Image_processing.Negate(images[1]));
            var task3 = Task<Bitmap>.Factory.StartNew(() => Image_processing.AdjustBrightness(images[2], 10));
            var task4 = Task<Bitmap>.Factory.StartNew(() => Image_processing.DetectEdges(images[3]));

            Task.WaitAll(task1, task2, task3, task4); // Wait for all tasks to complete

            // Assign the result images to PictureBoxes
            pictureBox1.Image = task1.Result;
            pictureBox2.Image = task2.Result;
            pictureBox3.Image = task3.Result;
            pictureBox4.Image = task4.Result;


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
