using UnityEngine;
using UnityEngine.UIElements;

public class InventoryController : SingletonMono<InventoryController>
{
    private VisualElement root;

    private InventoryButton OpenButton;
    private InventoryWindow Window;

    protected override void Awake()
    {
        base.Awake();
        Window = InventoryWindow.Instance;
        OpenButton = InventoryButton.Instance;
    }

    private void OnEnable()
    {
        InitElement();
    }

    private void InitElement()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        Window.AddOnClose(() =>
        {
            OpenButton.Animate(open: false);
            RemoveElement(Window.GetElement());
        });
        OpenButton.AddOnClick(() => { AddElement(Window.GetElement()); });
        AddElement(OpenButton.GetElement());
    }

    private void AddElement(VisualElement element)
    {
        root.Add(element);
    }

    private void RemoveElement(VisualElement element)
    {
        root.Remove(element);
    }
}