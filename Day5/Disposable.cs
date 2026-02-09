using System;
using System.IO;

namespace GarbageCollectionDemo
{
  public class Filemanager : IDisposable
  {
    private FileStream _fileStream;
    private bool _disposed = false;

    public void OpenFile(string Path)
    {
      _fileStream = new FileStream(Path, FileMode.Open);
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      // BUG FIX → was if (!_disposed) return;
      if (_disposed) return;

      if (disposing)
      {
        _fileStream?.Dispose();
      }

      _disposed = true;
    }

    ~Filemanager()
    {
      Dispose(false);
    }
  }
}
