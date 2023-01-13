using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Demo.F1.EventProducer.BusinessLogic.Models.Input
{
    public class EventRequest
    {
        public string Sender { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Sender+":"+Description;
        }
    }
}
