using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SalvarArquivosBanco
{
    public partial class FormArquivos : Form
    {
        public FormArquivos()
        {
            InitializeComponent();

            CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                using (var conn = AbrirConexao())
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT ID, NomeArquivo FROM Arquivos";
                        var reader = comm.ExecuteReader();
                        var table = new DataTable();
                        table.Load(reader);
                        dgvArquivos.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private IDbConnection AbrirConexao()
        {
            //return new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=Testes;Integrated Security=True");
            return new SQLiteConnection(@"Data Source=db.db");
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var arquivo = EscolherArquivo();

                if (!string.IsNullOrWhiteSpace(arquivo))
                {
                    SalvarArquivo(arquivo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string EscolherArquivo()
        {
            var retorno = string.Empty;

            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    retorno = dialog.FileName;
                }
            }

            return retorno;
        }

        private void SalvarArquivo(string arquivo)
        {
            using (var conn = AbrirConexao())
            {
                conn.Open();
                using (var comm = conn.CreateCommand())
                {
                    comm.CommandText = "INSERT INTO Arquivos (NomeArquivo, Arquivo) VALUES (@NomeArquivo, @Arquivo)";
                    ConfigurarParametrosSalvar(comm, arquivo);
                    comm.ExecuteNonQuery();
                    CarregarGrid();
                }
            }
        }

        private void ConfigurarParametrosSalvar(IDbCommand comm, string arquivo)
        {
            //comm.Parameters.Add(new SqlParameter("NomeArquivo", Path.GetFileName(arquivo)));
            //comm.Parameters.Add(new SqlParameter("Arquivo", File.ReadAllBytes(arquivo)));
            comm.Parameters.Add(new SQLiteParameter("NomeArquivo", Path.GetFileName(arquivo)));
            comm.Parameters.Add(new SQLiteParameter("Arquivo", File.ReadAllBytes(arquivo)));
        }

        private void ConfigurarParametrosAbrir(IDbCommand comm)
        {
            //comm.Parameters.Add(new SqlParameter("ID", dgvArquivos.CurrentRow.Cells["ID"].Value));
            comm.Parameters.Add(new SQLiteParameter("ID", dgvArquivos.CurrentRow.Cells["ID"].Value));
        }

        private void btAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = AbrirConexao())
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT Arquivo FROM Arquivos WHERE (ID = @ID)";
                        ConfigurarParametrosAbrir(comm);
                        var bytes = comm.ExecuteScalar() as byte[];
                        if (bytes != null)
                        {
                            var nomeArquivo = dgvArquivos.CurrentRow.Cells["NomeArquivo"].Value.ToString();
                            var arquivoTemp = Path.GetTempFileName();
                            arquivoTemp = Path.ChangeExtension(arquivoTemp, Path.GetExtension(nomeArquivo));
                            File.WriteAllBytes(arquivoTemp, bytes);
                            Process.Start(arquivoTemp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
