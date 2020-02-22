using ACE.Event_System;
using Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ACE.Event_System
{
    interface ACE_IEventTrigger
    {
        void Trigger(GameObject askingObject);

    }
}
