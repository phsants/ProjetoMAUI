using Firebase.Database;
using ProjetoMAUI.Model;

namespace ProjetoMAUI;

public partial class ListarTipo : ContentPage
{
	private FirebaseClient banco;

	private List<Tipo> tipo;
	public ListarTipo()
	{
		InitializeComponent();
		banco = new FirebaseClient("https://maui-20573-default-rtdb.firebaseio.com/");
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		var tipo = (await banco.Child("Tipo")
			.OnceAsync<Tipo>()).Select(
				item => new Tipo()
				{
					Id = item.Key,
					Nome = item.Object.Nome
				}).ToList();
		Dados.ItemsSource = tipo;
	}

	private void Dados_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		var tipo = (Tipo)e.Item;
		Navigation.PushAsync(new AlterarExcluirTipo(tipo));
	}
}