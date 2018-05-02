namespace Playoff.Classes {
    public class Sport {
        static int autoincrement = 0;
        int sportId;
        string imeSporta;
        int maxBrojIgracaPoTimu, minBrojIgracaPoTimu;

        public Sport(string imeSporta, int maxBrojIgracaPoTimu, int minBrojIgracaPoTimu) {
            SportId = autoincrement++;
            this.ImeSporta = imeSporta;
            this.MaxBrojIgracaPoTimu = maxBrojIgracaPoTimu;
            this.MinBrojIgracaPoTimu = minBrojIgracaPoTimu;
        }

        public int SportId { get => sportId; set => sportId = value; }
        public string ImeSporta { get => imeSporta; set => imeSporta = value; }
        public int MaxBrojIgracaPoTimu { get => maxBrojIgracaPoTimu; set => maxBrojIgracaPoTimu = value; }
        public int MinBrojIgracaPoTimu { get => minBrojIgracaPoTimu; set => minBrojIgracaPoTimu = value; }
    }
}