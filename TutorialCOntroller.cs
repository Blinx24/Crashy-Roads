using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCOntroller : MonoBehaviour
{
    [SerializeField] private Transform Menu;

    [SerializeField] private Image CurrentImage;

    [SerializeField] private Button ButtonNext;
    [SerializeField] private Button ButtonBack;

    [SerializeField] private List<Sprite> Imgs;
    private int nImg = 0;

    [SerializeField] private Button PlayButton;
    
    void Start()
    {
        ButtonNext.Select();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        nImg = 0;
        CurrentImage.sprite = Imgs[nImg];

        ButtonNext.Select();

        ButtonBack.interactable = false;
        ButtonNext.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackImgBtn() {

        StartCoroutine(BackImg());
    }
    public IEnumerator BackImg() {
        yield return new WaitForSeconds(0.15f);
        nImg --;
        CurrentImage.sprite = Imgs[nImg];

        if (nImg == 0) {

            ButtonBack.interactable = false;
            ButtonNext.Select();
        }

        ButtonNext.interactable = true;
    }

    public void NextImgBtn() {

        StartCoroutine(NextImg());
    }
    public IEnumerator NextImg() {
        yield return new WaitForSeconds(0.15f);
        nImg ++;
        CurrentImage.sprite = Imgs[nImg];

        if (nImg == Imgs.Count-1) {

            ButtonNext.interactable = false;
            ButtonBack.Select();
        }

        ButtonBack.interactable = true;
    }

    public void ExitBtn() {

        StartCoroutine(Exit());
    }
    public IEnumerator Exit() {
        yield return new WaitForSeconds(0.15f);
        Menu.gameObject.SetActive(true);
        gameObject.SetActive(false);

        PlayButton.Select();
    }
}
