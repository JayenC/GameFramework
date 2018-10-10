using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using System.IO;

public class ProtoTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        User user = new User();
        user.ID = 4;
        user.Name = "zhangSan";
        user.Password = "123465";
        user.Level = 100;
        user._UserType = User.UserType.Master;

        using (FileStream fs = File.Create(Application.dataPath + "/user.bin"))
        {
            Serializer.Serialize<User>(fs, user);
        }

        User s = new User();
        s.ID = 1111;
        s.Password = "sdfds";


        using (FileStream fs = File.OpenRead(Application.dataPath + "/user.bin"))
        {
            s = Serializer.Deserialize<User>(fs);
        }

        print(s.ID);
        print(s.Name);
        print(s._UserType);
        print(s.Level);
        print(s.Password);


    }


}
