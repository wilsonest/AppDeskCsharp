using tCelulares.Views;

namespace tCelulares
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openForm3();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            openForm3();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openForm2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openForm3();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            openForm4(); 
        }
        private void button6_Click(object sender, EventArgs e)
        {
            openForm5();
        }
        //metodo para abrir formulario
        public void openForm3()
        {
            Form3 formulario3 = new Form3();
            formulario3.ShowDialog();
        }
        //metodo para abrir formulario
        public void openForm2()
        {
            Form2 formulario1 = new Form2();
            formulario1.ShowDialog();
        }

        public void openForm4()
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        } 

        public void openForm5()
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}