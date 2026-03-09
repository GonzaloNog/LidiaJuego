using System.Collections;
using UnityEngine;

public class SoundManagerPlayer : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip enemyEncounterClip;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && Input.GetKeyUp(KeyCode.E))
        {
            sfxSource.pitch = Random.Range(0.0f, 1.2f);

            sfxSource.PlayOneShot(enemyEncounterClip);
        }
    }
}
