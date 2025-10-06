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

            //Выбор элемента целиком, по грани
            //Reference selectedElementref = uIDocument.Selection.PickObject(ObjectType.Edge, "Выберите элемент по грани");
            //Element element = document.GetElement(selectedElementref);

            //TaskDialog.Show("Selection", $"Имя: {element.Name}{Environment.NewLine}id: {element.Id}");

            //Выбор нескольких элементов
            //IList<Reference> selectedElementsRefList = uIDocument.Selection.PickObjects(ObjectType.Element, "Выберите элементы");
            //var elementList = new List<Element>();

            //foreach (var selectedElement in selectedElementsRefList) 
            //{
            //    Element element = document.GetElement(selectedElement);
            //    elementList.Add(element);
            //}

            //TaskDialog.Show("Selection", $"Количество: {elementList.Count}");

            //Реализация ISelectionFilter
            //IList<Reference> selectedElementsRefList = uIDocument.Selection.PickObjects(ObjectType.Element, new WallFilter(), "Выберите стены");
            //var elementWall = new List<Wall>();

            //string info = string.Empty;
            //foreach (var selectedElement in selectedElementsRefList)
            //{
            //    Wall wall = document.GetElement(selectedElement) as Wall;                                
            //    elementWall.Add(wall);
            //    var width = UnitUtils.ConvertFromInternalUnits(wall.Width, UnitTypeId.Millimeters);
            //    info += $"Имя: {wall.Name}, Ширина: {width}{Environment.NewLine}";
            //}

            //info += $"Количество: {elementWall.Count}";

            //TaskDialog.Show("Selection", info);

            //Выбор точки
            //XYZ pickdot = null;
            //try
            //{
            //    pickdot = uIDocument.Selection.PickPoint(ObjectSnapTypes.Endpoints, "Выберете точку");
            //}
            //catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            //{ }

            //if (pickdot == null)
            //    return Result.Cancelled;            

            //TaskDialog.Show("Point info", $"X: {UnitUtils.ConvertFromInternalUnits(pickdot.X, UnitTypeId.Millimeters)},{Environment.NewLine}" +
            //    $"Y: {UnitUtils.ConvertFromInternalUnits(pickdot.Y, UnitTypeId.Millimeters)}");

            //Поиск элементов по категории
            //FilteredElementCollector collector = new FilteredElementCollector(document);
            //List<FamilyInstance> familyInstances = collector
            //    .OfCategory(BuiltInCategory.OST_Doors)
            //    .WhereElementIsNotElementType()
            //    .Cast<FamilyInstance>()
            //    .ToList();
            //TaskDialog.Show("Количество дверей:", familyInstances.Count.ToString());

            //Поиск элементов по категории на активном виде
            //FilteredElementCollector collector = new FilteredElementCollector(document, document.ActiveView.Id);
            //List<FamilyInstance> familyInstances = collector
            //    .OfCategory(BuiltInCategory.OST_Doors)
            //    .WhereElementIsNotElementType()
            //    .Cast<FamilyInstance>()
            //    .ToList();
            //TaskDialog.Show("Количество дверей:", familyInstances.Count.ToString());

            //Поиск элементов по классу
            //var walls = new FilteredElementCollector(document).OfClass(typeof(Wall)).Cast<Wall>().ToList();
            //TaskDialog.Show("Количество стен:", walls.Count.ToString());

            //Поиск элементов по нескольким условиям
            //ElementCategoryFilter elementCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_Windows);
            //ElementClassFilter elementClassFilter = new ElementClassFilter(typeof(FamilyInstance));

            //LogicalAndFilter logicalAndFilter = new LogicalAndFilter(elementCategoryFilter, elementClassFilter);

            //var windows = new FilteredElementCollector(document).WherePasses(logicalAndFilter).Cast<FamilyInstance>().ToList();

            //TaskDialog.Show("Количество окон:", windows.Count.ToString());

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
