using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Model;

namespace ProjetoMAUI;

public partial class AlterarExcluirUsuario : ContentPage
{
    private FirebaseClient banco;
    private Usuario usuario;
    public AlterarExcluirUsuario(Usuario u)
    {
        InitializeComponent();
        banco = new FirebaseClient("https://maui-20573-default-rtdb.firebaseio.com/");
        this.usuario = u;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        this.usuario.Nome = Nome.Text;
        this.usuario.Login = Login.Text;
        this.usuario.Senha = Senha.Text;
        await banco.Child("Usuario")
            .Child(usuario.Id)
            .PutAsync(usuario);
        DisplayAlert("Alteração", "Registro Alterado!", "OK");
        Navigation.PopAsync();
    }

    protected async override void OnAppearing()
    {
        Nome.Text = this.usuario.Nome;
        Login.Text = this.usuario.Login;
        Senha.Text = this.usuario.Senha;
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await banco.Child("Usuario")
            .Child(usuario.Id)
            .DeleteAsync();
        DisplayAlert("Exclusão", "Registro Excluido", "OK");
        Navigation.PopAsync();
    }
}