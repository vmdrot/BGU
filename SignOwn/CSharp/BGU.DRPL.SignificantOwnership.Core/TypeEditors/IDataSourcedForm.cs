using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGU.DRPL.SignificantOwnership.Core.TypeEditors
{
    public interface IDataSourcedForm<T>
    {
        T DataSource { get; set; }

        
        event FormCloseHandler<T> FormClose;
    }
    public delegate void FormCloseHandler<T>(object sender, DataSoucedFormCloseArgs<T> args);
    public class DataSoucedFormCloseArgs<T>: EventArgs
    {
        public DataSoucedFormCloseArgs(T obj)
        {
            DataObject = obj;
        }
        public T DataObject { get; private set;}
        public bool Cancel { get; set; }
    }
    
}
