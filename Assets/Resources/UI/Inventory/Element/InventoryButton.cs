using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryButton : Singleton<InventoryButton>
{
    private VisualElement frame;
    private Button element;
    private Sprite[] sprites;

    public InventoryButton()
    {
        sprites = Resources.LoadAll<Sprite>("Sprite/EnergyBag-Sheet");
        InitElement();
    }

    public void InitElement()
    {
        string path = "UI/Inventory/Element/InventoryButtonView";
        var template = Resources.Load<VisualTreeAsset>(path);
        frame = template.Instantiate();
        frame.AddToClassList("inven-open-button");
        element = frame.Q<Button>();
        element.clicked += () => { Animate(open: true); };
    }

    public VisualElement GetElement()
    {
        return frame;
    }

    public void AddOnClick(Action onClick)
    {
        element.clicked += onClick;
    }

    public async void Animate(bool open)
    {
        int start = open ? 0 : sprites.Length - 1;
        int end = open ? sprites.Length - 1 : 0;
        int offset = start < end ? 1 : -1;
        for (int i = start; open ? i <= end : i >= end; i += offset)
        {
            element.style.backgroundImage = new(sprites[i]);
            await Task.Delay(50);
        }
    }
}
