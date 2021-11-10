namespace EditorTXTVS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region Menu Arquivo
        private void mArquivoNovo_Click(object sender, EventArgs e)
        {
            txtConteudo.Clear();
        }
        

        private void mArquivoNovaJanela_Click(object sender, EventArgs e)
        {
            //Form1 f = new Form1();
            //f.Show();

            Thread t = new Thread(() => Application.Run(new Form1()));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        

        private void mArquivoAbrir_Click(object sender, EventArgs e)
        {

        }

        private void mArquivoSalvar_Click(object sender, EventArgs e)
        {
            if (File.Exists(Gerenciador.FilePath))
            {
                SalvarArquivo(Gerenciador.FilePath);
            }
            else
            { 
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "Salvar...";
                dialog.Filter = "rich text file |*.rtf|texto|*.txt|todos|*.*";
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;

                var result = dialog.ShowDialog();

                if (result != DialogResult.Cancel && result != DialogResult.Abort)
                {
                    SalvarArquivo(dialog.FileName);
                }
            }
        }

        private void mArquivoSalvarComo_Click(object sender, EventArgs e)
        {

        }

        private void SalvarArquivo(string path)
        { 
               // Obejto responsável por escrever o arquivo 
               StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(path, false);
                writer.Write(txtConteudo.Text);

                FileInfo file = new FileInfo(path);
                Gerenciador.FolderPath = file.DirectoryName + "\\";
                Gerenciador.FileName = file.Name.Remove(file.Name.LastIndexOf("."));
                Gerenciador.FileExt = file.Extension;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Salvar Arquivo: \n" + ex.Message);
            }
            finally 
            { 
                writer.Close(); 
            }
        }

        private void mArquivoSair_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja sair?","SAIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) 
            {
                Application.Exit();
            }

            
        }

        #endregion
    }
}