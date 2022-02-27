using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    private Animator m_animator;
    private CharacterController m_controller;
    private GameManager m_gameManager;
    Quaternion targetRot, defaultRot;
    Vector3 swerveDirection, targetSwerveDirection;
    [SerializeField] private float platformWidth = 4f;

    [SerializeField] private bool running;
    bool disabled = false;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject arrow;
    [SerializeField] private float runSpeed = 3, swerveSpeed = 2;


    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_controller = GetComponent<CharacterController>();
        m_gameManager = FindObjectOfType<GameManager>();
        defaultRot = Quaternion.identity;
    }

    void Update()
    {
        if(!running && Input.touchCount > 0 && !disabled){
            StartRun();
        }
        if (running && SwerveInput.swerveLeft && transform.position.x > -platformWidth)
        {
            targetSwerveDirection = Vector3.left;
            targetRot = Quaternion.Euler(0, -25f, 0);
        }
        else if (running && SwerveInput.swerveRight && transform.position.x < platformWidth)
        {
            targetSwerveDirection = Vector3.right;
            targetRot = Quaternion.Euler(0, 25f, 0);
        }
        else
        {
            targetSwerveDirection = Vector3.zero;
            targetRot = defaultRot;
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
        m_gameManager.RunStarted();
        running = true;
        m_animator.SetTrigger("run");
    }
    public void StopRun()
    {
        running = false;
        m_animator.SetTrigger("idle");
        m_animator.SetTrigger("draw");
        disabled = true;
    }
    public void Shoot(){
        var ok = Instantiate(arrow, shootPoint.position, Quaternion.identity);
        FindObjectOfType<CameraManager>().SetTarget(ok.transform);
        ok.GetComponent<Arrow>().Launch(FindObjectOfType<GameManager>().GetXp());
        Dance();
    }
    public void Dance()
    {
        defaultRot = Quaternion.Euler(0, 180f, 0);
        m_animator.SetTrigger("dance");
    }
}
