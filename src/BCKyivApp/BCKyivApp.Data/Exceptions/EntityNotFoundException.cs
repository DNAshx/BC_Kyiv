using System;

namespace GlauxSoft.Sachware.TabletPrototype.Storage.Exceptions
{
    public class EntityNotFoundException<T> : Exception where T : new()
    {
        public EntityNotFoundException(int id)
            : base($"Entity {typeof(T)} not found in db by key {id}")
        {

        }

        public EntityNotFoundException(Guid id)
            : base($"Entity {typeof(T)} not found in db by key {id}")
        {
        }
    }
}
