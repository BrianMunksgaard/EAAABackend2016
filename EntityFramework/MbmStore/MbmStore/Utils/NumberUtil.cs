using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Utils
{
    public class NumberUtil
    {
        #region PrivateFields

        /// <summary>
        /// Singleton reference,
        /// </summary>
        private static NumberUtil instance;

        /// <summary>
        /// Dummy object used as lock.
        /// </summary>
        private static object lockObject = new object();

        /// <summary>
        /// Internal unique number.
        /// </summary>
        private int uniqueNumber;

        #endregion

        #region Properties

        /// <summary>
        /// Returns the next number.
        /// </summary>
        public int UniqueNumber
        {
            get
            {
                return ++uniqueNumber;
            }
        }

        #endregion

        /// <summary>
        /// Returns an instance reference.
        /// </summary>
        public static NumberUtil Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new NumberUtil();
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        public NumberUtil()
        {
            uniqueNumber = 0;
        }
    }
}