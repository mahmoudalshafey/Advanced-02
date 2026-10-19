namespace Advanced_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ===================== Starter Code: Product Catalog =====================
            List<Product> catalog = new()
        {
            new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
            new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
            new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
            new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
            new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
            new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
            new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
            new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
            new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
            new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
        };

            // ---------------------------- Task 01 ----------------------------
            Console.WriteLine("--- Electronics ---");
            PrintSearchResults(SearchProducts(catalog, p => p.Category == "Electronics"));

            Console.WriteLine("--- Under $50 ---");
            PrintSearchResults(SearchProducts(catalog, p => p.Price < 50));

            Console.WriteLine("--- In Stock ---");
            PrintSearchResults(SearchProducts(catalog, p => p.Stock > 0));

            Console.WriteLine("--- Clothing Under $100 ---");
            PrintSearchResults(SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100));

            // ---------------------------- Task 03.1 ----------------------------
            Console.WriteLine("--- Short Report ---");
            PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));
            Console.WriteLine();

            Console.WriteLine("--- Detailed Report ---");
            PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));
            Console.WriteLine();

            // ---------------------------- Task 03.2 ----------------------------
            Console.WriteLine("--- Summary List ---");
            List<string> summaries = TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
            foreach (string s in summaries)
                Console.WriteLine(s);
            Console.WriteLine();

            Console.WriteLine("--- Price Labels ---");
            List<string> labels = TransformProducts(catalog, p => p.Price > 100 ? "Expensive!" : "Affordable");
            for (int i = 0; i < catalog.Count; i++)
                Console.WriteLine($"{catalog[i].Name}: {labels[i]}");
            Console.WriteLine();

            // ---------------------------- Task 03.3 ----------------------------
            Console.WriteLine("--- Low-Stock Alert ---");
            List<Product> lowStock = FilterProducts(catalog, p => p.Stock < 20);
            foreach (Product p in lowStock)
                Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
        }

        // ===================== Task 01: Smart Product Search =====================
        // Delegate used: Func<Product, bool>
        // Why: the filter takes a Product and returns true/false, which is exactly what
        // Func<Product, bool> models. One method works for ANY condition (open for extension,
        // closed for modification) because the caller passes the rule as a lambda.
        static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> result = new();
            foreach (Product p in products)
            {
                if (filter(p))
                    result.Add(p);
            }
            return result;
        }

        static void PrintSearchResults(List<Product> products)
        {
            foreach (Product p in products)
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            Console.WriteLine();
        }

        // ===================== Task 03.1: Print Reports =====================
        // Delegate used: Action<Product>
        // Why: the caller decides HOW to print each product. The action does something
        // (prints) and returns nothing, so Action<T> is the right built-in delegate.
        static void PrintReport(List<Product> products, Action<Product> action)
        {
            foreach (Product p in products)
                action(p);
        }

        // ===================== Task 03.2: Transform Products =====================
        // Delegate used: Func<Product, string>
        // Why: each product is converted into a string, so the delegate takes a Product
        // and RETURNS a value. That is Func<Product, string>.
        static List<string> TransformProducts(List<Product> products, Func<Product, string> transformer)
        {
            List<string> result = new();
            foreach (Product p in products)
                result.Add(transformer(p));
            return result;
        }

        // ===================== Task 03.3: Filter Products =====================
        // Delegate used: Predicate<Product>
        // Why: Predicate<T> is the built-in delegate for "does this item match?"
        // (takes T, returns bool), which fits a filtering condition naturally.
        static List<Product> FilterProducts(List<Product> products, Predicate<Product> condition)
        {
            List<Product> result = new();
            foreach (Product p in products)
            {
                if (condition(p))
                    result.Add(p);
            }
            return result;
        }
    }
}
