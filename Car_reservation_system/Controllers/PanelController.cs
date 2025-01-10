﻿﻿using Microsoft.AspNetCore.Mvc;

namespace Car_reservation_system.Controllers
{
    public class PanelController : Controller
    {
        public ActionResult ChangePanel(string panelType)
        {
            // Zapisz wybór panelu w pliku cookie
            HttpContext.Response.Cookies.Append("PanelType", panelType);

            // Możesz przekierować na dowolną akcję lub inną stronę
            return Redirect("/Cars/MyReservations");
        }
    }
}
