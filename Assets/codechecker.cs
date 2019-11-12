using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class codechecker : MonoBehaviour {

    public string nextScene= "UMenuGallery";
    public TMP_InputField TMP_codeInput;
	public TMP_Text msg;
    public static string Partmode;
    public GameObject MainPanel;
    public GameObject ScottMorisson;
    public GameObject JoshFrydenberg;
    public GameObject TonyAbbott;
    public GameObject lindaburney;

    public void Start()
    {
        if (loadScene.nameWidow != "")
        {
            if(loadScene.nameWidow == "ScottMorisson")
            {
                ScottMorisson.SetActive(true);
                MainPanel.SetActive(false);
            }
            else if(loadScene.nameWidow == "JoshFrydenberg")
            {
                JoshFrydenberg.SetActive(true);
                MainPanel.SetActive(false);
            }
            else if(loadScene.nameWidow == "TonyAbbott")
            {
                TonyAbbott.SetActive(true);
                MainPanel.SetActive(false);
            }
            else if (loadScene.nameWidow == "LindaBurney")
            {
                lindaburney.SetActive(true);
                MainPanel.SetActive(false);
            }
        }
    }

    public void ck(){
        
        if (TMP_codeInput.text.ToUpper() =="NSW1") {

			msg.SetText ("");
            loadScene.nameWidow ="ScottMorisson";
            MainPanel.SetActive(false);
            ScottMorisson.SetActive(true);
            

        } 
		else if (TMP_codeInput.text.ToUpper() =="NSW2")
        {

			msg.SetText ("");
            loadScene.nameWidow ="JoshFrydenberg";
            MainPanel.SetActive(false);
            JoshFrydenberg.SetActive(true);
            


        }

		else if (TMP_codeInput.text.ToUpper() == "NSW3")
        {

			msg.SetText ("");
            loadScene.nameWidow ="TonyAbbott";
            MainPanel.SetActive(false);
            TonyAbbott.SetActive(true);
            
        }

		else if (TMP_codeInput.text.ToUpper() == "NSW4")
        {

			msg.SetText ("");
            loadScene.nameWidow ="LindaBurney";
            MainPanel.SetActive(false);
            lindaburney.SetActive(true);
            
        }
		else {
		
			msg.SetText ("Invalid Code");
		
		}


	}
    public void clickViewBtn()
    {
        SceneManager.LoadScene(nextScene);
        bl_UMGManager.isback = true;
        Partmode = "textPart";
    }
    public void clickBackOne()
    {
        if(ScottMorisson.activeSelf|| JoshFrydenberg.activeSelf|| TonyAbbott.activeSelf|| lindaburney.activeSelf)
        {
            MainPanel.SetActive(true);
            ScottMorisson.SetActive(false);
            JoshFrydenberg.SetActive(false);
            TonyAbbott.SetActive(false);
            lindaburney.SetActive(false);
            loadScene.nameWidow = "";

        }
    }
	



}
