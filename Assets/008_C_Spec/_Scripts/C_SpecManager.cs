using UnityEngine;
using DG.Tweening;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class C_SpecManager : MonoBehaviour
{
    public static C_SpecManager Instance;
    public int ArrowDelay = 20;
    [Header(" ##### FNA INSTANCE ####")]
    public C_SpecData[] C_SpecData_Instance;

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


    public GameObject StartButton;
    public TextMeshProUGUI StartButtonText;
    public GameObject ReStartButton;
    public TextMeshProUGUI ReStartButtonText;
    public Transform CameraObj;
    public Transform CameraObj_Initial;
    public Transform CameraObj_TrayPoint;
    public Transform CameraObj_Step7;

    [Header("#### INFO ####")]
    public GameObject InfoButton;
    public GameObject InfoOnImage;
    public GameObject InfoOffImage;


    [Header("#### AUDIO ####")]
    public GameObject SoundButton;
    public GameObject SoundOnImage;
    public GameObject SoundOffImage;
    public AudioSource C_Spec_AudioSource;

    [Header("#### TOOL TIP ####")]
    public TextMeshProUGUI RestartToolTip;
    public TextMeshProUGUI SoundToolTip;
    public TextMeshProUGUI InfoToolTip;
    public TextMeshProUGUI MenuToolTip;

  


    [Header("#### ITEMS ON TABLE ####")]
    public GameObject SmartPhone;
    public GameObject SmartPhone_AtFocusPoint;
    public GameObject SmartPhone_OnAssemblyHand;
    public GameObject SmartPhone_GicMed;
    public GameObject SmartPhoneHolder;
    public GameObject SmartPhoneHolder_AtFocusPoint;
    public GameObject SmartPhoneHolder_AtFit_Point;
    public GameObject AssemblyHandObj;
    public GameObject AssemblyHand;
    public GameObject AssemblyHand_Mesh;
    public GameObject AssemblyHand_Grabbed;
    public GameObject AssemblyHand_Glove;
    public GameObject AssemblyHand_Initial;
    public GameObject AssemblyHand_Target;
    public GameObject AssemblyHand_AtRightGlove; 
    public GameObject AssemblyHand_At_Sheath;
    public GameObject AssemblyHand_Rotation;
    public GameObject AssemblyHand_InsideUterus;
    public GameObject SpeculumInsertion_Thumbnail;
    public GameObject Speculum_Thumbnail;
    public GameObject Speculum_Thumbnail_InsideUterus;
    public GameObject Speculum_Thumbnail_OutsideUterus;
    public GameObject Posterior_Thumbnail_Obj;
    public GameObject Posterior_Thumbnail;
    public GameObject Posterior_Thumbnail_TargetRotation;
    public GameObject Posterior_Thumbnail_DeviceFocus;
    public GameObject Posterior_Thumbnail_Back;
    public GameObject Posterior_Smartphone;
    public GameObject Posterior_Smartphone_FlapImage;
    public GameObject FlapObj;
    public GameObject Flap_Top;
    public GameObject Flap_Bottom;
    public GameObject Speculum_Device;
    public GameObject ScrewingHandObj;
    public GameObject Flap_Top_Device;
    public GameObject Flap_Bottom_Device;
    public GameObject CervixCircle;
    public GameObject Speculum_Thumbnail_Collider;
    public GameObject Table;
    public GameObject Flaps_Parent;


    public GameObject TypingHand_Obj;
    public GameObject TypingHand;
    public GameObject TypingHand_glove_R;
    public GameObject TypingHand_MobileScreen;
    public GameObject TypingHand_MobileScreenInitial;
    public GameObject Glove_Hand_Right_Obj;
    public GameObject Glove_Left_AtStep7;
    public GameObject Glove_Left;
    public GameObject Glove_Left_Target;
    public GameObject Glove_Right;
    public GameObject Glove_Right_Target;
    public GameObject Glove_Hand_Right;
    public GameObject RightHandGlove;
    public GameObject Glove_Hand_Right_Initial;
    public GameObject Glove_Hand_Right_Target;
    public GameObject Glove_Hand_Right_AtGlove;
    public GameObject Glove_Hand_Right_AtSpeculum;
    public GameObject Glove_Hand_Right_BehindSheath;
    public GameObject Glove_Hand_Right_InsideSheath;
    public GameObject Glove_Hand_Right_AtEndoscope;

    [Header("#### STEP 9 ####")]
    public GameObject Glove_Hand_Right_BehindSheath_Step9;
    public GameObject Glove_Hand_Right_InsideSheath_Step9;
    public GameObject Step9_Cylinder;
    public GameObject Step9_CableStart;
    public GameObject Step9_CableStartReference;
    public GameObject Glove_Hand_Right_AtMobilePort;
    public GameObject Glove_Hand_Right_InsideMobilePort;
    public GameObject Glove_Hand_Right_AtLubricant;
    public GameObject Glove_Hand_Right_AboveSheath;

    public GameObject Lubricant;
    public GameObject Lubricant_Drop;

    public GameObject Smart_Speculum;
    public GameObject SmartSpeculum_FittingReference;
    public GameObject Sheath40;
    public GameObject Sheath40_ReferenceInsideSheath;
    public GameObject Sheath_InsideHand;
    public GameObject Endoscope;
    public GameObject Endoscope_MobilePort;
    public GameObject Endoscope_MobilePort_InsideMobile;
    public GameObject Endoscope_AtTableCenter;

    [Header("#### STEP 10 ####")]
    public GameObject Smart_Speculum_Tube;


    [Header("#### STEP 12 ####")]
    public GameObject Step12_Collider;

    [Header("#### STEP 15 ####")]
    public GameObject Step15_Setup;
    public GameObject Step15_Collider;
    public GameObject Step15_Arrow;

    [Header("#### STEP 19 ####")]
    public GameObject Swab1;
    public GameObject Swab1_Hand;
    public GameObject Swab1_Hand_Initial;
    public GameObject Swab1_Hand_Target;
    public GameObject Swab1_Hand_AboveDish;
    public GameObject Swab1_Hand_IntoDish;
    public GameObject Swab1_Hand_BehindDevice;
    public GameObject Swab1_Hand_IntoDevice;
    public GameObject Swab1_Thumbnail;
    public GameObject Swab1_Thumbnail_Target;
    public GameObject Swab1_Flaps;
    public GameObject KidneyDishWhite;

    [Header("#### STEP 20 ####")]
    public GameObject SprayBottle;
    public GameObject SprayBottle_Target;
    public GameObject SprayBottle_Hand;
    public GameObject SprayBottle_Hand_Initial;
    public GameObject SprayBottle_Hand_AtBottle;
    public GameObject SprayBottle_IntoDevice;
    public GameObject SprayBottle_RightThumbnail;
    public GameObject SprayBottle_RightThumbnail_Target;
    public GameObject SprayDrops;


    [Header("#### STEP 21 ####")]
    public GameObject Step21_Cervical_Brush;
    public GameObject Cervical_Brush;
    public GameObject Cervical_Brush_Target;
    public GameObject Cervical_Brush_Hand;
    public GameObject Cervical_Brush_Hand_Initial;
    public GameObject Cervical_Brush_Hand_AtBrush;
    public GameObject Cervical_Brush_Hand_IntoDevice;
    public GameObject Cervical_Brush_RightThumbnail;
    public GameObject Cervical_Brush_RightThumbnail_Target;
    public GameObject Cervical_Brush_LeftThumbnail;


    [Header("#### STEP 22 ####")]
    public GameObject Step22_Biopsy_Forceps;
    public GameObject Biopsy_Forceps;
    public GameObject Biopsy_Forceps_Target;
    public GameObject Biopsy_Forceps_InHand;
    public GameObject Biopsy_Forceps_Hand;
    public GameObject Biopsy_Forceps_Initial;
    public GameObject Biopsy_Forceps_Hand_AtForcep;
    public GameObject Biopsy_Forceps_Hand_IntoDevice;
    public GameObject Biopsy_Forceps_RightThumbnail;
    public GameObject Biopsy_Forceps_RightThumbnail_Target;
    public GameObject Biopsy_Forceps_LeftThumbnail;
    public GameObject Cervix_Piece;
    public GameObject Biopsy_Forceps_LeftThumbnail_Target;
    public GameObject Biopsy_Forceps_LeftThumbnail_Initial;

    public GameObject Biopsy_Forceps_Bloodspot;


    [Header("#### STEP 23 ####")]
    public GameObject FlapLeft_Step23;
    public GameObject UnScrewingHandObj;

    [Header("#### STEP 24 ####")]
    public GameObject Step24_Collider;
    public GameObject Smart_SpeculumCorrectPlace;
    public GameObject Smart_Speculum_Step24;
    public GameObject Smart_SpeculumTube;

    [Header("#### STEP 25 ####")]
    public GameObject Step25_Collider;
    public GameObject Step25_Arrow;
    public GameObject Step25_Hand;
    public GameObject Step25_Hand_Initial;
    public GameObject Step25_Hand_OnSheth;
    public GameObject Step25_Sheath40;
    public GameObject Step25_Sheath40_OutsideDevice;
    public GameObject Step25_Sheath40_IntoTrash;
    public GameObject Step25_Bin;
    public GameObject Step25_Endoscope;
    public GameObject Step25_Mobile;
    public GameObject Step25_DeviceHand;

    public GameObject Step25_Endoscope_Hand;
    public GameObject Step25_Endoscope_Hand_AtMobile;
    public GameObject Step25_MobileUnpluged;
    public GameObject Step25_Endoscope_Hand_AtEndoscope;
    public GameObject Step25_MobileUnplugedRotated;
    public GameObject Step25_CableStart;
    public GameObject Step25_MobileRotatedOnTable;
    public GameObject Step25_Cable_Target;
    public GameObject Step25_Endoscope_Outside;
    public GameObject Step25_Endoscope_OnTable;

    public GameObject Posterior_Thumbnail_BehindDish;
    public GameObject Posterior_Thumbnail_InDish;

    public GameObject Posterior_RightHand;




    [Header("#### NoticeBoard ####")]
    public int CurrentPage;
    public GameObject[] Pages_English;
    public GameObject[] Pages_French;

    [Header("#### ARROWS ####")]
    public GameObject SmartPhone_Arrow;
    public GameObject SmartPhoneHolder_Arrow;
    public GameObject Glove_Left_Arrow;
    public GameObject Glove_Right_Arrow;
    public GameObject Smart_Speculum_Arrow;
    public GameObject Sheath40_Arrow;
    public GameObject Endoscope_Arrow;
    public GameObject Lubricant_Arrow;
    public GameObject Posterior_Smartphone_Arrow;
    public GameObject ScrewingHand_Arrow;
    public GameObject Speculum_Thumbnail_Arrow;
    public GameObject Swab1_Arrow;
    public GameObject SprayBottle_Arrow;
    public GameObject Cervical_Brush_Arrow;
    public GameObject Biopsy_Forceps_Arrow;
    public GameObject FlapLeft_Step23_Arrow;

    public GameObject[] AllArrows;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        LanguageSelection.SetActive(true);
        DisableAllCollider();


    }


    public void DisableAllCollider()
    {
        SmartPhone.GetComponent<BoxCollider>().enabled = false;
        SmartPhoneHolder.GetComponent<BoxCollider>().enabled = false;
        Smart_Speculum.GetComponent<BoxCollider>().enabled = false;
        Sheath40.GetComponent<BoxCollider>().enabled = false;
        Posterior_Smartphone.GetComponent<BoxCollider>().enabled = false;
        Speculum_Device.GetComponent<BoxCollider>().enabled = false;
        Speculum_Thumbnail_Collider.GetComponent<BoxCollider>().enabled = false;
        Swab1.GetComponent<BoxCollider>().enabled = false;
        SprayBottle.GetComponent<BoxCollider>().enabled = false;
        Cervical_Brush.GetComponent<BoxCollider>().enabled = false;
        Biopsy_Forceps.GetComponent<BoxCollider>().enabled = false;
        FlapLeft_Step23.GetComponent<BoxCollider>().enabled = false;
        Step12_Collider.GetComponent<BoxCollider>().enabled = false;
        Step15_Collider.GetComponent<BoxCollider>().enabled = false;
        Step24_Collider.GetComponent<BoxCollider>().enabled = false;
        Step25_Collider.GetComponent<BoxCollider>().enabled = false;

    }


    public void ToogleSound()
    {
        if (C_Spec_AudioSource.volume == 1)
        {
            C_Spec_AudioSource.volume = 0;
            SoundOnImage.SetActive(false);
            SoundOffImage.SetActive(true);
        }
        else
        {
            C_Spec_AudioSource.volume = 1;
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
            for (int i = 0; i < AllArrows.Length; i++)
            {
                if (AllArrows[i].activeSelf)
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
        C_Spec_AudioSource.Stop();
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        StartCoroutine(AnimateMenuButton());
    }

    IEnumerator AnimateMenuButton()
    {
        Sequence s = DOTween.Sequence();
        s.Append(MenuButton.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f).SetEase(Ease.Linear));
        s.SetLoops(-1);
        yield return new WaitForSeconds(C_SpecData_Instance[ScreenIndex].Item_Audio[Simulation_Backend.SelectedLanguageID].length + 1);
        s.Kill();
        MenuButton.transform.localScale = Vector3.one;
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();

        Sequence s2 = DOTween.Sequence();
        s2.Append(CameraObj.transform.DOLocalMove(CameraObj_TrayPoint.localPosition, 3f)).SetEase(Ease.Linear);

        Sequence s3 = DOTween.Sequence();
        s3.Append(CameraObj.transform.DOLocalRotate(CameraObj_TrayPoint.localEulerAngles, 1.5f)).SetEase(Ease.Linear);

        Invoke("OnCameraReachedToTray",
            C_SpecData_Instance[ScreenIndex].Item_Audio[Simulation_Backend.SelectedLanguageID].length + 1);
    }

    void OnCameraReachedToTray()
    {
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        SmartPhone.GetComponent<BoxCollider>().enabled = true;
        Invoke("ShowSmartPhone_Arrow", ArrowDelay);
    }

    public void FocusSmartphone()
    {
        Sequence s2 = DOTween.Sequence();
        s2.Append(SmartPhone.transform.DOLocalMove(SmartPhone_AtFocusPoint.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnSmartPhoneFocusCompleted);

        Sequence s3 = DOTween.Sequence();
        s3.Append(SmartPhone.transform.DOLocalRotate(SmartPhone_AtFocusPoint.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);

    }

    void OnSmartPhoneFocusCompleted()
    {
        SmartPhoneHolder.GetComponent<BoxCollider>().enabled = true;
        Invoke("ShowSmartPhoneHolder_Arrow", ArrowDelay);
    }

    public void FocusSmartphoneHolder()
    {
        Sequence s2 = DOTween.Sequence();
        s2.Append(SmartPhoneHolder.transform.DOLocalMove(SmartPhoneHolder_AtFocusPoint.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnSmartPhoneHolderFocusCompleted);

        Sequence s3 = DOTween.Sequence();
        s3.Append(SmartPhoneHolder.transform.DOLocalRotate(SmartPhoneHolder_AtFocusPoint.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);

    }

    void OnSmartPhoneHolderFocusCompleted()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(SmartPhoneHolder.transform.DOLocalMove(SmartPhoneHolder_AtFit_Point.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnSmartPhoneFit);

        Sequence s2 = DOTween.Sequence();
        s2.Append(SmartPhoneHolder.transform.DOLocalRotate(SmartPhoneHolder_AtFit_Point.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);

    }

    void OnSmartPhoneFit()
    {
        SmartPhoneHolder.GetComponent<C_SpecElement>().RemoveHand();
        Invoke("ShowStep4or5", 1.5f);
    }

    void ShowStep4or5()
    {
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        SmartPhone.GetComponent<BoxCollider>().enabled = true;
        Invoke("ShowSmartPhone_Arrow", ArrowDelay);
    }

    void EnterAssemblyHand()
    {
        AssemblyHand.SetActive(true);
        Sequence s1 = DOTween.Sequence();
        s1.Append(AssemblyHand.transform.DOLocalMove(AssemblyHand_Target.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnAssemblyHandEntered);
    }

    void OnAssemblyHandEntered()
    {
        SmartPhoneHolder.transform.parent = SmartPhone.transform;
        Sequence s1 = DOTween.Sequence();
        s1.Append(SmartPhone.transform.DOLocalMove(SmartPhone_OnAssemblyHand.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnSmartPhoneFitOnAssemblyHand);

        Sequence s2 = DOTween.Sequence();
        s2.Append(SmartPhone.transform.DOLocalRotate(SmartPhone_OnAssemblyHand.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);

    }

    void OnSmartPhoneFitOnAssemblyHand()
    {
        SmartPhone.GetComponent<C_SpecElement>().RemoveHand();
        Invoke("ShowStep4or5", 1.5f);
    }

    void ShowGicMedLogoAndTypingHand()
    {
        SmartPhone_GicMed.SetActive(true);
        TypingHand_Obj.SetActive(true);
    }

    public void StartStep7()  // Step-7
    {
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Glove_Hand_Right.SetActive(true);
        Sequence s = DOTween.Sequence();
        s.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_Target.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnGloveHandEntered);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Glove_Left.transform.DOLocalMove(Glove_Left_AtStep7.transform.localPosition, 0.5f)).SetEase(Ease.Linear);

    }

    public void OnGloveHandEntered()
    {

        Glove_Left.GetComponent<BoxCollider>().enabled = true;
        Invoke("Show_Left_GloveArrow", ArrowDelay);
    }

    public IEnumerator PickUpLeftGlove()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_AtGlove.transform.localPosition, 2f)).SetEase(Ease.Linear);

        yield return new WaitForSeconds(2.1f);
        Glove_Hand_Right_Obj.transform.parent = Glove_Left.transform;
        Sequence s2 = DOTween.Sequence();
        s2.Append(Glove_Left.transform.DOLocalMove(Glove_Left_Target.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnLeftGloveWorn);

        Sequence s3 = DOTween.Sequence();
        s3.Append(Glove_Left.transform.DOLocalRotate(Glove_Left_Target.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
    }

    void OnLeftGloveWorn()
    {
        Glove_Left_Arrow.transform.GetChild(0).gameObject.SetActive(false);
        Glove_Hand_Right_Obj.transform.parent = null;
        Glove_Left.SetActive(false);
        AssemblyHand_Glove.SetActive(true);
        Glove_Hand_Right.transform.parent = null;
        Glove_Hand_Right_Obj.transform.localPosition = Vector3.zero;
        Glove_Hand_Right_Obj.transform.localEulerAngles = Vector3.zero;
        Glove_Hand_Right.transform.parent = Glove_Hand_Right_Obj.transform;
        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_Target.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnGloveRightHandReset);
        Sequence s2 = DOTween.Sequence();
        s2.Append(Glove_Hand_Right.transform.DOLocalRotate(Glove_Hand_Right_Target.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
    }

    void OnGloveRightHandReset()
    {
        Glove_Right.GetComponent<BoxCollider>().enabled = true;
        Invoke("Show_Right_GloveArrow", ArrowDelay);
    }

    public IEnumerator PickUpRightGlove()
    {
        SmartPhone.transform.parent = AssemblyHand.transform;
        Sequence s1 = DOTween.Sequence();
        s1.Append(AssemblyHand.transform.DOLocalMove(AssemblyHand_AtRightGlove.transform.localPosition, 2f)).SetEase(Ease.Linear);

        Sequence s2 = DOTween.Sequence();
        s2.Append(AssemblyHand.transform.DOLocalRotate(AssemblyHand_AtRightGlove.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);

        AssemblyHandObj.transform.parent = Glove_Right.transform;

        yield return new WaitForSeconds(2.1f);
        
        Sequence s3 = DOTween.Sequence();
        s3.Append(Glove_Right.transform.DOLocalMove(Glove_Right_Target.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnRightGloveWorn);

        Sequence s4 = DOTween.Sequence();
        s4.Append(Glove_Right.transform.DOLocalRotate(Glove_Right_Target.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
    }


    void OnRightGloveWorn()
    {
        AssemblyHandObj.transform.parent = null;
        Glove_Right.SetActive(false);
        RightHandGlove.SetActive(true);
        AssemblyHand.transform.parent = null;
        AssemblyHandObj.transform.localPosition = Vector3.zero;
        AssemblyHandObj.transform.localEulerAngles = Vector3.zero;
        AssemblyHand.transform.parent = AssemblyHandObj.transform;
        Sequence s1 = DOTween.Sequence();
        s1.Append(AssemblyHand.transform.DOLocalMove(AssemblyHand_Target.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnAssemblyHandReset);
        Sequence s2 = DOTween.Sequence();
        s2.Append(AssemblyHand.transform.DOLocalRotate(AssemblyHand_Target.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
    }

    void OnAssemblyHandReset()   //Step-8
    {
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        Smart_Speculum.GetComponent<BoxCollider>().enabled = true;
        Invoke("Show_SmartSpeculum_Arrow", ArrowDelay);
    }

    public void PickUpSmartSpeculum()
    {
        Smart_Speculum_Arrow.SetActive(false);
        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_AtSpeculum.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnRightHandReachedToSpeculum);
    }

    void OnRightHandReachedToSpeculum()
    {
        Smart_Speculum.transform.parent = Glove_Hand_Right.transform;
        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_Target.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnRightHandReachedToFocus);
    }

    void OnRightHandReachedToFocus()
    {
        DisableAllCollider();
        Sheath40.GetComponent<BoxCollider>().enabled = true;
        Invoke("Show_Sheath40_Arrow", ArrowDelay);
    }

    public void PickUpSheath40()
    {
        Sheath40_Arrow.SetActive(false);
        AssemblyHand_Grabbed.SetActive(true);
        AssemblyHand_Mesh.SetActive(false);
        AssemblyHand_Glove.SetActive(false);
        SmartPhone.GetComponent<C_SpecElement>().MyHand.SetActive(false);
        Sequence s1 = DOTween.Sequence();
        s1.Append(AssemblyHand.transform.DOLocalMove(AssemblyHand_At_Sheath.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnLeftHandReachedToSheath);

        Sequence s2 = DOTween.Sequence();
        s2.Append(AssemblyHand.transform.DOLocalRotate(AssemblyHand_At_Sheath.transform.localEulerAngles, 2f)).SetEase(Ease.Linear);
    }

    void OnLeftHandReachedToSheath()
    {
        Sheath40.transform.parent = AssemblyHand.transform;
        Sheath40.transform.localPosition = Sheath40_ReferenceInsideSheath.transform.localPosition;
        Sheath40.transform.localEulerAngles = Sheath40_ReferenceInsideSheath.transform.localEulerAngles;
        Sheath40.transform.localScale = Sheath40_ReferenceInsideSheath.transform.localScale;


        Sequence s1 = DOTween.Sequence();
        s1.Append(AssemblyHand.transform.DOLocalMove(AssemblyHand_Target.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnAssemblyHandReachedToFocus);

        Sequence s2 = DOTween.Sequence();
        s2.Append(AssemblyHand.transform.DOLocalRotate(AssemblyHand_Target.transform.localEulerAngles, 2f)).SetEase(Ease.Linear);

        Sequence s3 = DOTween.Sequence();
        s3.Append(Sheath40.transform.DOLocalRotate(Sheath_InsideHand.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);


    }

    void OnAssemblyHandReachedToFocus()  //Right hand will go to behind the assembly hand to fit smart into sheath
    {
        Sheath40.transform.localPosition = Sheath40_ReferenceInsideSheath.transform.localPosition;
        Sheath40.transform.localEulerAngles = Sheath40_ReferenceInsideSheath.transform.localEulerAngles;
        Sheath40.transform.localScale = Sheath40_ReferenceInsideSheath.transform.localScale;

        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_BehindSheath.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnRightHandReachedBehindSmart_Speculum);
        Sequence s2 = DOTween.Sequence();
        s2.Append(Glove_Hand_Right.transform.DOLocalRotate(Glove_Hand_Right_BehindSheath.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
    }

    void OnRightHandReachedBehindSmart_Speculum()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_InsideSheath.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(ResetHandAfterSpeculumFitIntoSheath);
        Sequence s2 = DOTween.Sequence();
        s2.Append(Glove_Hand_Right.transform.DOLocalRotate(Glove_Hand_Right_InsideSheath.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
    }

    void ResetHandAfterSpeculumFitIntoSheath()
    {
        Smart_Speculum.transform.parent = null;

        Smart_Speculum.transform.localPosition = SmartSpeculum_FittingReference.transform.localPosition;
        Smart_Speculum.transform.localEulerAngles = SmartSpeculum_FittingReference.transform.localEulerAngles;
        Smart_Speculum.transform.localScale = SmartSpeculum_FittingReference.transform.localScale;

        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_Target.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(ShowStep9);
        Sequence s2 = DOTween.Sequence();
        s2.Append(Glove_Hand_Right.transform.DOLocalRotate(Glove_Hand_Right_Target.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);

        Sequence s3 = DOTween.Sequence();
        s3.Append(Endoscope.transform.DOLocalMove(Endoscope_AtTableCenter.transform.localPosition, 0.5f)).SetEase(Ease.Linear);
    }

    void ShowStep9()  //Step-9
    {
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        Endoscope.GetComponent<BoxCollider>().enabled = true;
        Invoke("Show_Endoscope_Arrow", ArrowDelay); 
    }

    public void PickUpEndoscope()
    {
        Endoscope.GetComponent<BoxCollider>().enabled = false;

        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_AtEndoscope.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnRightHandReachedAtCable);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Glove_Hand_Right.transform.DOLocalRotate(Glove_Hand_Right_AtEndoscope.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
    }

    void OnRightHandReachedAtCable()
    {
        Endoscope.transform.parent = Glove_Hand_Right.transform;

        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_BehindSheath_Step9.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(InsertCableIntoSheath);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Glove_Hand_Right.transform.DOLocalRotate(Glove_Hand_Right_BehindSheath_Step9.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
    }

    void InsertCableIntoSheath()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_InsideSheath_Step9.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(PickMobilePort);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Glove_Hand_Right.transform.DOLocalRotate(Glove_Hand_Right_InsideSheath_Step9.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
    }

    void PickMobilePort()
    {
        
        Endoscope.transform.parent = null;
        Step9_Cylinder.SetActive(false);
        Step9_CableStart.transform.localPosition = Step9_CableStartReference.transform.localPosition;
        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_AtMobilePort.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(ConnectMobilePort);
    }

    void ConnectMobilePort()
    {
        Endoscope_MobilePort.transform.parent = Glove_Hand_Right.transform;

        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_InsideMobilePort.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(ResetHandAfterConnection);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Glove_Hand_Right.transform.DOLocalRotate(Glove_Hand_Right_InsideMobilePort.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
    }

    void ResetHandAfterConnection()
    {
        Endoscope_MobilePort.transform.parent = null;
        Endoscope_MobilePort.transform.localPosition = Endoscope_MobilePort_InsideMobile.transform.localPosition;
        Endoscope_MobilePort.transform.localEulerAngles = Endoscope_MobilePort_InsideMobile.transform.localEulerAngles;
        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_Target.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(ShowStep10);
        Sequence s2 = DOTween.Sequence();
        s2.Append(Glove_Hand_Right.transform.DOLocalRotate(Glove_Hand_Right_Target.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
    }

    void ShowStep10()  //Step-10
    {
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Lubricant.SetActive(true);
        Invoke("Show_Lubricant_Arrow", ArrowDelay);       
    }

    public void PickUpLubbricant()
    {
        Lubricant.GetComponent<BoxCollider>().enabled = false;
        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_AtLubricant.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(OnRightHandReachedAtLubbricant);
        Sequence s2 = DOTween.Sequence();
        s2.Append(Glove_Hand_Right.transform.DOLocalRotate(Glove_Hand_Right_AtLubricant.transform.localEulerAngles, 1f)).SetEase(Ease.Linear);
    }

    void OnRightHandReachedAtLubbricant()
    {
        Lubricant.transform.parent = Glove_Hand_Right.transform;
        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_AboveSheath.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(StartPauring);
        Sequence s2 = DOTween.Sequence();
        s2.Append(Glove_Hand_Right.transform.DOLocalRotate(Glove_Hand_Right_AboveSheath.transform.localEulerAngles, 2f)).SetEase(Ease.Linear);
    }

    void StartPauring()
    {
        Sheath40.transform.parent = AssemblyHandObj.transform;
        Smart_Speculum.transform.parent = AssemblyHandObj.transform;
        Endoscope.transform.parent= AssemblyHandObj.transform;
        Endoscope_MobilePort.transform.parent= AssemblyHandObj.transform;
        AssemblyHandObj.transform.parent = AssemblyHand_Rotation.transform;
        Sequence s1 = DOTween.Sequence();
        Lubricant_Drop.SetActive(true);
        Smart_Speculum_Tube.SetActive(false);
        s1.Append(AssemblyHand_Rotation.transform.DOLocalRotate(new Vector3(170,0,0), 2f)).SetEase(Ease.Linear).OnComplete(ResetHandRotation);
    }

    void ResetHandRotation()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(AssemblyHand_Rotation.transform.DOLocalRotate(new Vector3(0, 0, 0), 2f)).SetEase(Ease.Linear).OnComplete(ResetBottleHand);
    }

    void ResetBottleHand() 
    {
        Lubricant_Drop.SetActive(false);
        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_Target.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(ShowStep11);
        Sequence s2 = DOTween.Sequence();
        s2.Append(Glove_Hand_Right.transform.DOLocalRotate(Glove_Hand_Right_Target.transform.localEulerAngles, 2f)).SetEase(Ease.Linear);
    }

    void ShowStep11()  //Step-11
    {
        Smart_Speculum_Tube.SetActive(true);
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Lubricant.SetActive(false);
        Sequence s1 = DOTween.Sequence();
        s1.Append(Glove_Hand_Right.transform.DOLocalMove(Glove_Hand_Right_Initial.transform.localPosition, 2f)).SetEase(Ease.Linear);
        Invoke("InsertSpeculumIntoUterus",
            C_SpecData_Instance[ScreenIndex].Item_Audio[Simulation_Backend.SelectedLanguageID].length + 1);
    }

    void InsertSpeculumIntoUterus()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(AssemblyHand_Rotation.transform.DOLocalMove(AssemblyHand_InsideUterus.transform.localPosition, 5f)).SetEase(Ease.Linear).OnComplete(ShowStep12);
        Invoke("ShowThumbnail", 3);
    }

    void ShowThumbnail()
    {
        SpeculumInsertion_Thumbnail.SetActive(true);
        Sequence s2 = DOTween.Sequence();
        s2.Append(Speculum_Thumbnail.transform.DOLocalMove(Speculum_Thumbnail_InsideUterus.transform.localPosition, 2f)).SetEase(Ease.Linear);
    }
    void ShowStep12() //Step-12
    {        
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Step12_Collider.SetActive(true);
        Step12_Collider.GetComponent<BoxCollider>().enabled = true;
        AssemblyHand_Rotation.SetActive(false);
        Posterior_Thumbnail_Obj.SetActive(true);
        Invoke("Show_Step12_Arrow", ArrowDelay);
    }

    void RotateThumbnails()
    {
        Speculum_Thumbnail_Arrow.SetActive(false);
        Sequence s1 = DOTween.Sequence();
        s1.Append(Posterior_Thumbnail.transform.DOLocalRotate(Posterior_Thumbnail_TargetRotation.transform.localEulerAngles, 4f)).SetEase(Ease.Linear);//.OnComplete(ShowStep13);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Speculum_Thumbnail.transform.DOLocalRotate(Speculum_Thumbnail_InsideUterus.transform.localEulerAngles, 4f)).SetEase(Ease.Linear);

        Invoke("ShowStep13",5);

    }


    void ShowStep13() //Step-13
    {
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Posterior_Smartphone.GetComponent<BoxCollider>().enabled = true;
        Posterior_Thumbnail_Obj.transform.localPosition = Posterior_Thumbnail_DeviceFocus.transform.localPosition;
        Posterior_Thumbnail_Obj.transform.localEulerAngles = Posterior_Thumbnail_DeviceFocus.transform.localEulerAngles;
        Invoke("Show_Posterior_SmartPhone_Arrow", ArrowDelay);
    }

    void TapOnMobileScreen()
    {
        Posterior_Smartphone_Arrow.SetActive(false);
        Sequence s1 = DOTween.Sequence();
        TypingHand_glove_R.SetActive(true);
        s1.Append(TypingHand.transform.DOLocalMove(TypingHand_MobileScreen.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(ResetTypingHandAfterClicked);
    }

    void ResetTypingHandAfterClicked()
    {
        Posterior_Smartphone_FlapImage.SetActive(true);
        Sequence s1 = DOTween.Sequence();
        s1.Append(TypingHand.transform.DOLocalMove(TypingHand_MobileScreenInitial.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(ShowStep14);
    }

    void ShowStep14() //Step-14
    {
        FlapObj.SetActive(true);
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Speculum_Device.GetComponent<BoxCollider>().enabled = true;
        Invoke("Show_ScrewingHand_Arrow", ArrowDelay);
    }

    Sequence ScrewingHandObj_s;
    void ScrewTheDevice()
    {
        ScrewingHand_Arrow.SetActive(false);
        ScrewingHandObj.SetActive(true);

        Sequence s1 = DOTween.Sequence();
        s1.Append(Flap_Top.transform.DOLocalRotate(new Vector3(-20, 0, 0), 3f)).SetEase(Ease.Linear).OnComplete(ShowStep15);


        ScrewingHandObj_s = DOTween.Sequence();
        ScrewingHandObj_s.Append(ScrewingHandObj.transform.DOLocalRotate(new Vector3(40, 0, 0), 3f).SetEase(Ease.Linear));
        ScrewingHandObj_s.SetLoops(-1);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Flap_Top_Device.transform.DOLocalRotate(new Vector3(10, 0, 0), 3f)).SetEase(Ease.Linear);

    }


    void ShowStep15() //Step-15
    {
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Step15_Collider.GetComponent<BoxCollider>().enabled = true;
        ScrewingHandObj.SetActive(false);
        SpeculumInsertion_Thumbnail.SetActive(false);
        Step15_Setup.SetActive(true);
        Invoke("Show_Step15_Arrow", ArrowDelay);
    }

    
    void ShowStep16() //Step-16
    {
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Step15_Arrow.SetActive(false);
        Step15_Setup.SetActive(false);
        ScrewingHandObj.SetActive(true);
        SpeculumInsertion_Thumbnail.SetActive(true);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Flap_Bottom.transform.DOLocalRotate(new Vector3(-10, 0, 0), 3f)).SetEase(Ease.Linear);
        Invoke("DisableScrewingHandObj_s",3);
        Sequence s3 = DOTween.Sequence();
        s3.Append(Flap_Bottom_Device.transform.DOLocalRotate(new Vector3(-10, 0, 0), 3f)).SetEase(Ease.Linear);

        Invoke("ShowStep17", C_Spec_AudioSource.clip.length + 1);
    }

    void DisableScrewingHandObj_s()
    {
        ScrewingHandObj_s.Kill();
    }

    void ShowStep17() //Step-17
    {
        ScrewingHandObj.SetActive(false);
        //FlapObj.SetActive(false);
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        CervixCircle.SetActive(true);
        Invoke("ShowStep18", C_Spec_AudioSource.clip.length + 1);
    }

    void ShowStep18() //Step-18
    {
        CervixCircle.SetActive(false);
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Table.SetActive(false);
        Speculum_Thumbnail_Collider.GetComponent<BoxCollider>().enabled = true;
        Invoke("Show_Speculum_Thumbnail_Arrow", ArrowDelay);
    }

    void StartRotatingLeftRight()
    {
        Speculum_Thumbnail_Arrow.SetActive(false);

        Sequence s1 = DOTween.Sequence();
        s1.Append(Posterior_Thumbnail.transform.DOLocalRotate(new Vector3(-10, 0, 55), 3f)).SetEase(Ease.Linear).OnComplete(Reset_Posterior_Thumbnail);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Speculum_Thumbnail.transform.DOLocalRotate(new Vector3(0,20,0), 3f)).SetEase(Ease.Linear);

        Sequence s3 = DOTween.Sequence();
        s3.Append(Flaps_Parent.transform.DOLocalRotate(new Vector3(-20, 60, 0), 3f)).SetEase(Ease.Linear);

    }

    void Reset_Posterior_Thumbnail()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(Posterior_Thumbnail.transform.DOLocalRotate(new Vector3(0, 0, 55), 3f)).SetEase(Ease.Linear).OnComplete(RotateRight);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Speculum_Thumbnail.transform.DOLocalRotate(new Vector3(0, -20, 0), 3f)).SetEase(Ease.Linear);

        Sequence s3 = DOTween.Sequence();
        s3.Append(Flaps_Parent.transform.DOLocalRotate(new Vector3(0, 60, 0), 3f)).SetEase(Ease.Linear);

    }

    void RotateRight()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(Posterior_Thumbnail.transform.DOLocalRotate(new Vector3(20, 0, 55), 3f)).SetEase(Ease.Linear).OnComplete(Reset_Posterior_Thumbnail2);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Speculum_Thumbnail.transform.DOLocalRotate(new Vector3(0, -60, 0), 3f)).SetEase(Ease.Linear);

        Sequence s3 = DOTween.Sequence();
        s3.Append(Flaps_Parent.transform.DOLocalRotate(new Vector3(20, 60, 0), 3f)).SetEase(Ease.Linear);


    }

    void Reset_Posterior_Thumbnail2()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(Posterior_Thumbnail.transform.DOLocalRotate(new Vector3(0, 0, 55), 3f)).SetEase(Ease.Linear).OnComplete(ShowStep19);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Speculum_Thumbnail.transform.DOLocalRotate(new Vector3(0, -20, 0), 3f)).SetEase(Ease.Linear);

        Sequence s3 = DOTween.Sequence();
        s3.Append(Flaps_Parent.transform.DOLocalRotate(new Vector3(0,60,0), 3f)).SetEase(Ease.Linear);

    }


    void ShowStep19() //Step-19
    {
        Table.SetActive(true);
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Swab1.GetComponent<BoxCollider>().enabled = true;
        Invoke("Show_Swab1_Arrow", ArrowDelay);
    }

    void PickUpSwab1()
    {
        DisableAllCollider();
        Swab1_Arrow.SetActive(false);
        Swab1_Hand.SetActive(true);
        Sequence s1 = DOTween.Sequence();
        s1.Append(Swab1_Hand.transform.DOLocalMove(Swab1_Hand_Target.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(MoveSwabUpwards);
    }

    void MoveSwabUpwards()
    {
        Swab1.transform.parent = Swab1_Hand.transform;

        Sequence s1 = DOTween.Sequence();
        s1.Append(Swab1_Hand.transform.DOLocalMove(Swab1_Hand_AboveDish.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(DipSwabIntoDish);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Swab1_Hand.transform.DOLocalRotate(Swab1_Hand_AboveDish.transform.localEulerAngles, 2f)).SetEase(Ease.Linear);
    }

    void DipSwabIntoDish()
    {
        KidneyDishWhite.SetActive(true);

        Sequence s1 = DOTween.Sequence();
        s1.Append(Swab1_Hand.transform.DOLocalMove(Swab1_Hand_IntoDish.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(ResetSwabUpwards);
    }

    void ResetSwabUpwards()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(Swab1_Hand.transform.DOLocalMove(Swab1_Hand_AboveDish.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(MoveSwabBehindDevice);
    }


    void MoveSwabBehindDevice()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(Swab1_Hand.transform.DOLocalMove(Swab1_Hand_BehindDevice.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(InsertSwabIntoDevice);

    }

    void InsertSwabIntoDevice()
    {
        Swab1_Flaps.SetActive(true);

        Sequence s1 = DOTween.Sequence();
        s1.Append(Swab1_Hand.transform.DOLocalMove(Swab1_Hand_IntoDevice.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(StartSwabUpDownAnimation);

        Swab1_Thumbnail.SetActive(true);
        Sequence s2 = DOTween.Sequence();
        s2.Append(Swab1_Thumbnail.transform.DOLocalMove(Swab1_Thumbnail_Target.transform.localPosition, 2f)).SetEase(Ease.Linear);
    }

    void StartSwabUpDownAnimation()
    {
        Swab1_Thumbnail.GetComponent<SwabUpDownAnimation>().GoSwabUp();
        Swab1_Flaps.GetComponent<SwabUpDownAnimation>().GoSwabUp();
        Invoke("ShowStep20", 6);
    }

    void ShowStep20() //Step-20
    {
        Swab1_Thumbnail.SetActive(false);
        Swab1_Flaps.SetActive(false);
        KidneyDishWhite.SetActive(false);
        Swab1_Hand.SetActive(false);
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Sequence s1 = DOTween.Sequence();
        s1.Append(SprayBottle.transform.DOLocalMove(SprayBottle_Target.transform.localPosition, 0.5f)).SetEase(Ease.Linear);

        SprayBottle.GetComponent<BoxCollider>().enabled = true;

        Invoke("Show_SprayBottle_Arrow", ArrowDelay);
    }

    void PickupSprayBottle()
    {
        SprayBottle_Arrow.SetActive(false);
        SprayBottle_Hand.SetActive(true);
        Sequence s1 = DOTween.Sequence();
        s1.Append(SprayBottle_Hand.transform.DOLocalMove(SprayBottle_Hand_AtBottle.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(MoveSprayHandIntoDevice);
        
    }

    void MoveSprayHandIntoDevice()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(SprayBottle.transform.DOLocalMove(SprayBottle_IntoDevice.transform.localPosition, 2f)).SetEase(Ease.Linear);
        Invoke("ShowSprayNozzle", 1);
    }

    void ShowSprayNozzle()
    {
        SprayBottle_RightThumbnail.SetActive(true);
        Sequence s1 = DOTween.Sequence();
        s1.Append(SprayBottle_RightThumbnail.transform.DOLocalMove(SprayBottle_RightThumbnail_Target.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(ShowSprayDrops);
    }

    void ShowSprayDrops()
    {
        SprayDrops.SetActive(true);
        Invoke("ShowStep21", 1);
    }


    void ShowStep21() //Step-21
    {
        SprayDrops.SetActive(false);
        SprayBottle_RightThumbnail.SetActive(false);
        SprayBottle.SetActive(false);
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Sequence s1 = DOTween.Sequence();
        s1.Append(Cervical_Brush.transform.DOLocalMove(Cervical_Brush_Target.transform.localPosition, 0.5f)).SetEase(Ease.Linear);
        Cervical_Brush.GetComponent<BoxCollider>().enabled = true;
        Invoke("Show_Cervical_Brush_Arrow", ArrowDelay);
    }

    void Pickup_Cervical_Brush()
    {
        Cervical_Brush_Arrow.SetActive(false);
        Cervical_Brush_Hand.SetActive(true);
        Sequence s1 = DOTween.Sequence();
        s1.Append(Cervical_Brush_Hand.transform.DOLocalMove(Cervical_Brush_Hand_AtBrush.transform.localPosition, 2f)).SetEase(Ease.Linear).OnComplete(InsertCervical_Brush);
    }

    void InsertCervical_Brush()
    {
        Cervical_Brush.transform.parent=Cervical_Brush_Hand.transform;
        Sequence s1 = DOTween.Sequence();
        Invoke("ShowBrushAtThumbnail", 1);
        s1.Append(Cervical_Brush_Hand.transform.DOLocalMove(Cervical_Brush_Hand_IntoDevice.transform.localPosition, 2f)).SetEase(Ease.Linear);
    }

    void ShowBrushAtThumbnail()
    {
        Cervical_Brush_RightThumbnail.SetActive(true);
        Sequence s1 = DOTween.Sequence();
        s1.Append(Cervical_Brush_RightThumbnail.transform.DOLocalMove(Cervical_Brush_RightThumbnail_Target.transform.localPosition, 2f))
            .SetEase(Ease.Linear).OnComplete(RotateBrush);
    }

    void RotateBrush()
    {
        
        Cervical_Brush_LeftThumbnail.SetActive(true);
        Sequence s1 = DOTween.Sequence();
        s1.Append(Cervical_Brush_RightThumbnail.transform.DOLocalRotate(new Vector3(0, -180, -90), 4f)).SetEase(Ease.Linear);
        Sequence s2 = DOTween.Sequence();
        s2.Append(Cervical_Brush_LeftThumbnail.transform.DOLocalRotate(new Vector3(180, -125,0), 4f)).SetEase(Ease.Linear)
            .OnComplete(ShowStep22);
    }



    void ShowStep22() //Step-22
    {
        
        Step21_Cervical_Brush.SetActive(false);
        Cervical_Brush_RightThumbnail.SetActive(false);
        Cervical_Brush_LeftThumbnail.SetActive(false);
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Biopsy_Forceps.GetComponent<BoxCollider>().enabled = true;
        Sequence s1 = DOTween.Sequence();
        s1.Append(Biopsy_Forceps.transform.DOLocalMove(Biopsy_Forceps_Target.transform.localPosition, 0.5f)).SetEase(Ease.Linear);
        Invoke("Show_BiopscyForceps_Arrow", ArrowDelay);
    }


    void Pickup_Biopsy_Forceps()
    {
        Biopsy_Forceps_Arrow.SetActive(false);
        Sequence s1 = DOTween.Sequence();
        Biopsy_Forceps_Hand.SetActive(true);
        s1.Append(Biopsy_Forceps_Hand.transform.DOLocalMove(Biopsy_Forceps_Hand_AtForcep.transform.localPosition,2f)).SetEase(Ease.Linear)
            .OnComplete(Insert_BiopsyForceps);
    }

    void Insert_BiopsyForceps()
    {
        Biopsy_Forceps.SetActive(false);
        Biopsy_Forceps_InHand.SetActive(true);
        Sequence s1 = DOTween.Sequence();
        s1.Append(Biopsy_Forceps_Hand.transform.DOLocalMove(Biopsy_Forceps_Hand_IntoDevice.transform.localPosition, 2f)).SetEase(Ease.Linear);
        Invoke("ShowForcepsAtThumbnail", 1);
    }

    void ShowForcepsAtThumbnail()
    {
        Biopsy_Forceps_RightThumbnail.SetActive(true);
        Biopsy_Forceps_LeftThumbnail.SetActive(true);
        Sequence s1 = DOTween.Sequence();
        s1.Append(Biopsy_Forceps_RightThumbnail.transform.DOLocalMove(Biopsy_Forceps_RightThumbnail_Target.transform.localPosition, 2f))
            .SetEase(Ease.Linear).OnComplete(ShowBloodSpot);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Biopsy_Forceps_LeftThumbnail.transform.DOLocalMove(Biopsy_Forceps_LeftThumbnail_Target.transform.localPosition, 2f));
    }

    void ShowBloodSpot()
    {
        Biopsy_Forceps_Bloodspot.SetActive(true);
        Cervix_Piece.SetActive(true);
        Invoke("ShowStep23", 3);
    }

    void ShowStep23() //Step-23
    {
        Biopsy_Forceps_Bloodspot.SetActive(false);
        Biopsy_Forceps_RightThumbnail.SetActive(false);
        Step22_Biopsy_Forceps.SetActive(false);
        Biopsy_Forceps_LeftThumbnail.SetActive(false);
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        FlapLeft_Step23.SetActive(true);
        FlapLeft_Step23.GetComponent<BoxCollider>().enabled = true;
        Invoke("ShowFlapLeft_Step23_Arrow", ArrowDelay);
    }
    
    void CloseUpperFlaps()
    {
        FlapLeft_Step23_Arrow.SetActive(false);
        FlapLeft_Step23.SetActive(false);


        Sequence s1 = DOTween.Sequence();
        s1.Append(Flap_Top_Device.transform.DOLocalRotate(new Vector3(35, 0, 0), 2f));

        Sequence s2 = DOTween.Sequence();
        s2.Append(Flap_Top.transform.DOLocalRotate(Vector3.zero, 2f))
             .SetEase(Ease.Linear).OnComplete(CloseLowerFlaps);

        StartCoroutine(UnscrewCo());
    }

    IEnumerator UnscrewCo()
    {
        UnScrewingHandObj.SetActive(true);
        Sequence s_unscrew = DOTween.Sequence();
        s_unscrew.Append(UnScrewingHandObj.transform.DOLocalRotate(new Vector3(-40, 0, 0), 2f).SetEase(Ease.Linear));
        s_unscrew.SetLoops(-1);
        yield return new WaitForSeconds(4);
        s_unscrew.Kill();
    }

    void CloseLowerFlaps()
    {

        Sequence s1 = DOTween.Sequence();
        s1.Append(Flap_Bottom.transform.DOLocalRotate(new Vector3(-35, 0, 0), 2f));


        Sequence s2 = DOTween.Sequence();
        s2.Append(Flap_Bottom_Device.transform.DOLocalRotate(new Vector3(-35, 0, 0), 2f))
            .SetEase(Ease.Linear).OnComplete(ShowStep24);
    }

    void ShowStep24() //Step-24
    {
        FlapObj.SetActive(false);
        
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Step24_Collider.GetComponent<BoxCollider>().enabled = true;
        Invoke("Show_Step24_Arrow", ArrowDelay);
    }

    void RemoveSpeculum()
    {
        Smart_Speculum_Step24.transform.localPosition = Smart_SpeculumCorrectPlace.transform.localPosition;
        Smart_Speculum_Step24.transform.localEulerAngles = Smart_SpeculumCorrectPlace.transform.localEulerAngles;
        UnScrewingHandObj.transform.parent = Speculum_Thumbnail.transform;
        Speculum_Thumbnail_Arrow.SetActive(false);
        Sequence s1 = DOTween.Sequence();
        s1.Append(Speculum_Thumbnail.transform.DOLocalMove(Speculum_Thumbnail_OutsideUterus.transform.localPosition,
            2f)).SetEase(Ease.Linear).OnComplete(ShowStep25);
        Smart_SpeculumTube.SetActive(false);
        Sequence s2 = DOTween.Sequence();
        s2.Append(Posterior_Thumbnail.transform.DOLocalMove(Posterior_Thumbnail_Back.transform.localPosition,
            2f)).SetEase(Ease.Linear);
    }

    void ShowStep25() //Step-25
    {
        SpeculumInsertion_Thumbnail.SetActive(false);
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Step25_Collider.SetActive(true);
        Step25_Collider.GetComponent<BoxCollider>().enabled = true;
        Invoke("Show_Step25_Arrow", ArrowDelay);
        Step25_Bin.SetActive(true);
    }


    void RemoveEndoscope() 
    {
        Step25_Arrow.SetActive(false);
        Step25_Endoscope_Hand.SetActive(true);

        Sequence s1 = DOTween.Sequence();
        s1.Append(Step25_Endoscope_Hand.transform.DOLocalMove(Step25_Endoscope_Hand_AtMobile.transform.localPosition,
            2f)).SetEase(Ease.Linear).OnComplete(UnplugFromMobile);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Step25_Endoscope_Hand.transform.DOLocalRotate(Step25_Endoscope_Hand_AtMobile.transform.localEulerAngles,
            2f));
    }

    void UnplugFromMobile()
    {

        Step25_Mobile.transform.parent = Step25_Endoscope_Hand.transform;
        Sequence s1 = DOTween.Sequence();
        s1.Append(Step25_Endoscope_Hand.transform.DOLocalMove(Step25_MobileUnpluged.transform.localPosition,
            2f)).SetEase(Ease.Linear).OnComplete(MoveHandToEndoscope);
    }

    void MoveHandToEndoscope()
    {
        Step25_Mobile.transform.parent = Step25_Endoscope.transform;
        Sequence s0 = DOTween.Sequence();
        s0.Append(Step25_Mobile.transform.DOLocalRotate(Step25_MobileUnplugedRotated.transform.localEulerAngles, 2f));

        Sequence s1 = DOTween.Sequence();
        s1.Append(Step25_Endoscope_Hand.transform.DOLocalMove(Step25_Endoscope_Hand_AtEndoscope.transform.localPosition,
            2f)).SetEase(Ease.Linear).OnComplete(PullEndoscope);

        Step25_CableStart.transform.localPosition = Step25_Cable_Target.transform.localPosition;

        Sequence s2 = DOTween.Sequence();
        s2.Append(Step25_Endoscope_Hand.transform.DOLocalRotate(Step25_Endoscope_Hand_AtEndoscope.transform.localEulerAngles,
            2f)).SetEase(Ease.Linear);
    }

    void PullEndoscope()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(Step25_Endoscope.transform.DOLocalMove(Step25_Endoscope_Outside.transform.localPosition,
            2f)).SetEase(Ease.Linear).OnComplete(PutEndoscopeOnTable);

    }
    void PutEndoscopeOnTable()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(Step25_Endoscope.transform.DOLocalMove(Step25_Endoscope_OnTable.transform.localPosition,
            2f)).SetEase(Ease.Linear).OnComplete(RemoveSheath);


        Sequence s2 = DOTween.Sequence();
        s2.Append(Step25_Mobile.transform.DOLocalRotate(Step25_MobileRotatedOnTable.transform.localEulerAngles,2f));

        Sequence s3 = DOTween.Sequence();
        s3.Append(Step25_Mobile.transform.DOScale(Step25_MobileRotatedOnTable.transform.localScale, 2f));
    }

    void RemoveSheath()
    {
        Step25_Endoscope_Hand.SetActive(false);
        Step25_Hand.SetActive(true);
        Sequence s1 = DOTween.Sequence();
        s1.Append(Step25_Hand.transform.DOLocalMove(Step25_Hand_OnSheth.transform.localPosition,
            2f)).SetEase(Ease.Linear).OnComplete(MoveSheathOutside_Device);
    }

    void MoveSheathOutside_Device()
    {
        Smart_SpeculumTube.SetActive(true);
        Sequence s1 = DOTween.Sequence();
        s1.Append(Step25_Sheath40.transform.DOLocalMove(Step25_Sheath40_OutsideDevice.transform.localPosition,
            2f)).SetEase(Ease.Linear).OnComplete(ThrowSheathIntoTrash);
    }

    void ThrowSheathIntoTrash()
    {
        Sequence s1 = DOTween.Sequence();
        s1.Append(Step25_Sheath40.transform.DOLocalMove(Step25_Sheath40_IntoTrash.transform.localPosition,
            2f)).SetEase(Ease.Linear).OnComplete(RemoveDevice);
    }

    void RemoveDevice()
    {
        Step25_Sheath40.SetActive(false);
        Step25_Bin.SetActive(false);
        Step25_Endoscope_Hand.SetActive(false);
        Step25_Endoscope.transform.parent = null;

        Sequence s1 = DOTween.Sequence();
        s1.Append(Posterior_Thumbnail.transform.DOLocalMove(Posterior_Thumbnail_BehindDish.transform.localPosition,
            2f)).SetEase(Ease.Linear).OnComplete(DropDeviceIntoDish);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Posterior_Thumbnail.transform.DOLocalRotate(Posterior_Thumbnail_BehindDish.transform.localEulerAngles,
            2f)).SetEase(Ease.Linear);
    }

    void DropDeviceIntoDish()
    {
        Posterior_RightHand.SetActive(false);
        Sequence s1 = DOTween.Sequence();
        s1.Append(Posterior_Thumbnail.transform.DOLocalMove(Posterior_Thumbnail_InDish.transform.localPosition,
            2f)).SetEase(Ease.Linear).OnComplete(ShowStep26);

        Sequence s2 = DOTween.Sequence();
        s2.Append(Posterior_Thumbnail.transform.DOLocalRotate(Posterior_Thumbnail_InDish.transform.localEulerAngles,
            2f)).SetEase(Ease.Linear);

        Sequence s3 = DOTween.Sequence();
        s3.Append(Posterior_Thumbnail.transform.DOScale(Posterior_Thumbnail_InDish.transform.localScale,
            2f)).SetEase(Ease.Linear);
    }
    void ShowStep26() //Step-26
    {
      
        Step25_DeviceHand.SetActive(false);
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();
        Invoke("ShowStep27", C_Spec_AudioSource.clip.length+1);
    }


    void ShowStep27() //Step-26
    {
       AssemblyHand_Rotation.SetActive(false);
       Posterior_Thumbnail_Obj.SetActive(false);
       TypingHand_Obj.SetActive(false);
       Glove_Hand_Right_Obj.SetActive(false);
        Posterior_Thumbnail.SetActive(false);
        Step25_Endoscope.SetActive(false);
        ScreenIndex = ScreenIndex + 1;
        ShowCurrentScreen();
        DisableAllCollider();

        Sequence s1 = DOTween.Sequence();
        s1.Append(CameraObj.transform.DOLocalMove(CameraObj_Initial.localPosition, 3f)).SetEase(Ease.Linear)
            .OnComplete(FinishSimulation);

        Sequence s2 = DOTween.Sequence();
        s2.Append(CameraObj.transform.DOLocalRotate(CameraObj_Initial.localEulerAngles, 1.5f)).SetEase(Ease.Linear);
    }

    void FinishSimulation()
    {

    }


    public void OnClick_CSpec_Element(GameObject Item)
    {
        if (Item.name == "01_SmartPhone")
        {
            SmartPhone_Arrow.SetActive(false);
            if(ScreenIndex==4)
            {
                EnterAssemblyHand();
            }
            else if (ScreenIndex == 5)
            {
                ShowGicMedLogoAndTypingHand();
            }
        }
        else if (Item.name == "02_SmartPhoneHolder")
        {
            SmartPhoneHolder_Arrow.SetActive(false);
        }
        else if (Item.name == "03_Glove_Left")
        {
            Glove_Left_Arrow.SetActive(false);
            StartCoroutine(PickUpLeftGlove());
        }
        else if (Item.name == "04_Glove_Right")
        {
            Glove_Right_Arrow.SetActive(false);
            StartCoroutine(PickUpRightGlove());
        }
        else if (Item.name == "05_Smart_Speculum")
        {
            PickUpSmartSpeculum();
        }
        else if (Item.name == "06_Sheath40")
        {
            PickUpSheath40();
        }
        else if (Item.name == "07_Endoscope")
        {
            PickUpEndoscope();
        }
        else if (Item.name == "08_Lubricant")
        {
            PickUpLubbricant();
        }
        else if (Item.name == "Posterior_SmartPhone")
        {
            TapOnMobileScreen();
        }
        else if (Item.name == "Step15_Collider")
        {
            ShowStep16();
        }
        else if (Item.name == "SeculumDevice")
        {
            ScrewTheDevice();
        }
        else if (Item.name == "Speculum_Thumbnail_Collider")
        {
            StartRotatingLeftRight();
        }
        else if (Item.name == "Swab_1")
        {
            PickUpSwab1();
        }
        else if (Item.name == "09_SprayBottle")
        {
            PickupSprayBottle();
        }
        else if (Item.name == "10_Cervical_Brush")
        {
            Pickup_Cervical_Brush();
        }
        else if (Item.name == "11_Biopsy_forceps")
        {
            Pickup_Biopsy_Forceps();
        }
        else if (Item.name == "Step12Collider")
        {
            RotateThumbnails();
        }
        else if (Item.name == "FlapLeft_Step23")
        {
            CloseUpperFlaps();
        }
        else if (Item.name == "Step24_Collider")
        {
            RemoveSpeculum();
        }
        else if (Item.name == "Step25_Collider")
        {
            RemoveEndoscope();
        }
    }


    //====================================================================================================
    //========================= ARROW STARTS========================================================


    void ShowSmartPhone_Arrow()
    {
        if (SmartPhone.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            SmartPhone_Arrow.SetActive(true);
        }
    }


    void ShowSmartPhoneHolder_Arrow()
    {
        if (SmartPhoneHolder.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            SmartPhoneHolder_Arrow.SetActive(true);
        }
    }

    void Show_Left_GloveArrow()
    {
        if (Glove_Left.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Glove_Left_Arrow.SetActive(true);
        }
    }

    void Show_Right_GloveArrow()
    {
        if (Glove_Right.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Glove_Right_Arrow.SetActive(true);
        }
    }

    void Show_SmartSpeculum_Arrow()
    {
        if (Smart_Speculum.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Smart_Speculum_Arrow.SetActive(true);
        }
    }

    void Show_Sheath40_Arrow()
    {
        if (Sheath40.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Sheath40_Arrow.SetActive(true);
        }
    }

    void Show_Endoscope_Arrow()
    {
        if (Sheath40.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Endoscope_Arrow.SetActive(true);
        }
    }

    void Show_Lubricant_Arrow()
    {
        if (Lubricant.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Lubricant_Arrow.SetActive(true);
        }
    }

    void Show_Posterior_SmartPhone_Arrow()
    {
        if (Posterior_Smartphone.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Posterior_Smartphone_Arrow.SetActive(true);
        }
    }

    void Show_ScrewingHand_Arrow()
    {
        if (Speculum_Device.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            ScrewingHand_Arrow.SetActive(true);
        }
    }

    void Show_Speculum_Thumbnail_Arrow()
    {
        if (Speculum_Thumbnail_Collider.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Speculum_Thumbnail_Arrow.SetActive(true);
        }
    }

    void Show_Step12_Arrow()
    {
        if (Step12_Collider.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Speculum_Thumbnail_Arrow.SetActive(true);
        }
    }

    void Show_Step15_Arrow()
    {
        if (Step15_Collider.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Step15_Arrow.SetActive(true);
        }
    }

    void Show_Swab1_Arrow()
    {
        if (Swab1.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Swab1_Arrow.SetActive(true);
        }
    }

 
    void Show_SprayBottle_Arrow()
    {
        if (SprayBottle.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            SprayBottle_Arrow.SetActive(true);
        }
    }

    void Show_Cervical_Brush_Arrow()
    {
        if (Cervical_Brush.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Cervical_Brush_Arrow.SetActive(true);
        }
    }

    void Show_BiopscyForceps_Arrow()
    {
        if (Biopsy_Forceps.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Biopsy_Forceps_Arrow.SetActive(true);
        }
    }

    void ShowFlapLeft_Step23_Arrow()
    {
        if (FlapLeft_Step23.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            FlapLeft_Step23_Arrow.SetActive(true);
        }
    }

    void Show_Step24_Arrow()
    {
        if (Step24_Collider.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Speculum_Thumbnail_Arrow.SetActive(true);
        }
    }

    void Show_Step25_Arrow()
    {
        if (Step25_Collider.GetComponent<BoxCollider>().enabled && DoShowInfo)
        {
            Step25_Arrow.SetActive(true);
        }
    }





    //==============================ARROW ENDS===================================================
    //====================================================================================================




    //====================================================================================================
    //====================================================================================================
    //== NOTHING BELOW ===================================================================================
    //====================================================================================================


    public void OnClickReStartSimulation()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("C_Spec");
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
        C_Spec_AudioSource.Stop();
        StepDescription.text = C_SpecData_Instance[ScreenIndex].Step_Description[Simulation_Backend.SelectedLanguageID];
        C_Spec_AudioSource.clip = C_SpecData_Instance[ScreenIndex].Item_Audio[Simulation_Backend.SelectedLanguageID];
        C_Spec_AudioSource.Play();
    }

  
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Time.timeScale = 10;
        }
    }
   
    public void GoToNextPage()
    {
        CurrentPage = CurrentPage + 1;
        if (CurrentPage > Pages_English.Length-1)
        {
            CurrentPage = Pages_English.Length - 1;
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
public class C_SpecData
{
    // 0 English , 1 French
    public string Step_Number;
    public string[] Step_Description;
    public AudioClip[] Item_Audio;
}

