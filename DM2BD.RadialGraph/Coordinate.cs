namespace DM2BD.RadialGraph
{
    public class Coordinate<TItem>
    {
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public TItem Item { get; set; }
    }
}
