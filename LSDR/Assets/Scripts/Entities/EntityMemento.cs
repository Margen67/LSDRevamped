using System;
using LSDR.Entities.Dream;
using LSDR.Entities.Original;
using LSDR.Entities.Trigger;
using ProtoBuf;
using UnityEngine;

namespace LSDR.Entities
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    [ProtoInclude(1000, typeof(SpawnPointMemento))]
    [ProtoInclude(2000, typeof(TriggerLinkMemento))]
    [ProtoInclude(3000, typeof(InteractiveObjectSpawnMemento))]
    [ProtoInclude(4000, typeof(TriggerLuaMemento))]
    public abstract class EntityMemento
    {
        public string EntityID;
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;

        protected virtual Type EntityType => typeof(BaseEntity);

        public GameObject CreateGameObject(LevelEntities entities)
        {
            GameObject entityObj = new GameObject(EntityType.Name);
            BaseEntity component = (BaseEntity)entityObj.AddComponent(EntityType);
            component.Restore(this, entities);
            return entityObj;
        }

        protected EntityMemento(BaseEntity state)
        {
            EntityID = state.EntityID;
            Position = state.transform.position;
            Rotation = state.transform.rotation;
            Scale = state.transform.localScale;
        }
    }
}
