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

public class addHighScoreEntry : MonoBehaviour
{
    public List<LeaderboardData> leaderboarddata = new List<LeaderboardData>();
    public int score;
    public InputField nameInputField;
    
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score");
        Debug.Log(score);
        GetLeaderboard();
    }
    public void submitButton()
    {
        addScore(score, nameInputField.text);
        SceneManager.LoadScene("Gameover");
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

    public void testMethod ()
    {

    }

    public void addScore(int high_score, string user)
    {
       

        LeaderboardData leaderboarddatas = new LeaderboardData { high_score = score, user = nameInputField.text };

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
   

    [System.Serializable]
    public class LeaderboardData
    {

        public string user { get; set; }
        public int high_score { get; set; }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
