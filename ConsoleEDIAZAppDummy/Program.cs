using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net.Http.Json;

//Author: Edgar Díaz
//date: 23/01/2024

class Program
{
	static async Task Main()
	{
		// Hacer Login
		await Login();

		// Lista de productos
		await GetProducts();

		// Agregar un producto nuevo
		await EditOrAddProduct();

		
	}

	static async Task Login()
	{
		using (HttpClient client = new HttpClient())
		{
			string loginUrl = "https://dummyjson.com/auth/login";

			// Datos de usuario 
			var userData = new { username = "kminchelle", password = "0lelplR" };

			HttpResponseMessage response = await client.PostAsJsonAsync(loginUrl, userData);

			if (response.IsSuccessStatusCode)
			{
				Console.WriteLine("Inicio de sesión exitoso");
			}
			else
			{
				Console.WriteLine($"Error en el inicio de sesión: {await response.Content.ReadAsStringAsync()}");
			}
		}
	}

	static async Task GetProducts()
	{
		using (HttpClient client = new HttpClient())
		{
			string productsUrl = "https://dummyjson.com/products";

			HttpResponseMessage response = await client.GetAsync(productsUrl);

			if (response.IsSuccessStatusCode)
			{

				var products = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Lista de productos:");			

				Console.WriteLine(products);

				//foreach (var product in products){
					//Console.WriteLine(product);
				//}
			}
			else
			{
				Console.WriteLine($"Error al obtener la lista de productos: {await response.Content.ReadAsStringAsync()}");
			}
		}
	}

	static async Task EditOrAddProduct()
	{
		using (HttpClient client = new HttpClient())
		{
			string editProductUrl = "https://dummyjson.com/products/add";

			// Datos del producto 
			var productData = new { id = 1, description = "Nuevo Producto Agrotech", price = 19.99 };

			HttpResponseMessage response = await client.PostAsJsonAsync(editProductUrl, productData);

			if (response.IsSuccessStatusCode)
			{
				Console.WriteLine("Producto agregado con éxito");
			}
			else
			{
				Console.WriteLine($"Error al agregar el producto: {await response.Content.ReadAsStringAsync()}");
			}
		}
	}

}
