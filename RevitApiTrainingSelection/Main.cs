using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
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
           
            FilteredElementCollector collector = new FilteredElementCollector(document, document.ActiveView.Id);
            var pipes = collector.OfClass(typeof(Pipe)).Cast<Pipe>().ToList();
            TaskDialog.Show("Количество труб:", pipes.Count.ToString());

            return Result.Succeeded;
        }
    }
}
