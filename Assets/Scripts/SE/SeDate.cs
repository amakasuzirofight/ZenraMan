using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Zenra
{
    namespace SE
    {
        //SE���f�[�^�ŕێ�
        //�����Ŗ��O��n������SE���Đ������}�l�[�W���[�����
        [CreateAssetMenu(menuName = "SEDate")]
        public class SeDate : ScriptableObject
        {
            public List<AudioDate> audioData = new List<AudioDate>();
        }


        [System.Serializable]
        public class AudioDate
        {
            [SerializeField] public string audioName;
            [SerializeField] public AudioClip audioClip;

            
            //public string AudioName => audioname;
        }

    }
}
