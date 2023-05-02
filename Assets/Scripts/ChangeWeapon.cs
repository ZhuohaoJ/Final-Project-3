using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _weapon1;
    [SerializeField] private GameObject _weapon2;
    [SerializeField] private GameObject _weapon3;

    // Start is called before the first frame update
    void Start()
    {
        _weapon1.SetActive(true);
        _weapon2.SetActive(false);
        _weapon3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _weapon1.SetActive(true);
            _weapon2.SetActive(false);
            _weapon3.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _weapon1.SetActive(false);
            _weapon2.SetActive(true);
            _weapon3.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _weapon1.SetActive(false);
            _weapon2.SetActive(false);
            _weapon3.SetActive(true);
        }
    }
}
