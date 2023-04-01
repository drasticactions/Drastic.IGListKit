using System;
using System.Collections.Generic;
using System.IO;
using Foundation;

namespace Drastic.IGListKitSample.macOS
{
    public class UsersProvider
    {
        public enum UsersError
        {
            InvalidData
        }
        public List<User> Users { get; }

        public UsersProvider(NSUrl file)
        {
            var byteStream = File.ReadAllBytes(file.Path!);
            NSData data = NSData.FromArray(byteStream);
            NSError error;
            object json = NSJsonSerialization.Deserialize(data, 0, out error);

            if (error != null || !(json is NSArray jsonArray))
            {
                throw new Exception();
            }

            List<User> users = new List<User>();
            for (nuint i = 0; i < jsonArray.Count; i++)
            {
                if (jsonArray.GetItem<NSDictionary>(i) is NSDictionary dict &&
                    dict.ContainsKey(new NSString("name")) &&
                    dict.ObjectForKey(new NSString("name")) is NSString name)
                {
                    users.Add(new User((int)i, name.ToUpper(NSLocale.CurrentLocale)));
                }
            }

            users.Sort((u1, u2) => string.Compare(u1.Name, u2.Name));
            Users = users;
        }
    }
}

