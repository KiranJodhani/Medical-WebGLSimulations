using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class FireManager : MonoBehaviour
{
    public static FireManager Instance;

    public DragObject DragObjectInstance;
    public Transform CameraObj;
    public Transform CameraInitial;
    public Transform CameraZoom1;
    public Transform CameraZoomAtPin;
    public Transform CameraZoomAtFire;
    public GameObject FireExtenguisherObj;
    public GameObject PinHandObj;
    public bool IsAtCorrectPos;
    public GameObject PinObj;
    public GameObject Left_Hand;
    public GameObject Right_Hand;
    public GameObject IntroScreen;

    [Header("#### UI SCREENS ####")]
    public GameObject LanguageSelection;
    public GameObject IntroScreen_Eng;
    public GameObject IntroScreen_French;
    public GameObject InstructionPanel;
    public GameObject CompletionPanel_Eng;
    public GameObject CompletionPanel_French;
    public TextMeshProUGUI InstructionText;
    public GameObject WarningPanel_Eng;
    public GameObject WarningPanel_French;


    [Header("#### ARROWS ####")]
    public GameObject Exting_Grab_Arrow;
    public GameObject Green_Arrow;
    public GameObject PinPull_Arrow;
    public GameObject Safe_DistanceObj;

    [Header("#### SQUEEZE ####")]
    public bool CanSqueeze;
    public bool IsSqueezed;
    public GameObject Thumb1_r;
    public GameObject Thumb1_r_squeezed;
    public GameObject Thumb1_r_Unsqueezed;
    public GameObject Lever;
    public GameObject LeverSqueezed;
    public GameObject LeverUnSqueezed;
    public float speed;
    public GameObject SqueezeArrow;
    //public int SqueezeCounter = 0;

    [Header("#### NOZZLE ####")]
    public bool CanSpray;
    public Slider RotationSlider;
    public GameObject NozzleObj;
    public ParticleSystem SprayParticle;
    public ParticleSystem FireParticle;
    public float FireParticleStartSize;
    public AudioSource Simulator_AS;
    public AudioClip[] ClipsEnglish;
    public AudioClip[] ClipsFrench;




    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }


    public void PlayAudio(int ClipIndex)
    {
        Simulator_AS.Stop();
        if(Simulation_Backend.SelectedLanguageID==1)
        {
            Simulator_AS.PlayOneShot(ClipsEnglish[ClipIndex]);
        }
        else
        {
            Simulator_AS.PlayOneShot(ClipsFrench[ClipIndex]);
        }
    }

    public void MoveCameraToTheFire()
    {
        Simulator_AS.Stop();
        IntroScreen.SetActive(false);
        IntroScreen_Eng.SetActive(false);
        IntroScreen_French.SetActive(false);
        Sequence s = DOTween.Sequence();
        s.Append(CameraObj.DOLocalMove(CameraZoom1.localPosition, 3f).SetEase(Ease.Linear)).OnComplete(OnCamReached);
    }

    public void OnCamReached()
    {
        print("OnCamReached");
        DragObjectInstance.enabled = true;
        FireExtenguisherObj.GetComponent<BoxCollider>().enabled = true;
        Safe_DistanceObj.SetActive(true);
        if(Simulation_Backend.SelectedLanguageID==1)
        {
            Safe_DistanceObj.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            Safe_DistanceObj.transform.GetChild(1).gameObject.SetActive(true);
        }
        Exting_Grab_Arrow.SetActive(true);
        PlayAudio(1);
        ShowInstructionPanel();
        Invoke("HideInstructionPanel",10);
    }

    bool IsGrabsoundPlaying = false;
    public void OnFireExtinguisherGrabbed()
    {
        CancelInvoke("HideInstructionPanel");
        Exting_Grab_Arrow.SetActive(false);
        Green_Arrow.SetActive(true);
        ShowInstructionPanel();
        if(!IsGrabsoundPlaying)
        {
            PlayAudio(2);
            IsGrabsoundPlaying = true;
        }
        if(Simulation_Backend.SelectedLanguageID==1)
        {
            InstructionText.text = "Take the fire extinguisher closer to the flames. Make sure you are at least 2 Meters from the flames.";
        }
        else
        {
            InstructionText.text = "Rapprochez l'extincteur des flammes. Assurez-vous que vous êtes à au moins 2 mètres des flammes.";
        }
    }

    public void OnFireExtinguisherDropped()
    {
        DragObjectInstance.gameObject.GetComponent<BoxCollider>().enabled = false;
        DragObjectInstance.enabled = false;
        Green_Arrow.SetActive(false);
        FireExtenguisherObj.transform.localPosition = new Vector3(0.7f, -0.1f, 6);
        MoveCameraToPin();
    }

    void MoveCameraToPin()
    {
        PlayAudio(3);
        if (Simulation_Backend.SelectedLanguageID == 1)
        {
            InstructionText.text = "Great! Now pull the pin";
        }
        else
        {
            InstructionText.text = "Excellent ! Maintenant, tirez la goupille.";
        }
        
        Sequence s = DOTween.Sequence();
        s.Append(CameraObj.DOLocalMove(CameraZoomAtPin.localPosition, 4f).SetEase(Ease.Linear)).OnComplete(OnReachedAtPin);

        Sequence Rotate_s = DOTween.Sequence();
        Rotate_s.Append(CameraObj.DOLocalRotate(CameraZoomAtPin.localEulerAngles, 4f).SetEase(Ease.Linear));
    }

    void OnReachedAtPin()
    {
        print("OnReachedAtPin");
        PinPull_Arrow.SetActive(true);
        PinHandObj.SetActive(true);
        PinObj.GetComponent<BoxCollider>().enabled = true;
    }

    public void OnPinPulled()
    {
        PinPull_Arrow.SetActive(false);
        PinHandObj.SetActive(false);
        MoveCameraToFire();
    }

    void MoveCameraToFire()
    {
        PlayAudio(4);
        if (Simulation_Backend.SelectedLanguageID == 1)
        {
            InstructionText.text = "Awesome! Now press the handle to spray.";
        }
        else
        {
            InstructionText.text = "Impressionnant ! Maintenant, appuyez sur la poignée pour pulvériser.";

        }

        Sequence s = DOTween.Sequence();
        s.Append(CameraObj.DOLocalMove(CameraZoomAtFire.localPosition, 4f).SetEase(Ease.Linear)).OnComplete(OnReachedAtFire);

        Sequence Rotate_s = DOTween.Sequence();
        Rotate_s.Append(CameraObj.DOLocalRotate(CameraZoomAtFire.localEulerAngles, 4f).SetEase(Ease.Linear));
    }

    void OnReachedAtFire()
    {
        print("OnReachedAtFire");
        Left_Hand.SetActive(true);
        Right_Hand.SetActive(true);
        SqueezeArrow.SetActive(true);
        Invoke("ShowSqueezInstruction", 2);
    }

    void ShowSqueezInstruction()
    {
        if (Simulation_Backend.SelectedLanguageID == 1)
        {
            InstructionText.text = "Click on handle to Squeeze / Unsqueeze";
        }
        else
        {
            InstructionText.text = "Cliquez sur la poignée pour presser/dépresser";

        }

        CanSqueeze = true;
    }

    void ShowSprayInstruction()
    {
        PlayAudio(5);
        if (Simulation_Backend.SelectedLanguageID == 1)
        {
            InstructionText.text = "Drag the nozzle up or down to aim at the fire. The fire will turn off slowly if you do it correctly.";
        }
        else
        {
            InstructionText.text = "Fais glisser la buse vers le haut ou le bas pour viser le feu. Le feu s'éteindra lentement si vous le faites correctement.";

        }

        CanSpray = true;
        RotationSlider.gameObject.SetActive(true);
    }


    public void ShowInstructionPanel()
    {
        IntroScreen_Eng.SetActive(false);
        IntroScreen_French.SetActive(false);
        InstructionPanel.SetActive(true);
        if (Simulation_Backend.SelectedLanguageID == 1)
        {
            InstructionText.text = "Grab the fire extinguisher fast and turn out the flames. Oh! You don’t know how to use one? Don’t worry I got you!";
        }
        else
        {
            InstructionText.text = "Saisissez rapidement l'extincteur et éteignez les flammes. Oh ! Vous ne savez pas vous en servir ? Ne vous inquiétez pas, je vais vous aider!";

        }
    }

    public void HideInstructionPanel()
    {
        InstructionPanel.SetActive(false);
    }

    private void Update()
    {

        Vector3 FireExtenguisherPos = FireExtenguisherObj.transform.localPosition;
        if (FireExtenguisherPos.x<1 && FireExtenguisherPos.x > 0.2f)
        {
            IsAtCorrectPos = true;
        }
        else
        {
            IsAtCorrectPos = false;
        }

        if (FireExtenguisherPos.x < 0.6f)
        {
            if(Simulation_Backend.SelectedLanguageID==1)
            {
                WarningPanel_Eng.SetActive(true);
            }
            else
            {
                WarningPanel_French.SetActive(true);
            }
            
        }
        else
        {
            if (Simulation_Backend.SelectedLanguageID == 1)
            {
                WarningPanel_Eng.SetActive(false);
            }
            else
            {
                WarningPanel_French.SetActive(false);
            }
        }


        if (CanSpray)
        {
            RotationSlider.gameObject.SetActive(true);
            Vector3 tmpAngle = NozzleObj.transform.localEulerAngles;
            tmpAngle.y = 0;
            tmpAngle.z = 0;
            tmpAngle.x = RotationSlider.value;
            NozzleObj.transform.localEulerAngles = tmpAngle;
            if(RotationSlider.value>200 && IsSqueezed)
            {
                if(FireParticleStartSize>0)
                {
                    FireParticleStartSize = FireParticleStartSize - (Time.deltaTime*0.2f);
                    FireParticle.gameObject.transform.Translate(Vector3.back *( Time.deltaTime*0.1f));
                    var main = FireParticle.main;
                    main.startSize = FireParticleStartSize;
                    if(FireParticleStartSize<=0)
                    {
                        FireParticle.gameObject.transform.parent.gameObject.SetActive(false);
                        InstructionPanel.SetActive(false);
                        if (Simulation_Backend.SelectedLanguageID == 1)
                        {
                            CompletionPanel_Eng.SetActive(true);
                        }
                        else
                        {
                            CompletionPanel_French.SetActive(true);
                        }
                        
                        PlayAudio(6);
                        Safe_DistanceObj.SetActive(false);
                    }
                }                    
            }

        }
    }

    public void Squeeze_UnSqueeze()
    {
        if (CanSqueeze)
        {
            IsSqueezed = !IsSqueezed;
            SqueezeArrow.SetActive(false);
            if (IsSqueezed)
            {
                Sequence Squeeze_s = DOTween.Sequence();
                Squeeze_s.Append(Lever.transform.DOLocalRotate(LeverSqueezed.transform.localEulerAngles,0.2f).
                                SetEase(Ease.Linear)).OnComplete(OnSqueezeCompleted);


                Sequence Squeeze_sT = DOTween.Sequence();
                Squeeze_sT.Append(Thumb1_r.transform.DOLocalRotate(Thumb1_r_squeezed.transform.localEulerAngles, 0.2f).SetEase(Ease.Linear));
                SprayParticle.Play();
                ShowSprayInstruction();
            }
            else
            {
                Sequence UnSqueeze_s = DOTween.Sequence();
                UnSqueeze_s.Append(Lever.transform.DOLocalRotate(LeverUnSqueezed.transform.localEulerAngles, 0.2f).
                                SetEase(Ease.Linear)).OnComplete(OnUnSqueezeCompleted);

                Sequence UnSqueeze_sT = DOTween.Sequence();
                UnSqueeze_sT.Append(Thumb1_r.transform.DOLocalRotate(Thumb1_r_Unsqueezed.transform.localEulerAngles, 0.2f).SetEase(Ease.Linear));
                SprayParticle.Stop();
            }
        }
    }

    void OnSqueezeCompleted()
    {

    }

    void OnUnSqueezeCompleted()
    {

    }

    public void RestartScene()
    {
        DOTween.KillAll();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGameScene");
    }


    // Localisation
    public void OnClickLanguageButton(int LanguageID)
    {
        Simulation_Backend.SelectedLanguageID = LanguageID;
        LanguageSelection.SetActive(false);
        PlayAudio(0);
        if (Simulation_Backend.SelectedLanguageID == 1)
        {
            IntroScreen_Eng.SetActive(true);
        }
        else
        {
            IntroScreen_French.SetActive(true);
        }


    }

}
