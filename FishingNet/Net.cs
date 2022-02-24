using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish { get; set; }
        public IReadOnlyCollection<Fish> Fish { get { return this.fish; } }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return fish.Count; } }
        public Net(string material, int cap)
        {
            this.Material = material;
            this.Capacity = cap;
            this.fish = new List<Fish>();
        }

        public string AddFish(Fish fish)
        {
            bool meetsCriteria = (!string.IsNullOrWhiteSpace(fish.FishType) &&
                                 (fish.Length > 0 && fish.Weight > 0));
            if (!meetsCriteria)
                return "Invalid fish.";

            bool isThereRoom = this.fish.Count < this.Capacity;
            if (!isThereRoom)
                return "Fishing net is full.";

            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            bool doesExist = this.fish.Any(x => x.Weight.Equals(weight));
            if (doesExist)
            {
                this.fish.Remove(this.fish.Find(x => x.Weight.Equals(weight)));
                return true;
            }
            else return false;
        }

        public Fish GetFish(string fishType)
        {
            bool doesExist = this.fish.Any(x => x.FishType.Equals(fishType));
            if (doesExist)
                return this.fish.Find(x => x.FishType.Equals(fishType));
            else
                return null;
        }

        public Fish GetBiggestFish()
        {
            if (this.fish.Count > 0)
                return this.fish.OrderBy(x => x.Length).Last();
            else
                return null;
        }

        public string Report()
        {
            var report = new StringBuilder();
            report.AppendLine($"Into the {this.Material}:");
            foreach (var fi in fish.OrderByDescending(x => x.Length))
                report.AppendLine($"{fi}");
            return report.ToString().TrimEnd();
        }
    }
}
