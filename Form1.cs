namespace Cinemania
{
    public partial class Form1 : Form
    {

        private Cine cine;
        private Form2 hijoLogin;
        private Main hijoMain;
        private Perfil hijoPerfil;
        private Register hijoRegister;
        private PerfilUsuario hijoPerfilUsuario;
        private CambiarPassword hijoCambiarPassword;
        

        public Form1()
        {
            InitializeComponent();
            cine = new Cine();

            //creo forma 2 pantalla de log in
            hijoLogin = new Form2(cine);

            hijoLogin.MdiParent = this;
            hijoLogin.TransfEvento += TransfDelegado;
            hijoLogin.loginToRegister += LoginToRegister;

            hijoLogin.Show();

        }

        private void TransfDelegado()
        {
            MessageBox.Show("Log in correcto: " + cine.usuarioLogueado(), "Inicio de Sesi�n", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hijoLogin.Close();

            //Ahora s� creo la pantalla principal Form3
            hijoMain = new Main(cine);
            hijoMain.MdiParent = this;
            hijoMain.TransfLogin += mainToLogin;
            hijoMain.TransfEvento += mainToPerfil;
            hijoMain.TransfUsuario += mainToUsuario;
            hijoMain.Show();

        }

        private void mainToLogin()
        {
            hijoMain.Close();
            hijoLogin = new Form2(cine);

            hijoLogin.MdiParent = this;
            hijoLogin.Show();
            hijoLogin.TransfEvento += TransfDelegado;
            hijoLogin.loginToRegister += LoginToRegister;



        }

        private void mainToPerfil()
        {
            hijoMain.Close();
            hijoLogin.Close();
            hijoPerfil = new Perfil(cine);
            hijoPerfil.MdiParent = this;
            hijoPerfil.Show();
            hijoPerfil.TransfEvento2 += PerfilToMain;

        }

        private void PerfilToMain()
        {
            hijoPerfil.Close();
            hijoLogin.Close();
            hijoMain = new Main(cine);
            hijoMain.MdiParent = this;
            hijoMain.Show();
            hijoMain.TransfLogin += mainToLogin;
            hijoMain.TransfEvento += mainToPerfil;
            hijoMain.TransfUsuario += mainToUsuario;
        }

        private void LoginToRegister()
        {
            hijoLogin.Close();
            hijoRegister = new Register(cine);
            hijoRegister.MdiParent = this;
            hijoRegister.registerToLogin += RegisterToLogin;
            hijoRegister.Show();

        }

        private void RegisterToLogin()
        {
            hijoRegister.Close();
            hijoLogin = new Form2(cine);
            hijoLogin.MdiParent = this;
            hijoLogin.TransfEvento += TransfDelegado;
            hijoLogin.loginToRegister += LoginToRegister;
            hijoLogin.Show();
        }

        private void mainToUsuario()
        { 
            hijoMain.Close();
            hijoPerfilUsuario = new PerfilUsuario(cine);
            hijoPerfilUsuario.MdiParent = this;
            hijoPerfilUsuario.transfMain += usuarioToMain;
            hijoPerfilUsuario.transfCambiarPassword += usuarioToCambiarPassword;
            hijoPerfilUsuario.Show();
            
        }

        private void usuarioToMain() 
        { 
            hijoPerfilUsuario.Close();
            hijoMain = new Main(cine);
            hijoMain.MdiParent = this;
            hijoMain.TransfLogin += mainToLogin;
            hijoMain.TransfEvento += mainToPerfil;
            hijoMain.TransfUsuario += mainToUsuario;
            hijoMain.Show();


        }
        private void usuarioToCambiarPassword()
        {
            hijoPerfilUsuario.Close();
            hijoCambiarPassword = new CambiarPassword(cine);
            hijoCambiarPassword.MdiParent = this;
            hijoCambiarPassword.passToUsuario += cambiarPassToUsuario;
            hijoCambiarPassword.Show();


        }

        private void cambiarPassToUsuario()
        { 
            hijoCambiarPassword.Close();
            hijoPerfilUsuario = new PerfilUsuario(cine);
            hijoPerfilUsuario.transfMain += usuarioToMain;
            hijoPerfilUsuario.transfCambiarPassword += usuarioToCambiarPassword;
            hijoPerfilUsuario.Show();
        }
    }
}