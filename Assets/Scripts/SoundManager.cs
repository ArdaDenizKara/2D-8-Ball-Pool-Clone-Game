using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    #region Fields
    public static SoundManager Instance;
    [SerializeField]
    private AudioSource  effectSource;
    public AudioClip ballHitEffect;
    #endregion
    #region Functions
    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound()
    {
        effectSource.clip = ballHitEffect;
        effectSource.Play();
    }
    #endregion
}
