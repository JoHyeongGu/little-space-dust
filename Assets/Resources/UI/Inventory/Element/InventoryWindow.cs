using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryWindow : Singleton<InventoryWindow>
{
    private VisualElement element;
    private List<Action> closeActionList;

    public InventoryWindow()
    {
        closeActionList = new();
        InitElement();
    }

    public VisualElement GetElement()
    {
        return element;
    }

    private void InitElement()
    {
        string path = "UI/Inventory/Element/InventoryWindowView";
        var template = Resources.Load<VisualTreeAsset>(path);
        element = template.Instantiate();
        element.AddToClassList("inven-window");

        VisualElement frame = element.Q<VisualElement>("Frame");
        frame.RegisterCallback<PointerUpEvent>(OnClose);
    }

    private void OnClose(PointerUpEvent point)
    {
        foreach (Action action in closeActionList)
        {
            action();
        }
    }

    public void AddOnClose(Action action)
    {
        closeActionList.Add(action);
    }
}
