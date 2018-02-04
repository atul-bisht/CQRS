using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Events
{
    static class EventStoreHelper
    {
        //public static object Deserialize(this ResolvedEvent resolvedEvent)
        //{
        //    return JsonConvert
        //         .DeserializeObject(Encoding.UTF8.GetString(resolvedEvent.Event.Data), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
        //}

        public static string Serialize(this object e)
        {
            var ary = JsonConvert.SerializeObject(e, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
            return ary;
        }
    }
}
