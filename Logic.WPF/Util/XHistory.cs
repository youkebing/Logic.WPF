﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.WPF.Util
{
    public class XHistory<T> where T : class
    {
        private XJson _json = new XJson();
        private Stack<byte[]> _undos = new Stack<byte[]>();
        private Stack<byte[]> _redos = new Stack<byte[]>();

        public void Snapshot(T obj)
        {
            var bson = _json.BsonSerialize(obj);
            if (bson != null)
            {
                if (_redos.Count > 0)
                {
                    _redos.Clear();
                }
                _undos.Push(bson);
            }
        }

        public T Undo(T current)
        {
            if (_undos.Count > 0)
            {
                var bson = _json.BsonSerialize(current);
                if (bson != null)
                {
                    _redos.Push(bson);
                    return _json.BsonDeserialize<T>(_undos.Pop());
                }
            }
            return null;
        }

        public T Redo(T current)
        {
            if (_redos.Count > 0)
            {
                var bson = _json.BsonSerialize(current);
                if (bson != null)
                {
                    _undos.Push(bson);
                    return _json.BsonDeserialize<T>(_redos.Pop()); 
                }
            }
            return null;
        }
    }
}
