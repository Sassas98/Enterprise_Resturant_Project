using Microsoft.IdentityModel.Tokens;
using Models.Entities;
using PriceCalculation.Models;

namespace PriceCalculation.Controller {
    public class PriceCalculator {

        private int _discauntRange;
        private static int MENU_PARTS = 4;
        private static int STANDARD_DISCAUNT = 10;

        //il costruttore accetta un valore diverso
        //di scontistica, ma se non fornito viene usanta
        //la scontistica standard del 10%
        public PriceCalculator(int discauntRange) {
            this._discauntRange = discauntRange;
        }

        public PriceCalculator() : this(STANDARD_DISCAUNT) {}

        //Metodo per calcolare il prezzo di una serie di piatti.
        public float CalculatePrice(IEnumerable<Dish> dishes) {
            if(dishes.IsNullOrEmpty())
                return 0f;
            var products = GetProducts(dishes.ToList());
            var prices = GetPrices(products);
            if (prices.Count < MENU_PARTS) 
                return prices.Select(x => x.Sum()).Sum();
            return CalculateDiscauntPrice(prices);
        }

        //metodo per scontare i menu e sommare tutti i prezzi
        private float CalculateDiscauntPrice(List<List<float>> prices) {
            int menuNumber = prices.First().Count();
            float disc = 0f, normal = 0f;
            prices.ForEach((list) => {
                for(int i = 0; i < list.Count; i++) {
                    if(i < menuNumber) 
                        disc += list[i];
                    else normal += list[i];
                }
            });
            return normal + CalculateDiscaunt(disc);
        }

        //metodo per scontare un prezzo
        private float CalculateDiscaunt(float price) {
            price -= price / this._discauntRange;
            return (float)Math.Round(price, 2);
        }

        //metodo per trasformare i piatti, che possono essere stati
        //presi più volte, nei singoli prodotti
        private List<Product> GetProducts(List<Dish> dishes) {
            List<Product> list = new List<Product>();
            dishes.ForEach((dish) => {
                for (int i = 0; i < dish.Portions; i++) {
                    list.Add(new Product() {
                        price = dish.Price,
                        type = dish.Type
                    });
                }
            });
            return list;
        }

        //metodo per ottenere i prezzi divisi in tutte le categorie
        //sono ordinati dal più costoso al meno e le categorie sono
        //ordinate da quella meno presa a quella più presa
        private List<List<float>> GetPrices(List<Product> products) {
            return products.GroupBy(x => x.type)
                .ToDictionary(g => g.Key, g => g.ToList()).Values.ToList()
                .Select(x => x.Select(y => y.price).OrderDescending().ToList())
                .OrderBy(x => x.Count).ToList();
        }


    }
}
