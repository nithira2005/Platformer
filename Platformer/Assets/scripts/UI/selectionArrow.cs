using UnityEngine;
using UnityEngine.UI;

public class selectionArrow : MonoBehaviour
{
   [SerializeField] private RectTransform[] options;
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;
    private RectTransform rect;
    private int currentPostition;
    

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {// selection arrow move
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);
        // interact
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
            Interact();
    }


    private void ChangePosition(int _change)
    {
        currentPostition += _change;
        if (_change != 0)
            soundManager.instance.PlaySound(changeSound);



        if (currentPostition < 0)
            currentPostition = options.Length - 1;
        else if (currentPostition > options.Length - 1)
            currentPostition = 0;

        
        //assign the y pos yo current pos to arrow
        rect.position = new Vector3(rect.position.x, options[currentPostition].position.y, 0);
    }
     private void Interact()
    {
        soundManager.instance.PlaySound(interactSound);

        // access button
        options[currentPostition].GetComponent<Button>().onClick.Invoke();
    }

}
