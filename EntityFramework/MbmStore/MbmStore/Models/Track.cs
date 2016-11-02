using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models
{
    /// <summary>
    /// This class holds information about a
    /// single track on a CD.
    /// </summary>
    public class Track
    {
        #region PrivateFields

        private string title;
        private TimeSpan length;
        private string composer;

        #endregion

        #region Properties

        /// <summary>
        /// The track title.
        /// </summary>
        public string Title
        {
            get { return title == null ? string.Empty : title; }
            set { title = value; }
        }

        /// <summary>
        /// The length of the track.
        /// </summary>
        public TimeSpan Length
        {
            get { return length == null ? new TimeSpan(0) : length; }
            set { length = value; }
        }


        /// <summary>
        /// The track composer.
        /// </summary>
        public string Composer
        {
            get { return composer == null ? string.Empty : composer; }
            set { composer = value; }
        }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Track() { }

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="title"></param>
        public Track(string title)
        {
            this.title = title;
        }

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="length"></param>
        /// <param name="composer"></param>
        public Track(string title, TimeSpan length, string composer)
        {
            this.title = title;
            this.length = length;
            this.composer = composer;
        }
    }
}