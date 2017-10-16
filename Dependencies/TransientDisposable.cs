using System;
using System.Collections.Generic;

namespace Dependencies
{
    public class TransientDisposable : IDisposable
    {
        private List<int> _numbers = new List<int>(10_000);

        public TransientDisposable()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; private set; }

        public void Dispose()
        {
            _numbers = null;
        }
    }
}
