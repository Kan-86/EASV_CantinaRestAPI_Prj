using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaApp.Core.DomainServices.List
{
    public class ListMany<T>
    {
        public IEnumerable<T> ListT { get; set; }
    }
}
