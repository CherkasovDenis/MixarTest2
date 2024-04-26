namespace MixarTest2.Models
{
    public class Route
    {
        public Station ConnectedStation { get; }

        public string LineId { get; }

        public Route(Station connectedStation, string lineId)
        {
            ConnectedStation = connectedStation;
            LineId = lineId;
        }
    }
}