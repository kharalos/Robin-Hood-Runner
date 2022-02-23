using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    private Animator m_animator;

    [SerializeField] private bool running;
    [SerializeField] private float runSpeed = 3, swerveSpeed = 2;


    void Start()
    {
        //m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (running)
        {
            //m_rigidbody.velocity = Vector3.forward * Time.deltaTime * speed;
            transform.position += Vector3.forward * Time.deltaTime * runSpeed;
        }
        if (SwerveInput.swerveLeft)
        {
            transform.position += Vector3.left * Time.deltaTime * swerveSpeed;
        }
        else if (SwerveInput.swerveRight)
        {
            transform.position += Vector3.right * Time.deltaTime * swerveSpeed;
        }
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -4.0f, 4.0f);
        transform.position = pos;

    }
    public void StartRun()
    {
        running = true;
        m_animator.SetTrigger("Start");
    }
    public void StopRun()
    {
        running = false;
        m_animator.SetTrigger("Stop");
    }
    public void Dance()
    {
        m_animator.SetTrigger("Dance");
    }
}
