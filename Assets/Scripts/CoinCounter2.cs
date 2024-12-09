using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinCounter2 : MonoBehaviour
{
    public int coinCount;
    public TMP_Text coinText;
    private string Levelselect = "LevelSelect";
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinCount.ToString();

        if(coinCount == 20)
        {
            LoadLevelSelect();
        }
    }
        
        private void LoadLevelSelect()
        {
            SceneManager.LoadScene(Levelselect);
        }
}
    
