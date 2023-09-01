using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackStartScene : MonoBehaviour
{
    public void change_scene()
    {
        SceneManager.LoadScene("ExplorationScene1");
    }
    
}

