using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Zenra
{
    namespace StageSelect
    {
        [CreateAssetMenu(menuName = "StageElementData")]
        public class StageElementData : ScriptableObject
        {
            [SerializeField] private Sprite sprite;
            [SerializeField] private StageName stageName;
            [SerializeField, TextArea(1, 4)] private string info = null;

            public Sprite Sprite => sprite;
            public StageName StageName => stageName;
            public string Info => info;
        }
    }
}