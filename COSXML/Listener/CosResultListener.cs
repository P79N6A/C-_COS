using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSXML.Model;
using COSXML.CosException;



namespace COSXML.Listener
{
    public interface CosResultListener
    {
        void OnSuccess<T1, T2> (T1 cosRequest, T2 cosResult)where T1 :CosRequest  where T2 : CosResult;
        void OnFailed<T>(T cosRequest, CosClientException clientException, CosServerException serverException) where T : CosRequest;
    }
}
