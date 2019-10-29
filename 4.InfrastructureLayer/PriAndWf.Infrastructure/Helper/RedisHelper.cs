using PriAndWf.Infrastructure.Extension;
using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PriAndWf.Infrastructure.Helper
{
    /// <summary>
    /// ConnectionMultiplexer 对象管理类
    /// </summary>
    public static class ConnectionMultiplexerManager
    {
        private static ConnectionMultiplexer GetConnection(string configuration, TextWriter log = null)
        {
            var connectionMultiplexer = ConnectionMultiplexer.Connect(configuration, log);

            //注册事件
            connectionMultiplexer.ConfigurationChanged += ConfigurationChanged;
            connectionMultiplexer.ConfigurationChangedBroadcast += ConfigurationChangedBroadcast;
            connectionMultiplexer.ConnectionFailed += ConnectionFailed;
            connectionMultiplexer.ConnectionRestored += ConnectionRestored;
            connectionMultiplexer.ErrorMessage += ErrorMessage;
            connectionMultiplexer.HashSlotMoved += HashSlotMoved;
            connectionMultiplexer.InternalError += InternalError;

            return connectionMultiplexer;
        }

        #region GetConnectionMultiplexer
        private static readonly Dictionary<string, ConnectionMultiplexer> concurrentDictionary = new Dictionary<string, ConnectionMultiplexer>();
        private static readonly object lockerGetConnectionMultiplexer = new object();
        /// <summary>
        /// 获取 ConnectionMultiplexer（从缓存中获取，没有时创建）
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="log"></param>
        /// <returns></returns>

        public static ConnectionMultiplexer GetConnectionMultiplexer(string connectionString, TextWriter log = null)
        {
            lock (lockerGetConnectionMultiplexer)
            {
                if (!concurrentDictionary.ContainsKey(connectionString))
                {
                    concurrentDictionary[connectionString] = GetConnection(connectionString, log);
                }
                return concurrentDictionary[connectionString];
            }
        }
        #endregion

        #region 事件
        private static void ConfigurationChanged(object sender, EndPointEventArgs e)
        {
        }
        private static void ConfigurationChangedBroadcast(object sender, EndPointEventArgs e)
        {
        }

        private static void ConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
        }
        private static void ConnectionRestored(object sender, ConnectionFailedEventArgs e)
        {
        }

        private static void ErrorMessage(object sender, RedisErrorEventArgs e)
        {
        }

        private static void HashSlotMoved(object sender, HashSlotMovedEventArgs e)
        {
        }

        private static void InternalError(object sender, InternalErrorEventArgs e)
        {
        }
        #endregion
    }
    public class RedisHelper
    {
        private readonly ConnectionMultiplexer _connection;
        private IDatabase _db;

        public RedisHelper(int db = 0) : this(ConfigurationManager.ConnectionStrings["RedisDefaultConnectionString"].ConnectionString, db)
        {
        }
        public RedisHelper(string connectionString, int db = -1)
        {
            _connection = ConnectionMultiplexerManager.GetConnectionMultiplexer(connectionString);
            _db = _connection.GetDatabase(db);
        }

        #region IDatabase
        public IDatabase GetDatabase(int db, object asyncState = null)
        {
            return _connection.GetDatabase(db, asyncState);
        }
        #endregion

        #region KeyDelete
        public bool KeyDelete(string key)
        {
            return _db.KeyDelete(key);
        }
        #endregion

        #region String（字符串）
        public bool StringSet(string key, string value, TimeSpan? expiry = null)
        {
            return _db.StringSet(key, value, expiry);
        }
        public long StringIncrement(string key, long value = 1)
        {
            return _db.StringIncrement(key, value);
        }
        public RedisValue StringGet(string key)
        {
            return _db.StringGet(key);
        }
        #endregion

        #region Hash（哈希）
        public void HashSet<T>(string key, string hashField, T value)
        {
            var realValue = BinarySerialize(value);
            _db.HashSet(key, hashField, realValue);
        }
        public void HashSet<T>(string key, string hashField, T value, TimeSpan expiry)
        {
            var realValue = BinarySerialize(value);
            _db.HashSet(key, hashField, realValue);
            _db.KeyExpire(key, expiry);
        }
        public void HashSet<T>(string key, string hashField, T value, DateTime expiry)
        {
            var realValue = BinarySerialize(value);
            _db.HashSet(key, hashField, realValue);
            _db.KeyExpire(key, expiry);
        }
        public long HashIncrement(string key, string hashField, long value = 1)
        {
            return _db.HashIncrement(key, hashField, value);
        }
        public RedisValue HashGet(RedisKey key, RedisValue hashField)
        {
            return _db.HashGet(key, hashField);
        }
        public HashEntry[] HashGet(RedisKey key)
        {
            return _db.HashGetAll(key);
        }
        public bool HashDelete(RedisKey key, RedisValue hashField)
        {
            return _db.HashDelete(key, hashField);
        }
        #endregion

        #region List（列表）

        #endregion

        #region Set（集合）

        #endregion

        #region Sorted Set（有序集合）

        #endregion

        #region 序列化、反序列化（二进制序列化、JSON序列化、XML序列化...）
        /// <summary>
        /// 二进制序列化
        /// </summary>
        /// <param name="obj">待二进制序列化的数据</param>
        /// <returns>二进制序列化后的字节数组</returns>
        private byte[] BinarySerialize(object obj)
        {
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        /// <summary>
        /// 二进制反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializedObject">二进制序列化后的字节数组</param>
        /// <returns></returns>
        private T Deserialize<T>(byte[] serializedObj)
        {
            using (var ms = new MemoryStream(serializedObj))
            {
                var obj = new BinaryFormatter().Deserialize(ms);
                return (T)obj;
            }
        }
        #endregion
    }
}
