namespace Models.Entities {
    public class Dish : Entity {
        public string name { get; set; } = string.Empty;
        public float price { get; set; }
        public Dish_Type type { get; set; }
        public int portions { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}