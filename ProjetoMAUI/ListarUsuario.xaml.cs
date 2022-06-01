using Firebase.Database;
using ProjetoMAUI.Model;

namespace ProjetoMAUI;

public partial class ListarUsuario : ContentPage
{
	private FirebaseClient banco;

	private List<Usuario> usuario;
	public ListarUsuario()
	{
		InitializeComponent();
		banco = new FirebaseClient("https://maui-20573-default-rtdb.firebaseio.com/");
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		var usuario = (await banco.Child("Usuario")
			.OnceAsync<Usuario>()).Select(
				item => new Usuario()
				{
					Id = item.Key,
					Nome = item.Object.Nome,
					Login = item.Object.Login,
					Senha = item.Object.Senha
				}).ToList();
		Dados.ItemsSource = usuario;
	}

	private void Dados_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		var usuario = (Usuario)e.Item;
		Navigation.PushAsync(new AlterarExcluirUsuario(usuario));
	}
}