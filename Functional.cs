using System;
using Unit = System.ValueTuple;

namespace funcprog {
    public static class Functional {

        public static R Using<TDisp, R>(TDisp disposable, Func<TDisp, R> f) where TDisp : IDisposable {
            using (disposable) return f(disposable);
            // example: public static R Connect<R>(string connStr, Func<IDbConnection, R> f) => Using(new SqlConnection(connStr), conn => { conn.Open(); return f(conn); });
        }        

        
    }
}