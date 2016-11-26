using UnityEngine;
using System.Collections;
using LMWidgets;
using UnityEngine.SceneManagement;

public class PlayAndPause : ButtonToggleBase
{
    public ButtonDemoGraphics play;
    public ButtonDemoGraphics pause;
    //public ButtonDemoGraphics midGraphics;
    //public ButtonDemoGraphics botGraphics;

    //public Color MidGraphicsOnColor = new Color(0.0f, 0.5f, 0.5f, 1.0f);
    //public Color BotGraphicsOnColor = new Color(0.0f, 1.0f, 1.0f, 1.0f);
    //public Color MidGraphicsOffColor = new Color(0.0f, 0.5f, 0.5f, 0.1f);
    //public Color BotGraphicsOffColor = new Color(0.0f, 0.25f, 0.25f, 1.0f);

    //public MovieOnUI movie;
    
    //public bool buttonPush = false;
    //public Vector3 position;

    public override void ButtonTurnsOn()
    {
        //buttonPush = true;
        TurnsOnGraphics();
    }

    public override void ButtonTurnsOff()
    {
        //buttonPush = true;
        TurnsOffGraphics();
    }

    private void TurnsOnGraphics()
    {
        play.SetActive(true);
        pause.SetActive(false);
        //midGraphics.SetColor(MidGraphicsOnColor);
        //botGraphics.SetColor(BotGraphicsOnColor);
    }

    private void TurnsOffGraphics()
    {
        play.SetActive(false);
        pause.SetActive(true);
        //midGraphics.SetColor(MidGraphicsOffColor);
        //botGraphics.SetColor(BotGraphicsOffColor);
    }

    public void UpdateGraphics()
    {
        Vector3 position = transform.localPosition;
        position.z = Mathf.Min(position.z, m_localTriggerDistance);
        Debug.Log(m_localTriggerDistance);
        play.transform.localPosition = position;
        pause.transform.localPosition = position;
        //Vector3 bot_position = position;
        //bot_position.z = Mathf.Max(bot_position.z, m_localTriggerDistance - m_localCushionThickness);
        //botGraphics.transform.localPosition = bot_position;
        //Vector3 mid_position = position;
        //mid_position.z = (position.z + bot_position.z) / 2.0f;
        //midGraphics.transform.localPosition = mid_position;
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        UpdateGraphics();

        //if (movieplay == true && !movie.IsPlaying)
        //{
        //    Debug.Log("a");
        //    movie.Pause();
        //    Debug.Log("c");
        //}
        //else if (movieplay == false && movie.IsPlaying)
        //{
        //    Debug.Log("d");
        //    movie.Play();
        //    Debug.Log("f");
        //}
    }
}

