using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Model;

namespace ProjetoMAUI;

public partial class NovaCategoria : ContentPage
{
    private async void Button_Clicked(object sender, EventArgs e)
    {
        var categoria = new Categoria()
        {
            Descricao = Nome.Text
        };
        await banco.Child("Categorias").PostAsync(categoria);    //faz inserção no banco de dados
        DisplayAlert("Respota", "Registro inserido", "OK");
    }
    private FirebaseClient banco;
    public NovaCategoria()
    {
        InitializeComponent();
        banco = new FirebaseClient("https://maui-20573-default-rtdb.firebaseio.com/");
    }
    
}