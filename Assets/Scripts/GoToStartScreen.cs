using UnityEngine;
using System.Collections;
using Leap;
using UnityEngine.SceneManagement;

public class GoToStartScreen : MonoBehaviour
{
    private Controller controller = new Controller();

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
            SceneManager.LoadScene(1);
        }
    }



    Vector3 ToVector3(Vector v)
    {
        return new UnityEngine.Vector3(v.x, v.y, v.z);
    }

}
