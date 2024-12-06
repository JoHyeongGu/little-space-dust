using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class JoyStickController : SingletonMono<JoyStickController>
{
    private VisualElement touchPad;
    private VisualElement touchFrame;
    private VisualElement touchCircle;

    private Size FrameSize = new(400, 400);
    private Vector3 firstPos = new();
    public Vector2 Move = Vector2.zero;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        InitTouchPad();
        SetTouchFrame();
    }

    private void InitTouchPad()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        touchPad = root.Q<VisualElement>("TouchPad");
        touchPad.RegisterCallback<PointerDownEvent>(OnTouchDown);
        touchPad.RegisterCallback<PointerUpEvent>(OnTouchUp);
        touchPad.RegisterCallback<PointerMoveEvent>(OnTouchMove);
    }

    private void SetTouchFrame()
    {
        touchFrame = new VisualElement();
        touchFrame.AddToClassList("touch-frame");
        touchFrame.style.width = FrameSize.Width;
        touchFrame.style.height = FrameSize.Height;

        touchCircle = new VisualElement();
        touchCircle.AddToClassList("touch-circle");
        touchFrame.Add(touchCircle);
    }

    private void OnTouchDown(PointerDownEvent point)
    {
        firstPos = point.position;
        Vector2 touchPos = point.localPosition;
        touchFrame.style.left = touchPos.x - (FrameSize.Width / 2);
        touchFrame.style.top = touchPos.y - (FrameSize.Height / 2);
        touchPad.Add(touchFrame);
    }

    private void OnTouchUp(PointerUpEvent point)
    {
        touchCircle.transform.position = Vector3.zero;
        Move = Vector3.zero;
        if (touchPad.Contains(touchFrame))
        {
            touchPad.Remove(touchFrame);
        }
    }

    private void OnTouchMove(PointerMoveEvent point)
    {
        if (touchFrame.Contains(touchCircle))
        {
            Vector3 delta = point.position - firstPos;
            delta.x = Mathf.Clamp(delta.x, -FrameSize.Width / 2, FrameSize.Width / 2);
            delta.y = Mathf.Clamp(delta.y, -FrameSize.Height / 2, FrameSize.Height / 2);
            touchCircle.transform.position = delta;
            Move = GetMoveVector(delta);
        }
    }

    private Vector3 GetMoveVector(Vector3 pos)
    {
        if (pos.x != 0) pos.x /= Mathf.Abs(pos.x);
        if (pos.y != 0) pos.y /= -Mathf.Abs(pos.y);
        return pos;
    }
}