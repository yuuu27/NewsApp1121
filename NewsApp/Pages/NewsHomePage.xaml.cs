using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsHomePage : ContentPage
{
	public List<Article> ArticleList;
    public List<Category> CategoryList = new List<Category>()
    {
        new Category(){Name="World", ImageUrl = "world.png"},
        new Category(){Name = "Nation" , ImageUrl="nation.png"},
        new Category(){Name = "Business" , ImageUrl="business.png"},
        new Category(){Name = "Technology" , ImageUrl="technology.png"},
        new Category(){Name = "Entertainment", ImageUrl = "entertainment.png"},
        new Category(){Name = "Sports" , ImageUrl="sports.png"},
        new Category(){Name = "Science", ImageUrl= "science.png"},
        new Category(){Name = "Health", ImageUrl="health.png"},
    };
    public NewsHomePage()
	{
		InitializeComponent();
		ArticleList = new List<Article>();		
		GetBreakingNews();
        CvCategories.ItemsSource = CategoryList;
	}

	private async void GetBreakingNews()
	{
		var apiService = new ApiService();
		var articles = await apiService.GetNews("general");
		foreach (var article in articles.Articles)
		{
            ArticleList.Add(article);
        }
		CvNews.ItemsSource = ArticleList;
	}
    private void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    var selectedItem = e.CurrentSelection.FirstOrDefault() as Article;
    if (selectedItem == null) return;
    Navigation.PushAsync(new NewsDetailPage(selectedItem));
    ((CollectionView)sender).SelectedItem = null;
}

}