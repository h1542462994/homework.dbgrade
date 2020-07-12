using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace Tro.DbGrade.Client.Wpf.Storage
{
    public class KeyMapperCollection<TKey, TValue>: ObservableCollection<TValue> where TKey:IComparable
    {
        public KeyMapperCollection(Func<TValue, TKey> keyMapper)
        {
            if (keyMapper == null)
            {
                throw new ArgumentNullException(nameof(keyMapper));
            }
            this.KeyMapper = keyMapper;
            
        }

        public Func<TValue, TKey> KeyMapper { get; }

        public virtual void ReplaceItems(IEnumerable<TValue> collection)
        {
            collection = collection.OrderBy(KeyMapper);
            // 游标
            int index = 0;
            foreach (var item in collection)
            {
                if(index < Count)
                {
                    while (index < Count && KeyMapper(this[index]).CompareTo(KeyMapper(item)) < 0)
                    {
                        //删除键值对
                        Remove(this[index]);
                    }
                    if (index < Count && KeyMapper(this[index]).CompareTo(KeyMapper(item)) == 0)
                    {
                        SetItem(index, item);
                        ++index;
                    }
                    else if (index < Count && KeyMapper( this[index]).CompareTo(KeyMapper(item)) > 0)
                    {
                        Insert(index, item);
                        ++index;
                    }
                } 
                else
                {
                    Add(item);
                    ++index;
                }
            }
        }
    }
}
