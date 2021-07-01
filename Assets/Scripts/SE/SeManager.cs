using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Zenra.SE
{
    public class SeManager : MonoBehaviour
    {
        
        [SerializeField] SeDate sedate;
        static AudioSource audioSource;
        static Dictionary<string, AudioClip> SeDic = new Dictionary<string, AudioClip>();
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            foreach (var item in sedate.audioData) 
            {
                if (SeDic.ContainsKey(item.audioName))
                {
                    throw new System.ArgumentException();
                }
                SeDic[item.audioName] = item.audioClip;
            }

        }
        public static void PlaySe(string PlayName)
        {
            audioSource.PlayOneShot(SeDic[PlayName]);
        }

    }

}

