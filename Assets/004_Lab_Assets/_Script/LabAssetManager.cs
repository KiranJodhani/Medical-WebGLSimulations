using UnityEngine;
using DG.Tweening;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class LabAssetManager : MonoBehaviour
{
    public static LabAssetManager Instance;

    [Header(" ##### LAB ASSETS ####")]
    public LabAssetData[] LabAssetDataInstance;
    public GameObject TargetPoint;
    public GameObject Lab_Items_Parent;

    [Header(" ##### SELECTED ITEM ####")]
    public GameObject SelectedItem;
    public Vector3 SelectedItem_InitialPosition;
    public bool IsItemSelected;

    [Header("#### UI ####")]
    public GameObject FrenchModel;
    public GameObject EnglishModel;
    public GameObject LanguageSelection;
    public TextMeshProUGUI ObjectDisplayDescription;
    public TextMeshProUGUI ObjectDisplayName;
    public int ScreenIndex;

    public GameObject StartButton;
    public TextMeshProUGUI StartButtonText;
    public GameObject ReStartButton;
    public TextMeshProUGUI ReStartButtonText;
    public Transform CameraObj;
    //public Transform CameraObj_Vertical;
    public int CurrentItemCounter;
    public TextMeshProUGUI ItemCounterText;


    [Header("#### AUDIO ####")]
    public GameObject SoundButton;
    public GameObject SoundOnImage;
    public GameObject SoundOffImage;
    public AudioSource LabAsset_AudioSource;


    public float HorizontalScrollDelta;
    public float VerticalScrollDelta;
    float horizontalSpeed = 4.0f;
    float VerticalSpeed = 4.0f;
    public Vector2 ScrollDelta;
    public bool CanInteract;
    public float MicroscopeRadian;
    public Vector3 Cameratmp_Pos;
    public Vector3 Cameratmp_Angle;

    private void Awake()
    {
        Instance = this;   
    }

    void Start()
    {
        LanguageSelection.SetActive(true);
        Invoke("HideAllObjectsOutline", 0.1f);
    }
   

    void Update()
    {
        if (Cameratmp_Pos.y > 0.3f)
        {
            Cameratmp_Pos.y = 0.3f;
        }
        if (Cameratmp_Pos.y < 0)
        {
            Cameratmp_Pos.y = 0;
        }
        if (Cameratmp_Pos.z > 0.65f)
        {
            Cameratmp_Pos.z = 0.65f;
        }
        if (Cameratmp_Pos.z < 0)
        {
            Cameratmp_Pos.z = 0;
        }

        CameraObj.transform.localPosition = Cameratmp_Pos;

        Cameratmp_Angle.x = Cameratmp_Pos.y * 100;
        CameraObj.transform.localEulerAngles = Cameratmp_Angle;

        ScrollDelta = Input.mouseScrollDelta;

        if (Input.GetMouseButton(0) && CanInteract)
        {
            HorizontalScrollDelta = horizontalSpeed * Input.GetAxis("Mouse X");
            VerticalScrollDelta = VerticalSpeed * Input.GetAxis("Mouse Y");

            if (VerticalScrollDelta > 0.1f)
            {
                Cameratmp_Pos.y = Cameratmp_Pos.y - Time.deltaTime;
            }

            if (VerticalScrollDelta < -0.1f)
            {
                Cameratmp_Pos.y = Cameratmp_Pos.y + Time.deltaTime;
            }            
        }

        if (CanInteract)
        {
            if (ScrollDelta.y > 0.01f)
            {
                Cameratmp_Pos.z = Cameratmp_Pos.z + Time.deltaTime;     
            }
            else if (ScrollDelta.y < -0.01f)
            {
                Cameratmp_Pos.z = Cameratmp_Pos.z - Time.deltaTime;
            }
        }
    }


    

    public void ToogleSound()
    {
        if (LabAsset_AudioSource.volume == 1)
        {
            LabAsset_AudioSource.volume = 0;
            SoundOnImage.SetActive(false);
            SoundOffImage.SetActive(true);
        }
        else
        {
            LabAsset_AudioSource.volume = 1;
            SoundOnImage.SetActive(true);
            SoundOffImage.SetActive(false);

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
        if (LanguageID == 0)
        {
            EnglishModel.SetActive(true);
            StartButtonText.text = "Start";
            ReStartButtonText.text = "Restart";
        }
        else if (LanguageID == 1)
        {
            FrenchModel.SetActive(true);
            StartButtonText.text = "Début";
            ReStartButtonText.text = "Redémarrage";
        }
    }


    public void OnClickStartButton()
    {
        StartButton.SetActive(false);
        CanInteract = true;
        LabAsset_AudioSource.Stop();
        ObjectDisplayDescription.text = "";
        ObjectDisplayName.text = "";
        Invoke("EnableSelection", 0.5f);
        ShowAllObjectsOutline();
    }

    void EnableSelection()
    {
        IsItemSelected = false;
    }

    public void OnClickReStartSimulation()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("LabAssets");
    }



    public void OnClickLabObject(GameObject Item)
    {
        IsItemSelected = true;
        SelectedItem = Item;
        SelectedItem_InitialPosition = SelectedItem.transform.localPosition;
        ShowCurrentScreen();
        CurrentItemCounter = CurrentItemCounter + 1;
        ItemCounterText.text = CurrentItemCounter.ToString() + "/33";
        HideAllObjectsOutline();
        if(SelectedItem.GetComponent<LabObjectElement>().DoUpAndGo)
        {
            Sequence s = DOTween.Sequence();
            s.Append(SelectedItem.transform.DOLocalMove(SelectedItem.GetComponent<LabObjectElement>().UpPosition, 0.5f).SetEase(Ease.Linear)).OnComplete(OnUpReached);
        }
        else
        {
            Sequence s = DOTween.Sequence();
            s.Append(SelectedItem.transform.DOLocalMove(TargetPoint.transform.localPosition, 2f).SetEase(Ease.Linear)).OnComplete(OnItemReachedToTarget);
        }
    }

    void OnUpReached()
    {
        Sequence s = DOTween.Sequence();
        s.Append(SelectedItem.transform.DOLocalMove(TargetPoint.transform.localPosition, 1.5f).SetEase(Ease.Linear)).OnComplete(OnItemReachedToTarget);
    }

    void ShowCurrentScreen()
    {
        LabAsset_AudioSource.Stop();
        ObjectDisplayDescription.text = LabAssetDataInstance[ScreenIndex].Item_Description[Simulation_Backend.SelectedLanguageID];
        ObjectDisplayName.text = LabAssetDataInstance[ScreenIndex].Item_DisplayName[Simulation_Backend.SelectedLanguageID];
        LabAsset_AudioSource.clip = LabAssetDataInstance[ScreenIndex].Item_Audio[Simulation_Backend.SelectedLanguageID];
        LabAsset_AudioSource.Play();
    }


    void OnItemReachedToTarget()
    {
        SelectedItem.GetComponent<LabObjectElement>().DoRoate = true;
        Invoke("GoBackToInitialPosition", LabAssetDataInstance[ScreenIndex].Item_Audio[Simulation_Backend.SelectedLanguageID].length+2);
    }

    void GoBackToInitialPosition()
    {
        SelectedItem.GetComponent<LabObjectElement>().DisableRotation();

        if (SelectedItem.GetComponent<LabObjectElement>().DoUpAndGo)
        {
            Sequence s = DOTween.Sequence();
            s.Append(SelectedItem.transform.DOLocalMove(SelectedItem.GetComponent<LabObjectElement>().UpPosition, 0.5f).SetEase(Ease.Linear)).OnComplete(OnUpReachedFromFront);
        }
        else
        {
            Sequence s = DOTween.Sequence();
            s.Append(SelectedItem.transform.DOLocalMove(SelectedItem_InitialPosition, 2f).SetEase(Ease.Linear)).OnComplete(OnItemReachedToInitial);
        }
    }

    void OnUpReachedFromFront()
    {
        Sequence s = DOTween.Sequence();
        s.Append(SelectedItem.transform.DOLocalMove(SelectedItem_InitialPosition, 1.5f).SetEase(Ease.Linear)).OnComplete(OnItemReachedToInitial);
    }
    void OnItemReachedToInitial()
    {
        SelectedItem.GetComponent<LabObjectElement>().DisableVisitedItem();
        IsItemSelected = false;
        ShowAllObjectsOutline();
        ObjectDisplayDescription.text = "";
        ObjectDisplayName.text = "";
        if (CurrentItemCounter==33)
        {
            ScreenIndex = 36;
            ShowCurrentScreen();
            ReStartButton.SetActive(true);
        }
    }

    void HideAllObjectsOutline()
    {
        foreach(Transform item in Lab_Items_Parent.transform)
        {
            if(item.gameObject.activeSelf)
            {
                item.gameObject.GetComponent<LabObjectElement>().HideMyOutline();
            }
        }
    }

    void ShowAllObjectsOutline()
    {
        foreach (Transform item in Lab_Items_Parent.transform)
        {
            if (item.gameObject.activeSelf)
            {
                item.gameObject.GetComponent<LabObjectElement>().ShowMyOutline();
            }
        }
    }

}

[Serializable]
public class LabAssetData
{
    // 0 English , 1 French
    public string Item_Name;
    public string[] Item_DisplayName;
    public string[] Item_Description;
    public AudioClip[] Item_Audio;
}


