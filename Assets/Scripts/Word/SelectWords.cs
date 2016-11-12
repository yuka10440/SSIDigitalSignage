using UnityEngine;
using System.Collections;
using Leap;
using UnityEngine.UI;

public class SelectWords : MonoBehaviour
{
    public Text label;  // 表示用ラベル

    private Controller controller = new Controller();

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
                Gesture gesture = gestures[i];
                switch (gesture.Type)
                {
                    //case Gesture.GestureType.TYPECIRCLE:
                    //    var circleGesture = new CircleGesture(gesture);
                    //    printGesture("Circle");
                    //    break;
                    //case Gesture.GestureType.TYPEKEYTAP:
                    //    var keytapGesture = new KeyTapGesture(gesture);
                    //    printGesture("KeyTap");
                    //    break;
                    case Gesture.GestureType.TYPESCREENTAP:
                        var screentapGesture = new ScreenTapGesture(gesture);
                        controller.Config.SetFloat("Gesture.ScreenTap.MinForwardVelocity", 30.0f);
                        controller.Config.SetFloat("Gesture.ScreenTap.HistorySeconds", 0.5f);
                        controller.Config.SetFloat("Gesture.ScreenTap.MinDistance", 1.0f);
                        controller.Config.Save();
                        //printGesture("ScreenTap");
                        Debug.Log("ScreenTap");
                        break;
                    //case Gesture.GestureType.TYPE_SWIPE:
                    //    var swipeGesture = new SwipeGesture(gesture);
                    //    controller.Config.SetFloat("Gesture.Swipe.MinLength", 200.0f);
                    //    controller.Config.SetFloat("Gesture.Swipe.MinVelocity", 750f);
                    //    controller.Config.Save();
                    //    printGesture("Swipe");
                    //    break;
                    default:
                        break;
                }
            }
        }
    }

    // ジェスチャー結果表示
    void printGesture(string str)
    {
        if (label != null)
        {
            label.text = str;
        }
        else
        {
            Debug.Log(str);
        }
    }

    Vector3 ToVector3(Vector v)
    {
        return new UnityEngine.Vector3(v.x, v.y, v.z);
    }

}
