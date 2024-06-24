using System.Collections.Generic;

namespace Model 
{
    public interface ISetModel<T>
    {
        public void SetValues(List<T> values);
    }
} 