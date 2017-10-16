using System;

namespace Dependencies
{
    public class DependantOnTransient
    {
        private TransientDisposable _transient;

        public DependantOnTransient(TransientDisposable transient)
        {
            _transient = transient;
        }

        public Guid ID
        {
            get
            {
                return _transient.ID;
            }
        }
    }
}
