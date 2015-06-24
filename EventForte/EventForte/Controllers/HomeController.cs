using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventForte.Models;
using System.Data.Entity.Core.Objects;

namespace EventForte.Controllers
{
    public class HomeController : Controller
    {
        EventDataContext eve = new EventDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            ViewBag.EventType = eve.EventTypes.ToList();
           // if ( Session["test"] == null)
             //   GetEventforDashboard();
            GetYear();
            return View();
        }

        public void GetYear()
        {
            var varyear = eve.GetYear();
            ViewBag.varyear = varyear.ToList();
                          
        }

        public void GetImage()
        {
            var EventVar = from e in eve.Events
                           where e.OrganizerId == 1 //&& e.RequestDeleted == false
                           select e.ImageURL;

            ViewBag.EventVar = EventVar.ToList();
        }


        public ActionResult DeleteEvent(string EventIds)
        {
            string strEvent = "";
            strEvent = EventIds;
            if (EventIds.Contains("on"))
            {
                strEvent = EventIds.Remove(0,3).ToString();
            }

            eve.sp_DeleteEvent(strEvent);
            //return PartialView("_PartialEventView");
            return RedirectToAction("GetEventforDashboard");
        }

        public ActionResult GetEventForCategory(string typeid)
        {
            int yearname = 0;
            int type = 0;
            yearname = Convert.ToInt32(Session["year"].ToString());
            if (typeid.Length > 0)
                type = Convert.ToInt32(typeid);
            else
                return RedirectToAction("GetEventforDashboard");

            var EventCollaborator = eve.sp_GetCollaborator(1);
            ViewBag.EventCollaborator = EventCollaborator.ToList();

            var EventVarDataJan = eve.sp_SearchEventOnCategory(1, 1, yearname, type);
            ViewBag.EventVarDataJan = EventVarDataJan.ToList();

            var EventVarDataFeb = eve.sp_SearchEventOnCategory(1, 2, yearname, type);
            ViewBag.EventVarDataFeb = EventVarDataFeb.ToList();

            var EventVarDataMarch = eve.sp_SearchEventOnCategory(1, 3, yearname, type);
            ViewBag.EventVarDataMarch = EventVarDataMarch.ToList();

            var EventVarDataApr = eve.sp_SearchEventOnCategory(1, 4, yearname, type);
            ViewBag.EventVarDataApr = EventVarDataApr.ToList();

            var EventVarDataMay = eve.sp_SearchEventOnCategory(1, 5, yearname, type);
            ViewBag.EventVarDataMay = EventVarDataMay.ToList();

            var EventVarDataJune = eve.sp_SearchEventOnCategory(1, 6, yearname, type);
            ViewBag.EventVarDataJune = EventVarDataJune.ToList();

            var EventVarDataJuly = eve.sp_SearchEventOnCategory(1, 7, yearname, type);
            ViewBag.EventVarDataJuly = EventVarDataJuly.ToList();

            var EventVarDataAug = eve.sp_SearchEventOnCategory(1, 8, yearname, type);
            ViewBag.EventVarDataAug = EventVarDataAug.ToList();

            var EventVarDataSep = eve.sp_SearchEventOnCategory(1, 9, yearname, type);
            ViewBag.EventVarDataSep = EventVarDataSep.ToList();

            var EventVarDataOct = eve.sp_SearchEventOnCategory(1, 10, yearname, type);
            ViewBag.EventVarDataOct = EventVarDataOct.ToList();

            var EventVarDataNov = eve.sp_SearchEventOnCategory(1, 11, yearname, type);
            ViewBag.EventVarDataNov = EventVarDataNov.ToList();

            var EventVarDataDec = eve.sp_SearchEventOnCategory(1, 12, yearname, type);
            ViewBag.EventVarDataDec = EventVarDataDec.ToList();

            return PartialView("_PartialEventView");
        }


        public ActionResult GetMyEvents(string status)
        {
            //status = 'I';
            if (status == "Invited")
            {
                var varGetEvents = eve.sp_GetGuestStatus(1, 'I');
                ViewBag.EventId = varGetEvents.ToList();
            }

            if(status == "Attending")
            {
                var varGetEvents = eve.sp_GetGuestStatus(1, 'A');
                ViewBag.EventId = varGetEvents.ToList();
            }

            if (status == "Organizing")
            {
                //var varGetEvents = eve.sp_GetGuestStatus(1, 'A');
                //ViewBag.EventId = varGetEvents.ToList();
                return RedirectToAction("GetEventforDashboard");
            }

            string eventids = "";
            foreach (var eventid in ViewBag.EventId)
            {
                eventids += Convert.ToString(eventid.eventid) + ',';
            }

            if (eventids.Length > 0)
            {
                eventids = eventids.Remove(eventids.Length - 1, 1);

                var EventCollaborator = eve.sp_GetCollaboratorForMyEvents(eventids);
                ViewBag.EventCollaborator = EventCollaborator.ToList();

                var EventVarDataJan = eve.sp_GetEventsForMyEvents(eventids, "1");
                ViewBag.EventVarDataJan = EventVarDataJan.ToList();

                var EventVarDataFeb = eve.sp_GetEventsForMyEvents(eventids, "2");
                ViewBag.EventVarDataFeb = EventVarDataFeb.ToList();

                var EventVarDataMarch = eve.sp_GetEventsForMyEvents(eventids, "3");
                ViewBag.EventVarDataMarch = EventVarDataMarch.ToList();

                var EventVarDataApr = eve.sp_GetEventsForMyEvents(eventids, "4");
                ViewBag.EventVarDataApr = EventVarDataApr.ToList();

                var EventVarDataMay = eve.sp_GetEventsForMyEvents(eventids, "5");
                ViewBag.EventVarDataMay = EventVarDataMay.ToList();

                var EventVarDataJune = eve.sp_GetEventsForMyEvents(eventids, "6");
                ViewBag.EventVarDataJune = EventVarDataJune.ToList();

                var EventVarDataJuly = eve.sp_GetEventsForMyEvents(eventids, "7");
                ViewBag.EventVarDataJuly = EventVarDataJuly.ToList();

                var EventVarDataAug = eve.sp_GetEventsForMyEvents(eventids, "8");
                ViewBag.EventVarDataAug = EventVarDataAug.ToList();

                var EventVarDataSep = eve.sp_GetEventsForMyEvents(eventids, "9");
                ViewBag.EventVarDataSep = EventVarDataSep.ToList();

                var EventVarDataOct = eve.sp_GetEventsForMyEvents(eventids, "10");
                ViewBag.EventVarDataOct = EventVarDataOct.ToList();

                var EventVarDataNov = eve.sp_GetEventsForMyEvents(eventids, "11");
                ViewBag.EventVarDataNov = EventVarDataNov.ToList();

                var EventVarDataDec = eve.sp_GetEventsForMyEvents(eventids, "12");
                ViewBag.EventVarDataDec = EventVarDataDec.ToList();
            }
            
           // var varGetEventByEventId = new List<sp_GetEventByEventIdResult>();
           // List<sp_GetEventByEventIdResult> varGetEventByEventId = new List<sp_GetEventByEventIdResult>();
            //ViewBag.EventVarDataDec = new List<sp_GetEventByEventIdResult>();
            //ViewBag.EventVarDataNov = new List<sp_GetEventByEventIdResult>();
            //ViewBag.EventVarDataOct = new List<sp_GetEventByEventIdResult>();
            //ViewBag.EventVarDataSep = new List<sp_GetEventByEventIdResult>();
            //ViewBag.EventVarDataAug = new List<sp_GetEventByEventIdResult>();
            //ViewBag.EventVarDataJuly = new List<sp_GetEventByEventIdResult>();
            ////ViewBag.EventVarDataJune = new List<sp_GetEventByEventIdResult>();
            //ViewBag.EventVarDataMay = new List<sp_GetEventByEventIdResult>();
            //ViewBag.EventVarDataApr = new List<sp_GetEventByEventIdResult>();
            //ViewBag.EventVarDataMar = new List<sp_GetEventByEventIdResult>();
            //ViewBag.EventVarDataFeb = new List<sp_GetEventByEventIdResult>();
            //ViewBag.EventVarDataJan = new List<sp_GetEventByEventIdResult>();

            //foreach (var eventid in ViewBag.EventId)
            //{
            //    var varGetEventByEventId = eve.sp_GetEventByEventId(Convert.ToInt32(eventid.eventid));
            //    ViewBag.GetEvents = varGetEventByEventId;

            //    foreach (var v in varGetEventByEventId)
            //    {
            //        string Month = v.FromDate.Month.ToString();
            //        string Year = v.FromDate.Year.ToString();
            //        switch (Month)
            //        {
            //            case "1":
            //                ViewBag.EventVarDataJan += varGetEventByEventId;
            //                break;
            //            case "2":
            //                ViewBag.EventVarDataFeb += varGetEventByEventId;
            //                break;
            //            case "3":
            //                ViewBag.EventVarDataMar += varGetEventByEventId;
            //                break;
            //            case "4":
            //                ViewBag.EventVarDataApr += varGetEventByEventId;
            //                break;
            //            case "5":
            //                ViewBag.EventVarDataMay += varGetEventByEventId;
            //                break;
            //            case "6":
            //                ViewBag.EventVarDataJune = varGetEventByEventId;
            //                break;
            //            case "7":
            //                ViewBag.EventVarDataJuly += varGetEventByEventId;
            //                break;
            //            case "8":
            //                ViewBag.EventVarDataAug += varGetEventByEventId;
            //                break;
            //            case "9":
            //                ViewBag.EventVarDataSep += varGetEventByEventId;
            //                break;
            //            case "10":
            //                ViewBag.EventVarDataOct += varGetEventByEventId;
            //                break;
            //            case "11":
            //                ViewBag.EventVarDataNov += varGetEventByEventId;
            //                break;
            //            case "12":
            //                ViewBag.EventVarDataDec += varGetEventByEventId;
            //                break;
            //        }
            //    }


           // }
            else
            {
                ViewBag.EventVarDataDec = "";
                ViewBag.EventVarDataNov = "";
                ViewBag.EventVarDataOct = "";
                ViewBag.EventVarDataSep = "";
                ViewBag.EventVarDataAug = "";
                ViewBag.EventVarDataJuly = "";
                ViewBag.EventVarDataJune = "";
                ViewBag.EventVarDataMay = "";
                ViewBag.EventVarDataApr = "";
                ViewBag.EventVarDataMarch = "";
                ViewBag.EventVarDataFeb = "";
                ViewBag.EventVarDataJan = "";
            }
            return PartialView("_PartialEventView");

        }

         public ActionResult GetEventforDashboard(string name)
         {
                             
             //int yearname = 0;

             //if (Request["name"] == null)
             //{
             //    var varyear = eve.GetYear();
             //    foreach (var v in varyear)
             //    {
             //        yearname = Convert.ToInt32(v.memdate);
             //        break;
             //    }
             //    Session["test"] = "test";
             //}


             //if (Request["name"] != null)
             //    yearname = Convert.ToInt32(Request["name"].ToString());
             int yearname = 0;
             if ((Session["year"]) != null)
             {
                 if (name == "")
                     yearname = Convert.ToInt32(Session["year"].ToString());
                 if(name == null)
                     yearname = Convert.ToInt32(Session["year"].ToString());
             }
             else
             {

                 if (name == "")
                 {
                     var varyear = eve.GetYear();
                     foreach (var v in varyear)
                     {
                         yearname = Convert.ToInt32(v.memdate);
                         break;
                     }
                 }

                 
             }
             if (name != "" && name != null)
             {
                 yearname = Convert.ToInt32(name);
             }

             if(name != null && yearname != 0)
                 Session["year"] = yearname;

             var EventCollaborator = eve.sp_GetCollaborator(1);
             ViewBag.EventCollaborator = EventCollaborator.ToList();
             
             var EventVarDataJan = eve.sp_GetEventForMember(1, 1, yearname);
             ViewBag.EventVarDataJan = EventVarDataJan.ToList();

             var EventVarDataFeb = eve.sp_GetEventForMember(1, 2, yearname);
             ViewBag.EventVarDataFeb = EventVarDataFeb.ToList();

             var EventVarDataMarch = eve.sp_GetEventForMember(1, 3, yearname);
             ViewBag.EventVarDataMarch = EventVarDataMarch.ToList();
             
             var EventVarDataApr = eve.sp_GetEventForMember(1, 4, yearname);
             ViewBag.EventVarDataApr = EventVarDataApr.ToList();

             var EventVarDataMay = eve.sp_GetEventForMember(1, 5, yearname);
             ViewBag.EventVarDataMay = EventVarDataMay.ToList();

             var EventVarDataJune = eve.sp_GetEventForMember(1, 6, yearname);
             ViewBag.EventVarDataJune = EventVarDataJune.ToList();

             var EventVarDataJuly = eve.sp_GetEventForMember(1, 7, yearname);
             ViewBag.EventVarDataJuly = EventVarDataJuly.ToList();

             var EventVarDataAug = eve.sp_GetEventForMember(1, 8, yearname);
             ViewBag.EventVarDataAug = EventVarDataAug.ToList();

             var EventVarDataSep = eve.sp_GetEventForMember(1, 9, yearname);
             ViewBag.EventVarDataSep = EventVarDataSep.ToList();

             var EventVarDataOct = eve.sp_GetEventForMember(1, 10, yearname);
             ViewBag.EventVarDataOct = EventVarDataOct.ToList();

             var EventVarDataNov = eve.sp_GetEventForMember(1, 11, yearname);
             ViewBag.EventVarDataNov = EventVarDataNov.ToList();

             var EventVarDataDec = eve.sp_GetEventForMember(1, 12, yearname);
             ViewBag.EventVarDataDec = EventVarDataDec.ToList();
             return PartialView("_PartialEventView");
         }

       

    }

}