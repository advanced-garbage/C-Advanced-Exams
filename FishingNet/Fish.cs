namespace FishingNet
{
    public class Fish
    {
        public string FishType { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public Fish(string fishtype, double length, double weight)
        {
            this.FishType = fishtype;
            this.Length = length;
            this.Weight = weight;
        }
        public override string ToString()
        {
            return $"There is a {this.FishType}, {this.Length} cm. long, and {this.Weight} gr. in weight.";
        }
    }
}
