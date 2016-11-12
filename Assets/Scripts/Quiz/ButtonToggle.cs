using UnityEngine;
using System.Collections.Generic;
using Leap;

public class ButtonToggle : MonoBehaviour
{

    #region [Leap motion parameters]
    HandModel handModel;
    Hand leapHand;
    FingerModel indexFingerModel;
    #endregion

    #region [Public Parameters]
    public int positionCacheNum = 180;    // 格納する最小点数（60 fps なら 180 で 3 sec 分保存）
    public Vector3 indexTip;
    public Vector3 thumbTip;
    public GameObject b1;   //Button1
    //public GameObject b2;   //Button2
    //public GameObject b3;   //Button3
    //public GameObject b4;   //Button4
    #endregion

    #region [Velocity Parameters]
    public float velocity;  //velocity of the finger
    Vector3 currPosition;   //finger's current frame position
    Vector3 prePosition;    //finger's previous frame position
    #endregion

    #region [Private Parameters]
    private List<Vector3> positions_ = new List<Vector3>(); //recording parameter
    private const float THUMB_TRIGGER_DISTANCE = 0.04f;             //Minimum distance to trigger the test
    private const float MIN_CONFIDENCE = 0.2f;                  //Minimum value of handmodel confidence
    #endregion

    // Update is called once per frame
    void Update()
    {
        //define LeapHands & Fingers
        handModel = GetComponent<HandModel>();
        leapHand = handModel.GetLeapHand();
        //get indexfinger
        indexFingerModel = handModel.fingers[1];
        //get indexfingerTip position
        indexTip = indexFingerModel.GetTipPosition();
        //get thumbTip position
        thumbTip = leapHand.Fingers[0].TipPosition.ToUnityScaled();

        //calculating velocity of finger
        currPosition = thumbTip;
        velocity = (currPosition - prePosition).magnitude / Time.deltaTime;
        prePosition = thumbTip;

        //Trigger test (true: thumbTip got close to rest of fingers)
        bool patternTrigger = false;
        for (int i = 1; i < 5 && !patternTrigger; ++i)
        {
            for (int j = 0; j < 4 && !patternTrigger; ++j)
            {
                Finger.FingerJoint joint = (Finger.FingerJoint)(j);
                Vector3 difference = leapHand.Fingers[i].JointPosition(joint).ToUnityScaled() - thumbTip;
                if (difference.magnitude < THUMB_TRIGGER_DISTANCE
                   && leapHand.Confidence > MIN_CONFIDENCE)
                {
                    //Trigger is ON
                    patternTrigger = true;
                }
            }
        }

        //Particle system On/Off
        switch (patternTrigger)
        {
            case (true):
                //Start recording finger position
                AddPositionCache(indexTip);
                transform.FindChild("particle").gameObject.SetActive(true);
                break;
            case (false):
                transform.FindChild("particle").gameObject.SetActive(false);
                break;
        }
    }

    //Add finger position
    void AddPositionCache(Vector3 position)
    {
        positions_.Insert(0, position);
        if (positions_.Count > positionCacheNum)
        {
            positions_.RemoveAt(positions_.Count - 1);
        }
    }

    //Reseting position records
    void Reset()
    {
        positions_.Clear();
    }
}
