using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class end : MonoBehaviour
{
    long playerFrameCount;
    // Start is called before the first frame update
    void Start()
    {
        playerFrameCount = System.Convert.ToInt64(this.gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().frameCount);
        Debug.Log(playerFrameCount);
        //Invoke repeating of checkOver method
        InvokeRepeating("checkOver", .1f, .1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void checkOver()
    {
        long playerCurrentFrame = this.gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().frame;
        
       
        Debug.Log(playerCurrentFrame);
        if (playerCurrentFrame < 1187)
        {
        }
        else
        {
            SceneManager.LoadScene("Cinematique");
            
        }
    }
}
