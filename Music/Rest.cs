using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Music
{
    class Rest : MusicalNotation
    {
        public override string ToString()
        {
            return $"Resting for {Duration} beats";
        }

        public override void Play()
        {
            Thread.Sleep(300 * Duration);
        }
    }
}
