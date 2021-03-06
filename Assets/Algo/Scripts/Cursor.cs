using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    //global variables
    public float Speed = 10.0f;

    public LayerMask SelectMask;
    public LayerMask PlaceMask;
    private RectTransform rect;
    private bool _ishovering = false;
    private bool _isRelocating = false;
    private GameObject _selectedFactory;
    public Material factorydefault;
    public Material factoryhover;
    public Material factoryselected;

    // Start is called before the first frame update
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(rect.position);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.black);

        RaycastHit hit;

        if (_isRelocating)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, PlaceMask))
            {
                float yy = _selectedFactory.transform.localScale.y / 2.0f;
                _selectedFactory.transform.position = hit.point + new Vector3(0, yy, 0);
                if (Input.GetButtonDown("South"))
                {
                    Factory factory = _selectedFactory.GetComponent<Factory>();
                    factory.enabled = true;
                    _isRelocating = false;
                    _selectedFactory.GetComponent<MeshRenderer>().material = factorydefault;
                    Debug.Log("Please Work");
                }
            }
        }
        else
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, SelectMask))
            {
                Debug.Log("Factory");
                _selectedFactory = hit.transform.gameObject;
                _ishovering = true;
                if (_ishovering)
                {
                    _selectedFactory.GetComponent<MeshRenderer>().material = factoryhover;
                }
                else
                {
                    _selectedFactory.GetComponent<MeshRenderer>().material = factorydefault;
                }

                if (Input.GetButtonDown("South"))
                {
                    Debug.Log("ShowMeTheColor");
                    Factory factory = _selectedFactory.GetComponent<Factory>();
                    factory.enabled = false;
                    _isRelocating = true;
                    _selectedFactory.GetComponent<MeshRenderer>().material = factoryselected;
                }
            }
        }

        //get input
        Vector2 joy = new Vector2(Input.GetAxis("RightJoyX"), -Input.GetAxis("RightJoyY"));
        if (joy.magnitude < 0.3f) { return; }
        joy.Normalize();

        //local variables
        float width = Screen.width;
        float height = Screen.height;
        float multiplier = Speed * Time.deltaTime;
        Vector2 anchor = rect.anchoredPosition;

        //update values
        float x = anchor.x + joy.x * multiplier;
        x = Mathf.Clamp(x, -width / 2, width / 2);
        float y = anchor.y + joy.y * multiplier;
        y = Mathf.Clamp(y, -height / 2, height / 2);

        _ishovering = false;

        //set anchor
        anchor = new Vector2(x, y);
        rect.anchoredPosition = anchor;
    }
}