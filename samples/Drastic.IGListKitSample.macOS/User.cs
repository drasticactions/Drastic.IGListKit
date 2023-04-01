using System;
using IGListKit;

namespace Drastic.IGListKitSample.macOS
{
    public class User : IGListDiffable
    {

        public User(int pk, string name)
        {
            this.Pk = pk;
            this.Name = name;
        }

        public int Pk { get; }

        public string Name { get; }

        public override NSObject DiffIdentifier => NSObject.FromObject(this.Pk);

        public override bool IsEqualToDiffableObject(IGListDiffable? @object)
        {
            if (@object is User user)
            {
                return user.IsEqual(this);
            }

            return false;
        }
    }
}

