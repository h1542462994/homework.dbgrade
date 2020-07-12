using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Tro.DbGrade.Client.Wpf.Storage
{
    public class KeyMapperCheckedCollection<TKey, TValue>: ObservableCollection<CheckItem<TValue>> where TKey:IComparable
    {
        public KeyMapperCheckedCollection(Func<TValue, TKey> keyMapper)
        {
            KeyMapper = keyMapper;
        }

        public Func<TValue, TKey> KeyMapper { get; }

        public virtual void ReplaceItems(IEnumerable<TValue> collection)
        {
            collection = collection.OrderBy(KeyMapper);
            // 游标
            int index = 0;
            foreach (var item in collection)
            {
                if (index < Count)
                {
                    while (KeyMapper(this[index].Data).CompareTo(KeyMapper(item)) < 0)
                    {
                        //删除键值对
                        Remove(this[index]);
                    }
                    if (KeyMapper(this[index].Data).CompareTo(KeyMapper(item)) == 0)
                    {
                        this[index].Data = item;
                        ++index;
                    }
                    else if (KeyMapper(this[index].Data).CompareTo(KeyMapper(item)) > 0)
                    {
                        Insert(index, new CheckItem<TValue>() {
                            IsChecked = false,
                            Data = item
                        });
                        ++index;
                    }
                }
                else
                {
                    Add(new CheckItem<TValue>()
                    {
                        IsChecked = false,
                        Data = item
                    }) ;
                    ++index;
                }
            }
        }
    }
}
