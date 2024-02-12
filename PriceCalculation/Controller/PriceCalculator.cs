using Models.Entities;
using PriceCalculation.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PriceCalculation.Controller {
    public class PriceCalculator {

        private int _discauntRange;

        public PriceCalculator(int discauntRange) {
            this._discauntRange = discauntRange;
        }

        public PriceCalculator() : this(10){}

        public float CalculatePrice(IEnumerable<Dish> dishes) {
            var products = GetProducts(dishes.ToList());
            var prices = GetPrices(products);
            if (prices.Count < 4) 
                return prices.Select(x => x.Sum()).Sum();
            return CalculateDiscauntPrice(prices);
        }

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

        private float CalculateDiscaunt(float price) {
            price -= price / this._discauntRange;
            return (float)Math.Round(price, 2);
        }

        private List<Product> GetProducts(List<Dish> dishes) {
            List<Product> list = new List<Product>();
            dishes.ForEach((dish) => {
                for (int i = 0; i < dish.portions; i++) {
                    list.Add(new Product() {
                        price = dish.price,
                        type = dish.type
                    });
                }
            });
            return list;
        }

        private List<List<float>> GetPrices(List<Product> products) {
            return products.GroupBy(x => x.type)
                .ToDictionary(g => g.Key, g => g.ToList()).Values.ToList()
                .Select(x => x.Select(y => y.price).OrderDescending().ToList())
                .OrderBy(x => x.Count).ToList();
        }


    }
}
