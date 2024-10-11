using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_DZ_10_Dedok
{
    [Serializable]
    public class Song
    {
        public string Title { get; set; }
        public string Style { get; set; }
        public TimeSpan Duration { get; set; }

        public Song() { }

        public Song(string title, string style, TimeSpan duration)
        {
            Title = title;
            Style = style;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Style: {Style}, Duration: {Duration}";
        }
    }

    [Serializable]
    public class Album
    {
        public string Title { get; set; }
        public string Performer { get; set; }
        public int ReleaseYear { get; set; }
        public TimeSpan Duration { get; set; }
        public string Studio { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();

        public Album() { }
        public Album(string title, string performer, int releaseYear, TimeSpan duration, string studio)
        {
            Title = title;
            Performer = performer;
            ReleaseYear = releaseYear;
            Duration = duration;
            Studio = studio;
        }
        public override string ToString()
        {
            return $"Album: {Title}, Performer: {Performer}, Year: {ReleaseYear}, Duration: {Duration}, Studio: {Studio}, Songs: {string.Join("; ", Songs)}";
        }
    }
}
