using System;

namespace Labirinth
{
    class Location
    {
        public bool left_wall = true;
        public bool up_wall = true;
        // status +1 is Inside, 0 is Border, -1 is Outside
        // default is Outside for new labirinth
        public int status = -1;
        public string name = "";
        public bool visited = false;

        public Location()
        {
        }
    }
}
