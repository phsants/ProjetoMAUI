using Firebase.Database;
using ProjetoMAUI.Model;

namespace ProjetoMAUI;

public partial class ListarClassificacao : ContentPage
{
	private FirebaseClient banco;

	private List<Classificacao> classificacao;
	public ListarClassificacao()
	{
		InitializeComponent();
		banco = new FirebaseClient("https://maui-20573-default-rtdb.firebaseio.com/");
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		var classificacao = (await banco.Child("Classificacao")
			.OnceAsync<Classificacao>()).Select(
				item => new Classificacao()
				{
					Id = item.Key,
					Nome = item.Object.Nome
				}).ToList();
		Dados.ItemsSource = classificacao;
	}

	private void Dados_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		var classificacao = (Classificacao)e.Item;
		Navigation.PushAsync(new AlterarExcluirClassificacao(classificacao));
	}
}