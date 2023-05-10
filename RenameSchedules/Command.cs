#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

#endregion

namespace RenameSchedules
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // create lists for schedules by name
            List<ViewSchedule> veneerList = Utils.GetScheduleByNameContains(doc, "Exterior Veneer Calculations");
            List<ViewSchedule> floorList = Utils.GetScheduleByNameContains(doc, "Floor Areas");
            List<ViewSchedule> frameList = Utils.GetScheduleByNameContains(doc, "Frame Areas");
            List<ViewSchedule> atticList = Utils.GetScheduleByNameContains(doc, "Roof Ventilation Calculations");
            List<ViewSchedule> equipmentList = Utils.GetScheduleByNameContains(doc, "Roof Ventilation Equipment");
            List<ViewSchedule> indexList = Utils.GetScheduleByNameContains(doc, "Sheet Index");

            // set split point

            foreach (ViewSchedule curSchedule in veneerList)
            {
                int stringLength = curSchedule.ToString().Length;

                // split start = index 28
                // split end = length - 28
            }

            foreach (ViewSchedule curSchedule in floorList)
            {
                int stringLength = curSchedule.ToString().Length;

                // split start = index 11
                // split end = length - 11
            }







            return Result.Succeeded;
        }

        public static String GetMethod()
        {
            var method = MethodBase.GetCurrentMethod().DeclaringType?.FullName;
            return method;
        }
    }
}
