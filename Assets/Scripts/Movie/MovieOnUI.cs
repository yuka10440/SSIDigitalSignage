using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(RawImage))]
[RequireComponent(typeof(AudioSource))]
public class MovieOnUI : MonoBehaviour
{

    [SerializeField]
    string m_moviePath;

    MovieTexture m_movieTexture = null;

    //public MovieTexture m_movieTexture;

    RawImage m_rawImage = null;
    AudioSource m_audioSource = null;
    //public AudioSource m_audioSource;

    //public PlayAndPause play;

    public bool IsPlaying
    {
        get { return m_movieTexture != null && m_movieTexture.isPlaying; }
    }

    public void Play()
    {
        Debug.Log("play1");
        Debug.Log(m_moviePath);
        m_movieTexture = (MovieTexture)Resources.Load<MovieTexture>(m_moviePath);
        Debug.Log("play2");
        Debug.Log(m_movieTexture);

        //if (m_movieTexture == null)
        //{
        //    Debug.LogError("movie is nothing" + m_moviePath);
        //    return;
        //}

        //m_movieTexture.loop = false;

        m_rawImage.material.mainTexture = m_movieTexture;
        Debug.Log("play3");
        Debug.Log(m_rawImage.material.mainTexture);
        m_audioSource.clip = m_movieTexture.audioClip;
        Debug.Log("play4");
        Debug.Log(m_audioSource.clip);

        m_movieTexture.Play();
        Debug.Log("play5");
        m_audioSource.Play();
        Debug.Log("play6");
    }


    public void Stop()
    {

        if (!IsPlaying)
        {
            return;
        }

        m_movieTexture.Stop();
        m_audioSource.Stop();
    }

    public void Pause()
    {
        Debug.Log("pause1");
        Debug.Log(m_moviePath);
        m_movieTexture = (MovieTexture)Resources.Load<MovieTexture>(m_moviePath);
        Debug.Log("pause2");
        Debug.Log(m_movieTexture);
        m_rawImage.material.mainTexture = m_movieTexture;
        Debug.Log("pause3");
        m_audioSource.clip = m_movieTexture.audioClip;
        Debug.Log("pause4");

        m_movieTexture.Pause();
        Debug.Log("pause5");
        m_audioSource.Pause();
        Debug.Log("pause6");
    }


    // Use this for initialization
    void Start()
    {
        m_rawImage = this.GetComponent<RawImage>();
        m_audioSource = this.GetComponent<AudioSource>();

        Play();//テスト用
    }

    // Update is called once per frame
    void Update()
    {
        if (m_movieTexture != null && !m_movieTexture.isPlaying)
        {
            m_movieTexture = null;
        }

        //Debug.Log(Mathf.Abs(play.positionBefore.z - play.positionAfter.z));
        //bool IsMoving = false;

        //if (play.buttonPush == true)
        //{
        //    IsMoving = true;
        //}

        //if (IsMoving && IsPlaying)
        //{
        //    Debug.Log("a");
        //    Pause();
        //    Debug.Log("c");
        //}
        //else if (IsMoving && !IsPlaying)
        //{
        //    Debug.Log("d");
        //    Play();
        //    Debug.Log("f");
        //}

        //if (Input.GetKeyDown(KeyCode.Space) && !IsPlaying)
        //{
        //    Pause();
        //    Debug.Log(Input.GetKeyDown(KeyCode.Space));
        //}
        //else if (Input.GetKeyDown(KeyCode.Space) && IsPlaying)
        //{
        //    Play();
        //    Debug.Log("b");
        //}

        //if (!IsPlaying)
        //{
        //    Debug.Log("a");
        //    Pause();
        //    Debug.Log("c");
        //}
        //else if (IsPlaying)
        //{
        //    Debug.Log("d");
        //    Play();
        //    Debug.Log("f");
        //}
        //else
        //{
        //    Debug.Log("g");
        //}
    }
}
