using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryWindow : Singleton<InventoryWindow>
{
    private VisualElement element;
    private VisualElement frame;
    private VisualElement window;
    private VisualElement outside;
    private List<Action> closeActionList;

    public InventoryWindow()
    {
        closeActionList = new();
        InitElement();
    }

    public VisualElement GetElement()
    {
        OpenAnimate();
        return element;
    }

    private void InitElement()
    {
        string path = "UI/Inventory/Element/InventoryWindowView";
        var template = Resources.Load<VisualTreeAsset>(path);
        element = template.Instantiate();
        element.AddToClassList("inven-window");

        window = element.Q<VisualElement>("Window");
        frame = element.Q<VisualElement>("Frame");
        outside = element.Q<VisualElement>("Outside");
        outside.RegisterCallback<PointerUpEvent>(OnClose);
    }

    private async void OnClose(PointerUpEvent point)
    {
        window.style.height = 0;
        await Task.Delay(500);
        foreach (Action action in closeActionList)
        {
            action();
        }
    }

    public void AddOnClose(Action action)
    {
        closeActionList.Add(action);
    }

    private async void OpenAnimate()
    {
        window.style.height = 0;
        await Task.Delay(10);
        window.style.height = StyleKeyword.Null;
    }
}
