using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Demo.F1.EventProducer.BusinessLogic.Models.Bus
{
    public class EventData
    {
        public string Sender { get; set; }
        public string Description { get; set; }

    }
}
