using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Events
{
    public class EventData
    {
        public Guid Id { get; }
        public Guid AggregateId { get; }
        public string EventName { get; }
        public string serialEvent { get; }


        public EventData(Guid eventId, Guid aggregateId, string eventName, string serializeEvent)
        {
            this.Id = eventId;
            this.AggregateId = aggregateId;
            this.EventName = eventName;
            this.serialEvent = serializeEvent;
        }
    }
}
