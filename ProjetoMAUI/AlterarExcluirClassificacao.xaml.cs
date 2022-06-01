using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Model;

namespace ProjetoMAUI;

public partial class AlterarExcluirClassificacao : ContentPage
{
    private FirebaseClient banco;
    private Classificacao classificacao;
    public AlterarExcluirClassificacao(Classificacao c)
    {
        InitializeComponent();
        banco = new FirebaseClient("https://maui-20573-default-rtdb.firebaseio.com/");
        this.classificacao = c;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        this.classificacao.Nome = Classificacao.Text;
        await banco.Child("Classificacao")
            .Child(classificacao.Id)
            .PutAsync(classificacao);
        DisplayAlert("Alteração", "Registro Alterado!", "OK");
        Navigation.PopAsync();
    }

    protected async override void OnAppearing()
    {
        Classificacao.Text = this.classificacao.Nome;
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await banco.Child("Classificacao")
            .Child(classificacao.Id)
            .DeleteAsync();
        DisplayAlert("Exclusão", "Registro Excluido", "OK");
        Navigation.PopAsync();
    }
}