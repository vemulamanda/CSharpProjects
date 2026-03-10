using CodingDropletsMauiApp.Models;
using Microsoft.Maui.Controls;

namespace CodingDropletsMauiApp.Controls;

public partial class CourouselViewDemo : ContentPage
{
	public CourouselViewDemo()
	{
		InitializeComponent();

        var items = new List<CollectionItem>
        {
            new CollectionItem {Title = "Coding Droplets", Description = "Welcome to CD."},
            new CollectionItem {Title = "Title 2", Description = "Description 2"},
            new CollectionItem {Title = "Title 3", Description = "Description 3"},
            new CollectionItem {Title = "Title 4", Description = "Description 4"},
            new CollectionItem {Title = "Title 5", Description = "Description 5"}
        };
        carouselView.ItemsSource = items;
    }
}