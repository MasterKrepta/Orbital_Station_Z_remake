using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    SpawnManager spawnManager;
    

    [SerializeField] public int Level { get; set; }


    #region Singleton
    private static GameManager instance = null;
    public static GameManager Instance {
        get { return instance; }
    }

    void Awake() {
        Level = 1;
        spawnManager = GetComponent<SpawnManager>();
        
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

   
    #endregion

    
}

