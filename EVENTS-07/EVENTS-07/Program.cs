using System;

namespace EVENTS_07
{
    class Program
    {
        static void Main(string[] args)
        {

            var stock = new Stock("Amazon");
            stock.Price = 100;
            stock.OnPriceChange += (Stock stoc, decimal oldPrice) =>
            {
                string result = "";
                if (stock.Price > oldPrice)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    result = "Up";
                }
                else if (oldPrice > stock.Price)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    result = "Down";

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;

                }
                Console.WriteLine($"{stock.Name}: {stock.Price} - {result}");
            };

            stock.changestockprice(0.05m);
            stock.changestockprice(-0.02m);
            stock.changestockprice(0.00m);

            Console.ReadKey();
        }

        private static void Stock_OnPriceChange(Stock stock, decimal oldPrice)
        {


        }
    }


    public delegate void StokPriceChange(Stock stock, decimal oldPrice);
    public class Stock
    {
        private string name;
        private decimal price;


        public event StokPriceChange OnPriceChange;
        public string Name => this.name;
        public decimal Price { get => this.price; set => this.price = value; }

        public Stock(string stockName)
        {
            this.name = stockName;
        }

        public void changestockprice(decimal percent)
        {
            decimal oldprice = this.price;
            this.price += Math.Round(this.price * percent, 2);

            if (OnPriceChange != null)
            {
                OnPriceChange(this, oldprice);
            }
        }
    }
}
