using System;

namespace Dependencies
{
    public class Scoped
    {
        public Scoped()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; private set; }
    }
}
