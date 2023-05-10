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

            // get all the schedules
            // split the schedule name on the space after the last title word
            // if the next 3 characters are "- E" do nothing
            // if not get the first character that is a letter and set it = to curElev
            // and replace the string after the space with "Elevation " + curElev

            // create lists for schedules by name
            List<ViewSchedule> veneerList = Utils.GetScheduleByNameContains(doc, "Exterior Veneer Calculations");
            List<ViewSchedule> floorList = Utils.GetScheduleByNameContains(doc, "Floor Areas");
            List<ViewSchedule> frameList = Utils.GetScheduleByNameContains(doc, "Frame Areas");
            List<ViewSchedule> atticList = Utils.GetScheduleByNameContains(doc, "Roof Ventilation Calculations");
            List<ViewSchedule> equipmentList = Utils.GetScheduleByNameContains(doc, "Roof Ventilation Equipment");
            List<ViewSchedule> indexList = Utils.GetScheduleByNameContains(doc, "Sheet Index");

            using (Transaction t = new Transaction(doc))
            {
                t.Start("Rename Schedules");

                foreach (ViewSchedule curSchedule in veneerList)
                {
                    string originalString = curSchedule.Name;

                    string schedTitle = originalString.Substring(0, 28);
                    string schedElev = originalString.Substring(29);

                    int elevIndex = Utils.GetIndexOfFirstLetter(schedElev);

                    string curElev = schedElev.Substring(elevIndex, 1);

                    if (curElev != "E")
                    {
                        // replace schedElev with "- Elevation " + curElev
                        curSchedule.Name = schedTitle + " - Elevation " + curElev;
                    }
                }

                foreach (ViewSchedule curSchedule in floorList)
                {
                    string originalString = curSchedule.Name;

                    string schedTitle = originalString.Substring(0, 11);
                    string schedElev = originalString.Substring(12);

                    int elevIndex = Utils.GetIndexOfFirstLetter(schedElev);

                    string curElev = schedElev.Substring(elevIndex, 1);

                    if (curElev != "E")
                    {
                        // replace schedElev with "- Elevation " + curElev
                        curSchedule.Name = schedTitle + " - Elevation " + curElev;
                    }
                }

                foreach (ViewSchedule curSchedule in frameList)
                {
                    string originalString = curSchedule.Name;

                    string schedTitle = originalString.Substring(0, 10);
                    string schedElev = originalString.Substring(11);

                    int elevIndex = Utils.GetIndexOfFirstLetter(schedElev);

                    string curElev = schedElev.Substring(elevIndex, 1);

                    if (curElev != "E")
                    {
                        // replace schedElev with "- Elevation " + curElev
                        curSchedule.Name = schedTitle + " - Elevation " + curElev;
                    }                    
                }

                foreach (ViewSchedule curSchedule in atticList)
                {
                    string originalString = curSchedule.Name;

                    string schedTitle = originalString.Substring(0, 29);
                    string schedElev = originalString.Substring(30);

                    int elevIndex = Utils.GetIndexOfFirstLetter(schedElev);

                    string curElev = schedElev.Substring(elevIndex, 1);

                    if (curElev != "E")
                    {
                        // replace schedElev with "- Elevation " + curElev
                        curSchedule.Name = schedTitle + " - Elevation " + curElev;
                    }
                }

                foreach (ViewSchedule curSchedule in equipmentList)
                {
                    string originalString = curSchedule.Name;

                    string schedTitle = originalString.Substring(0, 27);
                    string schedElev = originalString.Substring(28);

                    int elevIndex = Utils.GetIndexOfFirstLetter(schedElev);

                    string curElev = schedElev.Substring(elevIndex, 1);

                    if (curElev != "E")
                    {
                        // replace schedElev with "- Elevation " + curElev
                        curSchedule.Name = schedTitle + " - Elevation " + curElev;
                    }
                }

                foreach (ViewSchedule curSchedule in indexList)
                {
                    string originalString = curSchedule.Name;

                    string schedTitle = originalString.Substring(0, 11);
                    string schedElev = originalString.Substring(12);

                    int elevIndex = Utils.GetIndexOfFirstLetter(schedElev);

                    string curElev = schedElev.Substring(elevIndex, 1);

                    if (curElev != "E")
                    {
                        // replace schedElev with "- Elevation " + curElev
                        curSchedule.Name = schedTitle + " - Elevation " + curElev;
                    }
                }

                t.Commit();
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
