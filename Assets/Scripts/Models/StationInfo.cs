namespace MixarTest2.Models
{
    public class StationInfo
    {
        public Station Station { get; set; }

        public bool IsUnvisited { get; set; }

        public bool IsStartStation { get; set; }

        public string LineId { get; set; }

        public int PathLength { get; set; }

        public int TransferCount { get; set; }

        public Station PreviousStation { get; set; }

        public StationInfo(Station station)
        {
            Station = station;
            Reset();
        }

        public void Reset()
        {
            IsUnvisited = true;
            IsStartStation = false;
            LineId = "";
            PathLength = int.MaxValue;
            TransferCount = 0;
            PreviousStation = null;
        }
    }
}