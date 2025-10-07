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

            IList<Reference> selectedElementsRefList = uIDocument.Selection.PickObjects(ObjectType.Edge, "Выберите элементы по грани");
            var elementList = new List<Element>();

            double info = 0;
            foreach (var selectedElement in selectedElementsRefList)
            {                
                Element element = document.GetElement(selectedElement);
                if (element is Wall)
                {
                    Parameter parameterVolume = element.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED);
                    if (parameterVolume.StorageType is StorageType.Double)
                    {
                        double volumeValue = UnitUtils.ConvertFromInternalUnits(parameterVolume.AsDouble(), UnitTypeId.Meters);
                        info += volumeValue;
                    }
                }                              
            }
            TaskDialog.Show("Объем выбранных стен:", info.ToString());

            return Result.Succeeded;
        }
    }
}
