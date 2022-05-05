using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneStartGame : MonoBehaviour
{
    public PreGame preGamescript;

    public void MouveToScene(int sceneId) {
  //      preGamescript = GetComponent<PreGame>();
 //       preGamescript.WriteToPManager();
        SceneManager.LoadScene(sceneId);
    }
    
}
