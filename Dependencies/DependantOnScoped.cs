using System;

namespace Dependencies
{
    public class DependantOnScoped
    {
        private Scoped _scoped;

        public DependantOnScoped(Scoped scoped)
        {
            _scoped = scoped;
        }

        public Guid ID
        {
            get
            {
                return _scoped.ID;
            }
        }
    }
}
