using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private float hAxis;
    private float vAxis;

    private Vector3 inputDir;

    private Rigidbody playerRigid;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        State();

        PlayerMove();
    }

    private void State()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        inputDir = new Vector3(hAxis, 0, vAxis).normalized;
    }

    private void PlayerMove()
    {
        playerRigid.velocity = inputDir * moveSpeed;

        //transform.LookAt(transform.position + inputDir);

        if (hAxis == 0 && vAxis == 0) return;

        Quaternion playerRotation = Quaternion.LookRotation(playerRigid.velocity);
        playerRigid.rotation = Quaternion.Slerp(playerRigid.rotation, playerRotation, moveSpeed * Time.deltaTime);
    }

    private void PlayerAnim()
    {

    }
}