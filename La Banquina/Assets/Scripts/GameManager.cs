using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject[] tourist;
    private int marineWolfsAmount;
    private int touristAmount = 1;
    private int instantiatedTourists = 0;
    public int destroyedTourists = 0;

    private void Start()
    {
        instance = this;
        marineWolfsAmount = FindObjectsOfType<MarineWolfController>().Length;
        StartCoroutine("InstantiateTourist");
        Debug.Log(marineWolfsAmount);
    }

    IEnumerator InstantiateTourist()
    {
        while (instantiatedTourists < touristAmount)
        {
            Instantiate(tourist[Random.Range(0, tourist.Length)], new Vector2(10000f, 10000f), Quaternion.identity).SetActive(true);
            instantiatedTourists++;
            yield return new WaitForSeconds(Random.Range(60, 80));
        }
    }
    
    public void CheckWin()
    {
        if (destroyedTourists == touristAmount)
        {
            print("You win");
        }
    }

    public void SubstractMarineWolf()
    {
        marineWolfsAmount--;
        CheckLoose();
    }

    private void CheckLoose()
    {
        if(marineWolfsAmount <= 0)
        {
            print("You lose");
        }
    }
}
