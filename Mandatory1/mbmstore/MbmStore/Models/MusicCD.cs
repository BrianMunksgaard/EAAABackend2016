using System;
using System.Collections.Generic;
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
            get { return tracks == null ? new List<Track>() :  tracks; }
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
    }
}