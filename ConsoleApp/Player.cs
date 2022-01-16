using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game21
{
    public class Player : IPlayer
    {
        public int _score { get; set; }


        public void ResetScore()
        {
            _score = 0;
        }
    }
}
