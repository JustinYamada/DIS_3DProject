using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseItem : MonoBehaviour
{
    public float phaseCooldown = 15;
    public float phaseTime = 5;
    public float phaseTimeIncrease = .5f;

    private bool isPhasing = false;
    private GameObject[] phasable;

    private void Start()
    {
        phasable = GameObject.FindGameObjectsWithTag("Phasable");
    }

    public void useSinglePhase(GameObject player)
    {
        StartCoroutine(Phase(player));
    }

    IEnumerator Phase(GameObject player)
    {
        if ((singletonGameManager.Instance.getNumPhaseItems() > 0) && (!isPhasing))
        {
            isPhasing = true;

            

            foreach(GameObject phase in phasable)
            {
                if (phase.GetComponent<Collider>() != null)
                {
                    Collider collider = phase.GetComponent<Collider>();
                    StartCoroutine(PhaseOn(collider, phase));
                }
            }
            singletonGameManager.Instance.numPhaseItem--;
        }
        yield return new WaitForSeconds(phaseCooldown);
        isPhasing = false;
    }



    IEnumerator PhaseOn(Collider collider, GameObject phase)
    {
        Renderer render = phase.GetComponent<Renderer>();
        Color holder = render.material.color;
        Color GameObjectColor = new Color(0, 255, 255, .025f);
        render.material.color = GameObjectColor;

        phase.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        collider.enabled = false;
        yield return new WaitForSeconds(phaseTime + (phaseTimeIncrease * singletonGameManager.Instance.phaseItemLevel));

        render.material.color = holder;
        collider.enabled = true;
        //phase.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    public bool buyPhaseItem()
    {
        return singletonGameManager.Instance.buyPhaseItem(1);
    }

    public bool buyPhaseItem(int numItems)
    {
        return singletonGameManager.Instance.buyPhaseItem(numItems);
    }

    public bool levelUpPhase(int numLevels)
    {
        return singletonGameManager.Instance.levelUpPhaseItem(numLevels);
    }

    public void resetPhaseLevel()
    {
        singletonGameManager.Instance.resetPhaseItemLevel();
    }


}
