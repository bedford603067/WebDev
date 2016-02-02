using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models
{
    public class AlertParameter
    {
        [MongoDB.Bson.Serialization.Attributes.BsonId]
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class AlertTypeReference
    {
        [MongoDB.Bson.Serialization.Attributes.BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class AlertType : AlertTypeReference
    {
        public virtual ICollection<AlertParameter> Paramaters { get; set; }
    }

    public class Alert
    {
        [MongoDB.Bson.Serialization.Attributes.BsonId]
        public int Id { get; set; }
        public AlertTypeReference Type { get; set; }
        public string Message { get; set; }
        public string TargetUrl { get; set; }
    }
}