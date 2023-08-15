using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace ProgressBarColor
{
    public partial class Form1 : Form
    {
        // Cria objeto a partir da classe que criamos.
        // Este objeto estará disponivél para todos os métodos.
        ProgressBarColor pgbColor = new ProgressBarColor();

        public Form1()
        {
            InitializeComponent();

            // Informa em que lugar o ProgressBar será adicionado.
            pgbColor.Dock = System.Windows.Forms.DockStyle.Bottom;
            pgbColor.Height = 10;
            pgbColor.Style = ProgressBarStyle.Blocks;

            // Adiciona o ProgressBar no formulário.
            this.Controls.Add(pgbColor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                // Espera para poder incrementar.
                Thread.Sleep(50);
                pgbColor.Value += 1;
            }

            // Aguarda antes de mudar a cor.
            Thread.Sleep(50);
            // Muda a cor do ProgressBar
            pgbColor.Color = Brushes.DarkRed;
            //Thread.Sleep(1000);

            // Força a mudança de cor.
            pgbColor.Refresh();
        }

        private int nScreenshot = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            // Cria os objetos necessários
            Bitmap bmpScreenshot;
            Graphics gfxScreenshot;

            // Esconde o form para ele não aparecer no screenshot
            // Hide the form so that it does not appear in the screenshot
            this.Hide();

            // Espera um tempo para garantir que o form escondeu
            // Wait a second
            Thread.Sleep(1000);

            // Seta o obejto bitmap com o tamanho da tela
            // Set the bitmap object to the size of the screen
            bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);

            // Cria um objeto graphics a partir do bitmap
            // Create a graphics object from the bitmap
            gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Tira o screenshot do canto superior esquerdo até o canto inferior direito
            // Take the screenshot from the upper left corner to the right bottom corner
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

            // Salva o screenshot no local indicado e no formato esolhido
            // Save the screenshot to the specified path
            bmpScreenshot.Save("teste" + nScreenshot + ".png", ImageFormat.Png);

            // Exibe o form
            this.Show();

            // Incrementa o contador para que o próximo screenshot não sobrescreva o anterior.
            nScreenshot++;
        }
    }
}
