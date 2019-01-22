using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Vector3 _pickPosition;
    [SerializeField] private Vector3 _pickRotation;

    private UIManager _uiManager;
    private GameObject _hand;
    public bool _canPickItem;
    private GameObject _itemToPick;
    private GameObject _pickedItem;

    public bool _hasTorch = false;
    public bool _itemClose = false;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        //_hand = GameObject.Find("hand.R");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _canPickItem && _itemClose)
        {
            _hand = GameObject.Find("hand.R");
            _itemToPick.transform.parent = _hand.transform;
            _itemToPick.transform.localPosition = _pickPosition;
            _itemToPick.transform.localEulerAngles = _pickRotation;
            _itemToPick.GetComponent<Rigidbody>().isKinematic = true;

            _pickedItem = _itemToPick;

            _canPickItem = false;
            _uiManager.HideUIToggle();

            _hasTorch = true;

            Debug.Log(_canPickItem);
        } else if (Input.GetKeyDown(KeyCode.F) && !_canPickItem && _itemClose)
        {
            _pickedItem.transform.parent = null;
            _pickedItem.GetComponent<Rigidbody>().isKinematic = false;

            _canPickItem = true;
            _uiManager.ShowUIToggle("Presser F pour ramasser la torche");

            _hasTorch = false;

            Debug.Log(_canPickItem);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // message take object    
        if (other.tag == "TorchPlayer")
        {
            _uiManager.ShowUIToggle("Presser F pour ramasser la torche");
            _canPickItem = true;
            _itemClose = true;
            _itemToPick = other.gameObject;

            Debug.Log(_canPickItem);
        }      
    }

    private void OnTriggerExit(Collider other)
    {
        // close message
        if (other.tag == "TorchPlayer")
        {
            _canPickItem = false;
            _itemClose = false;
            _uiManager.HideUIToggle();

            Debug.Log(_canPickItem);
        }
    }
    
}
