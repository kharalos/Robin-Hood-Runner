using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectHandler : MonoBehaviour
{
    [SerializeField] private float animDuration = 0.5f;
    [SerializeField] private AudioClip clip;
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            FindObjectOfType<AudioSource>().PlayOneShot(clip);
            FindObjectOfType<GameManager>().CollectedMoney();
            GetComponentInChildren<ParticleSystem>().Play();
            StartCoroutine(Collected());
        }
    }
    IEnumerator Collected(){
        // Create a new Sequence.
		Sequence s = DOTween.Sequence();
		// Add an horizontal relative move tween that will last the whole Sequence's duration
		s.Append(transform.DOScale(0.5f, animDuration).SetRelative());
		// Insert a rotation tween which will last half the duration
		s.Insert(animDuration, transform.DOScale(0.0f, animDuration / 2));

        yield return new WaitForSeconds(animDuration * 1.5f);
        
        Destroy(gameObject);
    }
}
