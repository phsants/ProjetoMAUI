using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Model;

namespace ProjetoMAUI;

public partial class NovoTipo : ContentPage
{
	private FirebaseClient banco;
	public NovoTipo()
	{
		InitializeComponent();
		banco = new FirebaseClient("https://maui-20573-default-rtdb.firebaseio.com/");
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var tipo = new Tipo()
        {
            Nome = Tipo.Text
        };
        await banco.Child("Tipo").PostAsync(tipo);    //faz inserção no banco de dados
        DisplayAlert("Respota", "Registro inserido", "OK");
    }
}