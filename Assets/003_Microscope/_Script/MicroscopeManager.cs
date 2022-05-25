using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class MicroscopeManager : MonoBehaviour
{
    public static MicroscopeManager Instance;
    [Header("#### UI ####")]
    public GameObject[] HumanModel;
    public GameObject LanguageSelection;
    public GameObject ErrorMessage;
    public GameObject Step_screen;
    public TextMeshProUGUI Step_Text;
    public GameObject StartButton;
    public TextMeshProUGUI StartButtonText;
    public GameObject ReStartButton;
    public TextMeshProUGUI ReStartButtonText;

    public string[] Step_String_Eng;
    public string[] Step_String_French;
    public int CurrentStepNumber;
    public bool DoShowStep4;
    public GameObject BlackImage;
    public GameObject BlackImage_Objective;

    public GameObject CellPanel;
    public Material BlurMaterial;
    public bool DoClean;
    public float BlurValue = 5;
    public GameObject Cell_Image;

    public TextMeshProUGUI Error_Message_Text;
    public string Error_Message_English;
    public string Error_Message_French;

    [Header("#### AUDIO ####")]
    public TextMeshProUGUI SoundText;
    public GameObject SoundOnImage;
    public GameObject SoundOffImage;
    public AudioSource Microscope_AudioSource;
    public AudioClip[] ClipsEnglish;
    public AudioClip[] ClipsFrench;

    [Header("#### ARROWS ####")]
    public GameObject MicroscopeArmArrow;
    public GameObject MicroscopeBaseArrow;
    public GameObject MicroscopeMirrorArrow;
    public GameObject SlideArrow;
    public GameObject StageArrow;
    public GameObject MetalArrow;
    public GameObject FourXArrow;
    public GameObject FocusingKnobArrow;
    public GameObject EyepieceArrow;
    public GameObject TenXArrow;
    public GameObject FourtyXArrow;
    public GameObject FourXArrow_Reset;

    [Header("#### MAIN TABLE ####")]
    public GameObject TableObj;
    public GameObject TableLight;
    public GameObject TableCollider;
    public GameObject TableArrow;
    public GameObject LightSource1;
    public GameObject LightSource2;
    public bool DoCheckLightSource2;
    public GameObject SlideObj;
    public GameObject SlideObj_Initial;
    public GameObject Head;


    [Header("#### HANDS ####")]
    public GameObject MicroscopeArmHand;
    public GameObject MicroscopeBaseHand;
    public GameObject SlideHand;
    public GameObject MicroscopeMirrorHand;
    public GameObject MicroscopeMetalHand;
    public GameObject FourXHand;
    public GameObject FocusingKnobHand;
    public GameObject TenXHand;
    public GameObject FourtyXHand;



    [Header("#### CAMERA POINTS ####")]
    public Transform CameraObj;
    public Transform CameraAtStartingPoint;
    public Transform CameraAtMicroscope;

    [Header("#### MICROSCOPE PARTS ####")]
    public GameObject MicroscopeObj;
    public GameObject MicroscopeOnBackTable;
    public GameObject MicroscopeOnMainTable;
    public GameObject MicroscopeMirror;
    public GameObject StagePoint;
    public GameObject ObjectiveLense;
    public GameObject ObjectiveLenseDummy;
    public GameObject Lense_4x;
    public GameObject Lense_10x;
    public GameObject Lense_40x;
    public GameObject LoadingStage;
    public GameObject FocusingKnob;
    
    

    [Header("#### COLLIDER ####")]
    public GameObject ArmCollider;
    public GameObject BaseCollider;
    public GameObject MirrorCollider;
    public GameObject SlideCollider;
    public GameObject StageCollider;
    public GameObject MetalCollider;
    public GameObject FourXCollider;
    public GameObject FocusingKnobCollider;
    public GameObject EyepieceCollider;
    public GameObject TenXCollider;
    public GameObject FourtyXCollider;



    public float HorizontalScrollDelta;
    public float VerticalScrollDelta;
    float horizontalSpeed = 4.0f;
    float VerticalSpeed = 4.0f;
    public Vector2 ScrollDelta;
    public bool CanInteract;
    public float MicroscopeRadian;
    
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        LanguageSelection.SetActive(true);  
    }

    void CleanTheCell()
    {
        
        if (DoClean)
        {
            BlurValue = BlurValue - (Time.deltaTime*0.35f);
            if(BlurValue>0)
            {
                BlurMaterial.SetFloat("_Size", BlurValue);
            }
            else
            {
                DoClean = false;
                if(CurrentStepNumber==8)
                {
                    //CellPanel.SetActive(false);
                    FocusingKnobHand.SetActive(false);
                    PlayAudio(9);
                    CurrentStepNumber = CurrentStepNumber + 1;
                    StartCoroutine(ShowCurrentStepScreen(0));
                    if (Simulation_Backend.SelectedLanguageID == 1)
                    {
                        Invoke("OnStep9Finished", 12);
                    }
                    else
                    {
                        Invoke("OnStep9Finished", 14);
                    }
                }
                else if (CurrentStepNumber == 11)
                {
                    FocusingKnobHand.SetActive(false);
                    PlayAudio(12);
                    CurrentStepNumber = CurrentStepNumber + 1;
                    StartCoroutine(ShowCurrentStepScreen(0));
                    Sequence s = DOTween.Sequence();
                    s.Append(Cell_Image.transform.DOLocalMove(new Vector3(100, 0, 0), 4f).SetEase(Ease.Linear));
                    if (Simulation_Backend.SelectedLanguageID == 1)
                    {
                        Invoke("OnStep12Finished",4);
                    }
                    else
                    {
                        Invoke("OnStep12Finished",5);
                    }
                }
                else if (CurrentStepNumber == 13)
                {
                    FocusingKnobHand.SetActive(false);
                    PlayAudio(14);
                    CurrentStepNumber = CurrentStepNumber + 1;
                    StartCoroutine(ShowCurrentStepScreen(0));
                    Sequence s = DOTween.Sequence();
                    s.Append(Cell_Image.transform.DOLocalMove(new Vector3(150, 0, 0), 4f).SetEase(Ease.Linear));
                    if (Simulation_Backend.SelectedLanguageID == 1)
                    {
                        Invoke("OnStep14Finished", 4);
                    }
                    else
                    {
                        Invoke("OnStep14Finished", 5);
                    }
                }

            }
        }
    }

    void OnStep9Finished()
    {
        PlayAudio(10);
        CurrentStepNumber = CurrentStepNumber + 1;
        StartCoroutine(ShowCurrentStepScreen(0));
        Sequence s = DOTween.Sequence();
        s.Append(Cell_Image.transform.DOLocalMove(new Vector3(50,0,0), 4f).SetEase(Ease.Linear));

        if (Simulation_Backend.SelectedLanguageID == 1)
        {
            Invoke("OnStep10Finished",4);
        }
        else
        {
            Invoke("OnStep10Finished", 5);
        }
    }

    void OnStep10Finished()
    {
        PlayAudio(11);
        CurrentStepNumber = CurrentStepNumber + 1;
        StartCoroutine(ShowCurrentStepScreen(0));

        Lense_4x.SetActive(true);
        Lense_10x.SetActive(true);
        Lense_40x.SetActive(true);

        TenXCollider.SetActive(true);
        TenXArrow.SetActive(true);
    }

    void OnStep12Finished()
    {
        PlayAudio(13);
        CurrentStepNumber = CurrentStepNumber + 1;
        StartCoroutine(ShowCurrentStepScreen(0));

        FourtyXCollider.SetActive(true);
        FourtyXArrow.SetActive(true);

    }

    void OnStep14Finished()
    {
        PlayAudio(15);
        CellPanel.SetActive(false);
        LightSource1.SetActive(false);
        DoCheckLightSource2 = false;
        LightSource2.SetActive(false);
        Head.SetActive(false);
        CurrentStepNumber = CurrentStepNumber + 1;
        StartCoroutine(ShowCurrentStepScreen(0));
        FocusingKnobArrow.SetActive(true);
        FocusingKnobCollider.SetActive(true);
    }


    void Update()
    {
        CleanTheCell();
        ScrollDelta = Input.mouseScrollDelta;
        MicroscopeRadian = MicroscopeObj.transform.localEulerAngles.y * Mathf.Deg2Rad;
        ObjectiveLense.transform.localEulerAngles = ObjectiveLenseDummy.transform.localPosition;
        if(MicroscopeRadian>6.1f || MicroscopeRadian < 0.18f)
        {
            ErrorMessage.SetActive(false);
            if(CurrentStepNumber==3 && DoShowStep4)
            {
                PlayAudio(4);
                CurrentStepNumber = CurrentStepNumber + 1;
                StartCoroutine(ShowCurrentStepScreen(0));

                SlideObj.SetActive(true);
                SlideArrow.SetActive(true);
            }
            
        }
        else
        {
            ErrorMessage.SetActive(true);
        }

        BlackImage.SetActive(ErrorMessage.activeSelf);

        if (DoCheckLightSource2)
        {
            LightSource2.SetActive(!ErrorMessage.activeSelf);
        }
        
        if (Input.GetMouseButton(0) && CanInteract)
        {
            HorizontalScrollDelta = horizontalSpeed * Input.GetAxis("Mouse X");
            VerticalScrollDelta = VerticalSpeed * Input.GetAxis("Mouse Y");

            if (HorizontalScrollDelta > 0.3f)
            {
                MicroscopeObj.transform.Rotate(Vector3.down * Time.deltaTime * 100);
            }
            else if (HorizontalScrollDelta < -0.3f)
            {
                MicroscopeObj.transform.Rotate(Vector3.up * Time.deltaTime * 100);
            }

            if (VerticalScrollDelta > 0.3f && CameraObj.transform.localPosition.y > 3)
            {
                CameraObj.transform.Translate(Vector3.down * Time.deltaTime*10 );
                CameraObj.transform.Rotate(Vector3.left * Time.deltaTime * 50);
            }

            if (VerticalScrollDelta < -0.3f && CameraObj.transform.localPosition.y < 8)
            {
                CameraObj.transform.Translate(Vector3.up * Time.deltaTime*10);
                CameraObj.transform.Rotate(Vector3.right * Time.deltaTime * 50);
            }
        }

        if(CanInteract)
        {
            if (ScrollDelta.y > 0.01f && CameraObj.transform.localPosition.z<11.5)
            {
                CameraObj.transform.Translate(Vector3.forward * Time.deltaTime * 10);
            }
            else if (ScrollDelta.y < -0.01f && CameraObj.transform.localPosition.z > 0)
            {
                CameraObj.transform.Translate(Vector3.back * Time.deltaTime * 10);
            }
        }
    }


    public void PlayAudio(int ClipIndex)
    {
        Microscope_AudioSource.Stop();
        if (Simulation_Backend.SelectedLanguageID == 1)
        {
            Microscope_AudioSource.PlayOneShot(ClipsEnglish[ClipIndex]);
        }
        else
        {
            Microscope_AudioSource.PlayOneShot(ClipsFrench[ClipIndex]);
        }
    }

    IEnumerator ShowCurrentStepScreen(int Delay)
    {
        yield return new WaitForSeconds(Delay);
        Step_screen.SetActive(true);
        if (Simulation_Backend.SelectedLanguageID == 1)
        {
            Step_Text.text = Step_String_Eng[CurrentStepNumber];
        }
        else
        {
            Step_Text.text = Step_String_French[CurrentStepNumber];
        }
    }

    public void ToogleSound()
    {
        if (Simulation_Backend.SelectedLanguageID == 1)
        {
            if (Microscope_AudioSource.volume == 1)
            {
                Microscope_AudioSource.volume = 0;
                SoundText.text = "Sound On";
                SoundOnImage.SetActive(true);
                SoundOffImage.SetActive(false);
            }
            else
            {
                Microscope_AudioSource.volume = 1;
                SoundText.text = "Sound Off";
                SoundOnImage.SetActive(false);
                SoundOffImage.SetActive(true);

            }
        }
        else
        {
            if (Microscope_AudioSource.volume == 1)
            {
                Microscope_AudioSource.volume = 0;
                SoundText.text = "Son activé";
                SoundOnImage.SetActive(true);
                SoundOffImage.SetActive(false);

            }
            else
            {
                Microscope_AudioSource.volume = 1;
                SoundText.text = "Son désactivé";
                SoundOnImage.SetActive(false);
                SoundOffImage.SetActive(true);

            }
        }
    }


    public void OnClickLanguageButton(int LanguageID)
    {
        Simulation_Backend.SelectedLanguageID = LanguageID;
        LanguageSelection.SetActive(false);
        PlayAudio(0);
        SoundText.transform.parent.gameObject.SetActive(true);
        StartCoroutine(ShowCurrentStepScreen(0));
        if (LanguageID == 1)
        {
            SoundText.text = "Sound Off";
            StartButtonText.text = "Start";
            ReStartButtonText.text = "Restart";
            Error_Message_Text.text = Error_Message_English;
        }
        else
        {
            SoundText.text = "Son désactivé";
            StartButtonText.text = "Début";
            ReStartButtonText.text = "Redémarrage";
            Error_Message_Text.text = Error_Message_French;
        }
        HumanModel[LanguageID - 1].SetActive(true);
    }

    public void OnClickStartButton()
    {
        PlayAudio(1);
        CurrentStepNumber = 1;
        StartButton.SetActive(false);
        Sequence s = DOTween.Sequence();
        s.Append(CameraObj.DOLocalMove(CameraAtMicroscope.localPosition, 5f).SetEase(Ease.Linear)).OnComplete(OnCamReachedAtMicroscope);
        StartCoroutine(ShowCurrentStepScreen(0));
    }

    public void OnCamReachedAtMicroscope()
    {
        MicroscopeArmArrow.SetActive(true);
        ArmCollider.SetActive(true);
    }

    public void OnClickMicorscopePart(string PartName)
    {
        if(PartName== "ArmCollider")
        {
            ArmCollider.SetActive(false);
            MicroscopeArmArrow.SetActive(false);
            MicroscopeArmHand.SetActive(true);

            BaseCollider.SetActive(true);
            MicroscopeBaseArrow.SetActive(true);
        }
        else if (PartName == "BaseCollider")
        {
            BaseCollider.SetActive(false);
            MicroscopeBaseArrow.SetActive(false);
            MicroscopeBaseHand.SetActive(true);
            if (CurrentStepNumber == 1)
            {
                Sequence s = DOTween.Sequence();
                s.Append(CameraObj.DOLocalMove(CameraAtStartingPoint.localPosition, 5f).SetEase(Ease.Linear)).OnComplete(OnCameraReachAtStartingPoint);
            }
            else if (CurrentStepNumber == 17)
            {
                Sequence s = DOTween.Sequence();
                s.Append(MicroscopeObj.transform.DOLocalMove(MicroscopeOnBackTable.transform.localPosition, 5f).SetEase(Ease.Linear)).
                    OnComplete(OnMicroscopeReachAtBackTable);

            }
        }
        else if (PartName == "TableCollider")
        {
            TableArrow.SetActive(false);
            TableCollider.SetActive(false);
            Sequence s = DOTween.Sequence();
            s.Append(MicroscopeObj.transform.DOLocalMove(MicroscopeOnMainTable.transform.localPosition, 5f).SetEase(Ease.Linear)).OnComplete(OnMicroscopeReachAtTable);
        }
        else if (PartName == "MirrorCollider")
        {
            MicroscopeMirrorArrow.SetActive(false);
            MirrorCollider.SetActive(false);
            MicroscopeMirrorHand.SetActive(true);
            Sequence s = DOTween.Sequence();
            s.Append(MicroscopeMirror.transform.DOLocalRotate(new Vector3(45,0,0), 2f).SetEase(Ease.Linear)).OnComplete(OnMirrorRotationCompleted);
        }
        else if (PartName == "SlideObj")
        {
            SlideArrow.SetActive(false);
            SlideObj.GetComponent<BoxCollider>().enabled = false;
            SlideHand.SetActive(true);
            StageArrow.SetActive(true);
            StageCollider.SetActive(true);
        }
        else if (PartName == "StageCollider")
        {
            StageArrow.SetActive(false);
            StageCollider.SetActive(false);
            SlideObj.transform.parent = MicroscopeObj.transform.GetChild(0).transform;

            Sequence s = DOTween.Sequence();
            s.Append(SlideObj.transform.DOLocalMove(StagePoint.transform.localPosition, 3f).SetEase(Ease.Linear)).OnComplete(OnSlideReachedToStage);

            Sequence s_Rotate = DOTween.Sequence();
            s_Rotate.Append(SlideObj.transform.DOLocalRotate(StagePoint.transform.localEulerAngles, 2f).SetEase(Ease.Linear));
        }
        else if (PartName == "MetalCollider")
        {
            MetalArrow.SetActive(false);
            MetalCollider.SetActive(false);
            MicroscopeMetalHand.SetActive(true);

            PlayAudio(6);
            CurrentStepNumber = CurrentStepNumber + 1;
            StartCoroutine(ShowCurrentStepScreen(0));
            Lense_4x.SetActive(true);
            Lense_10x.SetActive(true);
            Lense_40x.SetActive(true);

            FourXArrow.SetActive(true);
            FourXCollider.SetActive(true);
        }
        else if (PartName == "4xCollider")
        {
            FourXArrow.SetActive(false);
            FourXArrow_Reset.SetActive(false);
            FourXCollider.SetActive(false);
            FourXHand.SetActive(true);
            MicroscopeMetalHand.SetActive(false);

            if (CurrentStepNumber==6)
            {
                Sequence s = DOTween.Sequence();
                //from Vector3(-110,0,160)
                s.Append(ObjectiveLenseDummy.transform.DOLocalMove(new Vector3(-110, 0, 120), 3f).SetEase(Ease.Linear)).OnComplete(OnObjectiveLensRotated);
            }
            else if (CurrentStepNumber == 16)
            {
                Sequence s = DOTween.Sequence();
                s.Append(ObjectiveLenseDummy.transform.DOLocalMove(new Vector3(-110, 0, -180), 3f).SetEase(Ease.Linear)).OnComplete(OnObjectiveLensReset);
            
            }


        }
        else if (PartName == "FocusingKnobCollider")
        {
            FocusingKnobArrow.SetActive(false);
            FocusingKnobCollider.SetActive(false);
            FocusingKnobHand.SetActive(true);
            SlideObj.transform.parent = LoadingStage.transform;

            if (CurrentStepNumber==7)
            {
                Sequence s = DOTween.Sequence();
                s.Append(FocusingKnob.transform.DOLocalRotate(Vector3.zero, 3f).SetEase(Ease.Linear)).OnComplete(OnFocusingKnobRotated);

                Vector3 StageTargetPosition = LoadingStage.transform.localPosition;
                StageTargetPosition.y = 3.8f;

                Sequence s2 = DOTween.Sequence();
                s2.Append(LoadingStage.transform.DOLocalMove(StageTargetPosition, 3).SetEase(Ease.Linear));
            }
            else if(CurrentStepNumber == 15)
            {
                Sequence s = DOTween.Sequence();
                s.Append(FocusingKnob.transform.DOLocalRotate(new Vector3(30,0,0), 3f).SetEase(Ease.Linear)).OnComplete(OnFocusingKnobReset);

                Vector3 StageTargetPosition = LoadingStage.transform.localPosition;
                StageTargetPosition.y = 3.66f;

                Sequence s2 = DOTween.Sequence();
                s2.Append(LoadingStage.transform.DOLocalMove(StageTargetPosition, 3).SetEase(Ease.Linear));

            }
            

           
        }
        else if (PartName == "EyepieceCollider")
        {
            EyepieceArrow.SetActive(false);
            EyepieceCollider.SetActive(false);
            Head.SetActive(true);
            BlurMaterial.SetFloat("_Size", 5);
            CellPanel.SetActive(true);
            DoClean = true;
            StartCoroutine(RotateFocusingKnob3Times());
        }
        else if (PartName == "10xCollider")
        {
            TenXArrow.SetActive(false);
            TenXCollider.SetActive(false);
            TenXHand.SetActive(true);
            BlackImage_Objective.SetActive(true);

            Sequence s = DOTween.Sequence();
            s.Append(ObjectiveLenseDummy.transform.DOLocalMove(new Vector3(-110, 0, 0), 3f).SetEase(Ease.Linear)).
                OnComplete(On10xObjectiveLensRotated);
        }
        else if (PartName == "40xCollider")
        {
            FourtyXArrow.SetActive(false);
            FourtyXCollider.SetActive(false);
            FourtyXHand.SetActive(true);
            BlackImage_Objective.SetActive(true);

            Sequence s = DOTween.Sequence();
            s.Append(ObjectiveLenseDummy.transform.DOLocalMove(new Vector3(-110, 0, -120), 3f).SetEase(Ease.Linear)).
                OnComplete(On40xObjectiveLensRotated);

        }
    }

    IEnumerator RotateFocusingKnob3Times()
    {
        FocusingKnobHand.SetActive(true);

        Sequence s = DOTween.Sequence();
        s.Append(FocusingKnob.transform.DOLocalRotate(new Vector3(20,0,0), 2f).SetEase(Ease.Linear));

        yield return new WaitForSeconds(2.5f);

        Sequence s2 = DOTween.Sequence();
        s2.Append(FocusingKnob.transform.DOLocalRotate(new Vector3(0, 0, 0), 2f).SetEase(Ease.Linear));

        yield return new WaitForSeconds(2.5f);

        Sequence s3 = DOTween.Sequence();
        s3.Append(FocusingKnob.transform.DOLocalRotate(new Vector3(20, 0, 0), 2f).SetEase(Ease.Linear));

        yield return new WaitForSeconds(2.5f);
        Sequence s4 = DOTween.Sequence();
        s4.Append(FocusingKnob.transform.DOLocalRotate(new Vector3(0, 0, 0), 2f).SetEase(Ease.Linear));

        yield return new WaitForSeconds(2.5f);

        Sequence s5 = DOTween.Sequence();
        s5.Append(FocusingKnob.transform.DOLocalRotate(new Vector3(20, 0, 0), 2f).SetEase(Ease.Linear));

        yield return new WaitForSeconds(2.5f);

        Sequence s6 = DOTween.Sequence();
        s6.Append(FocusingKnob.transform.DOLocalRotate(new Vector3(0, 0, 0), 2f).SetEase(Ease.Linear));
    }

    void OnCameraReachAtStartingPoint()
    {
        PlayAudio(2);
        TableLight.SetActive(true);
        TableArrow.SetActive(true);
        TableCollider.SetActive(true);
        CurrentStepNumber = CurrentStepNumber+1;
        StartCoroutine(ShowCurrentStepScreen(0));
    }

    void OnMicroscopeReachAtTable()
    {
        MicroscopeArmHand.SetActive(false);
        MicroscopeBaseHand.SetActive(false);
        LightSource1.SetActive(true);
        CanInteract = true;
        PlayAudio(3);
        CurrentStepNumber = CurrentStepNumber + 1;
        StartCoroutine(ShowCurrentStepScreen(0));
        MicroscopeMirrorArrow.SetActive(true);
        MirrorCollider.SetActive(true);
    }

    void OnMicroscopeReachAtBackTable()
    {
        MicroscopeArmHand.SetActive(false);
        MicroscopeBaseHand.SetActive(false);
        PlayAudio(18);
        CurrentStepNumber = CurrentStepNumber + 1;
        StartCoroutine(ShowCurrentStepScreen(0));
        ReStartButton.SetActive(true);
    }

    void OnSlideReachedToInitial()
    {
        SlideHand.SetActive(false);
        TableLight.SetActive(false);

        PlayAudio(17);
        CurrentStepNumber = CurrentStepNumber + 1;
        StartCoroutine(ShowCurrentStepScreen(0));

        MicroscopeArmArrow.SetActive(true);
        ArmCollider.SetActive(true);

    }

    public void OnClickReStartSimulation()
    {
        DOTween.KillAll();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Microscope");
    }

    void OnMirrorRotationCompleted()
    {
        MicroscopeMirrorHand.SetActive(false);
        LightSource2.SetActive(true);
        DoCheckLightSource2 = true;
        
        if (!ErrorMessage.activeSelf)
        {
            PlayAudio(4);
            CurrentStepNumber = CurrentStepNumber + 1;
            StartCoroutine(ShowCurrentStepScreen(0));

            SlideObj.SetActive(true);
            SlideArrow.SetActive(true);
        }
        else
        {
            DoShowStep4 = true;
        }
    }

    void OnSlideReachedToStage()
    {
        SlideObj.transform.GetChild(1).gameObject.SetActive(false);

        PlayAudio(5);
        CurrentStepNumber = CurrentStepNumber + 1;
        StartCoroutine(ShowCurrentStepScreen(0));

        MetalArrow.SetActive(true);
        MetalCollider.SetActive(true);
    }

    void OnObjectiveLensRotated()
    {
        FourXHand.SetActive(false);

        PlayAudio(7);
        CurrentStepNumber = CurrentStepNumber + 1;
        StartCoroutine(ShowCurrentStepScreen(0));

        FocusingKnobArrow.SetActive(true);
        FocusingKnobCollider.SetActive(true);
    }

    void OnObjectiveLensReset()
    {
        FourXHand.SetActive(false);

        SlideObj.transform.parent = null;
        SlideHand.SetActive(true);
        Sequence s2 = DOTween.Sequence();
        s2.Append(SlideObj.transform.DOLocalMove(SlideObj_Initial.transform.localPosition, 2f).SetEase(Ease.Linear)).
            OnComplete(OnSlideReachedToInitial);

    }

    void OnFocusingKnobRotated()
    {
        FocusingKnobHand.SetActive(false);

        PlayAudio(8);
        CurrentStepNumber = CurrentStepNumber + 1;
        StartCoroutine(ShowCurrentStepScreen(0));

        EyepieceArrow.SetActive(true);
        EyepieceCollider.SetActive(true);
    }

    void OnFocusingKnobReset()
    {
        FocusingKnobHand.SetActive(false);

        PlayAudio(16);
        CurrentStepNumber = CurrentStepNumber + 1;
        StartCoroutine(ShowCurrentStepScreen(0));
        FourXArrow_Reset.SetActive(true);
        FourXCollider.SetActive(true);
    }

    void On10xObjectiveLensRotated()
    {
        TenXHand.SetActive(false);
        BlackImage_Objective.SetActive(false);
        BlurValue = 5;
        BlurMaterial.SetFloat("_Size", BlurValue);
        Cell_Image.transform.localScale = new Vector3(2, 2, 2);
        DoClean = true;
        StartCoroutine(RotateFocusingKnob3Times());
    }

    void On40xObjectiveLensRotated()
    {
        FourtyXHand.SetActive(false);
        BlackImage_Objective.SetActive(false);
        BlurValue = 5;
        BlurMaterial.SetFloat("_Size", BlurValue);
        Cell_Image.transform.localScale = new Vector3(4, 4, 4);
        DoClean = true;
        StartCoroutine(RotateFocusingKnob3Times());
    }



}
/*

Microscope Initial position :
X : 12.24774
Y : 2.94
Z : 36.38017

Rotation : 0
Scale : 1


Cam Position : -3.1,5,0


ObjectiveLense Rotation :
-110,0,160

120 4x Correct angle

0 10x Correct angle

-120 40x Correct angle

-180 4x Correct angle reset


 */