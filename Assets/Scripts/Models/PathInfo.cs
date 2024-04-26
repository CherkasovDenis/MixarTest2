using System.Collections.Generic;

namespace MixarTest2.Models
{
    public class PathInfo
    {
        public List<Station> Path { get; }

        public int TransferCount { get; }

        public PathInfo(List<Station> path, int transferCount)
        {
            Path = path;
            TransferCount = transferCount;
        }
    }
}