using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    private bool _isnearDoor = false;
    private string Text = "Appuyer sur E pour retourner à l'écran d'accueil";
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_isnearDoor && Input.GetKeyDown(KeyCode.E))
        {
           
            SceneManager.LoadScene("Cinematique");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isnearDoor = true;
            _uiManager.ShowUIToggle(Text);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isnearDoor = false;
            _uiManager.HideUIToggle();
        }
    }
}
