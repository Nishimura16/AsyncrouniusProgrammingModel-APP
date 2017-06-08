﻿using ConcurrecnyAPPattern.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrecnyAPPattern.Example
{
    public sealed class DataCalculator
    {

        private int _data1;
        private int _data2;
        private int _response;

        // Sleep 5 Second!
        private void _calculate(int Data1, int Data2)
        {
            Thread.Sleep(5000);
            _response = (int)(Math.PI * (Data1 + Data2));
        }

        public int Calculate(int Data1,int Data2)
        {
            _calculate(Data1,Data2);
            return _response;
        }

        public IAsyncResult BeginCalculate(int Data1,int Data2,AsyncCallback CallBack,object @objState)
        {
            this._data1 = Data1;
            this._data2 = Data2;
            CoreMessage Message = new CoreMessage((x) => _calculate(Data1,Data2), CallBack, objState);
            CoreAsyncResult Async = new CoreAsyncResult();
            Async.SyncProcessMessage(Message);
            return Async;
        }

        public int EndCalculate(IAsyncResult AResult)
        {
            if (!(AResult as CoreAsyncResult).IsInvokeAsyncCallBack)
                AResult.AsyncWaitHandle.WaitOne();
            return _response;
        }
    }
}
