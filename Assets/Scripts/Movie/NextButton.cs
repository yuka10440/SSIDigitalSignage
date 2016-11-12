using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour {

    //int scene_num;

    void Start()
    {
        //Scene scene = SceneManager.GetActiveScene();
        //scene_num = scene.buildIndex;
    }

    public void OnNextButtonClick()
    {
        SceneManager.LoadScene(3);
        //SceneManager.LoadScene(scene_num + 1);

        //if (scene_num == 2)
        //{
        //    SceneManager.LoadScene(0);
        //}
    }

}
