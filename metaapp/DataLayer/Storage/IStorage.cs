using System;
using System.Collections.Generic;

namespace Metaapp.DataLayer.Storage
{
    public interface IStorage
    {
        event EventHandler DataSaved;
        void Save<T>(IEnumerable<T> obj);
        IEnumerable<T> Read<T>();
    }
}
