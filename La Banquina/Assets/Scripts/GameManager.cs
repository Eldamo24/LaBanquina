using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject[] tourist;
    private int marineWolfsAmount;
    private int touristAmount = 10;
    private int instantiatedTourists = 0;
    public int destroyedTourists = 0;
    private GameObject UIPanelInGame;
    [SerializeField] private TMP_Text winOrLoseText;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject image;

    private void Start()
    {
        instance = this;
        Time.timeScale = 1f;
        marineWolfsAmount = FindObjectsOfType<MarineWolfController>().Length;
        StartCoroutine("InstantiateTourist");
        UIPanelInGame = GameObject.Find("InGameUI");
        UIPanelInGame.SetActive(false);
    }

    IEnumerator InstantiateTourist()
    {
        while (instantiatedTourists < touristAmount)
        {
            Instantiate(tourist[Random.Range(0, tourist.Length)], new Vector2(10000f, 10000f), Quaternion.identity).SetActive(true);
            instantiatedTourists++;
            yield return new WaitForSeconds(Random.Range(20, 60));
        }
    }
    
    public void CheckWin()
    {
        if (destroyedTourists == touristAmount)
        {
            UIPanelInGame.SetActive(true);
            winOrLoseText.text = "You Win";
            Time.timeScale = 0f;
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
            UIPanelInGame.SetActive(true);
            image.SetActive(true);
            anim.Play("Cry");
            winOrLoseText.text = "You Lose";
            Time.timeScale = 0f;
        }
    }
}
