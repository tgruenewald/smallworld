using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Interactions : MonoBehaviour
{
    public Image textbg;
    public Image textBorder;
    public Image talkingHead;

    public Sprite radioImage;
    public Sprite pcImage;

    public Text textWithImage;
    public Text storytext;
    public bool dialogueComplete = false;
    public bool inDialogue = false;
    public bool printingText = false;

    public string dialogueTag = "";

    private float fadeInTime = 0.025F;
    private bool keyPressed = false;

    public int textStage = 0;
    // Use this for initialization
    private static Interactions interactions = null;

    private Dictionary<string, Dialog> Dialogs;
    private Dictionary<string, Sprite> DialogSpriteCache;

    private DialogPlayer OurDialogPlayer;

    private Text CurrentText;

    public string DialogScriptsDirectory = "Dialog";

    public Interactions()
    {
        Dialogs = new Dictionary<string, Dialog>();
        DialogSpriteCache = new Dictionary<string, Sprite>();
        //OurDialogPlayer = new DialogPlayer();
        CurrentText = null;
    }

    void Start()
    {
        if (OurDialogPlayer == null)
            OurDialogPlayer = this.gameObject.AddComponent<DialogPlayer>();

        LoadDialogs();
        CacheDialogSprites();
        OurDialogPlayer.SectionStarted += this.SectionStarted;
        OurDialogPlayer.SectionFinished += this.SectionFinished;
        OurDialogPlayer.StartedPlaying += this.PlayerStarted;
        OurDialogPlayer.FinishedPlaying += this.PlayerFinished;
        OurDialogPlayer.TextUpdated += this.TextUpdated;
    }

    private void SectionStarted(object sender, DialogSection section)
    {
        if (!string.IsNullOrEmpty(section.Icon))
        {
            if (DialogSpriteCache.ContainsKey(section.Icon))
            {
                talkingHead.sprite = DialogSpriteCache[section.Icon];
                talkingHead.enabled = true;
                storytext.enabled = false;
                textWithImage.enabled = true;
                CurrentText = textWithImage;
            }
            else
            {
                talkingHead.sprite = null;
                talkingHead.enabled = false;
                textWithImage.enabled = false;
                storytext.enabled = true;
                CurrentText = storytext;
            }
        }
        else
        {
            talkingHead.sprite = null;
            talkingHead.enabled = false;
            textWithImage.enabled = false;
            storytext.enabled = true;
            CurrentText = storytext;
        }
    }

    private void SectionFinished(object sender, DialogSection section)
    {

    }

    private void PlayerStarted(object sender)
    {

    }

    private void PlayerFinished(object sender)
    {

    }

    private void TextUpdated(object sender, string updatedText)
    {
        if (CurrentText != null)
            CurrentText.text = updatedText;
    }
    private void LoadDialogs()
    {
        var dialogScripts = Resources.LoadAll<TextAsset>(DialogScriptsDirectory);
        foreach (var dialogScript in dialogScripts)
        {
            Dialog dialog = JsonUtility.FromJson<Dialog>(dialogScript.text);
            if (dialog == null)
                continue;
            if (string.IsNullOrEmpty(dialog.Name))
                continue;

            Dialogs.Add(dialog.Name, dialog);
        }
    }

    private void CacheDialogSprites()
    {
        HashSet<string> spritePaths = new HashSet<string>(Dialogs.SelectMany(x => from section in x.Value.Sections where !string.IsNullOrEmpty(section.Icon) select section.Icon));
        foreach (var path in spritePaths)
        {
            Sprite loadedSprite = Resources.Load<Sprite>(path);
            if (loadedSprite != null)
                DialogSpriteCache.Add(path, loadedSprite);
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (interactions == null)
        {
            interactions = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            //Debug.Log ("clicked");
            if (OurDialogPlayer.IsFinishedPlaying)
            {

                //Debug.Log ("hiding text");
                hideText();
                inDialogue = false;
                dialogueComplete = false;

            }
        }//if click
    }//if Update


    public void showText(string tag)
    {
        Dialog dialog = null;
        if (!Dialogs.TryGetValue(tag, out dialog))
        {
            talkingHead.enabled = false;
            textWithImage.enabled = false;
        }

        if (!OurDialogPlayer.LoadDialog(dialog))
        {
            talkingHead.enabled = false;
            textWithImage.enabled = false;
        }
        else if (OurDialogPlayer.PlayDialog())
        {
            talkingHead.enabled = true;
            storytext.enabled = false;
        }


        //dialogueTag = tag;
        ////Debug.Log ("showing text: " + dialoguetext);
        //inDialogue = true;

        //if(textManager (tag)==true){
        //	talkingHead.enabled = true;
        //	storytext.enabled = false;
        //}
        //else
        //{
        //	talkingHead.enabled = false;
        //	textWithImage.enabled = false;
        //}
        textBorder.enabled = true;
        textbg.enabled = true;

        //StartCoroutine (animate (textManager(tag)));

    }

    public void hideText()
    {
        textBorder.enabled = false;
        talkingHead.enabled = false;
        textWithImage.enabled = false;
        textbg.enabled = false;
        storytext.enabled = false;
    }
}

