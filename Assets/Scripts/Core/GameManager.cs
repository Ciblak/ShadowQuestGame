using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Progression")]
    public int currentRoom = 0;
    public int maxRooms = 5;
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1.34f;
    private bool playerIsHidden = false;
    public Action FightEnd;
    public Sword selectedSword;
    public Armor selectedArmor;
    public Amulet selectedAmulet;
    public Dictionary<string, Item> selectedItems = new Dictionary<string, Item>();


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }       // SceneManager.sceneLoaded += OnSceneLoaded;
    }
    /*
     private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject fadeScreenObj = GameObject.Find("FadeScreen");
        fadeCanvasGroup = fadeScreenObj.GetComponent<CanvasGroup>();
    }
    */
    private void Start()
    {
    
    }

    public void StartGame()
    {
        Debug.Log("Game Started!");
        currentRoom = 1;
        LoadLoadout();
        //Player.Instance.ResetPlayer();
    }

    public void FadeScene(string sceneName)
    {
        StartCoroutine(SceneTransition(sceneName));
    }
    public void LoadBattle()
    {
        FadeScene("BattleScene");
    }
    public void LoadLoadout()
    {
        FadeScene("Loadout");
    }

    public void NextRoom()
    {
        Player.Instance.poisonEffect.poisonStacks=0;
        FightEnd?.Invoke();
        if(currentRoom==5) FadeScene("CampaignOverScreen");
        else FadeScene("Transition");
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        FadeScene("GameOver");
    }

     IEnumerator SceneTransition(string sceneName)
    {
        yield return StartCoroutine(Fade(1));
        yield return new WaitForSeconds(0.7f);
        if(sceneName=="BattleScene") ShowPlayer();
        else HidePlayer();
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(0.7f);
        yield return StartCoroutine(Fade(0));
    }

    IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeCanvasGroup.alpha;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            yield return null;
        }

        fadeCanvasGroup.alpha = targetAlpha;
    }

    private void HidePlayer()
    {
        if (Player.Instance != null)
        {
            Animator playerAnimator = Player.Instance.GetComponent<Animator>();
            playerAnimator.SetTrigger("Disappear");
            playerIsHidden=true;
        }
    }

    private void ShowPlayer()
    {
        if (Player.Instance!=null&&playerIsHidden)
        {
            Animator playerAnimator = Player.Instance.GetComponent<Animator>();
            playerAnimator.SetTrigger("Reappear");
            playerIsHidden=false;
        }
    }

        public void SelectItemByName(string className)
    {
        Item selectedItem=CreateItemByName(className);
        if(selectedItem is Sword)selectedSword=(Sword)selectedItem;
        if(selectedItem is Armor)selectedArmor=(Armor)selectedItem;
        if(selectedItem is Amulet)selectedAmulet=(Amulet)selectedItem;
        //Debug.Log($"Selected {selectedItem}.");

    }
        public Item CreateItemByName(string className)
    {
        Type type = Type.GetType(className);
        if (type != null && typeof(Item).IsAssignableFrom(type))
        {
            Item newItem = (Item)Activator.CreateInstance(type);
            return newItem;
        }
        else
        {
            Debug.LogWarning($"ITEM ERROR");
            return null;
        }
    }
}