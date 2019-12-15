using System;
using MapParse.Types;
using ProtoBuf;
using Torii.Resource;
using UnityEngine;

namespace LSDR.Entities.Dream
{
    public class SpawnPoint : BaseEntity
    {
        public bool DayOneSpawn;
        
        [NonSerialized]
        public GameObject PlayerPrefab;

        public void Awake() { PlayerPrefab = ResourceManager.UnityLoad<GameObject>("Prefabs/Player"); }

        public void Spawn()
        {
            Instantiate(PlayerPrefab, transform.position + new Vector3(0, 0.45f, 0), transform.rotation); 
        }

        public void OnDrawGizmos()
        {
            var position = transform.position;
            Gizmos.DrawIcon(position, "SpawnPoint.png");
            Gizmos.DrawRay(position, transform.forward * 0.25f);
        }

        public override EntityMemento Save() { return new SpawnPointMemento(this); }

        public override void Restore(EntityMemento memento, LevelEntities entities)
        {
            base.Restore(memento, entities);

            var spawnPointMemento = (SpawnPointMemento)memento;
            DayOneSpawn = spawnPointMemento.DayOneSpawn;
            entities.Register(this);
        }
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic, SkipConstructor = true)]
    public class SpawnPointMemento : EntityMemento
    {
        public bool DayOneSpawn;

        protected override Type EntityType => typeof(SpawnPoint);
        public SpawnPointMemento(SpawnPoint state) : base(state) { DayOneSpawn = state.DayOneSpawn; }
    }
}
