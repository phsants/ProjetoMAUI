using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Model;

namespace ProjetoMAUI;

public partial class NovoUsuario : ContentPage
{
	private FirebaseClient banco;
	public NovoUsuario()
	{
		InitializeComponent();
		banco = new FirebaseClient("https://maui-20573-default-rtdb.firebaseio.com/");
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var usuario = new Usuario()
        {
            Nome = Nome.Text,
            Login = Login.Text,
            Senha = Senha.Text
        };
        await banco.Child("Usuario").PostAsync(usuario);    //faz inserção no banco de dados
        DisplayAlert("Respota", "Registro inserido", "OK");
    }
}