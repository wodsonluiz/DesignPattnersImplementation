using System.Collections.Generic;

namespace Composite
{
    /// <summary>
    /// Component
    /// </summary>
    public abstract class FileSytemItem
    {
        public string Name { get; set; }

        public abstract long GetSize();

        public FileSytemItem(string name)
        {
            Name = name;
        }
    }

    /// <summary>
    /// Leaf
    /// </summary>
    public class File: FileSytemItem
    {
        private readonly long _size;

        public File(string name, long size): base(name)
        {
            _size = size;
        }

        public override long GetSize()
        {
            return _size;
        }
    }

    /// <summary>
    /// Composite
    /// </summary>
    public class Directory: FileSytemItem
    {
        private readonly long _size;

        private List<FileSytemItem>  _fileSystemItens = new();

        public Directory(string name, long size): base(name)
        {
            _size = size;
        }

        public override long GetSize()
        {
            var treeSize = _size;
            foreach (var fileSytemItem in _fileSystemItens)
            {
                treeSize += fileSytemItem.GetSize();
            }

            return treeSize;
        }

        public void Add(FileSytemItem fileSytemItem)
        {
            _fileSystemItens.Add(fileSytemItem);
        }

        public void Remove(FileSytemItem fileSytemItem)
        {
            _fileSystemItens.Remove(fileSytemItem);
        }
    }
}