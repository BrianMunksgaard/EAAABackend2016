using MbmStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MbmStore.Controllers
{
    /// <summary>
    /// Base controller class with methods used to retrieve and
    /// store the session state object in the HTTP session.
    /// </summary>
    public class SessionController : Controller
    {
        /// <summary>
        /// The current session state.
        /// </summary>
        protected SessionState CurrentSessionState
        {
            get
            {
                return LoadSessionState();
            }
        }

        /// <summary>
        /// Retrieve the current sessions state.
        /// </summary>
        /// <returns></returns>
        protected SessionState LoadSessionState()
        {
            SessionState sessionState = Session["SessionState"] as SessionState;
            if (sessionState == null)
            {
                sessionState = new SessionState();
                SaveSessionState(sessionState);
            }
            return sessionState;
        }

        /// <summary>
        /// Save the current session state.
        /// </summary>
        /// <param name="sessionState"></param>
        protected void SaveSessionState(SessionState sessionState)
        {
            Session["SessionState"] = sessionState;
        }
    }
}