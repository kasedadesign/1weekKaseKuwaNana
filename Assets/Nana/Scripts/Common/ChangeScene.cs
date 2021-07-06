using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("SelectLevelScene");
    }

    public void OnClickSelectSceneButton(string sceneNumber)
    {
        SceneManager.LoadScene("S_00" + sceneNumber);
    }

    public void OnClickNextButton()
    {
        //TODO:クリアしたシーンを保存

        SceneManager.LoadScene("SelectLevelScene");
    }

    public void OnClickRetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
