using CodingDropletsMauiApp.Models;
using Microsoft.Maui.Controls;

namespace CodingDropletsMauiApp.Controls;

public partial class CollectionViewDemo : ContentPage
{
	public CollectionViewDemo()
	{
		InitializeComponent();

        collectionview.ItemsSource = GetCountries();

    }

	private List<Country> GetCountries()
	{
		return new List<Country>
		{
			new Country {CountryName = "India", IsoCode = "120", FlagUrl = "https://www.bing.com/ck/a?!&&p=56935bb887b3c14e02669f4ac32a8bfb2af92ede8e18680209d47219a7b4a867JmltdHM9MTc1MzgzMzYwMA&ptn=3&ver=2&hsh=4&fclid=1132ba8f-2bad-6351-0377-ac8b2a916296&u=a1L2ltYWdlcy9zZWFyY2g_cT1pbmRpYStmbGFnJmlkPUYzRTUxMEM5NjhFNjYxRTYzNjJDMDc3NkM4MjQxODkxNEZEQzJEODcmRk9STT1JQUNGSVI&ntb=1"},
			new Country {CountryName = "NewYork", IsoCode = "130", FlagUrl = "https://www.bing.com/ck/a?!&&p=edff2e01283fefacb293d6b261e974bbee3b315f84a9c0e218d16e630e019dd2JmltdHM9MTc1MzgzMzYwMA&ptn=3&ver=2&hsh=4&fclid=1132ba8f-2bad-6351-0377-ac8b2a916296&u=a1L2ltYWdlcy9zZWFyY2g_cT11c2ErZmxhZyZpZD1BQzdERDQ4OEQxMDVCRjREQjgxRDZGMUNBQ0U5ODAyODJCNEY1QzZCJkZPUk09SUFDRklS&ntb=1"},
			new Country {CountryName = "Australia", IsoCode = "140", FlagUrl = "https://www.bing.com/ck/a?!&&p=7087966285d77336a15244511cb21ad5c8d8a7a11bac983a49b43cd742b6b429JmltdHM9MTc1MzgzMzYwMA&ptn=3&ver=2&hsh=4&fclid=1132ba8f-2bad-6351-0377-ac8b2a916296&u=a1L2ltYWdlcy9zZWFyY2g_cT1hdXN0cmFsaWErZmxhZyZpZD1EOURDRTQ3MTA4QUFDMUMyMUNGOEIzQkRENzY3NTRFRTYyM0M1OTNBJkZPUk09SUFDRklS&ntb=1"}
		};
	}
}