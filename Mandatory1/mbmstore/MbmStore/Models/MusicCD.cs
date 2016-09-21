using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MbmStore.Models
{
    /// <summary>
    /// This class is used to hold information
    /// about a CD in the store.
    /// </summary>
    public class MusicCD : Product
    {
        #region

        private Random r = new Random();

        private string artist;
        private string label;
        private short released;
        private List<Track> tracks;

        #endregion

        #region Properties

        /// <summary>
        /// The music artist.
        /// </summary>
        public string Artist
        {
            get { return artist == null ? string.Empty : artist; }
            set { artist = value; }
        }

        /// <summary>
        /// The CD/record label.
        /// </summary>
        public string Label
        {
            get { return label == null ? string.Empty : label; }
            set { label = value; }
        }

        /// <summary>
        /// The CD release year.
        /// </summary>
        public short Released
        {
            get { return released; }
            set { released = value; }
        }

        /// <summary>
        /// CD tracks.
        /// </summary>
        public List<Track> Tracks
        {
            get { return tracks == null ? tracks = new List<Track>() :  tracks; }
        }

        /// <summary>
        /// Returns CD total play time.
        /// </summary>
        public TimeSpan TotalPlayTime
        {
            get
            {
                TimeSpan t;
                t = Tracks.Aggregate(TimeSpan.Zero, (totalPlayTime, nextItem) => totalPlayTime.Add(nextItem.Length));
                return t;
            }
        }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MusicCD() { }

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="title"></param>
        /// <param name="price"></param>
        /// <param name="released"></param>
        public MusicCD(string artist, string title, decimal price, short released) : base(title, price)
        {
            this.artist = artist;
            this.released = released;
        }

        /// <summary>
        /// Add a track to the CD.
        /// </summary>
        /// <param name="track"></param>
        public void AddTrack(Track track)
        {
            Tracks.Add(track);
        }

        /// <summary>
        /// Add a track to the CD.
        /// Use random timespan for track length and
        /// artist name as track composer.
        /// </summary>
        /// <param name="track"></param>
        public void AddTrack(string track)
        {
            AddTrack(new Track(track, GetRandomTimeSpan(), Artist));
        }

        /// <summary>
        /// Add a track to the CD.
        /// </summary>
        /// <param name="track"></param>
        /// <param name="length"></param>
        /// <param name="composer"></param>
        public void AddTrack(string track, string length, string composer)
        {
            int pos = length.IndexOf(':');
            int minutes = int.Parse(length.Substring(0, pos));
            int seconds = int.Parse(length.Substring(pos + 1));
            TimeSpan t = new TimeSpan(0, minutes, seconds);
            AddTrack(new Track(track, t, composer));
        }

        /// <summary>
        /// Generate random timespan.
        /// </summary>
        /// <returns></returns>
        private TimeSpan GetRandomTimeSpan()
        {
            int minutes = r.Next(1, 10);
            int seconds = r.Next(0, 60);
            TimeSpan t = new TimeSpan(0, minutes, seconds);
            return t;
        }
    }
}