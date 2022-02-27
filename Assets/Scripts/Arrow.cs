using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Arrow : MonoBehaviour
{
    Rigidbody m_rigidbody;
    [SerializeField] private AudioClip impact;
    AudioSource source;
    bool moving = false;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        source = GetComponent<AudioSource>();
        m_rigidbody = GetComponent<Rigidbody>();
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(moving)
            transform.rotation = Quaternion.LookRotation(m_rigidbody.velocity);
    }

    public void Launch(float power){
        m_rigidbody.rotation = Quaternion.Euler(-75f, 0.0f, 0.0f);
        m_rigidbody.velocity = transform.forward * power;
        Time.timeScale = 0.1f;
        moving = true;
    }
    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Range")){
            if(!moving) return;
            moving = false;
            m_rigidbody.velocity = Vector3.zero;
            m_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            m_rigidbody.rotation = Quaternion.Euler(45f, 0.0f, 0.0f);
            source.PlayOneShot(impact);
            StartCoroutine(DelayToCamera(other.transform.GetComponent<RangeSegment>().multiplier));
        }
    }

    IEnumerator DelayToCamera(int multiplier){
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(2f);
        FindObjectOfType<CameraManager>().Normalize();
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<GameManager>().GameOver(multiplier);
    }
}
