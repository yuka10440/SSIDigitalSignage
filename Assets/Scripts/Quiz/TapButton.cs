using UnityEngine;
using System.Collections;
using Leap;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class TapButton : MonoBehaviour
{

    private Controller controller = new Controller();
    Button button;
    //string btnname = EventSystem.current.currentSelectedGameObject.name;
    Gesture gesture;

    // Use this for initialization
    void Start()
    {
        // ジェスチャー有効化
        //controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
        //controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP);
        controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP);
        //controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
    }

    // Update is called once per frame
    void Update()
    {
        var frame = controller.Frame();
        var fingerCount = frame.Fingers.Count;
        var gestures = frame.Gestures();
        var interactionBox = frame.InteractionBox;



        if (frame.Fingers[0].IsValid)
        {
            Vector normalizedPosition = interactionBox.NormalizePoint(frame.Fingers[0].TipPosition);
            normalizedPosition *= 10;
            normalizedPosition.z = -normalizedPosition.z;

            for (int i = 0; i < gestures.Count; i++)
            {
                // ジェスチャー結果取得 & 表示
                gesture = gestures[i];
                switch (gesture.Type)
                {
                    case Gesture.GestureType.TYPESCREENTAP:
                        ScreenTapGesture();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void ScreenTapGesture()
    {
        var screentapGesture = new ScreenTapGesture(gesture);
        controller.Config.SetFloat("Gesture.ScreenTap.MinForwardVelocity", 30.0f);
        controller.Config.SetFloat("Gesture.ScreenTap.HistorySeconds", 0.5f);
        controller.Config.SetFloat("Gesture.ScreenTap.MinDistance", 1.0f);
        controller.Config.Save();
        //Debug.Log("A");
        if (button.name == "Yes")
        {
            button.onClick.AddListener(ClickYesButton);
        }

        if (button.name == "No")
        {
            button.onClick.AddListener(ClickNoButton);
        }

        //if (btnname == "Yes")
        //{
        //    Debug.Log("Yes");
        //}

        //if (btnname == "No")
        //{
        //    Debug.Log("No");
        //}
    }

    void ClickYesButton()
    {
        print("Yes");
    }

    void ClickNoButton()
    {
        print("No");
    }

    Vector3 ToVector3(Vector v)
    {
        return new UnityEngine.Vector3(v.x, v.y, v.z);
    }
}

