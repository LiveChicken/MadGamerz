using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Email : MonoBehaviour
{
    public string EmailName;

    private const string Source = "Dialogue/English/";

    private TextAsset TA;

    public TMP_Text Text;

    private void OnEnable()
    {

        SetText();

    }

    public void SetText()
    {

        TA = Resources.Load(Source + EmailName) as TextAsset;

        Text.text = TA.text;


    }








}
