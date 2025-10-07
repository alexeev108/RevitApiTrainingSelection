using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitApiTrainingSelection
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApplication = commandData.Application;
            UIDocument uIDocument = uiApplication.ActiveUIDocument;
            Document document = uIDocument.Document;            

            FilteredElementCollector collector = new FilteredElementCollector(document);
            List<Element> levels = collector
                .OfClass(typeof(Level))
                .Cast<Element>()
                .ToList();

            var elementList = new List<Element>();
            foreach (Element el in collector)
            {
                if (el.Name == "Level 1")
                {
                    elementList.Add(el);
                }
                if (el.Name == "Level 2")
                {
                    elementList.Add(el);
                }
            }

            ElementId levelId_1 = elementList[0].Id;
            ElementId levelId_2 = elementList[1].Id;

            ElementLevelFilter level1Filter = new ElementLevelFilter(levelId_1);
            FilteredElementCollector collector_2 = new FilteredElementCollector(document);
            List<Element> allWallsOnLevel1 = collector_2
                .OfCategory(BuiltInCategory.OST_Walls)
                .WherePasses(level1Filter)
                .Cast<Element>()
                .ToList();
            ElementLevelFilter level2Filter = new ElementLevelFilter(levelId_2);
            FilteredElementCollector collector_3 = new FilteredElementCollector(document);
            List<Element> allWallsOnLevel2 = collector_3
                .OfCategory(BuiltInCategory.OST_Walls)
                .WherePasses(level2Filter)
                .Cast<Element>()
                .ToList();

            TaskDialog.Show("Количество стен на этажах:", $"Количество стен на 1 этаже: {allWallsOnLevel1.Count.ToString()}, {Environment.NewLine}" +
                $"Количество стен на 2 этаже: {allWallsOnLevel2.Count.ToString()}");

            return Result.Succeeded;
        }
    }
}
