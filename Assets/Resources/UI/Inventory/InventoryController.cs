using UnityEngine.UIElements;

public class InventoryController : SingletonMono<InventoryController>
{
    private VisualElement root;

    private InventoryButton OpenButton;
    private InventoryWindow Window;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        InitElement();
    }

    private void InitElement()
    {
        Window = InventoryWindow.Instance;
        OpenButton = InventoryButton.Instance;
        OpenButton.AddOnClick(AddWindowOnRoot);
        root = GetComponent<UIDocument>().rootVisualElement;
        root.Add(OpenButton.GetElement());
    }

    private void AddWindowOnRoot()
    {
        root.Add(Window.GetElement());
    }
}