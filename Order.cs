public class Order {
    public int Id { get; private set; }
    public int Amount { get; private set; }
    public Product? TargetProduct { get; private set; }
    public bool IsCompleted { get; private set; }

    public Order(int id, int amount) {
        Id = id;
        Amount = amount < 1 ? 1 : amount;
        TargetProduct = null;
        IsCompleted = false;
    }

    public bool TryStart(Product product) {
        if (IsCompleted || TargetProduct != null) {
            return false;
        }
        if (product.Quantity < Amount) {
            return false;
        }

        TargetProduct = product;
        return true;
    }

    public bool TryFinish() {
        if (IsCompleted || TargetProduct == null) {
            return false;
        }
        if (TargetProduct.Quantity < Amount) {
            return false;
        }

        TargetProduct.Sell(Amount);
        IsCompleted = true;
        return true;
    }
}
