using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySporn : MonoBehaviour
{
    [SerializeField] GameObject PoliceObj;
    [SerializeField] int warningLevel;
    bool isSporn = false;
    // Start is called before the first frame update
    void Start()
    {
        isSporn = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpornEnemy(int Level)
    {
        if(warningLevel<=Level)
        {
            if (isSporn) return;
            var enemy = Instantiate(PoliceObj);
            isSporn = true; 
        }
    }
}
