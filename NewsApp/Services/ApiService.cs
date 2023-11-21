using Newtonsoft.Json;
using NewsApp.Models;

namespace NewsApp.Services;

public class ApiService
{
	public async Task<Root> GetNews(string categoryName)
	{
		var httpClient = new HttpClient();
		var response = await httpClient.GetStringAsync($"https://gnews.io/api/v4/top-headlines?category={categoryName.ToLower()}&apikey=9b53f5b0ff481b6ada9cfd143c03bedb&lang=zh");
		return JsonConvert.DeserializeObject<Root>(response);
	}
}