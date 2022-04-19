using System;

namespace DunBrad
{
    public class BaseLogic : IDisposable
    {
        protected DunBEntities DB = new DunBEntities();

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
