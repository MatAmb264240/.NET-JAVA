using ConsoleApp1;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void items_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (int.TryParse(number_of_items.Text, out int n) &&
                int.TryParse(seed_box.Text, out int seed) &&
                int.TryParse(capacity.Text, out int cap))
            {
                if (seed <= 0 || seed > 10)
                {
                    seed_box.BackColor = Color.Red;
                    return;
                }
                else
                    seed_box.BackColor = Color.White;


                if (n <= 0)
                {
                    number_of_items.BackColor = Color.Red;
                    return;
                }
                else
                    number_of_items.BackColor = Color.White;


                if (cap <= 0)
                {
                    capacity.BackColor = Color.Red;
                    return;
                }
                else
                {
                    capacity.BackColor = Color.White;
                }
                listBox1.Items.Clear();
                listBox2.Items.Clear();


                // Utworzenie obiektu klasy Problem
                Problem problem = new Problem(n, seed);
                // Mo¿esz tutaj wykonywaæ inne operacje z obiektem p1
                List<Przedmiot> przedmioty = problem.GenerateItems(n);


                Result result = problem.Solve(przedmioty, cap);

                for (int i = 0; i < przedmioty.Count(); i++)
                    listBox2.Items.Add(przedmioty[i].ToString());

                listBox1.Items.Add(result.ToString());

            }
            else
            {
                MessageBox.Show("Niepoprawne dane. Upewnij siê, ¿e wprowadzone wartoœci s¹ liczbami ca³kowitymi.");
            }
        }

        private void number_of_items_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
