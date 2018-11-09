using System;
using System.Collections.Generic;

using System.Text;

namespace COSXML
{
    public class CosXmlServer
    {
        private CosXmlConfig config;

        public CosXmlServer(CosXmlConfig config)
        {
            if (config != null)
            {
                this.config = config;
            }
        }
    }
}
