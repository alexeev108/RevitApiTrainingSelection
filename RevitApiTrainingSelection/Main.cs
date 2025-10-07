using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
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

            IList<Reference> selectedElementsRefList = uIDocument.Selection.PickObjects(ObjectType.Element, "Выберите элементы");
            var elementList = new List<Element>();

            double info = 0;
            foreach (var selectedElement in selectedElementsRefList)
            {                
                Element element = document.GetElement(selectedElement);
                if (element is Pipe)
                {
                    Parameter parameterLength = element.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
                    if (parameterLength.StorageType is StorageType.Double)
                    {
                        double lengthValue = UnitUtils.ConvertFromInternalUnits(parameterLength.AsDouble(), UnitTypeId.Meters);
                        info += lengthValue;
                    }
                }                              
            }
            TaskDialog.Show($"Общая длина выбранных труб:", $"{Math.Round(info, 2).ToString()} м");

            return Result.Succeeded;
        }
    }
}
