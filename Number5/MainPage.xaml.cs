using System.Collections.ObjectModel;

namespace Number5;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Tovar> Products { get; set; } = new ObservableCollection<Tovar>();

    public MainPage()
    {
        InitializeComponent();
        ProductsGrid.BindingContext = this;

        Products.Add(new Product("Молоко", 25.99m, "Україна", DateTime.Now.AddMonths(-1), "Молоко високої якості", DateTime.Now.AddMonths(1), 1, "л"));
        Products.Add(new Book("Шерлок Холмс", 199.99m, "Великобританія", DateTime.Now.AddYears(-2), "Класична література", 350, "Видавництво 1", new List<string> { "Артур Конан Дойль" }));

        ProductCollection.ItemsSource = Products;
    }

    private void OnAddProductClicked(object sender, EventArgs e)
    {
        Products.Add(new Product("Сік", 15.50m, "Україна", DateTime.Now, "Фруктовий сік", DateTime.Now.AddMonths(3), 2, "л"));
    }

    private void OnDeleteProductClicked(object sender, EventArgs e)
    {
        if (Products.Count > 0)
        {
            Products.RemoveAt(0);
        }
    }

    public class Tovar
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CountryOfOrigin { get; set; }
        public DateTime PackagingDate { get; set; }
        public string Description { get; set; }

        public Tovar(string name, decimal price, string countryOfOrigin, DateTime packagingDate, string description)
        {
            Name = name;
            Price = price;
            CountryOfOrigin = countryOfOrigin;
            PackagingDate = packagingDate;
            Description = description;
        }
    }

    public class Product : Tovar
    {
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }

        public Product(string name, decimal price, string countryOfOrigin, DateTime packagingDate, string description, DateTime expiryDate, int quantity, string unit)
            : base(name, price, countryOfOrigin, packagingDate, description)
        {
            ExpiryDate = expiryDate;
            Quantity = quantity;
            Unit = unit;
        }
    }
    public class Book : Tovar
    {
        public int PageCount { get; set; }
        public string Publisher { get; set; }
        public List<string> Authors { get; set; }

        public Book(string name, decimal price, string countryOfOrigin, DateTime packagingDate, string description, int pageCount, string publisher, List<string> authors)
            : base(name, price, countryOfOrigin, packagingDate, description)
        {
            PageCount = pageCount;
            Publisher = publisher;
            Authors = authors;
        }
    }
}