using EFcoreProjectHomeTask.Data;
using EFcoreProjectHomeTask.Models.Concretes;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using EFcoreProjectHomeTask.Command;

namespace EFcoreProjectHomeTask
{
 
	public partial class MainWindow : Window,INotifyPropertyChanged
	{

		private readonly  AppDbContext appContext;

		public ObservableCollection<Product> ProductsObs { get => productsObs; set { productsObs=value; OnPropertyChanged(nameof(SelectedCategory)); } }

		private List<Category> categories;
		private Category selectedCategory;
		private ObservableCollection<Product> productsObs;
		private string productName;
		private string desc;
		private decimal price;

		public List<Category> Categories
		{
			get => categories;
			set
			{
				categories=value;
				OnPropertyChanged(nameof(Categories));
			}
		}

		public Category SelectedCategory { get => selectedCategory; set
			{
				selectedCategory=value;
				OnPropertyChanged(nameof(SelectedCategory));

			}
			}


		public string ProductName { get => productName; set { productName=value; OnPropertyChanged(nameof(ProductName)); }
			}
		public string Desc { get => desc; set {
				desc=value;
				OnPropertyChanged(nameof(Desc));
			}
		}
		public decimal Price { get => price; set { price=value; OnPropertyChanged(nameof(Price));
			}
		}



		public RelayCommand AddCommand { get; set; }
        public MainWindow()
		{
			InitializeComponent();
			appContext = new();
			Categories=appContext.Categories.ToList();
			ProductsObs = [];
			DataContext=this;
			AddCommand=new(addProduct);
		}

		private void addProduct(object obj)
		{
			try
			{
				appContext.Products.Add(
								new Product()
								{
									Name =ProductName,
									Desc =Desc,
									Category_Id = SelectedCategory.Id,
									Price = Price

								});
				appContext.SaveChanges();
				ProductsObs.Add(new Product()
				{
					Name =ProductName,
					Desc =Desc,
					Category = SelectedCategory,
					Price = Price

				});
				MessageBox.Show("Add Successfully Product!");
			}
			catch (Exception)
			{

				MessageBox.Show("Dont forget empty box and please pay attention constraint");
			}
			finally {
				ProductName=string.Empty;
				Desc =string.Empty;
				SelectedCategory=null;
				Price = 0;


			}
				
		}

		private void Window_Load(object sender, RoutedEventArgs e)
		{

			var products = appContext.Products.Include(c => c.Category).ToList();
			foreach (var product in products)
			{

				ProductsObs.Add(new Product
				{
					Id = product.Id,
					Name = product.Name,
					Desc = product.Desc,
					Category_Id = product.Category_Id,
					Price = product.Price,
					Category = product.Category

				}
				); ;
			
					
			}
		}


		public event PropertyChangedEventHandler? PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

}