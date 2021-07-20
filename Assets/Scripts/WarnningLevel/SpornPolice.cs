using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpornPolice : MonoBehaviour
{
    [SerializeField] int thisSpornLevel;
    [SerializeField] GameObject Police;
    [SerializeField] GameObject LevelManager;
    IPoliceSporn policeSporn;
    // Start is called before the first frame update
    void Start()
    {
        policeSporn = LevelManager.GetComponent<IPoliceSporn>();
        policeSporn.SpornEve += PoliceSummon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PoliceSummon(int Level)
    {
        if(Level==thisSpornLevel)
        {
            var t = Instantiate(Police);
            t.transform.position = this.transform.position;
        }
    }
}
