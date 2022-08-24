using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork
{
    internal static class Server
    {      
        private static int count = 0;
        private static ReaderWriterLockSlim locker = new ReaderWriterLockSlim();
        public static int GetCount()
        {
            locker.EnterReadLock();
            try
            {
                return count;
            }
            finally
            {
                locker.ExitReadLock();
            }
        }
        public static void AddToCount(int value)
        {
            locker.EnterWriteLock();
            count += value;
            locker.ExitWriteLock();
        }
    }
}
