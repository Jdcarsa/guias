using BlazorApp2.Models;

using Newtonsoft.Json;

using System.Web.Mvc;

namespace BlazorApp2.Controllers
{

		[Route("api/characters")]
		public class CharactersController : Controller
		{
			private HttpClient _httpClient;
			public CharactersController()
			{
				_httpClient = new HttpClient();
			}

			[HttpGet]
			[Route("all")]
			public async Task<Characters> GetCharacters()
			{
				try
				{
				Characters characters = null;
				HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("https://rickandmortyapi.com/api/character");
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
					// Deserializa el JSON en una lista de Character
					characters = JsonConvert.DeserializeObject<Characters>(responseBody);
				}
				Console.WriteLine(characters);
				return characters;
				}
				catch (Exception ex)
				{
					return null;
				}
			}
		}
}
