public class Warehouse {
    private List<Product> _products = new List<Product>();

    public string Name { get; private set; }

    public int ProductCount {
        get { return _products.Count; }
    }

    public Warehouse(string name) {
        Name = name;
    }

    public bool AddProduct(Product product) {
        if (FindProductByTitle(product.Title) != null) {
            return false;
        }

        _products.Add(product);
        return true;
    }

    public Product? FindProductByTitle(string title) {
        if (string.IsNullOrWhiteSpace(title)) {
            return null;
        }

        string searchTitle = title.Trim();

        foreach (Product product in _products) {
            if (string.Equals(product.Title.Trim(), searchTitle, StringComparison.OrdinalIgnoreCase)) {
                return product;
            }
        }

        return null;
    }

    public bool RemoveProduct(string title) {
        Product? product = FindProductByTitle(title);
        if (product == null) {
            return false;
        }
        return _products.Remove(product);
    }

    public List<Product> GetProducts() {
        List<Product> result = new List<Product>();
        foreach (Product product in _products) {
            result.Add(product);
        }
        return result;
    }

    public int CountInStock() {
        int count = 0;
        foreach (Product product in _products) {
            if (product.Quantity > 0) {
                count += 1;
            }
        }
        return count;
    }
}
