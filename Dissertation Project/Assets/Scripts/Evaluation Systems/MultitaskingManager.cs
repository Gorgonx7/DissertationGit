using ACE.TimeManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACE.EvaulationSystem
{
    public class MultitaskingManager : EvaluationManager
    {
        HintManager hintManager;
       // Start is called before the first frame update
       void Start()
        {
            hintManager = GameObject.FindGameObjectWithTag("HintManager").GetComponent<HintManager>();
        }

        // Update is called once per frame
        public override void Update()
        {

        }
        public AttentionType getTypeOfAttention()
        {
            hintManager.GetListOfActiveGoals();

            if()
        }
    }
}
