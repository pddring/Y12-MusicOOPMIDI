using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class MidiEvent
    {
        // the bytes that are sent as MIDI data
        private byte[] buffer = new byte[3];

        // there are 16 channels to choose from. Channel 9 is percussion
        private int Channel;

        /// <summary>
        /// Send MIDI data
        /// </summary>
        public void Send()
        {
            Console.WriteLine("Not implemented yet: sending midi data");
        }
    }
}
