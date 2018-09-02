using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class WaveConfig{
    public float timeSpawn;
    public int[] numberEnemy;
}

public class WaveManager : MonoBehaviour {
    [Header ("Select a Wave Type")]
    [Header ("   * Select and Config Random Position")]
    public bool waveRandom_Position;
    public Vector3 minPosition, maxPosition;
    [Header ("   * Select Random Houses")]
    public bool waveRandom_Houses = true;
    [Header ("   * Select House In Sequence")]
    public bool houseInSequence;
    public int numberNextHouse = 0;
    [Header ("Waves Configuration")]
    public WaveConfig[] waves;
    public bool lastWave;
    [Header ("House of Enemies Configuration")]
    public Transform[] houseOfEnemies;
    [Header ("Enemies Configuration")]
    public GameObject[] enemies;
    Transform posSpawn;
    int i = 0;
    [Header ("Other Configurations")]
    public Text currentWaveNumber;
    public static bool win;
    public AudioSource nextWaveSoundEffect;

    bool erro;

    void Start () {
        win = false;
        nextWaveSoundEffect = GetComponent<AudioSource>();
        if(!Error){
            StartCoroutine("WaveController");
        }
        
    }

    void Update(){
        currentWaveNumber.text = "Wave " + i;
    }


    IEnumerator WaveController() {
        while( i < waves.Length){
            for (int j = 0; j < waves[i].numberEnemy.Length; j++){
                yield return new WaitForSeconds(waves[i].timeSpawn);
                StartEnemyHouse(waves[i].numberEnemy[j]);
                print("Wave: " + i + " and Number Enemy: " + j);
            }
            //nextWaveSoundEffect.Play();
            i++;
        }
        lastWave = true;
    }

    void StartEnemyHouse(int numberEnemy){
        float house;
        if(waveRandom_Houses == true){
            house = UnityEngine.Random.Range(0, houseOfEnemies.Length);
            posSpawn = houseOfEnemies[(int)house];
            Instantiate(enemies[numberEnemy], posSpawn.position, Quaternion.identity);
        }else if(houseInSequence == true){
            posSpawn = houseOfEnemies[numberNextHouse];
            numberNextHouse++;
            if(numberNextHouse >= houseOfEnemies.Length){
                numberNextHouse = 0;
            }
            Instantiate(enemies[numberEnemy], posSpawn.position, Quaternion.identity);
        }else if(waveRandom_Position == true){
            float x = UnityEngine.Random.Range(minPosition.x,maxPosition.x);
            float y = UnityEngine.Random.Range(minPosition.y,maxPosition.y);
            float z = UnityEngine.Random.Range(minPosition.z,maxPosition.z);
            Vector3 randomPositon = new Vector3(x,y,z);
            Instantiate(enemies[numberEnemy], randomPositon, Quaternion.identity);
        }
    }

    public bool Error{
        get{
            if(waveRandom_Houses && waveRandom_Position || waveRandom_Houses && houseInSequence || waveRandom_Position && houseInSequence){
                print("2 variables from types waves selected");
                erro = true;
            } 
            return erro;
        }
    }
}
