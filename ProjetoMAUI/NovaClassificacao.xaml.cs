using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Model;

namespace ProjetoMAUI;

public partial class NovaClassificacao : ContentPage
{
	private FirebaseClient banco;
	public NovaClassificacao()
	{
		InitializeComponent();
		banco = new FirebaseClient("https://maui-20573-default-rtdb.firebaseio.com/");
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var classificacao = new Classificacao()
        {
            Nome = Classificacao.Text
        };
        await banco.Child("Classificacao").PostAsync(classificacao);    //faz inserção no banco de dados
        DisplayAlert("Respota", "Registro inserido", "OK");
    }
}