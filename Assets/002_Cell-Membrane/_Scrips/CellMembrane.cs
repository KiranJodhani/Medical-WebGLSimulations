using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class CellMembrane : MonoBehaviour
{
    public static CellMembrane Instance;

    public GameObject Cell_Obj;
    public GameObject CellMembrane_Obj;
    public GameObject CellMembrane_Obj_Rotate;
    //public GameObject CellMembrane_Obj_RotateY;
    public GameObject IntroductionScreen;
    public GameObject LetStartButton;
    public GameObject ReStartButton;
    public TextMeshProUGUI InstructionText;
    public GameObject PassthoughAnimation;
    public GameObject SubstanceAnimation;

    public int CurrentStep;
    public GameObject[] Steps_Screen;
    public GameObject Step2_Eng;
    public GameObject Step2_French;

    public GameObject Notification;
    public GameObject CorrectBG;
    public GameObject InCorrectBG;
    public TextMeshProUGUI NotificationText;

    public int Score;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI CompletedText;




    [Header("#### UI ####")]
    public GameObject LanguageSelection;
    public GameObject UI_Panel;
    public string MoveDirection;
    public string RotateDirection;
    public string Zoom;
    public float MaxZoomValue;
    public float MinZoomValue;
    public float ZoomFactor;
    public float MoveSpeed;
    public float RotateSpeed;
    public float RotateFactor;
    public Vector3 TempAngle;

    public TextMeshProUGUI RotateText;
    public TextMeshProUGUI ZoomText;
    public TextMeshProUGUI ResetText;
    public TextMeshProUGUI RestartText;



    [Header("#### COLLS AND OUTLINE ####")]
    public GameObject Coll_Phospholipid;
    public GameObject Coll_Heads;
    public GameObject Coll_FAC;
    public GameObject Coll_AlphaHelicalProtein;
    public GameObject PhospholipidOutline;
    public GameObject HeadOutline;
    public GameObject FAC_Outline;
    public GameObject InteProtein_Outline;
    public GameObject AlphaHelicalProtein_Outline;
    public GameObject PeripheralProtein_Outline;
    public GameObject Glycoproteins_Outline;

    [Header("#### AUDIO ####")]
    public TextMeshProUGUI SoundText;
    public AudioSource CM_AudioSource;
    public AudioClip[] ClipsEnglish;
    public AudioClip[] ClipsFrench;

    [Header("#### OUTLINE TEXT ####")]
    public TextMeshPro PhospholipidOutlineText;
    public TextMeshPro HeadOutlineText;
    public TextMeshPro FAC_OutlineText;
    public TextMeshPro InteProtein_OutlineText;
    public TextMeshPro AlphaHelicalProtein_OutlineText;
    public TextMeshPro PeripheralProtein_OutlineText;
    public TextMeshPro Glycoproteins_OutlineText;




    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
    }

    public void PlayAudio(int ClipIndex)
    {
        CM_AudioSource.Stop();
        if (Simulation_Backend.SelectedLanguageID == 1)
        {
            CM_AudioSource.PlayOneShot(ClipsEnglish[ClipIndex]);
        }
        else
        {
            CM_AudioSource.PlayOneShot(ClipsFrench[ClipIndex]);
        }        
    }

   

    void ClampPosition()
    {
        Vector3 PositionTemp = CellMembrane_Obj.transform.localPosition;
        if(PositionTemp.x>5)
        {
            PositionTemp.x = 5;
        }
        if (PositionTemp.x < -5)
        {
            PositionTemp.x = -5;
        }
        if (PositionTemp.y < 0)
        {
            PositionTemp.y = 0;
        }
        if (PositionTemp.y > 3)
        {
            PositionTemp.y = 3;
        }

        CellMembrane_Obj.transform.localPosition = PositionTemp;
    }
    public void ToogleSound()
    {
        if (Simulation_Backend.SelectedLanguageID == 1)
        {
            if (CM_AudioSource.volume==1)
            {
                CM_AudioSource.volume = 0;
                SoundText.text = "Sound On";
            }
            else
            {
                CM_AudioSource.volume = 1;
                SoundText.text = "Sound Off";
            }
        }
        else
        {
            if (CM_AudioSource.volume == 1)
            {
                CM_AudioSource.volume = 0;
                SoundText.text = "Son activé";
            }
            else
            {
                CM_AudioSource.volume = 1;
                SoundText.text = "Son désactivé";
            }
        }
    }

    IEnumerator ShowIntroductionScreenCo()
    {
        Cell_Obj.SetActive(true);
        CellMembrane_Obj.SetActive(false);
        ShowCurrentStepScreen();
        LetStartButton.SetActive(false);
        yield return new WaitForSeconds(5);
        LetStartButton.SetActive(true);
        if(Simulation_Backend.SelectedLanguageID==1)
        {
            LetStartButton.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            LetStartButton.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void OnClickStartSimulation()
    {
        CM_AudioSource.Stop();
        LetStartButton.SetActive(false);
        Steps_Screen[0].SetActive(false);
        Cell_Obj.SetActive(false);
        CellMembrane_Obj.SetActive(true);
        Coll_Phospholipid.SetActive(true);
        Coll_Heads.SetActive(false);
        Coll_FAC.SetActive(false);

        Sequence s = DOTween.Sequence();
        s.Append(CellMembrane_Obj.transform.DOScale(Vector3.one, 3f).SetEase(Ease.Linear)).OnComplete(OnZoomCellEmbraneCompleted);
    }

    public void OnClickReStartSimulation()
    {
        DOTween.KillAll();
        UnityEngine.SceneManagement.SceneManager.LoadScene("CellMembrane");
    }

    void OnZoomCellEmbraneCompleted()
    {
        print("OnZoomCellEmbraneCompleted");
        PlayAudio(1);
        CurrentStep = CurrentStep+1;
        ShowCurrentStepScreen();
    }

    private void Update()
    {
        if(Cell_Obj.activeSelf)
        {
            Cell_Obj.transform.Rotate(Vector3.forward * Time.deltaTime * 30);
        }

        if(CellMembrane_Obj.activeSelf)
        {
            if(Zoom=="in")
            {
                if(CellMembrane_Obj.transform.localScale.x<MaxZoomValue)
                {
                    CellMembrane_Obj.transform.localScale = CellMembrane_Obj.transform.localScale + new Vector3(ZoomFactor, ZoomFactor, ZoomFactor);
                }
            }
            else if (Zoom == "out")
            {
                if (CellMembrane_Obj.transform.localScale.x > MinZoomValue)
                {
                    CellMembrane_Obj.transform.localScale = CellMembrane_Obj.transform.localScale + new Vector3(-ZoomFactor, -ZoomFactor, -ZoomFactor);
                }
            }

            if (MoveDirection == "left")
            {
                if (CellMembrane_Obj.transform.localPosition.x > -5)
                {
                    CellMembrane_Obj.transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
                }
            }
            else if (MoveDirection == "right")
            {
                if (CellMembrane_Obj.transform.localPosition.x < 5)
                {
                    CellMembrane_Obj.transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
                }
                    
            }
            else if (MoveDirection == "up")
            {
                if(CellMembrane_Obj.transform.localPosition.y<3)
                {
                    CellMembrane_Obj.transform.Translate(Vector3.up * Time.deltaTime * MoveSpeed);
                }
            }
            else if (MoveDirection == "down")
            {
                if (CellMembrane_Obj.transform.localPosition.y > 0)
                {
                    CellMembrane_Obj.transform.Translate(Vector3.down * Time.deltaTime * MoveSpeed);
                }
            }


            //Rotate

            TempAngle = CellMembrane_Obj_Rotate.transform.localEulerAngles;
            //if (TempAngle.z != 0)
            //{
            //    TempAngle.z = 0;
            //}
            //CellMembrane_Obj.transform.localEulerAngles = TempAngle;


            if (RotateDirection == "left")
            {
                //CellMembrane_Obj.transform.Rotate(Vector3.up * Time.deltaTime * RotateSpeed);
                CellMembrane_Obj_Rotate.transform.localEulerAngles = CellMembrane_Obj_Rotate.transform.localEulerAngles + new Vector3( 0, RotateFactor,0);
            }
            else if (RotateDirection == "right")
            {
                //CellMembrane_Obj.transform.Rotate(Vector3.down * Time.deltaTime * RotateSpeed);
                CellMembrane_Obj_Rotate.transform.localEulerAngles = CellMembrane_Obj_Rotate.transform.localEulerAngles + new Vector3(0, -RotateFactor, 0);
            }
            else if (RotateDirection == "up")
            {
                CellMembrane_Obj_Rotate.transform.Rotate(Vector3.right * Time.deltaTime * RotateSpeed);

            }
            else if (RotateDirection == "down")
            {
                CellMembrane_Obj_Rotate.transform.Rotate(Vector3.left * Time.deltaTime * RotateSpeed);
            }
        }

        ClampPosition();
    }

    void ShowCurrentStepScreen()
    {
        for(int i = 0;i< Steps_Screen.Length;i++)
        {
            Steps_Screen[i].SetActive(false);
        }
        Step2_Eng.SetActive(false);
        Step2_French.SetActive(false);
        if (CurrentStep==1)
        {
            if(Simulation_Backend.SelectedLanguageID==1)
            {
                Step2_Eng.SetActive(true);
            }
            else
            {
                Step2_French.SetActive(true);
            }

        }
        else if (CurrentStep == 10)
        {
            Steps_Screen[CurrentStep].SetActive(true);

        }
        else
        {
            Steps_Screen[CurrentStep].SetActive(true);
            Steps_Screen[CurrentStep].transform.GetChild(0).gameObject.SetActive(false);
            Steps_Screen[CurrentStep].transform.GetChild(1).gameObject.SetActive(false);
            Steps_Screen[CurrentStep].transform.GetChild(Simulation_Backend.SelectedLanguageID - 1).gameObject.SetActive(true);
        }

    }

    public void OnClickOption(GameObject OptionData)
    {
        ShowNotification(int.Parse(OptionData.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text),
                         OptionData.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text,
                        int.Parse(OptionData.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text));
        if(int.Parse(OptionData.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text)==1)
        {
            PlayAudio(2);
            Steps_Screen[CurrentStep].SetActive(false);
            Invoke("ShowNextStep", 2);
            StartCoroutine(PlayStepSound(4, 3));
            Coll_Phospholipid.SetActive(true);
            Coll_Heads.SetActive(false);
        }
        else
        {
            PlayAudio(3);
        }
    }

    IEnumerator PlayStepSound(int Index,int Delay)
    {
        yield return new WaitForSeconds(Delay);
        PlayAudio(Index);
    }
    



    void ShowNotification(int success,string Msg,int Delay)
    {
        CorrectBG.SetActive(false);
        InCorrectBG.SetActive(false);
        if (success==1)
        {
            
            CorrectBG.SetActive(true);
            Score = Score + 1;
            UI_Panel.SetActive(true);
        }
        else
        {
            InCorrectBG.SetActive(true);
            Score = Score - 1;
        }
        NotificationText.text = Msg;
        Notification.SetActive(true);
        Invoke("HideNotification", Delay);

    }

    void HideNotification()
    {
        Notification.SetActive(false);
    }

    public void OnClickZoomButtonDown(string ZoomVal)
    {
        Zoom = ZoomVal;
    }

    public void OnClickZoomButtonUp()
    {
        Zoom = "";
    }

    public void OnClickMoveButtonDown(string MoveVal)
    {
        MoveDirection = MoveVal;
    }

    public void OnClickMoveButtonUp()
    {
        MoveDirection = "";
    }

    public void OnClickRotateButtonDown(string RotateVal)
    {
        RotateDirection = RotateVal;
    }

    public void OnClickRotateButtonUp()
    {
        RotateDirection = "";
    }

    public void Reset_CM_Model()
    {
        CellMembrane_Obj_Rotate.transform.localEulerAngles = Vector3.zero;
        CellMembrane_Obj.transform.localScale = Vector3.one;
        CellMembrane_Obj.transform.localPosition = new Vector3(0,1.5f,6);
    }


    public void OnClickSubObject(string ObjName)
    {

        if(CurrentStep==2)
        {
            if(ObjName== "Phospholipid Bilayer")
            {
                if(Simulation_Backend.SelectedLanguageID==1)
                {
                    ShowNotification(1,
                       "CORRECT: this is called so because it is a two-layered arrangement of phosphate and lipid molecules that form the cell membrane.",
                        8);
                    Invoke("ShowNextStep", 9);
                    StartCoroutine(PlayStepSound(7, 9));
                    Invoke("EnableHeadCollider", 9);

                }
                else
                {
                    ShowNotification(1,
                       "Réponses correctes ! On l'appelle ainsi parce que c'est un arrangement à deux couches de molécules de phosphate et de lipides qui forment la membrane cellulaire.",
                        10);
                    Invoke("ShowNextStep", 10);
                    StartCoroutine(PlayStepSound(7, 10));
                    Invoke("EnableHeadCollider", 10);

                }
                PhospholipidOutline.SetActive(false);
                Steps_Screen[CurrentStep].SetActive(false);
                PlayAudio(5);
            }
            else
            {
                PlayAudio(6);
                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    ShowNotification(0,
                   "NOT QUITE! Don’t worry let me show you, look below. It is called so because it is a two-layered arrangement of phosphate and lipid molecules that form the cell membrane.",
                   12);
                }
                else
                {
                    ShowNotification(0,
                   "Pas tout à fait ! Ne vous inquiétez pas, je vais vous montrer, regardez ici. On l'appelle ainsi parce que c'est un arrangement à deux couches de molécules de phosphate et de lipides qui forment la membrane cellulaire.",
                   16);
                }
                Invoke("ShowPhospholipidOutline", 3f);
            }
        }
        else if (CurrentStep == 3)
        {
            if (ObjName == "phosphate head")
            {
                PlayAudio(8);
                StartCoroutine(PlayStepSound(10, 13));
                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    ShowNotification(1,
                   "CORRECT: The phosphate head is located on the outer part of the bilayer, on either side of the plasma membrane. This is also because it is hydrophilic, meaning attracted to water.",
                   12);
                    Invoke("ShowNextStep", 13);
                    Invoke("EnableFAC_Collider", 13);

                }
                else
                {
                    ShowNotification(1,
                   "EXACTEMENT ! La tête phosphate est située sur la partie externe de la bicouche, de part et d'autre de la membrane plasmique. C'est aussi parce qu'elle est hydrophile, c'est-à-dire attirée par l'eau.",
                   14);
                    Invoke("ShowNextStep", 14);
                    Invoke("EnableFAC_Collider", 14);

                }
                HeadOutline.SetActive(false);
                Steps_Screen[CurrentStep].SetActive(false);
            }
            else
            {
                PlayAudio(9);
                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    ShowNotification(0,
                   "OH, NOT QUITE! The phosphate head is located on the outer part of the bilayer, on either side of the plasma membrane. This is also because it is hydrophilic, meaning attracted to water.",
                   14);
                }
                else
                {
                    ShowNotification(0,
                   "Oh, pas tout à fait ! Le voici. La tête phosphate est située sur la partie externe de la bicouche, de part et d'autre de la membrane plasmique. C'est aussi parce qu'elle est hydrophile, c'est-à-dire attirée par l'eau.",
                   15);
                }

                Invoke("ShowHeadOutline", 3f);
            }
        }
        else if (CurrentStep == 4)
        {
            if (ObjName == "fatty acid chain")
            {
                PlayAudio(11);
                StartCoroutine(PlayStepSound(13, 4));
                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    ShowNotification(1, "CORRECT, this is smart!", 3);
                }
                else
                {
                    ShowNotification(1, "Magnifique, c'est brillant !", 3);
                }

                FAC_Outline.SetActive(false);
                Steps_Screen[CurrentStep].SetActive(false);
                Invoke("ShowNextStep", 4);
                Invoke("EnableHeadCollider", 4);
            }
            else
            {
                PlayAudio(12);
                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    ShowNotification(0, "OH WRONG. Don’t worry, let me show you.", 3);
                }
                else
                {
                    ShowNotification(0, "Malheureusement, c'est faux. Ne vous inquiétez pas, je vais vous montrer.", 5);
                }

                Invoke("ShowFAC_Outline", 3f);
            }
        }
        else if (CurrentStep == 5)
        {
            if (ObjName == "phosphate head")
            {
                PlayAudio(14);
                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    StartCoroutine(PlayStepSound(16, 17));

                    ShowNotification(1, "CORRECT; This is great so far! The phosphate heads are negatively charged, reason why they are attracted towards the water covered environment both out of the cell and inside the cell. The fatty acid chains are positively charged, so ‘’run away’’ from water."
                        , 16);
                    HeadOutline.SetActive(false);
                    Steps_Screen[CurrentStep].SetActive(false);
                    Invoke("ShowNextStep", 17);

                }
                else
                {
                    StartCoroutine(PlayStepSound(16, 20));
                    ShowNotification(1, "Magnifique, c'est impressionnant jusqu'à présent !  Les têtes de phosphate sont chargées négativement, c'est pourquoi elles sont attirées vers l'environnement recouvert d'eau à l'extérieur et à l'intérieur de la cellule. Les chaînes d'acides gras sont chargées positivement, ce qui les fait ‘’fuir‘’ l'eau.",
                        20);
                    HeadOutline.SetActive(false);
                    Steps_Screen[CurrentStep].SetActive(false);
                    Invoke("ShowNextStep", 20);

                }

            }
            else
            {
                PlayAudio(15);
                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    ShowNotification(0,
                        "OH, NOT QUITE, HERE IT IS INSTEAD. The phosphate heads are negatively charged, reason why they are attracted towards the water covered environment both out of the cell and inside the cell. The fatty acid chains are positively charged, so ‘’run away’’ from water.",
                        17);
                }
                else
                {
                    ShowNotification(0,
                        "Oh, pas tout à fait, le voici plutôt. Les têtes de phosphate sont chargées négativement, c'est pourquoi elles sont attirées vers l'environnement recouvert d'eau à l'extérieur et à l'intérieur de la cellule. Les chaînes d'acides gras sont chargées positivement, ce qui les fait ‘’fuir‘’ l'eau.",
                        19);
                }


                Invoke("ShowHeadOutline", 3f);
            }
        }
        else if (CurrentStep == 6)
        {
            PassthoughAnimation.SetActive(true);
            if (ObjName == "Integral proteins")
            {
                PlayAudio(17);
                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    ShowNotification(1,
                        "CORRECT: Integral proteins also called intrinsic proteins are embedded in the whole bilayer. They serve as passage to transport molecules that cannot move normally through the Plasma Membrane.",
                        13);
                    StartCoroutine(PlayStepSound(19, 14));
                    InteProtein_Outline.SetActive(false);
                    Steps_Screen[CurrentStep].SetActive(false);
                    Invoke("ShowNextStep", 13);
                    Invoke("EnableAlphaHelical_Collider", 13);
                    Invoke("HidePassthoughAnimation", 13);

                }
                else
                {
                    ShowNotification(1,
                        "Vous avez raison. Les protéines intégrales, également appelées protéines intrinsèques, sont intégrées dans l'ensemble de la bicouche. Elles servent de passage pour transporter les molécules qui ne peuvent pas se déplacer normalement à travers la membrane plasmique.",
                        18);
                    StartCoroutine(PlayStepSound(19, 19));
                    InteProtein_Outline.SetActive(false);
                    Steps_Screen[CurrentStep].SetActive(false);
                    Invoke("ShowNextStep", 18);
                    Invoke("EnableAlphaHelical_Collider", 18);
                    Invoke("HidePassthoughAnimation", 18);

                }
            }
            else
            {
                PlayAudio(18);
                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    ShowNotification(0,
                        "OH! Not Quite. Integral proteins also called intrinsic proteins are embedded in the whole bilayer. They serve as passage to transport molecules that cannot move normally through the Plasma Membrane. Let me show you.",
                        13);
                }
                else
                {
                    ShowNotification(0,
                        "OH ! Pas tout à fait. Les protéines intégrales, également appelées protéines intrinsèques, sont incorporées à l'ensemble de la bicouche. Elles servent de passage aux molécules de transport qui ne peuvent pas se déplacer normalement à travers la membrane plasmique. Laissez-moi vous montrer.",
                        19);
                }
                Invoke("ShowInteProtein_Outline", 3f);
            }
        }
        else if (CurrentStep == 7)
        {
            if (ObjName == "Alpha helical proteins")
            {
                PlayAudio(20);
                StartCoroutine(PlayStepSound(22, 10));
                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    ShowNotification(1,
                        "CORRECT! α-helical membrane proteins are responsible for interactions between most cells and their environment.", 10);
                }
                else
                {
                    ShowNotification(1,
                        "Exact ! Les protéines membranaires α-hélicoïdales sont responsables des interactions entre la plupart des cellules et leur environnement.",
                        10);
                }
                AlphaHelicalProtein_Outline.SetActive(false);
                Steps_Screen[CurrentStep].SetActive(false);
                Invoke("ShowNextStep", 10);

            }
            else
            {
                PlayAudio(21);
                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    ShowNotification(0,
                        "OH NOT THIS ONE. Look here. α-helical membrane proteins are responsible for interactions between most cells and their environment.",
                        11);
                }
                else
                {
                    ShowNotification(0,
                        "Oh pas celle-là. Regardez ici. Les protéines membranaires α-hélice sont responsables des interactions entre la plupart des cellules et leur environnement.",
                        12);
                }
                Invoke("ShowAlphaHelicalProteins_Outline", 3f);
            }
        }
        else if (CurrentStep == 8)
        {
            if (ObjName == "Peripheral Protein")
            {
                PlayAudio(23);
                StartCoroutine(PlayStepSound(25, 10));
                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    ShowNotification(1,
                        "CORRECT: Peripheral proteins also called extrinsic proteins are located on the inner or outer surface of the phospholipid bilayer.",
                        10);
                    Invoke("ShowNextStep", 10);
                    Invoke("Enable_Glycoproteins_Collider", 10);

                }
                else
                {
                    ShowNotification(1,
                        "Excellent ! Les protéines périphériques également appelées protéines extrinsèques sont situées sur la surface interne ou externe de la bicouche phospholipidique.",
                        12);
                    Invoke("ShowNextStep", 12);
                    Invoke("Enable_Glycoproteins_Collider", 12);

                }
                PeripheralProtein_Outline.SetActive(false);
                Steps_Screen[CurrentStep].SetActive(false);

            }
            else
            {
                PlayAudio(24);
                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    ShowNotification(0,
                        "OH WRONG! Look here instead. Peripheral proteins also called extrinsic proteins are located on the inner or outer surface of the phospholipid bilayer.",
                        11);
                }
                else
                {
                    ShowNotification(0,
                        "Oh, c'est faux ! Regardez plutôt ici. Les protéines périphériques, également appelées protéines extrinsèques, sont situées sur la surface interne ou externe de la bicouche phospholipidique.",
                        15);
                }
                Invoke("ShowPeripheralProtein_Outline", 3f);
            }
        }
        else if (CurrentStep == 9)
        {
            
            SubstanceAnimation.SetActive(true);
            Reset_CM_Model();
            if (ObjName == "Glycoproteins")
            {
                PlayAudio(26);
                StartCoroutine(PlayStepSound(28, 11));

                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    ShowNotification(1,
                        "CORRECT! They are proteins attached to a Polysaccharide. They may function as recognition sites, enzymes, or receptors.",
                        10);
                    Invoke("ShowNextStep", 10);
                    Invoke("HideSubstanceAnimation", 10);
                    Invoke("ShowRestartButton", 13);
                }
                else
                {
                    ShowNotification(1,
                        "BRAVO ! Ce sont des protéines attachées à un polysaccharide. Elles peuvent fonctionner comme des sites de reconnaissance, des enzymes ou des récepteurs.",
                        11);
                    Invoke("ShowNextStep", 11);
                    Invoke("HideSubstanceAnimation", 11);
                    Invoke("ShowRestartButton", 14);
                }

                Glycoproteins_Outline.SetActive(false);
                Steps_Screen[CurrentStep].SetActive(false);
                if(Score<0)
                {
                    Score = 0;
                }
                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    ScoreText.text = "Here is your final score, you got " + Score.ToString() + " correct out of 9";
                    CompletedText.text = "REMEMBER PRACTICE MAKES PERFECT, KEEP PRACTICING TO PERFECT YOUR KNOWLEDGE.";

                }
                else
                {
                    ScoreText.text = "Voici votre score final, vous avez " + Score.ToString() + " réponses correctes sur 9";
                    CompletedText.text = "Sachez que c'est en forgeant qu'on devient forgeron, continuez à vous exercer pour affiner vos connaissances.";
                }
            }
            else
            {
                PlayAudio(27);

                if (Simulation_Backend.SelectedLanguageID == 1)
                {
                    ShowNotification(0,
                            "OH WRONG! They are proteins attached to a Polysaccharide. They may function as recognition sites, enzymes, or receptors.",
                             12);


                }
                else
                {
                    ShowNotification(0,
                        "Oh mauvaise réponse ! Regardez, c'est ici. Ce sont des protéines attachées à un polysaccharide. Elles peuvent fonctionner comme des sites de reconnaissance, des enzymes ou des récepteurs.",
                         14);

                }

                Invoke("ShowGlycoproteins_Outline", 3);
            }
        }
    }


    void HidePassthoughAnimation()
    {
        PassthoughAnimation.SetActive(false);
    }

    void HideSubstanceAnimation()
    {
        SubstanceAnimation.SetActive(false);
    }


    void ShowRestartButton()
    {
        ReStartButton.SetActive(true);
        //if(Simulation_Backend.SelectedLanguageID==1)
        //{
        //    RestartText.text = "Restart";
        //}
        //else
        //{
        //    RestartText.text = "Restart";
        //}
    }
    void EnableHeadCollider()
    {
        Coll_Heads.SetActive(true);
        Coll_Phospholipid.SetActive(false);
    }

    void EnableFAC_Collider()
    {
        Coll_Heads.SetActive(false);
        Coll_Phospholipid.SetActive(false);
        Coll_FAC.SetActive(true);
    }

    void Enable_Glycoproteins_Collider()
    {
        Coll_Heads.SetActive(false);
        Coll_Phospholipid.SetActive(false);
        Coll_FAC.SetActive(false);
    }

    void EnableAlphaHelical_Collider()
    {
        Coll_AlphaHelicalProtein.SetActive(true);
    }



    // OUTLINE STARTS

    void ShowPhospholipidOutline()
    {
        if (!PhospholipidOutline.activeSelf)
        {
            PhospholipidOutline.SetActive(true);
        }
    }

    void ShowHeadOutline()
    {
        if (!HeadOutline.activeSelf)
        {
            HeadOutline.SetActive(true);
        }
    }

    void ShowFAC_Outline()
    {
        if (!FAC_Outline.activeSelf)
        {
            FAC_Outline.SetActive(true);
        }
    }

    void ShowInteProtein_Outline()
    {
        if (!InteProtein_Outline.activeSelf)
        {
            InteProtein_Outline.SetActive(true);
        }
    }

    void ShowAlphaHelicalProteins_Outline()
    {
        if (!AlphaHelicalProtein_Outline.activeSelf)
        {
            AlphaHelicalProtein_Outline.SetActive(true);
        }
    }

    void ShowPeripheralProtein_Outline()
    {
        if (!PeripheralProtein_Outline.activeSelf)
        {
            PeripheralProtein_Outline.SetActive(true);
        }
    }

    void ShowGlycoproteins_Outline()
    {
        if (!Glycoproteins_Outline.activeSelf)
        {
            Glycoproteins_Outline.SetActive(true);
        }
    }

    // OUTLINE ENDS

    void ShowNextStep()
    {
        CurrentStep = CurrentStep + 1;
        ShowCurrentStepScreen();
    }

    public void OnClickLanguageButton(int LanguageID)
    {
        Simulation_Backend.SelectedLanguageID = LanguageID;
        LanguageSelection.SetActive(false);
        UI_Panel.SetActive(false);
        StartCoroutine(ShowIntroductionScreenCo());
        PlayAudio(0);
        SoundText.transform.parent.gameObject.SetActive(true);
        if (LanguageID==1)
        {
            SoundText.text = "Sound Off";
            RotateText.text = "Rotate";
            ZoomText.text = "Zoom";
            ResetText.text = "Reset";

            PhospholipidOutlineText.text= "PHOSPHOLIPID BILAYER";
            HeadOutlineText.text = "PHOSPHATE HEAD";
            FAC_OutlineText.text = "FATTY ACID TAILS";
            InteProtein_OutlineText.text = "INTEGRAL PROTEIN";
            AlphaHelicalProtein_OutlineText.text = "ALPHA HELIX PROTEIN";
            PeripheralProtein_OutlineText.text = "PERIPHERAL PROTEIN";
            Glycoproteins_OutlineText.text = "GLYCOPROTEINS";
            RestartText.text = "Restart";


        }
        else
        {
            SoundText.text = "Son désactivé";
            RotateText.text = "Tourner";
            ZoomText.text = "Zoom";
            ResetText.text = "Réinitialiser";
            RestartText.text = "Redémarrage";

            PhospholipidOutlineText.text = "BICOUCHE PHOSPHOLIPIDE";
            HeadOutlineText.text = "TÊTE PHOSPHATE";
            FAC_OutlineText.text = "QUEUES D'ACIDE GRAS";
            InteProtein_OutlineText.text = "PROTÉINE INTÉGRALE";
            AlphaHelicalProtein_OutlineText.text = "PROTÉINE ALPHA HELIX";
            PeripheralProtein_OutlineText.text = "PROTÉINE PÉRIPHÉRIQUE";
            Glycoproteins_OutlineText.text = "GLYCOPROTÉINES";

        }
    }

}
