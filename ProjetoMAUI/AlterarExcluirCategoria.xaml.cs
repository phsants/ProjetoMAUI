using Firebase.Database;
using Firebase.Database.Query;
using ProjetoMAUI.Model;

namespace ProjetoMAUI;

public partial class AlterarExcluirCategoria : ContentPage
{
    private FirebaseClient banco;
    private Categoria categoria;
	public AlterarExcluirCategoria(Categoria c)
    {
        InitializeComponent();
        banco = new FirebaseClient("https://maui-20573-default-rtdb.firebaseio.com/");
        this.categoria = c;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        this.categoria.Descricao = Nome.Text;
        await banco.Child("Categorias")
            .Child(categoria.Id)
            .PutAsync(categoria);
        DisplayAlert("Alteração", "Registro Alterado!", "OK");
        Navigation.PopAsync();
    }

    protected async override void OnAppearing()
    { 
        Nome.Text = this.categoria.Descricao;
    }

        private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await banco.Child("Categorias")
            .Child(categoria.Id)
            .DeleteAsync();
        DisplayAlert("Exclusão", "Registro Excluido", "OK");
        Navigation.PopAsync();
    }
}