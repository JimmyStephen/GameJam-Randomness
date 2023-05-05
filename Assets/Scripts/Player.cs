using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0, 100)] float MovementSpeed = 1;
    [SerializeField] float Gravity = -9.8f;
    [SerializeField] CharacterController Controller;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Controller.Move(GetMovement());
    }

    Vector3 GetMovement()
    {
        Vector3 ret = new(Input.GetAxis("Horizontal"), Gravity, Input.GetAxis("Vertical"));
        ret = (ret.normalized * Time.deltaTime) * MovementSpeed;
        return ret;
    }
}
