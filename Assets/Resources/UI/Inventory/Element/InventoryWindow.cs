using UnityEngine;
using UnityEngine.UIElements;

public class InventoryWindow : Singleton<InventoryWindow>
{
    private VisualElement element;

    public InventoryWindow()
    {
        string path = "UI/Inventory/Element/InventoryWindowView";
        var template = Resources.Load<VisualTreeAsset>(path);
        element = template.Instantiate();
        element.AddToClassList("inven-window");
    }

    public VisualElement GetElement()
    {
        return element;
    }
}
