using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace OnlineGameServer.Utils
{
    public static class Mapper
    {
        public static TClient ToClient<TClient, TGlobal>(this TGlobal global) where TClient : class, new()
        {
            if (global == null)
            {
                return null;
            }

            TClient client = (TClient)Activator.CreateInstance(typeof(TClient));

            foreach (PropertyInfo propertieGlobal in global.GetType().GetProperties())
            {
                foreach (PropertyInfo propertieClient in client.GetType().GetProperties())
                {
                    if (propertieGlobal.Name.Equals(propertieClient.Name))
                    {
                        propertieClient.SetValue(client, propertieGlobal.GetValue(global));
                        break;
                    }
                }
            }
            return client;
        }

        public static TClient ToClient<TClient, TGlobal>(this TGlobal global, Func<TGlobal ,TClient> convert) where TClient : class, new()
        {
            if (global == null)
            {
                return null;
            }

            return convert(global);
        }

        public static TGlobal ToGlobal<Tclient, TGlobal>(this Tclient client) where TGlobal : class, new()
        {
            if (client == null)
            {
                return null;
            }

            TGlobal global = (TGlobal)Activator.CreateInstance(typeof(TGlobal));

            foreach (PropertyInfo propertieClient in client.GetType().GetProperties())
            {
                foreach (PropertyInfo propertieGlobal in global.GetType().GetProperties())
                {
                    if (propertieGlobal.Name.Equals(propertieClient.Name))
                    {
                        propertieGlobal.SetValue(global, propertieClient.GetValue(client));
                        break;
                    }
                }
            }

            return global;
        }

        public static TGlobal ToGlobal<Tclient, TGlobal>(this Tclient client, Func<Tclient,TGlobal> convert) where TGlobal : class, new()
        {
            if (client == null)
            {
                return null;
            }

            return convert(client);
        }
    }
}