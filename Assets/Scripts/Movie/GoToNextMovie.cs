using UnityEngine;
using System.Collections;
using Leap;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToNextMovie : MonoBehaviour
{
    public Text label;  // 表示用ラベル

    private Controller controller = new Controller();

    int scene_num;

    // Use this for initialization
    void Start()
    {
        // ジェスチャー有効化
        //controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
        //controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP);
        //controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP);
        controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        Scene scene = SceneManager.GetActiveScene();
        scene_num = scene.buildIndex;
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
                    case Gesture.GestureType.TYPE_SWIPE:
                        var swipeGesture = new SwipeGesture(gesture);

                        controller.Config.SetFloat("Gesture.Swipe.MinLength", 200.0f);
                        controller.Config.SetFloat("Gesture.Swipe.MinVelocity", 750f);
                        controller.Config.Save();
                        //printGesture("Swipe");

                        for (int j = 0; j <= scene_num; j++)
                        {
                            // 左から右にスワイプしたとき
                            if (swipeGesture.State == Gesture.GestureState.STATE_START
                                && swipeGesture.Direction.x > 0
                                && Mathf.Abs(swipeGesture.Direction.y) < 5)
                            {

                                SceneManager.LoadScene(j + 1);
                                if (j == 2)
                                {
                                    SceneManager.LoadScene(0);
                                }
                            }

                        }

                        // 右から左にスワイプしたとき
                        //if (swipeGesture.State == Gesture.GestureState.STATE_START
                        //    && swipeGesture.Direction.y > -5
                        //    && Mathf.Abs(swipeGesture.Direction.z) < 0)
                        //{
                        //    switch (scene_num)
                        //    {
                        //        case 0:
                        //            SceneManager.LoadScene(2);
                        //            break;
                        //        case 1:
                        //            SceneManager.LoadScene(0);
                        //            break;
                        //        case 2:
                        //            SceneManager.LoadScene(1);
                        //            break;
                        //        default:
                        //            break;
                        //    }
                        //}
                        break;
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

