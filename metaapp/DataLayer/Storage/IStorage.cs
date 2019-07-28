using System;
using System.Collections.Generic;

namespace Metaapp.DataLayer.Storage
{
    interface IStorage
    {
        void Save<T>(IEnumerable<T> obj);
        IEnumerable<T> Read<T>();
    }
}
