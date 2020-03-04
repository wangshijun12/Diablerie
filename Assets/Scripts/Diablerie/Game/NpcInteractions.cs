using Diablerie.Engine;
using Diablerie.Engine.Datasheets;
using Diablerie.Engine.Entities;
using UnityEngine;

namespace Diablerie.Game
{
    public class NpcInteractions : MonoBehaviour
    {
        public void Awake()
        {
            Events.CharacterInteractionStarted += OnInteract;
        }
        
        public void OnInteract(Character target, Character who)
        {
            if (target.monStat == null || !target.monStat.npc)
                return;
            Debug.Log("Interact with " + target);
            who.LookAt(target.iso.pos);
            var greetingSound = SoundInfo.Find(target.monStat.id + "_greeting_1");
            AudioManager.instance.Play(greetingSound, target.transform);
        }
    }
}
