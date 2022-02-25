using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    private Animator m_animator;
    private CharacterController m_controller;
    Quaternion targetRot;
    Vector3 swerveDirection, targetSwerveDirection;
    [SerializeField] private float platformWidth = 4f;

    [SerializeField] private bool running;
    [SerializeField] private float runSpeed = 3, swerveSpeed = 2;


    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(!running && Input.touchCount > 0){
            StartRun();
        }
        if (SwerveInput.swerveLeft && transform.position.x > -platformWidth)
        {
            targetSwerveDirection = Vector3.left;
            targetRot = Quaternion.Euler(0, -25f, 0);
        }
        else if (SwerveInput.swerveRight && transform.position.x < platformWidth)
        {
            targetSwerveDirection = Vector3.right;
            targetRot = Quaternion.Euler(0, 25f, 0);
        }
        else
        {
            targetSwerveDirection = Vector3.zero;
            targetRot = Quaternion.identity;
        }
        swerveDirection = Vector3.Lerp(swerveDirection, targetSwerveDirection, 2f * Time.deltaTime);

        if (running)
        {
            m_controller.Move((Vector3.forward * Time.deltaTime * runSpeed) + (swerveDirection * Time.deltaTime * swerveSpeed));
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 4f * Time.deltaTime);

    }
    public void StartRun()
    {
        running = true;
        m_animator.SetTrigger("run");
    }
    public void StopRun()
    {
        running = false;
        m_animator.SetTrigger("idle");
    }
    public void Dance()
    {
        m_animator.SetTrigger("dance");
    }
}
