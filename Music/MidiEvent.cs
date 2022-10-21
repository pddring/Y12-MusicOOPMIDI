using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    abstract class MidiEvent
    {
        // the bytes that are sent as MIDI data
        protected byte[] buffer = new byte[3];

        // there are 16 channels to choose from. Channel 9 is percussion
        protected int Channel;

        /// <summary>
        /// Send MIDI data
        /// </summary>
        public abstract void Send();
    }
}
