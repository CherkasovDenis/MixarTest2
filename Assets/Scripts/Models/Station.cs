using System.Collections.Generic;

namespace MixarTest2.Models
{
    public class Station
    {
        public string Id { get; }

        public List<Route> Routes { get; }

        public Station(string id)
        {
            Id = id;
            Routes = new List<Route>();
        }

        public void AddRoute(Route route)
        {
            if (!Routes.Contains(route))
            {
                Routes.Add(route);
            }
        }
    }
}