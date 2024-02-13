namespace Models.Entities {
    public class Dish : Entity {
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public Dish_Type Type { get; set; }
        public int Portions { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
    }
}