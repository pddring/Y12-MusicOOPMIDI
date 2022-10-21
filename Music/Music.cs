using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Music
{
    class Music
    {
        List<MusicalNotation> Notes = new List<MusicalNotation>();
        public void Play()
        {
            Console.WriteLine($"Playing...");
            foreach(MusicalNotation n in Notes)
            {
                n.Play();
                if(n.GetType().Name == "Note")
                {
                    Note note = (Note)n;
                    Console.WriteLine($"Playing note: {note.NoteNumber} for {n.Duration} beat(s)");
                } else
                {
                    Console.WriteLine($"Resting for {n.Duration} beats");
                }
                //Console.WriteLine($"Playing note: {n.NoteNumber} for {n.Duration} beat(s)");
            }
        }

        public int NoteToNumber(char noteName, bool flat, bool sharp, int octave)
        {
            int noteNumber = 0;
            switch (noteName)
            {
                case 'C':
                    noteNumber = 0;
                    break;
                case 'D':
                    noteNumber = 2;
                    break;
                case 'E':
                    noteNumber = 4;
                    break;
                case 'F':
                    noteNumber = 5;
                    break;
                case 'G':
                    noteNumber = 7;
                    break;
                case 'A':
                    noteNumber = 9;
                    break;
                case 'B':
                    noteNumber = 11;
                    break;
            }

            // decrease if flat
            if (flat)
            {
                noteNumber--;
            }

            // increase if sharp
            if(sharp)
            {
                noteNumber++;
            }

            return noteNumber + (octave * 12);
        }

        public Music(string Filename)
        {
            Console.WriteLine($"Loading file from {Filename}");
            // load from the file
            /*
             * example: 
// C major scale
C4 D E F G A B C5:2

// F major scale
F4 G A Bb C5 D E F:2

// G major scale
G A B C D E F# G:2
             * */
            string fileContents = File.ReadAllText(Filename);

            // remove the comments
            fileContents = Regex.Replace(fileContents, @"\/\/.*", "");

            int octave = 4;
            // extract the notes
            foreach(Match m in Regex.Matches(fileContents, @"([A-G])?([b#])?(\d)*(:(\d))?"))
            {
                // get the note name
                string note = m.Groups[1].Value;

                // decide if it's a note or rest
                if (note.Length > 0)
                {

                    // get the octave
                    if (m.Groups[3].Value.Length > 0)
                    {
                        octave = int.Parse(m.Groups[3].Value);
                    }

                    // get flat or sharp
                    bool flat = m.Groups[2].Value == "b";
                    bool sharp = m.Groups[2].Value == "#";

                    Note n = new Note();
                    n.NoteNumber = NoteToNumber(note[0], flat, sharp, octave);
                    n.Duration = 1;
                    if (m.Groups[5].Value.Length > 0)
                    {
                        n.Duration = int.Parse(m.Groups[5].Value);
                    }

                    Notes.Add(n);
                } else
                {
                    // rest
                    Rest r = new Rest();
                    r.Duration = 1;
                    if (m.Groups[5].Value.Length > 0)
                    {
                        r.Duration = int.Parse(m.Groups[5].Value);
                        Notes.Add(r);
                    }
                    
                }
                //Console.WriteLine($"Note: {note} Octave: {octave}: Number: {n.NoteNumber} Duration: {n.Duration}");
            }
            //Console.WriteLine(fileContents);


        }
    }
}
