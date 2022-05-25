using UnityEngine;
using DG.Tweening;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LymphNode_Manager : MonoBehaviour
{
    public static LymphNode_Manager Instance;

    [Header(" ##### FNA INSTANCE ####")]
    public LimphNode_Data[] LimphNode_Data_Instance;

    [Header("#### UI ####")]
    public GameObject FrenchModel;
    public GameObject EnglishModel;
    public GameObject LanguageSelection;
    public GameObject MenuScreen;
    public GameObject MenuButton;
    public TextMeshProUGUI StepDescription;
    public GameObject HintButton;
    public GameObject AdapterHintScreen;
    public GameObject AdapterHint_E;
    public GameObject AdapterHint_F;
    public int ScreenIndex;
    public bool DoShowInfo = true;
    public GameObject Ceiling;
    
    public bool CanShowHintButton;

    public GameObject StartButton;
    public TextMeshProUGUI StartButtonText;
    public GameObject ReStartButton;
    public TextMeshProUGUI ReStartButtonText;
    public Transform CameraObj;
    public Transform CameraObj_Initial;
    public Transform CameraObj_TrayPoint;
    public Transform CameraObj_TrayPoint2;
    public Transform CameraObj_TrayPoint3;
    public Transform CameraObj_Step6;
    public Transform CameraObj_Step7;
    public Transform CameraObj_Step8;

    [Header("#### INFO ####")]
    public GameObject InfoButton;
    public GameObject InfoOnImage;
    public GameObject InfoOffImage;


    [Header("#### AUDIO ####")]
    public GameObject SoundButton;
    public GameObject SoundOnImage;
    public GameObject SoundOffImage;
    public AudioSource FNA_AudioSource;

    [Header("#### TOOL TIP ####")]
    public TextMeshProUGUI RestartToolTip;
    public TextMeshProUGUI SoundToolTip;
    public TextMeshProUGUI InfoToolTip;
    public TextMeshProUGUI MenuToolTip;

    [Header("#### Disinfectant sachet ####")]
    public GameObject Left_Obj;
    public GameObject Sachet_Cotton_Hand;
    public GameObject Right_Obj;
    public GameObject LeftHand_Sachet;
    public GameObject RightHand_Sachet;
    public Transform DisinfectantAt_Tray;
    public Transform DisinfectanAt_Zoom;
    public Transform Left_Obj_Target;
    public Transform Right_Obj_Target;


    [Header("#### Breast ####")]
    public GameObject Full_Breast;
    public GameObject Full_Breast_HandStep6;
    public GameObject Half_Breast;
    public Transform Cotton_Obj;
    public Transform Big_Needle;
    public Transform Big_Needle_Initial;
    public Transform Big_Needle_Target;

    [Header("#### COLLIDER ####")]
    public BoxCollider FNA_Adapter_Coll;
    public BoxCollider Syringe_Coll;
    public BoxCollider Disinfectant_Sachet_Coll;
    public BoxCollider Syringe_Cover_Coll;
    public BoxCollider Full_Breast_Coll;
    public BoxCollider FNA_Hand_Coll;
    public BoxCollider FNA_Button_Coll;
    public BoxCollider Lesion_Coll;
    


    [Header("#### SLIDES ####")]
    public GameObject Slide1;
    public GameObject Blood_Drop1;
    public GameObject Slide2;
    public GameObject Blood_Drop2;
    //public GameObject Slide_Cover;

    [Header("#### SYRINGE ####")]
    public GameObject Syringe_at_Initial;
    public GameObject Syringe_at_Step3;
    public GameObject Syringe_Inside_FNA;
    public GameObject Cover;
    public GameObject Cover_Target;
    public GameObject Cover_Target_OnTray;
    public GameObject Cover_Target_OnTray_Step11;
    public Transform Cover_Hand;
    public Transform Cover_Hand_Point1;
    public GameObject NeedleMesh;
    public GameObject Plunger;
    public GameObject Plunger_1;
    public GameObject Plunger_2;
    public Transform Syring_Step10;
    public Transform Syring_OnSlide1;
    public Transform Syring_OnSlide2;
    public Transform Thumb;
    public Transform Thumb_1;
    public Transform Thumb_2;

    [Header("#### FNA ADAPTER ####")]
    public Transform FNA_At_Step3;
    public Transform FNA_At_Step5;
    public Transform FNA_At_Step7;
    public Transform FNA_At_Step7_ForLymph;
    public Transform FNA_At_NeedleInsert;
    public Transform FNA_At_Step10;
    public Transform FNA_Step10_AboveCover;
    public Transform FNA_Step10_InCover;
    public Transform FNA_ThumbPressedPoint;
    public Transform FNA_Adapter_Step10_Standing;
    public Transform FNA_Adapter_Step10_Lying;
    public GameObject Button;
    public GameObject Button_Target;
    public GameObject Button_Initial;
    public Transform ThumbOn_Button;
    public Transform ThumbOn_Button_Target;
    public GameObject Case;
    public GameObject Shaft;
    public GameObject Shaft_Target;
    public GameObject Shaft_Initial;

    public GameObject Wrist;
    public GameObject FNA_Inside_Wrist;

    [Header("#### NoticeBoard ####")]
    public int CurrentPage;
    public GameObject[] Pages_English;
    public GameObject[] Pages_French;

    [Header("#### ARROWS ####")]
    public GameObject FNA_Arrow;
    public GameObject Syringe_Arrow;
    public GameObject Syringe_Cover_Arrow;
    public GameObject Disinfectant_Arrow;
    public GameObject Lesion_Step3_Arrow;
    public GameObject FNA_Step4_Arrow;
    public GameObject Lesion_Step5_Arrow;
    public GameObject FNA_Step6_Arrow;
    public GameObject FNA_Step7_Arrow;
    public GameObject FNA_Button_Arrow;
    public GameObject Hand_Arrow;
    public GameObject Syringe_Cover_Arrow_Step10;
    public GameObject Slide1_Arrow;
    public GameObject Slide2_Arrow;

    public GameObject[] AllArrows;

    [Header("#### LYMPH NODE ####")]
    public GameObject HospitalCart;
    public GameObject Patient;
    public GameObject BigNeedle_New;

    private void Awake()
    {
        Instance = this;

#if !UNITY_EDITOR
        Ceiling.SetActive(true);
#endif
    }

    void Start()
    {
        LanguageSelection.SetActive(true);
        DisableAllCollider();
    }


    void DisableAllCollider()
    {
        FNA_Adapter_Coll.enabled = false;
        Syringe_Coll.enabled = false;
        Disinfectant_Sachet_Coll.enabled = false;
        Syringe_Cover_Coll.enabled = false;
        Full_Breast_Coll.enabled = false;
        FNA_Hand_Coll.enabled = false;
        Lesion_Coll.enabled = false;
    }


    public void ToogleSound()
    {
        if (FNA_AudioSource.volume == 1)
        {
            FNA_AudioSource.volume = 0;
            SoundOnImage.SetActive(false);
            SoundOffImage.SetActive(true);
        }
        else
        {
            FNA_AudioSource.volume = 1;
            SoundOnImage.SetActive(true);
            SoundOffImage.SetActive(false);
        }
    }

    public void ToogleInfo()
    {
        if (DoShowInfo)
        {
            DoShowInfo = false;
            StepDescription.gameObject.SetActive(false);
            InfoOnImage.SetActive(false);
            InfoOffImage.SetActive(true);
            for(int i =0;i<AllArrows.Length;i++)
            {
                if(AllArrows[i].activeSelf)
                {
                    AllArrows[i].transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            DoShowInfo = true;
            StepDescription.gameObject.SetActive(true);
            InfoOnImage.SetActive(true);
            InfoOffImage.SetActive(false);
            for (int i = 0; i < AllArrows.Length; i++)
            {
                if (AllArrows[i].activeSelf)
                {
                    AllArrows[i].transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }
    }


    public void OnClickLanguageButton(int LanguageID)
    {
        Simulation_Backend.SelectedLanguageID = LanguageID;
        LanguageSelection.SetActive(false);
        SoundOnImage.SetActive(true);
        SoundButton.SetActive(true);
        ShowCurrentScreen();
        StartButton.SetActive(true);
        HideAllPages();
        if (LanguageID == 0)
        {
            EnglishModel.SetActive(true);
            StartButtonText.text = "Start";
            ReStartButtonText.text = "Restart";
            RestartToolTip.text = ReStartButtonText.text;
            AdapterHint_E.SetActive(true);
            InfoToolTip.text = "Instructions and guide display/hidden";
            SoundToolTip.text = "Sound on/off";
            MenuToolTip.text = "Click here at any time to access relevant theory on this simulation.";
            Pages_English[0].SetActive(true);
        }
        else if (LanguageID == 1)
        {
            FrenchModel.SetActive(true);
            AdapterHint_F.SetActive(true);
            StartButtonText.text = "Début";
            ReStartButtonText.text = "Redémarrage";
            RestartToolTip.text = ReStartButtonText.text;
            InfoToolTip.text = "Instructions et guide affichés/cachés";
            SoundToolTip.text = "Son activé/désactivé";
            MenuToolTip.text = "Cliquez ici à tout moment pour accéder à la théorie de cette simulation.";
            Pages_French[0].SetActive(true);
        }
    }


    public void OnClickStartButton()
    {
        StartButton.SetActive(false);
        FNA_AudioSource.Stop();
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        StartCoroutine(AnimateMenuButton());
    }
    
    IEnumerator AnimateMenuButton()
    {
        Sequence s = DOTween.Sequence();
        s.Append(MenuButton.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f).SetEase(Ease.Linear));
        s.SetLoops(-1);
        yield return new WaitForSeconds(LimphNode_Data_Instance[ScreenIndex].Item_Audio[Simulation_Backend.SelectedLanguageID].length+1);
        s.Kill();
        MenuButton.transform.localScale = Vector3.one;
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();

        Sequence s2 = DOTween.Sequence();
        s2.Append(CameraObj.transform.DOLocalMove(CameraObj_TrayPoint.localPosition, 3f)).SetEase(Ease.Linear).OnComplete(OnCameraReachedToTray);

        Sequence s3 = DOTween.Sequence();
        s3.Append(CameraObj.transform.DOLocalRotate(CameraObj_TrayPoint.localEulerAngles, 3f)).SetEase(Ease.Linear);
    }

    void OnCameraReachedToTray()
    {
        FNA_Adapter_Coll.enabled = true;
        Invoke("ShowAdapterHintAfter5Second", 15);
        CanShowHintButton = true;
        Invoke("ShowFNA_Arrow", 15);
    }

    void ShowFNA_Arrow()
    {
        if(FNA_Adapter_Coll.enabled && DoShowInfo)
        {
            FNA_Arrow.SetActive(true);
        }
    }

    void ShowAdapterHintAfter5Second()
    {
        if(!FNA_Adapter_Coll.GetComponent<LymphNode_Element>().MyHand.activeSelf && CanShowHintButton)
        {
            HintButton.SetActive(true);
        }
    }

    public void OnHintButtonClicked()
    {

    }

    public void OnClickReStartSimulation()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("LymphNode");
    }

    public void ShowInstructionScreen()
    {
        MenuScreen.SetActive(true);
    }

    public void HideInstructionScreen()
    {
        MenuScreen.SetActive(false);
    }


    void ShowCurrentScreen()
    {
        FNA_AudioSource.Stop();
        StepDescription.text = LimphNode_Data_Instance[ScreenIndex].Step_Description[Simulation_Backend.SelectedLanguageID];
        FNA_AudioSource.clip = LimphNode_Data_Instance[ScreenIndex].Item_Audio[Simulation_Backend.SelectedLanguageID];
        FNA_AudioSource.Play();
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.A))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Time.timeScale = 10;
        }
    }

    public void OnClickFNA_Item(GameObject Item)
    {

        if(Item.name== "FNA_Adapter")
        {
            CanShowHintButton = false;
            if (ScreenIndex==2)
            {
                HintButton.SetActive(false);
                AdapterHintScreen.SetActive(false);
                FNA_Arrow.SetActive(false);
                Sequence s1 = DOTween.Sequence();
                s1.Append(FNA_Adapter_Coll.transform.DOLocalMove(FNA_At_Step3.localPosition, 2f)).SetEase(Ease.Linear)
                    .OnComplete(OnAdapterAnimated);

                Sequence s2 = DOTween.Sequence();
                s2.Append(FNA_Adapter_Coll.transform.DOLocalRotate(FNA_At_Step3.localEulerAngles, 1f)).SetEase(Ease.Linear);
            }
            else if (ScreenIndex == 4)
            {
                FNA_Adapter_Coll.transform.GetComponent<LymphNode_Element>().MyHand.transform.localPosition =
                    FNA_Adapter_Coll.transform.GetComponent<LymphNode_Element>().HandInitialPosition;
                Sequence s1 = DOTween.Sequence();
                s1.Append(FNA_Adapter_Coll.transform.DOLocalMove(FNA_At_Step5.localPosition, 2f)).SetEase(Ease.Linear)
                    .OnComplete(OnAdapterAnimated);
                FNA_Step4_Arrow.SetActive(false);
                Sequence s2 = DOTween.Sequence();
                s2.Append(FNA_Adapter_Coll.transform.DOLocalRotate(FNA_At_Step5.localEulerAngles, 1f)).SetEase(Ease.Linear);
            }
            else if (ScreenIndex == 6)
            {
                Sequence s1 = DOTween.Sequence();
                Cover.transform.parent = null;
                FNA_Step6_Arrow.SetActive(false);
                s1.Append(FNA_Adapter_Coll.transform.DOLocalMove(FNA_At_Step7.localPosition, 2.1f)).SetEase(Ease.Linear)
                .OnComplete(OnFNASetAboveBreast);
                Sequence s2 = DOTween.Sequence();
                s2.Append(FNA_Adapter_Coll.transform.DOLocalRotate(FNA_At_Step7.localEulerAngles, 2f)).SetEase(Ease.Linear);
            }
            else if (ScreenIndex == 7)
            {
                FNA_Step7_Arrow.SetActive(false);
                ScreenIndex = ScreenIndex + 1;
                ShowCurrentScreen();
                FNA_Inside_Wrist.SetActive(true);
                Shaft.SetActive(false);
                Button.SetActive(false);
                Syringe_Coll.gameObject.SetActive(false);
                Case.SetActive(false);
            }
        }
        else if (Item.name == "Syringe")
        {
            Sequence s1 = DOTween.Sequence();
            s1.Append(Syringe_Coll.transform.DOLocalMove(Syringe_at_Step3.transform.localPosition, 2f)).SetEase(Ease.Linear)
                .OnComplete(OnSyringeAnimated);
            Syringe_Arrow.SetActive(false);
            Sequence s2 = DOTween.Sequence();
            s2.Append(Syringe_Coll.transform.DOLocalRotate(Syringe_at_Step3.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
        }
        else if (Item.name == "Disinfectant sachet")
        {
            Syringe_Coll.GetComponent<LymphNode_Element>().MyHand.SetActive(false);
            FNA_Adapter_Coll.GetComponent<LymphNode_Element>().MyHand.SetActive(false);
            LeftHand_Sachet.SetActive(true);
            RightHand_Sachet.SetActive(true);
            Disinfectant_Arrow.SetActive(false);
            Sequence s = DOTween.Sequence();
            s.Append(Disinfectant_Sachet_Coll.transform.DOLocalMove(DisinfectanAt_Zoom.localPosition, 2f)).SetEase(Ease.Linear)
                .OnComplete(OnSachetReachedAtZoom);

            Sequence s2 = DOTween.Sequence();
            s2.Append(Disinfectant_Sachet_Coll.transform.DOLocalRotate(DisinfectanAt_Zoom.localEulerAngles, 1f)).SetEase(Ease.Linear);
        }
        else if (Item.name == "Cover")
        {
            if(ScreenIndex == 4)
            {
                Sequence s = DOTween.Sequence();
                s.Append(Cover.transform.DOLocalMove(Cover_Target.transform.localPosition, 2f)).SetEase(Ease.Linear)
                   .OnComplete(OnCoverRemoved);
                Syringe_Cover_Arrow.SetActive(false);

            }
            else if (ScreenIndex == 10)
            {
                Cover.transform.GetComponent<LymphNode_Element>().MyHand2.SetActive(true);
                Sequence s = DOTween.Sequence();
                s.Append(Cover.transform.DOLocalMove(Cover_Target_OnTray_Step11.transform.localPosition, 2f)).SetEase(Ease.Linear)
                   .OnComplete(OnCoverRemovedStep11);
                Syringe_Cover_Arrow_Step10.SetActive(false);
                Sequence s2 = DOTween.Sequence();
                s2.Append(Cover.transform.DOLocalRotate(Cover_Target_OnTray_Step11.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
            }
           
        }
        else if (Item.name == "MyHandCollider")
        {
            Sequence s1 = DOTween.Sequence();
            s1.Append(FNA_Adapter_Coll.transform.DOLocalMove(FNA_At_Step10.localPosition, 2f)).SetEase(Ease.Linear)
                .OnComplete(OnNeedleRemovedStep10);
            Hand_Arrow.SetActive(false);
            Sequence s2 = DOTween.Sequence();
            s2.Append(Big_Needle.transform.DOLocalMove(Big_Needle_Initial.localPosition, 2f)).SetEase(Ease.Linear);
        }
        else if (Item.name == "Slide_1")
        {
            //Slide_Cover.SetActive(true);
            Sequence s1 = DOTween.Sequence();
            Slide1_Arrow.SetActive(false);
            s1.Append(Syringe_Coll.transform.DOLocalMove(Syring_OnSlide1.localPosition, 2f)).SetEase(Ease.Linear)
                .OnComplete(DropAspirateOnSlide);
            Invoke("ShowDrop1", 2);            

        }
        else if (Item.name == "Slide_2")
        {
            //Slide_Cover.SetActive(true);
            Sequence s1 = DOTween.Sequence();
            Slide2_Arrow.SetActive(false);
            s1.Append(Syringe_Coll.transform.DOLocalMove(Syring_OnSlide2.localPosition, 2f)).SetEase(Ease.Linear)
                .OnComplete(DropAspirateOnSlide);
            Invoke("ShowDrop2", 2);

        }
        else if (Item.name == "Button")
        {
            FNA_Button_Arrow.SetActive(false);
            Plunger.transform.parent = Shaft.transform;
            Sequence s1 = DOTween.Sequence();
            s1.Append(Button.transform.DOLocalMove(Button_Target.transform.localPosition, 2f)).SetEase(Ease.Linear)
                .OnComplete(OnFNA_BottonPressed);

            Sequence s2 = DOTween.Sequence();
            s2.Append(Shaft.transform.DOLocalMove(Shaft_Target.transform.localPosition, 2f)).SetEase(Ease.Linear);

            Sequence s3 = DOTween.Sequence();
            s3.Append(ThumbOn_Button.transform.DOLocalRotate(ThumbOn_Button_Target.transform.localEulerAngles, 2f)).SetEase(Ease.Linear);
        }
        else if (Item.name == "Lesion")
        {
            if (ScreenIndex == 3)
            {                
                Cotton_Obj.gameObject.SetActive(true);
                Lesion_Step3_Arrow.SetActive(false);
                Invoke("OnRubFinished", 8);
            }
            else if (ScreenIndex == 5)
            {
                Full_Breast_HandStep6.SetActive(true);
                Lesion_Step5_Arrow.SetActive(false);
                Invoke("Start_Step7", 5);
            }
        }
       
    }

    void Show_Slide2_Arrow()
    {
        if (Slide2.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Slide2_Arrow.SetActive(true);
        }
    }
    void ShowDrop1()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(Blood_Drop1.transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 2f)).SetEase(Ease.Linear);

    }

    void ShowDrop2()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(Blood_Drop2.transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 2f)).SetEase(Ease.Linear);

    }


    void DropAspirateOnSlide()
    {
        if(Thumb.transform.localPosition.z> 0.0007f)
        {
            Sequence s1 = DOTween.Sequence();
            s1.Append(Thumb.transform.DOLocalMove(Thumb_1.localPosition, 2f)).SetEase(Ease.Linear);

            Sequence s2 = DOTween.Sequence();
            s2.Append(Plunger.transform.DOLocalMove(Plunger_1.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnDropped);

        }
        else
        {
            Sequence s1 = DOTween.Sequence();
            s1.Append(Thumb.transform.DOLocalMove(Thumb_2.localPosition, 2f)).SetEase(Ease.Linear);

            Sequence s2 = DOTween.Sequence();
            s2.Append(Plunger.transform.DOLocalMove(Plunger_2.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnDropped);

        }
    }

    void OnDropped()
    {
        //Slide_Cover.SetActive(false);
        if (Thumb.transform.localPosition.z < 0.0005f)
        {
            ScreenIndex = ScreenIndex + 1;
            ShowCurrentScreen();
            Syringe_Cover_Coll.gameObject.SetActive(false);
            Syringe_Coll.gameObject.SetActive(false);
            FNA_Adapter_Coll.gameObject.SetActive(false);
            Slide1.SetActive(false);
            Slide2.SetActive(false);
            Sequence s1 = DOTween.Sequence();
            s1.Append(CameraObj.transform.DOLocalMove(CameraObj_Initial.localPosition, 2f)).SetEase(Ease.Linear);

            Sequence s2 = DOTween.Sequence();
            s2.Append(CameraObj.transform.DOLocalRotate(Plunger_2.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
        }
        else
        {
            Slide2.GetComponent<BoxCollider>().enabled = true;
            Invoke("Show_Slide2_Arrow", 15);
        }
    }

    void OnCoverRemovedStep11()
    {
        Cover.transform.parent = null;
        Cover.GetComponent<LymphNode_Element>().MyHand2.SetActive(false);
        Slide1.GetComponent<BoxCollider>().enabled = true;
        //Slide_Cover.SetActive(false);
        Invoke("Show_Slide1_Arrow", 15);
    }

    void Show_Slide1_Arrow()
    {
        if(Slide1.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Slide1_Arrow.SetActive(true);
        }
    }

    void OnAdapterAnimated()
    {
        DisableAllCollider();
        if (ScreenIndex == 2)
        {
            Syringe_Coll.enabled = true;
            Invoke("ShowSyringArrow", 15);
        }
        else if (ScreenIndex == 4)
        {
            Syringe_Cover_Coll.enabled = true;
            Invoke("ShowSyring_CoverArrow", 15);
        }
        
    }

    void ShowSyringArrow()
    {
        if(Syringe_Coll.enabled && DoShowInfo )
        {
            Syringe_Arrow.SetActive(true);
        }
    }

    void ShowSyring_CoverArrow()
    {
        if (Syringe_Cover_Coll.enabled)
        {
            Syringe_Cover_Arrow.SetActive(true);
        }
    }
    void OnSyringeAnimated()
    {
        Sequence s = DOTween.Sequence();
        s.Append(Syringe_Coll.transform.DOLocalMove(Syringe_Inside_FNA.transform.localPosition, 2f)).SetEase(Ease.Linear)
            .OnComplete(OnSyringeFit);
    }

    void OnSyringeFit()
    {
        Invoke("PutTheAdapterOnTray", 1);
    }

    void PutTheAdapterOnTray()
    {
        FNA_Adapter_Coll.transform.parent = Syringe_Coll.transform;
        Sequence s1 = DOTween.Sequence();
        s1.Append(Syringe_Coll.transform.DOLocalMove(Syringe_at_Initial.transform.localPosition, 2f)).SetEase(Ease.Linear)
            .OnComplete(OnAdapterPlacedOnTray);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Syringe_Coll.transform.DOLocalRotate(Vector3.zero, 1f)).SetEase(Ease.Linear);

    }

    void OnAdapterPlacedOnTray()
    {
        FNA_Adapter_Coll.transform.parent = null;
        FNA_Adapter_Coll.gameObject.GetComponent<LymphNode_Element>().RemoveHand();
        Syringe_Coll.gameObject.GetComponent<LymphNode_Element>().RemoveHand();
        Invoke("MoveCameraToTrayPoint2", 2);
    }

    void MoveCameraToTrayPoint2()
    {
        Sequence s = DOTween.Sequence();
        s.Append(CameraObj.transform.DOLocalMove(CameraObj_TrayPoint2.transform.localPosition, 2f)).SetEase(Ease.Linear)
            .OnComplete(OnCameraMovedToTrayPoint2);
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();

    }
    void OnCameraMovedToTrayPoint2()
    {
        DisableAllCollider();
        Disinfectant_Sachet_Coll.enabled = true;
        Invoke("ShowDisinfectant_Sachet_Arrow", 15);
        
    }

    void ShowDisinfectant_Sachet_Arrow()
    {
        if(Disinfectant_Sachet_Coll.enabled && DoShowInfo)
        {
            Disinfectant_Arrow.SetActive(true);
        }
    }

    void OnSachetReachedAtZoom()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(Left_Obj.transform.DOLocalMove(Left_Obj_Target.transform.localPosition, 2f)).SetEase(Ease.Linear)
           .OnComplete(OnTearSechet);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Right_Obj.transform.DOLocalMove(Right_Obj_Target.transform.localPosition, 2f)).SetEase(Ease.Linear);
    }

    void OnTearSechet()
    {
        Left_Obj.SetActive(false);
        Right_Obj.SetActive(false);
        Sachet_Cotton_Hand.SetActive(true);
        Invoke("ShowFullBreast", 2);
    }

    void ShowFullBreast()
    {
        Disinfectant_Sachet_Coll.gameObject.SetActive(false);
        Full_Breast.SetActive(true);
        DisableAllCollider();
        Lesion_Coll.enabled = true;
        Invoke("ShowLessionArrowStep3", 10);
    }

    void ShowLessionArrowStep3()
    {
      if(Lesion_Coll.enabled && DoShowInfo)
      {
            Lesion_Step3_Arrow.SetActive(true);
      }
    }

    void OnRubFinished()
    {
        Cotton_Obj.gameObject.SetActive(false);
        Syringe_Coll.transform.parent = FNA_Adapter_Coll.transform;
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        FNA_Adapter_Coll.enabled = true;
        Invoke("Show_FNA_Step4_Arrow", 10);
        //Sequence s = DOTween.Sequence();
        //s.Append(CameraObj.transform.DOLocalMove(CameraObj_TrayPoint3.transform.localPosition, 2f)).SetEase(Ease.Linear)
        //   .OnComplete(OnCameraReachedToPoint3);
    }

    void Show_FNA_Step4_Arrow()
    {
        if(FNA_Adapter_Coll.enabled && DoShowInfo)
        {
            FNA_Step4_Arrow.SetActive(true);
        }
    }
    //void OnCameraReachedToPoint3()
    //{
    //    FNA_Adapter_Coll.enabled = true;
    //}

    void OnCoverRemoved()
    {
        //Place cover on tray
        Invoke("OnCoverRemovedDelayed", 1);
    }

    void OnCoverRemovedDelayed()
    {
        Sequence s = DOTween.Sequence();
        s.Append(Cover.transform.DOLocalMove(Cover_Target_OnTray.transform.localPosition, 2f)).SetEase(Ease.Linear)
           .OnComplete(OnCoverPlacedOnTray);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Cover.transform.DOLocalRotate(Cover_Target_OnTray.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
    }

    void OnCoverPlacedOnTray()
    {
        Sequence s = DOTween.Sequence();
        s.Append(Cover_Hand.transform.DOLocalMove(Cover_Hand_Point1.transform.localPosition, 2f)).SetEase(Ease.Linear)
           .OnComplete(OnCoverHandRemoved);
    }

    void OnCoverHandRemoved()
    {
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();

        Sequence s = DOTween.Sequence();
        s.Append(CameraObj.transform.DOLocalMove(CameraObj_TrayPoint2.transform.localPosition, 2f)).SetEase(Ease.Linear)
           .OnComplete(OnCameraReachedToBreast);
    }

    void OnCameraReachedToBreast()
    {
        DisableAllCollider();
        Full_Breast_Coll.enabled = false;
        Invoke("Show_Lesion_Step5_Arrow", 10);
        DisableAllCollider();
        Lesion_Coll.enabled = true;
    }

    void Show_Lesion_Step5_Arrow()
    {
        if(Lesion_Coll.enabled && DoShowInfo)
        {
            Lesion_Step5_Arrow.SetActive(true);
        }
    }

    void Start_Step7()
    {        
        Full_Breast_HandStep6.GetComponent<LymphNode_Rub_Animation>().StopRubAnimation();
        Invoke("Start_Step7Delayed", 4);
        Invoke("ShowFNA_Step6Arrow", 15);
    }

    void Start_Step7Delayed()
    {
        ScreenIndex = ScreenIndex + 1;
        FNA_Adapter_Coll.enabled = true;
        ShowCurrentScreen();
    }
    void ShowFNA_Step6Arrow()
    {
        if(FNA_Adapter_Coll.enabled && DoShowInfo )
        {
            FNA_Step6_Arrow.SetActive(true);
        }
    }

    void OnFNASetAboveBreast()
    {
        Full_Breast.SetActive(false);
        Half_Breast.SetActive(true);
        HospitalCart.SetActive(false);
        Patient.SetActive(false);
        BigNeedle_New.SetActive(true);
        Sequence s1 = DOTween.Sequence();
        s1.Append(FNA_Adapter_Coll.transform.DOLocalMove(FNA_At_NeedleInsert.localPosition, 2f)).SetEase(Ease.Linear)
            .OnComplete(OnNeedleInserted);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Big_Needle.transform.DOLocalMove(Big_Needle_Target.localPosition, 2f)).SetEase(Ease.Linear);

        Sequence s3 = DOTween.Sequence();
        s3.Append(CameraObj.transform.DOLocalMove(CameraObj_Step8.localPosition, 0.5f)).SetEase(Ease.Linear);
        DisableAllCollider();
        FNA_Button_Coll.enabled = true;
    }

    void OnNeedleInserted()
    {
        DisableAllCollider();
        ScreenIndex = ScreenIndex + 1;
        FNA_Button_Coll.enabled = true;
        Invoke("ShowButton_Arrow", 15);
        ShowCurrentScreen();
    }
    void ShowButton_Arrow()
    {
        if(FNA_Button_Coll.enabled && DoShowInfo )
        {
            FNA_Button_Arrow.SetActive(true);
        }
    }

    void OnFNA_BottonPressed()
    {
        Invoke("OnFNA_BottonReleased", 1);
    }

    void OnFNA_BottonReleased()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(Button.transform.DOLocalMove(Button_Initial.transform.localPosition, 2f)).SetEase(Ease.Linear)
            .OnComplete(OnStep8Finished);
    }

    void OnStep8Finished()
    {
        DisableAllCollider();
        FNA_Adapter_Coll.enabled = true;
        Invoke("ShowFNAStep7_Arrow", 10);
    }

    void ShowFNAStep7_Arrow()
    {
        if(FNA_Adapter_Coll.enabled&&DoShowInfo)
        {
            FNA_Step7_Arrow.SetActive(true);
        }
    }

    public void OnStep9Finished()
    {
        FNA_Inside_Wrist.SetActive(false);
        Shaft.SetActive(true);
        Button.SetActive(true);
        Syringe_Coll.gameObject.SetActive(true);
        Case.SetActive(true);

        DisableAllCollider();
        ScreenIndex = ScreenIndex + 1;
        FNA_Hand_Coll.enabled = true;
        ShowCurrentScreen();
        Invoke("ShowHandArrow", 15);
    }

    void ShowHandArrow()
    {
        if(FNA_Hand_Coll.enabled && DoShowInfo )
        {
            Hand_Arrow.SetActive(true);
        }
    }
    void OnNeedleRemovedStep10()
    {
        Full_Breast.SetActive(false);
        Half_Breast.SetActive(false);
        HospitalCart.SetActive(true);
        Patient.SetActive(true);
        BigNeedle_New.SetActive(false);
        Sequence s1 = DOTween.Sequence();
        s1.Append(FNA_Adapter_Coll.transform.DOLocalMove(FNA_Step10_AboveCover.localPosition, 2f)).SetEase(Ease.Linear)
            .OnComplete(OnFNAReachedAboveCover);

        Sequence s2 = DOTween.Sequence();
        s2.Append(FNA_Adapter_Coll.transform.DOLocalRotate(FNA_Step10_AboveCover.localEulerAngles, 1f)).SetEase(Ease.Linear);
    }

    void OnFNAReachedAboveCover()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(FNA_Adapter_Coll.transform.DOLocalMove(FNA_Step10_InCover.localPosition, 2f)).SetEase(Ease.Linear)
            .OnComplete(OnFNAReachedInCover);
    }

    void OnFNAReachedInCover()
    {
        Cover.transform.parent = Syringe_Coll.transform;

        Sequence s1 = DOTween.Sequence();
        s1.Append(FNA_Adapter_Coll.transform.DOLocalMove(FNA_Adapter_Step10_Standing.localPosition, 2f)).SetEase(Ease.Linear)
            .OnComplete(OnFNA_StandFinished);

        s1.Append(FNA_Adapter_Coll.transform.DOLocalRotate(FNA_Adapter_Step10_Standing.localEulerAngles, 1f)).SetEase(Ease.Linear);
    }

    void OnFNA_StandFinished()
    {
        Syringe_Coll.transform.parent = null;
        Plunger.transform.parent = Syringe_Coll.transform.GetChild(0);
        Sequence s1 = DOTween.Sequence();
        Syringe_Coll.GetComponent<LymphNode_Element>().MyHand.transform.localPosition = Syringe_Coll.GetComponent<LymphNode_Element>().HandInitialPosition;
        Syringe_Coll.GetComponent<LymphNode_Element>().MyHand.SetActive(true);
        s1.Append(Syringe_Coll.transform.DOLocalMove(Syring_Step10.localPosition, 2f)).SetEase(Ease.Linear);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Syringe_Coll.transform.DOLocalRotate(Syring_Step10.localEulerAngles, 1f)).SetEase(Ease.Linear);

        Sequence s3 = DOTween.Sequence();
        s1.Append(FNA_Adapter_Coll.transform.DOLocalMove(FNA_Adapter_Step10_Lying.localPosition, 2f)).SetEase(Ease.Linear)
        .OnComplete(OnFNAPlacedOnTray);

        Sequence s4 = DOTween.Sequence();
        s2.Append(FNA_Adapter_Coll.transform.DOLocalRotate(FNA_Adapter_Step10_Lying.localEulerAngles, 1f)).SetEase(Ease.Linear);

        Invoke("OnSyringeRemovedFromFNA", 3);
    }

    void OnFNAPlacedOnTray()
    {
        FNA_Adapter_Coll.GetComponent<LymphNode_Element>().RemoveHand();
    }

    void OnSyringeRemovedFromFNA()
    {
        DisableAllCollider();
        ScreenIndex = ScreenIndex + 1;
        Syringe_Cover_Coll.enabled = true;
        ShowCurrentScreen();
        Slide1.SetActive(true);
        Slide2.SetActive(true);
        Syringe_Coll.GetComponent<LymphNode_Element>().MyHand.SetActive(false);
        Syringe_Coll.GetComponent<LymphNode_Element>().MyHand2.SetActive(true);
        Invoke("Show_SyringeCover_Arrow_Step10", 10);
    }

    void Show_SyringeCover_Arrow_Step10()
    {
        if(Syringe_Cover_Coll.enabled && DoShowInfo)
        {
            Syringe_Cover_Arrow_Step10.SetActive(true);
        }
    }
    public void GoToNextPage()
    {
        CurrentPage = CurrentPage + 1;
        if(CurrentPage>2)
        {
            CurrentPage = 2;
        }
        HideAllPages();
        if (Simulation_Backend.SelectedLanguageID == 0)
        {
            Pages_English[CurrentPage].SetActive(true);
        }
        else
        {
            Pages_French[CurrentPage].SetActive(true);
        }
        
    }

    void HideAllPages()
    {
        for (int i = 0; i < Pages_English.Length; i++)
        {
            Pages_English[i].SetActive(false);
        }

        for (int i = 0; i < Pages_French.Length; i++)
        {
            Pages_French[i].SetActive(false);
        }
    }

    public void GoToPrePage()
    {
        CurrentPage = CurrentPage - 1;
        if (CurrentPage < 0)
        {
            CurrentPage = 0;
        }
        HideAllPages();
        if (Simulation_Backend.SelectedLanguageID == 0)
        {
            Pages_English[CurrentPage].SetActive(true);
        }
        else
        {
            Pages_French[CurrentPage].SetActive(true);
        }

    }

}


[Serializable]
public class LimphNode_Data
{
    // 0 English , 1 French
    public string Step_Number;
    public string[] Step_Description;
    public AudioClip[] Item_Audio;
}
