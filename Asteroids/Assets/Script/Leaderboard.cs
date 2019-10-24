using System.Collections;
using System.Collections.Specialized;
using System.Net;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Data;
using System.Text;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;
    public List<LeaderboardData> leaderboarddata = new List<LeaderboardData>();
    public List<Transform> leaderboarddataEntryTransformList;
    public Text messageText;
    public Text scoreText;
    public Text posText;

    public InputField nameInputField;
    public InputField scoreInputField;
  

    public Text nameText;


    public void Awake()
    {

        GetLeaderboard();
        
        SendLeaderboard();
        
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = EntryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        for (int i = 0; i < leaderboarddata.Count; i++)
        {
            for (int j = i + 1; j < leaderboarddata.Count; j++)
            {


                if (leaderboarddata[j].high_score > leaderboarddata[i].high_score)
                {
                    //swap
                    LeaderboardData tmp = leaderboarddata[i];
                    leaderboarddata[i] = leaderboarddata[j];
                    leaderboarddata[j] = tmp;
                }
            }
        }
        leaderboarddataEntryTransformList = new List<Transform>();
        foreach (LeaderboardData leaderboardData in leaderboarddata)
        {

            CreateHighscoreEntryTransform(leaderboardData, entryContainer, leaderboarddataEntryTransformList);
        }






    }
    public void CreateHighscoreEntryTransform(LeaderboardData leaderBoardData, Transform container, List<Transform> transformList)
    {
       
        float templateHeight = 31f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);
        
        

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
            
        }
        Debug.Log(entryTransform.Find("posText"));

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;
        

        string user = leaderBoardData.user;
        entryTransform.Find("nameText").GetComponent<Text>().text = user;

        

        int high_score = leaderBoardData.high_score;

        entryTransform.Find("scoreText").GetComponent<Text>().text = high_score.ToString();

        transformList.Add(entryTransform);
       
    }


    public Transform EntryContainer { get => entryContainer; set => entryContainer = value; }

    public Leaderboard()
    {
        GetLeaderboard();
    }

    public void GetLeaderboard()
    {

        string strleader = new WebClient().DownloadString("https://jaibreyonlourens.nl/UnityAPI/read.php");
       // string strleader = new WebClient().DownloadString("http://localhost/UnityAPI/read.php");
        leaderboarddata = JsonConvert.DeserializeObject<List<LeaderboardData>>(strleader);
    }

    public void SendLeaderboard()
    {


    }

    public void addHighscoreEntry(int high_score, string user)
    {
        
        
            LeaderboardData leaderboarddatas = new LeaderboardData { high_score = high_score, user = nameInputField.text };

            GetLeaderboard();



            leaderboarddata.Add(leaderboarddatas);

            string json = JsonConvert.SerializeObject(leaderboarddata);

            StartCoroutine(RegisterUser(user, high_score));
        
       

    }
    IEnumerator RegisterUser(string user, int high_score)
    {
        WWWForm form = new WWWForm();
        form.AddField("user", user);
        form.AddField("high_score", high_score);

        using (UnityWebRequest uwr = UnityWebRequest.Post("https://jaibreyonlourens.nl/UnityAPI/write.php", form))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError)
            {
                Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                Debug.Log("Received: " + uwr.downloadHandler.text);
            }
        }

    }
   public void backButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    

    [System.Serializable]
    public class LeaderboardData
    {

        public string user { get; set; }
        public int high_score { get; set; }

    }
}
