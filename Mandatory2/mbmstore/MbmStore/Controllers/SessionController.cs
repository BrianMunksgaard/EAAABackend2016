using MbmStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    /// <summary>
    /// Base controller class with methods used to retrieve and
    /// store the session state object in the HTTP session.
    /// </summary>
    public class SessionController : Controller
    {
        /// <summary>
        /// Retrieve the current sessions state.
        /// </summary>
        /// <returns></returns>
        protected SessionState GetSessionState()
        {
            SessionState sessionState = Session["SessionState"] as SessionState;
            if (sessionState == null)
            {
                sessionState = new SessionState();
                Session["SessionState"] = sessionState;
            }
            return sessionState;
        }

        /// <summary>
        /// Save the current session state.
        /// </summary>
        /// <param name="sessionState"></param>
        protected void SetSessionState(SessionState sessionState)
        {
            Session["SessionState"] = sessionState;
        }
    }
}