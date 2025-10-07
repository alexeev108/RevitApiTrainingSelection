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

            //Поиск типов элементов
            //FilteredElementCollector collector = new FilteredElementCollector(document);
            //List<FamilySymbol> familySymbols = collector
            //    .OfCategory(BuiltInCategory.OST_Doors)
            //    .WhereElementIsElementType()
            //    .Cast<FamilySymbol>()
            //    .ToList();

            //TaskDialog.Show("Количество типов дверей:", familySymbols.Count.ToString());

            //Чтение параметров экземпляра
            //var selectedRef = uIDocument.Selection.PickObject(ObjectType.Element, "Выберете элемент");
            //var selectedElement = document.GetElement(selectedRef);
            //if (selectedElement is Wall)
            //{ 
            //    Parameter lengthParameter_1 = selectedElement.LookupParameter("Длина");
            //    if (lengthParameter_1.StorageType == StorageType.Double)
            //    {
            //        TaskDialog.Show("Длина1= ", lengthParameter_1.AsDouble().ToString());
            //    }
            //    Parameter lengthParameter_2 = selectedElement.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
            //    if (lengthParameter_2.StorageType == StorageType.Double)
            //    {
            //        TaskDialog.Show("Длина2= ", lengthParameter_2.AsDouble().ToString());
            //    }
            //}

            //Преобразование единиц измерения
            //var selectedRef = uIDocument.Selection.PickObject(ObjectType.Element, "Выберете элемент");
            //var selectedElement = document.GetElement(selectedRef);
            //if (selectedElement is Wall)
            //{             
            //    Parameter lengthParameter = selectedElement.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
            //    if (lengthParameter.StorageType == StorageType.Double)
            //    {
            //        double lengthValue = UnitUtils.ConvertFromInternalUnits(lengthParameter.AsDouble(), UnitTypeId.Meters);
            //        TaskDialog.Show("Длина2= ", lengthValue.ToString());
            //    }
            //}

            //Чтение параметров типа
            //var selectedRef = uIDocument.Selection.PickObject(ObjectType.Element, "Выберете элемент");
            //var selectedElement = document.GetElement(selectedRef);
            //if (selectedElement is FamilyInstance)
            //{
            //    var familyInstance = (FamilyInstance)selectedElement;
            //    Parameter lengthParameter_1 = familyInstance.LookupParameter("Ширина");
            //    TaskDialog.Show("Ширина1= ", lengthParameter_1.AsDouble().ToString());

            //    Parameter lengthParameter_2 = familyInstance.Symbol.get_Parameter(BuiltInParameter.CASEWORK_WIDTH);
            //    TaskDialog.Show("Ширина2= ", lengthParameter_2.AsDouble().ToString());

            //}

            //Запись параметров экземпляра и типа
            //var selectedRef = uIDocument.Selection.PickObject(ObjectType.Element, "Выберете элемент");
            //var selectedElement = document.GetElement(selectedRef);
            //if (selectedElement is FamilyInstance)
            //{
            //    using (Transaction ts = new Transaction(document, "Установка параметров"))
            //    {
            //        ts.Start();
            //        var familyInstance = selectedElement as FamilyInstance;
            //        Parameter commentParameter = familyInstance.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
            //        commentParameter.Set("TestComment");

            //        Parameter typeCommentParameter = familyInstance.Symbol.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_COMMENTS);
            //        typeCommentParameter.Set("TestTypeComment");
            //        ts.Commit();
            //    }    
            //}    



            return Result.Succeeded;
        }
    }
}
