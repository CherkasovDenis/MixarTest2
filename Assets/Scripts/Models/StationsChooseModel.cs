using System;

namespace MixarTest2.Models
{
    public class StationsChooseModel
    {
        public event Action<PathInfo> PathUpdated;

        public event Action<string> Error;

        public void OnPathUpdated(PathInfo pathInfo)
        {
            PathUpdated?.Invoke(pathInfo);
        }

        public void OnError(string error)
        {
            Error?.Invoke(error);
        }
    }
}