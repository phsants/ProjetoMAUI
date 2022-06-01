namespace ProjetoMAUI;

using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Model;

public partial class AlterarExcluirTipo : ContentPage
{
    private FirebaseClient banco;
    private Tipo tipo;
    public AlterarExcluirTipo(Tipo t)
    {
        InitializeComponent();
        banco = new FirebaseClient("https://maui-20573-default-rtdb.firebaseio.com/");
        this.tipo = t;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        this.tipo.Nome = Tipo.Text;
        await banco.Child("Tipo")
            .Child(tipo.Id)
            .PutAsync(tipo);
        DisplayAlert("Alteração", "Registro Alterado!", "OK");
        Navigation.PopAsync();
    }

    protected async override void OnAppearing()
    {
       Tipo.Text = this.tipo.Nome;
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await banco.Child("Tipo")
            .Child(tipo.Id)
            .DeleteAsync();
        DisplayAlert("Exclusão", "Registro Excluido", "OK");
        Navigation.PopAsync();
    }
}