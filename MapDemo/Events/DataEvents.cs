using MapDemo.Models;
using System.Collections.Generic;

namespace MapDemo.Events
{
    public delegate void LocationUpdateEvent(List<SoldierCache> soldiers);
}
