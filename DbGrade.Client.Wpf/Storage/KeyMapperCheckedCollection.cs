using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Tro.DbGrade.Client.Wpf.Storage
{
    public class ReplaceCollection<T> : ObservableCollection<T>
    {
        public ReplaceCollection(IComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                Comparer = Comparer<T>.Default;
            } else
            {
                Comparer = comparer;
            }
        }

        public ReplaceCollection(Comparison<T> comparison)
        {
            Comparer = Comparer<T>.Create(comparison);
        }

        public IComparer<T> Comparer { get; }

        public void ReplaceItems(IEnumerable<T> collection)
        {
            var index = 0;
            foreach (var item in collection)
            {
                while (index < Count && Comparer.Compare(this[index], item) <= 0)
                {
                    if (Comparer.Compare(this[index], item) <= 0)
                    {
                        RemoveAt(index);
                    }
                    else
                    {
                        SetItem(index, item);
                        continue;
                    }
                }

                if (index < Count && Comparer.Compare(this[index], item) > 0)
                {
                    Insert(index, item);
                    ++index;
                }
                else
                {
                    Add(item);
                    ++index;
                }
            }

            while (index < Count)
            {
                RemoveAt(index);
            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            var index = 0;
            foreach (var item in collection)
            {
                if (index < Count && Comparer.Compare(this[index], item) > 0)
                {
                    Insert(index, item);
                    ++index;
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