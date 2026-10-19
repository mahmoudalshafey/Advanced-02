namespace Advanced_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
