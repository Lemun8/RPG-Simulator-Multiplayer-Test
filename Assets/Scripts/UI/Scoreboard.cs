using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform container;
    [SerializeField] GameObject scoreboardItemPrefab;
    [SerializeField] CanvasGroup canvasGroup;

    private bool isMobile;
    public Button button;
    public bool toggle;

    Dictionary<Player, ScoreboardItem> scoreboardItems = new Dictionary<Player, ScoreboardItem>();

    void Start()
    {
        isMobile = Application.platform == RuntimePlatform.Android;

        foreach (Player player in PhotonNetwork.PlayerList)
        {
            AddScoreboardItem(player);
        }

        if (isMobile)
        {
            button.gameObject.SetActive(true);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddScoreboardItem(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RemoveScoreboardItem(otherPlayer);
    }

    void AddScoreboardItem(Player player)
    {
        ScoreboardItem item = Instantiate(scoreboardItemPrefab, container).GetComponent<ScoreboardItem>();
        item.Initialize(player);
        scoreboardItems[player] = item;
    }

    void RemoveScoreboardItem(Player player)
    {
        Destroy(scoreboardItems[player].gameObject);
        scoreboardItems.Remove(player);
    }

    void Update()
    {
        if(isMobile == false)
        {
            button.gameObject.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                canvasGroup.alpha = 1;
            }
            else if (Input.GetKeyUp(KeyCode.Tab))
            {
                canvasGroup.alpha = 0;
            }
        }
    }

    public void ScoreboardOnClick()
    {
        toggle = !toggle;
        if (toggle == false)
        {
            canvasGroup.alpha = 0;

        }
        if (toggle == true)
        {
            canvasGroup.alpha = 1;

        }
    }
}
