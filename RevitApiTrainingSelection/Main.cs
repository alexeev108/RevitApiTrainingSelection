using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
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

            int info = 0;
            FilteredElementCollector collector = new FilteredElementCollector(document);
            List<FamilyInstance> familyInstances_1 = collector
                .OfCategory(BuiltInCategory.OST_Columns)
                .WhereElementIsNotElementType()
                .Cast<FamilyInstance>()
                .ToList();
            info += familyInstances_1.Count;
            FilteredElementCollector collector_2 = new FilteredElementCollector(document);
            List<FamilyInstance> familyInstances_2 = collector_2
                .OfCategory(BuiltInCategory.OST_StructuralColumns)
                .WhereElementIsNotElementType()
                .Cast<FamilyInstance>()
                .ToList();
            info += familyInstances_2.Count;
            
            TaskDialog.Show("Количество колонн:", info.ToString());

            return Result.Succeeded;
        }
    }
}
