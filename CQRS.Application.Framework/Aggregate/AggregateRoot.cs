using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Framework.Aggregate
{
    /// <summary>
    /// used to handle command and gererate events
    /// </summary>
    public abstract class AggregateRoot : IAggregateRoot
    {
        public Guid Id { get; protected set; }
        public int Version { get; protected set; } = -1;
        protected readonly List<Object> _events = new List<object>();
        protected readonly Dictionary<Type, Action<object>> _eventHandler = new Dictionary<Type, Action<object>>();


        public void Apply(object e)
        {
            Raise(e);
            Version++;
        }

        protected void Register<T>(Action<T> action)
        {
            _eventHandler.Add(typeof(T), x => action((T)x));
        }

        public void ClearEvents()
        {
            _events.Clear();
        }

        public List<object> GetEvents()
        {
            return _events;
        }

        public void Raise(object e)
        {
            _eventHandler[e.GetType()](e);
            _events.Add(e);
        }
    }
}
