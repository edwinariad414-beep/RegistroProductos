
using RegistroProductos.Data;
using RegistroProductos.Models;

namespace RegistroProductos;

public partial class MainPage : ContentPage
{
    private readonly Database _database;

    public MainPage(Database database)
    {
        InitializeComponent();
        _database = database;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        productosList.ItemsSource = await _database.ObtenerProductosAsync();
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nombreEntry.Text) ||
            string.IsNullOrWhiteSpace(precioEntry.Text) ||
            string.IsNullOrWhiteSpace(cantidadEntry.Text))
        {
            await DisplayAlert( "Error", "Completa todos los campos requeridos.", "ACEPTAR" +
                "");

            return;
        }

        var producto = new Producto
        {
            Nombre = nombreEntry.Text,
            Descripcion = descripcionEntry.Text,
            Precio = decimal.Parse(precioEntry.Text),
            Cantidad = int.Parse(cantidadEntry.Text)
        };

        await _database.GuardarProductoAsync(producto);

        productosList.ItemsSource =
            await _database.ObtenerProductosAsync();

        nombreEntry.Text = string.Empty;
        descripcionEntry.Text = string.Empty;
        precioEntry.Text = string.Empty;
        cantidadEntry.Text = string.Empty;

    }
}
