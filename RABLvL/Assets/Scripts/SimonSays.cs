using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSays : MonoBehaviour
{
    private enum SimonState
    {
        Selecting,
        Waiting,
        Win,
    }

    private SimonState state;

    public GameObject Door;

    public ButtonPress[] buttons = new ButtonPress[4];

    public int PlayerCount;

    public List<ButtonPress> SimonsList = new List<ButtonPress>();

    // Start is called before the first frame update
    void Start()
    {

        PickRandomButton();

        StartCoroutine(SimonAnim());

        // randomize simon says pattern
    }

    public void PickRandomButton ()
    {

        state = SimonState.Selecting;

        // create simon says (red, red blue, red blue green, red blue green yellow, etc.)

        int Index = Random.Range(0, 4);

        ButtonPress currentButton = buttons[Index];

        SimonsList.Add(currentButton);

    }

    private IEnumerator SimonAnim()
    {

        foreach (ButtonPress currentButton in SimonsList)
        {

            currentButton.Pressed();

            yield return new WaitForSeconds(1);

            currentButton.Unpressed();

            yield return new WaitForSeconds(0.5f);

        }

        state = SimonState.Waiting;

    }

    public void OnButtonPress(ButtonPress currentButton)
    {
       
        if (state == SimonState.Waiting)
        {

            PlayerCount++;

            int Index = PlayerCount - 1;

            if (currentButton == SimonsList[Index])
            {
                if (Index == SimonsList.Count - 1)
                {
                    if (PlayerCount == 5)
                    {

                        Door.transform.position += new Vector3(0, -2, 0);

                        state = SimonState.Win;

                        return;

                    }
                    PlayerCount = 0;

                    PickRandomButton();

                    StartCoroutine(SimonAnim());


                }

            }

            else
            {
                SimonsList.Clear();

                PlayerCount = 0;

                PickRandomButton();

                StartCoroutine(SimonAnim());
            }

        }

    }

}
