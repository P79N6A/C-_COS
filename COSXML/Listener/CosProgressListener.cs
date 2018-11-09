using System;
using System.Collections.Generic;
using System.Text;

namespace COSXML.Listener
{
    public interface CosProgressListener
    {
        void onProgress(long completed, long total);
    }
}
