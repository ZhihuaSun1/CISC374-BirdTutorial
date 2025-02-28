using UnityEngine;

public class pipemiddlescript : MonoBehaviour
{
    public logicscript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicscript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.addScoreWithCombo();
        }
    }
}
